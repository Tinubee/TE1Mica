using MvCamCtrl.NET;
using MvUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace TE1.Schemas
{
    public class 그랩제어 : Dictionary<카메라구분, 그랩장치>
    {
        public delegate void 그랩완료대리자(그랩장치 장치);
        public event 그랩완료대리자 그랩완료보고;

        [JsonIgnore]
        private const string 로그영역 = "카메라";
        [JsonIgnore]
        private string 저장파일 => Path.Combine(Global.환경설정.기본경로, "Cameras.json");
        [JsonIgnore]
        public Boolean 정상여부 => !this.Values.Any(e => !e.상태);

        public Boolean Init()
        {
            this.Add(카메라구분.Cam01, new HikeGigE() { 구분 = 카메라구분.Cam01, 코드 = "DA2729845", 가로 = 4096, 세로 = 3000, OffsetX = 0, OffsetY = 0 });
            this.Add(카메라구분.Cam02, new HikeGigE() { 구분 = 카메라구분.Cam02, 코드 = "DA2729846", 가로 = 4096, 세로 = 3000, OffsetX = 0, OffsetY = 0, ReverseX = false, ReverseY = true });
            this.Add(카메라구분.Cam03, new HikeGigE() { 구분 = 카메라구분.Cam03, 코드 = "DA2729842", 가로 = 4096, 세로 = 3000, OffsetX = 0, OffsetY = 0 });
            this.Add(카메라구분.Cam04, new HikeGigE() { 구분 = 카메라구분.Cam04, 코드 = "DA2729843", 가로 = 4096, 세로 = 3000, OffsetX = 0, OffsetY = 0, ReverseX = false, ReverseY = true });
            this.Add(카메라구분.Cam05, new HikeGigE() { 구분 = 카메라구분.Cam05, 코드 = "DA2729844", 가로 = 4096, 세로 = 3000, OffsetX = 0, OffsetY = 0 });
            this.Add(카메라구분.Cam06, new HikeGigE() { 구분 = 카메라구분.Cam06, 코드 = "DA2729847", 가로 = 4096, 세로 = 3000, OffsetX = 0, OffsetY = 0, ReverseX = true, ReverseY = true });
            this.Add(카메라구분.Cam07, new HikeGigE() { 구분 = 카메라구분.Cam07, 코드 = "DA2729841", 가로 = 4096, 세로 = 3000, OffsetX = 0, OffsetY = 0 });
            this.Add(카메라구분.Cam08, new HikeGigE() { 구분 = 카메라구분.Cam08, 코드 = "DA2729840", 가로 = 4096, 세로 = 3000, OffsetX = 0, OffsetY = 0, ReverseX = true, ReverseY = true });

            // 카메라 설정 저장정보 로드
            그랩장치 정보;
            List<그랩장치> 자료 = Load();
            if (자료 != null)
            {
                foreach (그랩장치 설정 in 자료)
                {
                    정보 = this.GetItem(설정.구분);
                    if (정보 == null) continue;
                    정보.Set(설정);
                }
            }

            if (Global.환경설정.동작구분 != 동작구분.Live) return true;
            // GigE 카메라 초기화
            List<CCameraInfo> 카메라들 = new List<CCameraInfo>();
            Int32 nRet = CSystem.EnumDevices(CSystem.MV_GIGE_DEVICE, ref 카메라들);// | CSystem.MV_USB_DEVICE
            if (!Validate("Enumerate devices fail!", nRet, true)) return false;

            for (int i = 0; i < 카메라들.Count; i++)
            {
                CGigECameraInfo gigeInfo = 카메라들[i] as CGigECameraInfo;
                HikeGigE gige = this.GetItem(gigeInfo.chSerialNumber) as HikeGigE;
                if (gige == null) continue;
                gige.Init(gigeInfo);
            }

            Debug.WriteLine($"카메라 갯수: {this.Count}");
            GC.Collect();
            return true;
        }

        private List<그랩장치> Load()
        {
            if (!File.Exists(this.저장파일)) return null;
            return JsonConvert.DeserializeObject<List<그랩장치>>(File.ReadAllText(this.저장파일), Utils.JsonSetting());
        }

        public void Save()
        {
            if (!Utils.WriteAllText(저장파일, JsonConvert.SerializeObject(this.Values, Utils.JsonSetting())))
                Global.오류로그(로그영역, "카메라 설정 저장", "카메라 설정 저장에 실패하였습니다.", true);
        }

        public void Close()
        {
            if (Global.환경설정.동작구분 != 동작구분.Live) return;
            foreach (그랩장치 장치 in this.Values)
                장치?.Close();
        }
        public void Active(카메라구분 구분) => this.GetItem(구분)?.Active();
        public void Trig(카메라구분 구분) => this.GetItem(구분)?.Trig();

        public void 그랩완료(그랩장치 장치)
        {
            if (Global.장치상태.자동수동)
            {
                검사정보 검사 = Global.검사자료.현재검사찾기(장치.구분);
                if (검사 == null) return;
                Global.비전검사.Run(장치, 검사);
                장치.TurnOff();
            }
            else
            {
                //Global.비전검사.Run(장치.구분, 장치.CogImage(), Global.검사자료.수동검사);
                this.그랩완료보고?.Invoke(장치);
                if (장치.연속촬영여부)
                {
                    new Thread(() => {
                        Thread.Sleep(10);
                        장치.Trig();
                    }).Start();
                }
                else 장치.TurnOff();
            }
        }

        public Boolean 상태(카메라구분 구분) => GetItem(구분).상태;

        public 그랩장치 GetItem(카메라구분 구분)
        {
            if (this.ContainsKey(구분)) return this[구분];
            return null;
        }

        private 그랩장치 GetItem(String serial) => this.Values.Where(e => e.코드 == serial).FirstOrDefault();

        //public Double 교정X(카메라구분 구분)
        //{
        //    그랩장치 장치 = GetItem(구분);
        //    if (장치 == null) return 1;
        //    return 장치.교정X;
        //}
        //public Double 교정Y(카메라구분 구분)
        //{
        //    그랩장치 장치 = GetItem(구분);
        //    if (장치 == null) return 1;
        //    return 장치.교정Y;
        //}

        #region 수동촬영
        public void 스냅촬영(그랩장치 장치)
        {
            new Thread(() => {
                장치.TurnOn();
                Thread.Sleep(100);
                장치.Trig();
            }).Start();
        }
        public Boolean 스냅촬영(카메라구분 구분)
        {
            if (Global.장치상태.자동수동) return false;
            그랩장치 장치 = GetItem(구분);
            if (장치 == null) return false;
            if (장치.연속촬영여부) return false;
            스냅촬영(장치);
            return true;
        }

        public void 연속촬영(카메라구분 구분, Boolean 동작)
        {
            if (Global.장치상태.자동수동) return;
            그랩장치 장치 = GetItem(구분);
            if (장치 == null) return;
            if (동작)
            {
                if (장치.연속촬영여부) return;
                장치.연속촬영여부 = true;
                스냅촬영(장치);
            }
            else
            {
                장치.연속촬영여부 = false;
                장치.TurnOff();
            }
        }
        #endregion

        #region 영상촬영 
        public void 그랩하기(카메라구분[] 카메라)
        {
            new Thread(() => {
                foreach (카메라구분 캠 in 카메라)
                {
                    그랩장치 장치 = this.GetItem(캠);
                    if (장치 == null || !장치.상태) continue;
                    장치.TurnOn();
                    Thread.Sleep(100);
                    장치.Trig();
                }
            }).Start();
        }
        public void 좌측제품촬영() => 그랩하기(new 카메라구분[] { 카메라구분.Cam01, 카메라구분.Cam03 });
        public void 좌측시트촬영() => 그랩하기(new 카메라구분[] { 카메라구분.Cam02, 카메라구분.Cam04 });
        public void 우측제품촬영() => 그랩하기(new 카메라구분[] { 카메라구분.Cam05, 카메라구분.Cam07 });
        public void 우측시트촬영() => 그랩하기(new 카메라구분[] { 카메라구분.Cam06, 카메라구분.Cam08 });
        #endregion


        #region 오류메세지
        public static Boolean Validate(String message, Int32 errorNum, Boolean show)
        {
            if (errorNum == CErrorDefine.MV_OK) return true;

            String errorMsg = String.Empty;
            switch (errorNum)
            {
                case CErrorDefine.MV_E_HANDLE: errorMsg = "Error or invalid handle"; break;
                case CErrorDefine.MV_E_SUPPORT: errorMsg = "Not supported function"; break;
                case CErrorDefine.MV_E_BUFOVER: errorMsg = "Cache is full"; break;
                case CErrorDefine.MV_E_CALLORDER: errorMsg = "Function calling order error"; break;
                case CErrorDefine.MV_E_PARAMETER: errorMsg = "Incorrect parameter"; break;
                case CErrorDefine.MV_E_RESOURCE: errorMsg = "Applying resource failed"; break;
                case CErrorDefine.MV_E_NODATA: errorMsg = "No data"; break;
                case CErrorDefine.MV_E_PRECONDITION: errorMsg = "Precondition error, or running environment changed"; break;
                case CErrorDefine.MV_E_VERSION: errorMsg = "Version mismatches"; break;
                case CErrorDefine.MV_E_NOENOUGH_BUF: errorMsg = "Insufficient memory"; break;
                case CErrorDefine.MV_E_UNKNOW: errorMsg = "Unknown error"; break;
                case CErrorDefine.MV_E_GC_GENERIC: errorMsg = "General error"; break;
                case CErrorDefine.MV_E_GC_ACCESS: errorMsg = "Node accessing condition error"; break;
                case CErrorDefine.MV_E_ACCESS_DENIED: errorMsg = "No permission"; break;
                case CErrorDefine.MV_E_BUSY: errorMsg = "Device is busy, or network disconnected"; break;
                case CErrorDefine.MV_E_NETER: errorMsg = "Network error"; break;
                default: errorMsg = "Unknown error"; break;
            }

            Global.오류로그("Camera", "Error", $"[{errorNum}] {message} {errorMsg}", show);
            return false;
        }
        #endregion
    }
}