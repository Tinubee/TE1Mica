using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace TE1.Schemas
{
    public partial class 조명제어
    {
        [JsonIgnore]
        private ALTE8RSUL 컨트롤러;

        [JsonIgnore]
        public Boolean 정상여부 => this.컨트롤러.IsOpen;

        public void Init()
        {
            this.컨트롤러 = new ALTE8RSUL { 통신포트 = 통신포트.TCP1000, HostName = Global.환경설정.조명주소 };
            // 컨트롤러 당 카메라 1대씩 연결
            this.Add(new 조명정보(카메라구분.Cam01, 컨트롤러) { 채널 = 조명채널.CH01, 밝기 = 100 });
            this.Add(new 조명정보(카메라구분.Cam02, 컨트롤러) { 채널 = 조명채널.CH02, 밝기 = 100 });
            this.Add(new 조명정보(카메라구분.Cam03, 컨트롤러) { 채널 = 조명채널.CH03, 밝기 = 100 });
            this.Add(new 조명정보(카메라구분.Cam04, 컨트롤러) { 채널 = 조명채널.CH04, 밝기 = 100 });
            this.Add(new 조명정보(카메라구분.Cam05, 컨트롤러) { 채널 = 조명채널.CH05, 밝기 = 100 });
            this.Add(new 조명정보(카메라구분.Cam06, 컨트롤러) { 채널 = 조명채널.CH06, 밝기 = 100 });
            this.Add(new 조명정보(카메라구분.Cam07, 컨트롤러) { 채널 = 조명채널.CH07, 밝기 = 100 });
            this.Add(new 조명정보(카메라구분.Cam08, 컨트롤러) { 채널 = 조명채널.CH08, 밝기 = 100 });

            try
            {
                this.Load();
                if (Global.환경설정.동작구분 != 동작구분.Live) return;
                this.컨트롤러.Init();
                this.Open();
                this.Set();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message, "조명제어"); }
        }

        public void TurnOn()
        {
            new Thread(() =>
            {
                Dictionary<조명채널, Int32> 자료 = new Dictionary<조명채널, Int32>();
                foreach (조명정보 정보 in this)
                {
                    if (자료.ContainsKey(정보.채널)) continue;
                    자료.Add(정보.채널, 정보.밝기);
                }
                this.컨트롤러.TurnOn(자료);
            }).Start();
        }

        public void TurnOff()
        {
            new Thread(() => { this.컨트롤러.TurnOff(); }).Start();
        }
    }
}
