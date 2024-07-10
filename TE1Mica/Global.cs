using TE1.Schemas;
using MvUtils;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TE1
{
    public static class Global
    {
        public const String SkinName = "The Bezier";
        public const String BlackPalette = "Office Black";
        public const String ColorPalette = "Office Colorful";
        public static MainForm MainForm = null;
        public static Random Random = new Random();
        public static Int32 RandomSign => Random.NextDouble() >= 0.5 ? 1 : -1;
        public delegate void BaseEvent();
        public static event EventHandler<Boolean> Initialized;

        private const String 로그영역 = "프로그램";
        public static 환경설정 환경설정;
        public static 로그자료 로그자료;
        public static 유저자료 유저자료;
        public static 모델자료 모델자료;
        public static 장치통신 장치통신;
        public static 조명제어 조명제어;
        public static 그랩제어 그랩제어;
        public static 비전검사 비전검사;
        public static 사진자료 사진자료;
        public static 검사자료 검사자료;

        public static class 장치상태
        {
            public static Boolean 카메라1 => Global.그랩제어.상태(카메라구분.Cam01);
            public static Boolean 카메라2 => Global.그랩제어.상태(카메라구분.Cam02);
            public static Boolean 카메라3 => Global.그랩제어.상태(카메라구분.Cam03);
            public static Boolean 카메라4 => Global.그랩제어.상태(카메라구분.Cam04);
            public static Boolean 카메라5 => Global.그랩제어.상태(카메라구분.Cam05);
            public static Boolean 카메라6 => Global.그랩제어.상태(카메라구분.Cam06);
            public static Boolean 카메라7 => Global.그랩제어.상태(카메라구분.Cam07);
            public static Boolean 카메라8 => Global.그랩제어.상태(카메라구분.Cam08);
            public static Boolean 조명장치 => 조명제어.정상여부;
            public static Boolean 그랩장치 => Global.그랩제어.정상여부;
            public static Boolean 자동수동 => Global.장치통신.자동수동;
            public static Boolean 시작정지 => Global.장치통신.시작정지;
        }

        public static Boolean Init()
        {
            알림화면 = new AlertControl() { AutoHeight = true, FormSize = new System.Drawing.Size(400, 200), PopupLocation = AlertControl.PopupLocations.CenterForm };
            로그화면 = new AlertControl() { PopupLocation = AlertControl.PopupLocations.BottomRight };
            질문화면 = new FlyoutDialog(FlyoutDialog.DialogType.Confirm);
            try
            {
                로그자료 = new 로그자료();
                환경설정 = new 환경설정();
                유저자료 = new 유저자료();
                장치통신 = new 장치통신();
                조명제어 = new 조명제어();
                모델자료 = new 모델자료();
                비전검사 = new 비전검사();
                사진자료 = new 사진자료();
                그랩제어 = new 그랩제어();
                검사자료 = new 검사자료();

                로그자료.Init();
                환경설정.Init();
                유저자료.Init();
                장치통신.Init();
                모델자료.Init();
                검사자료.Init();
                if (!그랩제어.Init()) new Exception("카메라 초기화에 실패하였습니다.");
                if (!장치통신.Open()) new Exception("PLC 서버에 연결할 수 없습니다.");
                비전검사.Init(); // 그랩장치가 먼저 Init 되어야 함
                사진자료.Init();
                조명제어.Init();

                Global.정보로그(로그영역, "초기화", "시스템을 초기화 합니다.", false);
                Initialized?.Invoke(null, true);
                return true;
            }
            catch (Exception ex)
            {
                Utils.DebugException(ex, 3);
                Global.오류로그(로그영역, "초기화 오류", "시스템 초기화에 실패하였습니다.\n" + ex.Message, true);
            }
            Initialized.Invoke(null, false);
            return false;
        }

        public static Boolean Close()
        {
            Global.정보로그(로그영역, "종료", "시스템을 종료 합니다.", false);
            Boolean r = false;
            try
            {
                검사자료.Close();
                조명제어.Close();
                장치통신.Close();
                유저자료.Close();
                환경설정.Close();
                그랩제어.Close();
                비전검사.Close();
                사진자료.Close();
                모델자료.Close();
                로그자료.Close();
                
                Properties.Settings.Default.Save();
                Debug.WriteLine("시스템 종료");
                r = true;
            }
            catch (Exception ex) { r = Utils.ErrorMsg("프로그램 종료 중 오류가 발생하였습니다.\n" + ex.Message); }
            finally { Environment.Exit(0); }
            return r;
        }

        public static void Start()
        {
            장치통신.Start();
            if (Global.환경설정.동작구분 != 동작구분.Live) return;
        }

        public static void DxLocalization()
        {
            if (Localization.CurrentLanguage == Language.KO)
            {
                MvUtils.Localization.CurrentLanguage = MvUtils.Localization.Language.KO;
                MvUtils.DxDataGridLocalizer.Enable();
                MvUtils.DxEditorsLocalizer.Enable();
                MvUtils.DxDataFilteringLocalizer.Enable();
                MvUtils.DxLayoutLocalizer.Enable();
                MvUtils.DxBarLocalizer.Enable();
            }
            else MvUtils.Localization.CurrentLanguage = MvUtils.Localization.Language.EN;
        }

        public static String GetGuid()
        {
            Assembly assembly = typeof(Program).Assembly;
            GuidAttribute attribute = assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0] as GuidAttribute;
            return attribute.Value;
        }

        #region Log / Notify / Confirm
        private static AlertControl 알림화면;
        private static AlertControl 로그화면;
        private static FlyoutDialog 질문화면;
        public static void ShowLog(Form owner, 로그정보 로그)
        {
            if (owner == null || owner.IsDisposed) return;
            if (owner.InvokeRequired) { owner.BeginInvoke(new Action(() => ShowLog(owner, 로그))); return; }
            if (로그.구분 == 로그구분.오류)
                로그화면.Show(AlertControl.AlertTypes.Invalid, 로그.제목, 로그.내용, owner);
            else if (로그.구분 == 로그구분.경고)
                로그화면.Show(AlertControl.AlertTypes.Warning, 로그.제목, 로그.내용, owner);
            else if (로그.구분 == 로그구분.정보)
                로그화면.Show(AlertControl.AlertTypes.Information, 로그.제목, 로그.내용, owner);
        }
        public static void ShowLog(로그정보 로그) => ShowLog(MainForm, 로그);

        public static 로그정보 로그기록(String 영역, 로그구분 구분, String 제목, String 내용, Form parent)
        {
            try
            {
                로그정보 로그 = 로그자료.Add(영역, 구분, 제목, 내용);
                #if DEBUG
                Debug.WriteLine($"{Utils.FormatDate(DateTime.Now, "{0:HH:mm:ss}")}\t{구분.ToString()}\t{영역}\t{제목}\t{내용}");
                #endif
                ShowLog(parent, 로그);
                return 로그;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message, "로그기록 오류"); }
            return null;
        }
        public static 로그정보 오류로그(String 영역, String 제목, String 내용, bool show) => 오류로그(영역, 제목, 내용, show ? MainForm : null);
        public static 로그정보 오류로그(String 영역, String 제목, String 내용, Form parent) => 로그기록(영역, 로그구분.오류, 제목, 내용, parent);
        public static 로그정보 경고로그(String 영역, String 제목, String 내용, bool show) => 경고로그(영역, 제목, 내용, show ? MainForm : null);
        public static 로그정보 경고로그(String 영역, String 제목, String 내용, Form parent) => 로그기록(영역, 로그구분.경고, 제목, 내용, parent);
        public static 로그정보 정보로그(String 영역, String 제목, String 내용, bool show) => 정보로그(영역, 제목, 내용, show ? MainForm : null);
        public static 로그정보 정보로그(String 영역, String 제목, String 내용, Form parent) => 로그기록(영역, 로그구분.정보, 제목, 내용, parent);

        public static Boolean Notify(String 내용, String 제목, AlertControl.AlertTypes 구분 = AlertControl.AlertTypes.Information) => Notify(MainForm, 내용, 제목, 구분);
        public static Boolean Notify(Form owner, String 내용, String 제목, AlertControl.AlertTypes 구분 = AlertControl.AlertTypes.Information)
        {
            알림화면.Show(구분, 제목, 내용, owner);
            return 구분 == AlertControl.AlertTypes.Information;
        }

        public static Boolean Confirm(String 내용, String 제목) => Confirm(MainForm, 내용, 제목);
        public static Boolean Confirm(String 내용) => Confirm(MainForm, 내용, Localization.확인.GetString());
        public static Boolean Confirm(Control control, String 내용) => Confirm(control?.FindForm(), 내용, Localization.확인.GetString());
        public static Boolean Confirm(Form parent, String 내용, String 제목) => 질문화면.ShowConfirm(parent, 제목, 내용);
        #endregion
    }
}
