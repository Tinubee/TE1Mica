using DevExpress.Utils.Extensions;
using System;
using System.Diagnostics;
using System.Linq;

namespace TE1.Schemas
{
    partial class 장치통신
    {
        private DateTime 오류알림시간 = DateTime.Today.AddDays(-1);
        private Int32 오류알림간격 = 30; // 초

        public void 통신오류알림(Int32 오류코드)
        {
            if (오류코드 == 0)
            {
                this.정상여부 = true;
                return;
            }
            if ((DateTime.Now - this.오류알림시간).TotalSeconds < this.오류알림간격) return;
            this.오류알림시간 = DateTime.Now;
            this.정상여부 = false;
            Global.오류로그(로그영역, "PLC 통신", $"[{오류코드.ToString("X8")}] 통신 오류가 발생하였습니다.", false);
        }

        public void 원점정보갱신(시트구분[] 시트)
        {
            if (!Global.장치상태.자동수동) return;
            if (시트.Contains(시트구분.좌측)) this.위치자료.좌측원점읽기();
            if (시트.Contains(시트구분.우측)) this.위치자료.우측원점읽기();
            //this.위치자료.ForEach(r => {
            //    Debug.WriteLine(r.Value, r.Key.ToString());
            //});
        }

        public void 위치정보입력()
        {
            //this.위치자료.좌측위치쓰기(0.1, 0.2, 0.3);
            //this.위치자료.우측위치쓰기(0.4, 0.5, 0.6);
        }

        private Boolean 입출자료갱신()
        {
            DateTime 현재 = DateTime.Now;
            // 입출자료 갱신
            Int32 오류 = 0;
            Int32[] 자료 = ReadDeviceRandom(입출자료.주소목록, out 오류);
            if (오류 != 0)
            {
                통신오류알림(오류);
                return false;
            }
            this.입출자료.Set(자료);
            return true;
        }

        private Boolean 입출자료분석()
        {
            if (Global.환경설정.동작구분 == 동작구분.LocalTest) return 테스트수행();
            if (!입출자료갱신()) return false;
            제품검사수행();
            장치상태확인();
            통신핑퐁수행();
            return true;
        }

        private void 장치상태확인()
        {
            //if (this.입출자료.Changed(정보주소.시작정지))
            //    Debug.WriteLine($"{Utils.FormatDate(DateTime.Now, "{0:HH:mm:ss.fff}")} => {this.입출자료.Changed(정보주소.시작정지)}", "시작정지");
            if (this.입출자료.Changed(정보주소.자동수동) || this.입출자료.Changed(정보주소.시작정지))
                this.동작상태알림?.Invoke();
        }

        private void 제품검사수행()
        {
            if (this.입출자료.Firing(정보주소.제품촬영L, true))
            {
                Debug.WriteLine("좌측제품촬영", "Trig");
                Global.그랩제어.좌측제품촬영();
                //this.입출자료.SetDelay(정보주소.제품촬영L, 0, 200);
            }
            if (this.입출자료.Firing(정보주소.시트촬영L, true))
            {
                Debug.WriteLine("좌측시트촬영", "Trig");
                Global.그랩제어.좌측시트촬영();
                //this.입출자료.SetDelay(정보주소.시트촬영L, 0,200);
            }
            if (this.입출자료.Firing(정보주소.제품촬영R, true))
            {
                Debug.WriteLine("우측제품촬영", "Trig");
                Global.그랩제어.우측제품촬영();
                //this.입출자료.SetDelay(정보주소.제품촬영R, 0, 200);
            }
            if (this.입출자료.Firing(정보주소.시트촬영R, true))
            {
                Debug.WriteLine("우측시트촬영", "Trig");
                Global.그랩제어.우측시트촬영();
                //this.입출자료.SetDelay(정보주소.시트촬영R, 0, 200);
            }
            if (this.입출자료.Firing(정보주소.위치요청L, true))
            {
                Debug.WriteLine("좌측위치요청", "Trig");
                검사정보 검사 = Global.검사자료.현재검사찾기(시트구분.좌측);
                결과전송(시트구분.좌측, 검사);
            }
            if (this.입출자료.Firing(정보주소.위치요청R, true))
            {
                Debug.WriteLine("우측위치요청", "Trig");
                검사정보 검사 = Global.검사자료.현재검사찾기(시트구분.우측);
                결과전송(시트구분.우측, 검사);
            }
            if (this.입출자료.Firing(정보주소.배출완료, true))
            {
                Debug.WriteLine("배출완료", "Trig");
                Global.모델자료.수량추가(true);
                this.입출자료.SetDelay(정보주소.배출완료, 0, 200);
            }
        }

        public void 결과전송(시트구분 시트, 검사정보 검사)
        {
            if (검사 == null) {
                Debug.WriteLine($"Trig 결과전송 오류");
                결과전송(시트, false); 
                return; 
            }
            Global.검사자료.검사결과계산(검사);
            Debug.WriteLine($"결과전송: {검사.결과}, R={검사.보정R}, X={검사.보정X}, Y={검사.보정Y}", "Trig");
            if (검사.결과) {
                결과전송(시트, true, 검사.보정R, 검사.보정X, 검사.보정Y);
            } 
            else 결과전송(시트, false); 
        }
        private void 결과전송(시트구분 시트, Boolean 정상, Double R = 0, Double X = 0, Double Y = 0)
        {
            if (시트 == 시트구분.좌측)
            {
                this.위치자료.좌측위치쓰기(R, X, Y);
                if (!정상) this.입출자료.SetDelay(정보주소.위치오류L, 0, 100);
                this.입출자료.SetDelay(정보주소.위치요청L, 0, 200);
            }
            else
            {
                this.위치자료.우측위치쓰기(R, X, Y);
                if (!정상) this.입출자료.SetDelay(정보주소.위치오류R, 0, 100);
                this.입출자료.SetDelay(정보주소.위치요청R, 0, 200);
            }
        }

        // 핑퐁
        private void 통신핑퐁수행()
        {
            if (!this.입출자료[정보주소.통신핑퐁].Passed()) return;
            this.통신핑퐁 = !this.통신핑퐁;
            this.통신상태알림?.Invoke();
        }

        private Boolean 테스트수행()
        {
            통신핑퐁수행();
            return true;
        }
    }
}
