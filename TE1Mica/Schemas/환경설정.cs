﻿using MvUtils;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TE1.Schemas
{
    public class 환경설정
    {
        public delegate void 모델변경(모델구분 모델코드);
        public event 모델변경 모델변경알림;

        [JsonIgnore]
        public const String 프로젝트번호 = "23-0449-002"; // <= 부착기 23-0449-003 => 검사기
        [JsonIgnore]
        public const String DefaultPath = @"C:\IVM\TE1Mica";

        [Description("프로그램 동작구분"), JsonProperty("RunType")]
        public 동작구분 동작구분 { get; set; } = 동작구분.Live;
        [Translation("Config Path", "설정 저장 경로"), JsonProperty("ConfigSavePath")]
        public String 기본경로 { get; set; } = $@"{DefaultPath}\Config";
        [Translation("Document Save Path", "문서 저장 경로"), JsonProperty("DocumentSavePath")]
        public String 문서저장 { get; set; } = $@"{DefaultPath}\SaveData";
        [Translation("Copy Image Save Path", "사본 저장 경로"), JsonProperty("ImageSavePath")]
        public String 사진저장 { get; set; } = $@"{DefaultPath}\SaveImage";
        [Translation("Origin Save Path", "원본 저장 경로"), JsonProperty("OriginImageSavePath")]
        public String 원본보관폴더 { get; set; } = $@"{DefaultPath}\OriginImage";
        [Translation("Origin Storage Days", "원본 보관 일수"), JsonProperty("OriginImageStorageDays")]
        public Int32 원본보관일수 { get; set; } = 3;

        [Translation("Decimals", "검사 결과 자릿수"), JsonProperty("Decimals")]
        public Int32 결과자릿수 { get; set; } = 3;
        [Translation("Results Storage Days", "검사 결과 보관일"), JsonProperty("DaysToKeepResults")]
        public Int32 결과보관 { get; set; } = 900;
        [Translation("Logs Storage Days", "로그 보관일"), JsonProperty("DaysToKeepLogs")]
        public Int32 로그보관 { get; set; } = 60;

        [Description("조명 컨트롤러 IP"), JsonProperty("LightsHost")]
        public String 조명주소 { get; set; } = "192.168.5.10";

        [Description("비젼 Tools"), JsonIgnore]
        public String 도구경로 => Path.Combine(기본경로, "Tools");
        [Description("마스터 이미지"), JsonIgnore]
        public String 마스터사진 => Path.Combine(기본경로, "Masters");

        [JsonProperty("CurrentModel")]
        public 모델구분 선택모델 { get; set; } = 모델구분.UPR3P24S;

        [JsonIgnore]
        public Boolean 강제배출 { get; set; } = false;
        [JsonIgnore]
        public Boolean 양품불량 { get; set; } = true;

        [JsonIgnore]
        public String Format => "#,0." + String.Empty.PadLeft(this.결과자릿수, '0');
        [JsonIgnore]
        public String 결과표현 => "{0:" + Format + "}";

        [JsonIgnore, Description("사용자명")]
        public String 사용자명 { get; set; } = String.Empty;
        [JsonIgnore, Description("권한구분")]
        public 유저권한구분 사용권한 { get; set; } = 유저권한구분.없음;
        public Boolean 권한여부(유저권한구분 요구권한) => (Int32)사용권한 >= (Int32)요구권한;
        [JsonIgnore, Description("슈퍼유저")]
        public const String 시스템관리자 = "ivmadmin";
        public 유저권한구분 시스템관리자인증(string 사용자명, string 비밀번호)
        {
            if (사용자명 != 시스템관리자) return 유저권한구분.없음;
            String pass = $"{시스템관리자}";// {Utils.FormatDate(DateTime.Now, "{0:ddHH}")}";
            if (비밀번호 == pass)
            {
                this.시스템관리자로그인();
                return 유저권한구분.시스템;
            }
            return 유저권한구분.없음;
        }
        public void 시스템관리자로그인()
        {
            this.사용자명 = 시스템관리자;
            this.사용권한 = 유저권한구분.시스템;
        }
        [JsonIgnore]
        public Boolean 슈퍼유저 => 사용권한 == 유저권한구분.시스템 && 사용자명 == 시스템관리자;

        [JsonIgnore]
        public static TranslationAttribute 로그영역 = new TranslationAttribute("Preferences", "환경설정");
        [JsonIgnore]
        private String 저장파일 => Path.Combine(this.기본경로, "Config.json");

        [JsonIgnore, Description("이미지 저장 디스크 사용율")]
        public Int32 저장비율 => 100 - this.SaveImageDriveFreeSpace();
        [JsonIgnore]
        public static String LocalApplicationData => SpecialFolder(Environment.SpecialFolder.LocalApplicationData);
        [JsonIgnore]
        public static String ExecutablePath => Path.GetDirectoryName(Application.ExecutablePath);
        public static String SpecialFolder(Environment.SpecialFolder folder) => Environment.GetFolderPath(folder);

        public static NpgsqlConnection CreateDbConnection()
        {
            NpgsqlConnectionStringBuilder b = new NpgsqlConnectionStringBuilder() { Host = "localhost", Port = 5432, Username = "postgres", Password = "ivmadmin", Database = "te1mica" };
            return new NpgsqlConnection(b.ConnectionString);
        }

        public Boolean CanDbConnect()
        {
            Boolean can = false;
            try
            {
                NpgsqlConnection conn = CreateDbConnection();
                conn.Open();
                can = conn.ProcessID > 0;
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역.GetString(), "데이터베이스 연결실패", ex.Message, true);
            }
            return can;
        }

        public Boolean Init() => this.Load();
        public void Close() => this.Save();

        public Boolean Load()
        {
            if (!CanDbConnect())
            {
                Global.오류로그(로그영역.GetString(), "데이터베이스 연결실패", "데이터베이스에 연결할 수 없습니다.", true);
                return false;
            }
            Common.DirectoryExists(Path.Combine(Application.StartupPath, @"Views"), true);
            if (!Common.DirectoryExists(기본경로, true))
            {
                Global.오류로그(로그영역.GetString(), "환경설정 초기화 실패", "기본설정 폴더를 생성할 수 없습니다.", true);
                return false;
            }
            if (!Common.DirectoryExists(사진저장, true))
                Global.오류로그(로그영역.GetString(), "환경설정 초기화 실패", "사진저장 폴더를 생성할 수 없습니다.", true);
            if (!Common.DirectoryExists(문서저장, true))
                Global.오류로그(로그영역.GetString(), "환경설정 초기화 실패", "문서저장 폴더를 생성할 수 없습니다.", true);
            if (!Common.DirectoryExists(도구경로, true))
                Global.오류로그(로그영역.GetString(), "환경설정 초기화 실패", "비전도구 폴더를 생성할 수 없습니다.", true);
            if (!Common.DirectoryExists(마스터사진, true))
                Global.오류로그(로그영역.GetString(), "환경설정 초기화 실패", "마스터사진 폴더를 생성할 수 없습니다.", true);

            if (File.Exists(저장파일))
            {
                try
                {
                    환경설정 설정 = JsonConvert.DeserializeObject<환경설정>(File.ReadAllText(저장파일, Encoding.UTF8));
                    foreach (PropertyInfo p in 설정.GetType().GetProperties())
                    {
                        if (!p.CanWrite) continue;
                        Object v = p.GetValue(설정);
                        if (v == null) continue;
                        p.SetValue(this, v);
                    }
                }
                catch (Exception ex)
                {
                    Global.오류로그(로그영역.GetString(), "환경설정 초기화 실패", ex.Message, true);
                }
            }
            else
            {
                this.Save();
                Global.정보로그(로그영역.GetString(), "환경설정 초기화", "저장된 설정파일이 없습니다.", false);
            }

            Debug.WriteLine(this.동작구분, "동작구분");
            return true;
        }

        public void Save()
        {
            if (!Utils.WriteAllText(저장파일, JsonConvert.SerializeObject(this, Utils.JsonSetting())))
                Global.오류로그(로그영역.GetString(), "환경설정 저장", "환경설정 저장에 실패하였습니다.", true);
        }

        public void 모델변경요청(Int32 모델번호) => this.모델변경요청((모델구분)모델번호);
        public void 모델변경요청(모델구분 모델구분)
        {
            if (this.선택모델 == 모델구분) return;
            this.선택모델 = 모델구분;
            this.모델변경알림?.Invoke(this.선택모델);
        }

        //[Description("결과별 표현색상")]
        //public static Color ResultColor(결과구분 구분)
        //{
        //    if (구분 == 결과구분.WA) return DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText;
        //    if (구분 == 결과구분.ER) return DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
        //    if (구분 == 결과구분.OK) return DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
        //    if (구분 == 결과구분.NG) return DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
        //    return DevExpress.LookAndFeel.DXSkinColors.ForeColors.ControlText;
        //}

        #region 드라이브 용량계산
        private DriveInfo ImageSaveDrive = null;
        private DriveInfo GetSaveImageDrive()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (this.사진저장.StartsWith(drive.Name))
                {
                    //Debug.WriteLine(drive.Name, drive.VolumeLabel);
                    this.ImageSaveDrive = drive;
                    return this.ImageSaveDrive;
                }
            }
            if (drives.Length > 0)
                this.ImageSaveDrive = drives[0];

            return this.ImageSaveDrive;
        }

        public Int32 SaveImageDriveFreeSpace()
        {
            DriveInfo drive = this.GetSaveImageDrive();
            double FreeSpace = drive.AvailableFreeSpace / (double)drive.TotalSize * 100;
            return Convert.ToInt32(FreeSpace);
        }
        #endregion
    }
}
