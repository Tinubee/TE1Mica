using ActUtlType64Lib;
using MvUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TE1.Schemas
{
    // PLC 통신
    [Description("MELSEC Q06UDV")]
    public partial class 장치통신
    {
        public event Global.BaseEvent 동작상태알림;
        public event Global.BaseEvent 통신상태알림;

        #region 기본상수 및 멤버
        private static String 로그영역 = "PLC 통신";
        private const Int32 스테이션번호 = 0;
        private const Int32 입출체크간격 = 60;
        private DateTime 시작일시 = DateTime.Now;
        private Boolean 작업여부 = false;  // 동작 FLAG 
        private ActUtlType64 PLC = null;
        public Boolean 정상여부 = false;

        private enum 정보주소 : Int32
        {
            [Address("B1000", 1000,  0, true)] 통신핑퐁,
            [Address("B1001", 1000,  1, true)] 피씨상태,
            [Address("B1002", 1000, -1, true)] 자동수동,
            [Address("B1003", 1000, -1, true)] 시작정지,
            [Address("B1004", 3000,  0, true)] 제품촬영L,
            [Address("B1005", 3000,  0, true)] 시트촬영L,
            [Address("B1006", 3000,  0, true)] 위치요청L,
            [Address("B1007", 3000,  0, true)] 위치오류L, // Align 오류시 처리 해야 할 사항?
            [Address("B1008", 3000,  0, true)] 제품촬영R,
            [Address("B1009", 3000,  0, true)] 시트촬영R,
            [Address("B100A", 3000,  0, true)] 위치요청R,
            [Address("B100B", 3000,  0, true)] 위치오류R, // Align 오류 시 처리?
            [Address("B100F", 3000,  0, true)] 배출완료,

            [Address("WD", 0, 0, false)] 생산수량,
            [Address("WF")] 모델번호,
        }

        private enum 위치주소 : Int32
        {
            [Address("W0")] 좌측위치R,
            [Address("W2")] 좌측위치X,
            [Address("W4")] 좌측위치Y,
            [Address("W6")] 우측위치R,
            [Address("W8")] 우측위치X,
            [Address("WA")] 우측위치Y,

            [Address("W10")] 좌측원점R,
            [Address("W12")] 좌측원점X,
            [Address("W14")] 좌측원점Y,
            [Address("W16")] 우측원점R,
            [Address("W18")] 우측원점X,
            [Address("W1A")] 우측원점Y,
        }

        private 통신자료 입출자료 = new 통신자료();
        private 위치정보 위치자료 = new 위치정보();
        public static Boolean ToBool(Int32 val) => val != 0;
        public static Int32 ToInt(Boolean val) => val ? 1 : 0;
        private Int32 정보읽기(정보주소 구분) => this.입출자료.Get(구분);
        private Boolean 신호읽기(정보주소 구분) => ToBool(this.입출자료.Get(구분));
        private void 정보쓰기(정보주소 구분, Int32 val) => this.입출자료.Set(구분, val);
        private void 정보쓰기(정보주소 구분, Boolean val) => this.입출자료.Set(구분, ToInt(val));

        #region 입출신호
        public Boolean 통신핑퐁 { get => 신호읽기(정보주소.통신핑퐁); set => 정보쓰기(정보주소.통신핑퐁, value); }
        public Boolean 피씨상태 { get => 신호읽기(정보주소.피씨상태); set => 정보쓰기(정보주소.피씨상태, value); }
        public Boolean 자동수동 => 신호읽기(정보주소.자동수동);
        public Boolean 시작정지 => 신호읽기(정보주소.시작정지);

        public Boolean 제품촬영L { get => 신호읽기(정보주소.제품촬영L); set => 정보쓰기(정보주소.제품촬영L, value); }
        public Boolean 시트촬영L { get => 신호읽기(정보주소.시트촬영L); set => 정보쓰기(정보주소.시트촬영L, value); }
        public Boolean 위치요청L { get => 신호읽기(정보주소.위치요청L); set => 정보쓰기(정보주소.위치요청L, value); }
        public Boolean 위치오류L { get => 신호읽기(정보주소.위치오류L); set => 정보쓰기(정보주소.위치오류L, value); }
        public Boolean 제품촬영R { get => 신호읽기(정보주소.제품촬영R); set => 정보쓰기(정보주소.제품촬영R, value); }
        public Boolean 시트촬영R { get => 신호읽기(정보주소.시트촬영R); set => 정보쓰기(정보주소.시트촬영R, value); }
        public Boolean 위치요청R { get => 신호읽기(정보주소.위치요청R); set => 정보쓰기(정보주소.위치요청R, value); }
        public Boolean 위치오류R { get => 신호읽기(정보주소.위치오류R); set => 정보쓰기(정보주소.위치오류R, value); }
        public Boolean 배출완료  { get => 신호읽기(정보주소.배출완료);  set => 정보쓰기(정보주소.배출완료, value); }
        #endregion

        #region Data
        public Double 좌측원점R => this.위치자료.Get(위치주소.좌측원점R);
        public Double 좌측원점X => this.위치자료.Get(위치주소.좌측원점X);
        public Double 좌측원점Y => this.위치자료.Get(위치주소.좌측원점Y);
        public Double 우측원점R => this.위치자료.Get(위치주소.우측원점R);
        public Double 우측원점X => this.위치자료.Get(위치주소.우측원점X);
        public Double 우측원점Y => this.위치자료.Get(위치주소.우측원점Y);

        public Int32 모델번호  => 정보읽기(정보주소.모델번호);
        public Int32 생산수량 { get => 정보읽기(정보주소.생산수량); set => 정보쓰기(정보주소.생산수량, value); }
        #endregion
        #endregion

        #region 기본함수
        public void Init()
        {
            this.PLC = new ActUtlType64();
            this.PLC.ActLogicalStationNumber = 스테이션번호;
            if (Global.환경설정.동작구분 == 동작구분.Live)
            {
                this.입출자료.Init(new Action<정보주소, Int32>((주소, 값) => 자료전송(주소, 값)));
                this.위치자료.Init(this.PLC);
                //this.위치자료.Init(new Action<위치주소, Int32>((주소, 값) => 자료전송(주소, 값)));
            }
            else this.입출자료.Init(null);
        }
        public void Close() { this.Stop(); }

        public void Start()
        {
            if (this.작업여부) return;
            this.작업여부 = true;
            this.정상여부 = true;
            this.시작일시 = DateTime.Now;
            if (Global.환경설정.동작구분 == 동작구분.Live)
            {
                this.입출자료갱신();
                this.입출자료리셋();
                this.생산수량 = Global.모델자료.선택모델 != null ? Global.모델자료.선택모델.전체갯수 : 0;
                //this.원점정보갱신(new 시트구분[] { 시트구분.좌측, 시트구분.우측 });
                this.동작상태알림?.Invoke();
            }
            new Thread(장치통신작업) { Priority = ThreadPriority.Highest }.Start();
        }

        public void Stop() => this.작업여부 = false;
        public Boolean Open() { this.정상여부 = PLC.Open() == 0; return this.정상여부; }

        private void 연결종료()
        {
            try
            {
                PLC.Close();
                Global.정보로그(로그영역, "PLC 연결종료", $"서버에 연결을 종료하였습니다.", false);
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역, "PLC 연결종료", $"서버 연결을 종료하는 중 오류가 발생하였습니다.\r\n{ex.Message}", false);
            }
        }

        private void 자료전송(정보주소 주소, Int32 값)
        {
            DateTime 시간 = DateTime.Now;
            Int32 오류 = 0;
            SetDevice(입출자료.Address(주소), 값, out 오류);
            통신오류알림(오류);
        }

        private void 자료전송(위치주소 주소, Int32 값)
        {
            DateTime 시간 = DateTime.Now;
            Int32 오류 = 0;
            SetDevice(위치정보.Address(주소), 값, out 오류);
            통신오류알림(오류);
        }

        private void 장치통신작업()
        {
            Global.정보로그(로그영역, "PLC 통신", $"통신을 시작합니다.", false);
            //#if DEBUG
            //List<Double> 시간 = new List<Double>();
            //Int32 횟수 = 300;
            //#endif
            while (this.작업여부)
            {
                //#if DEBUG
                //DateTime 현재 = DateTime.Now;
                //#endif
                입출자료분석();
                Thread.Sleep(입출체크간격);

                //#if DEBUG
                //시간.Add((DateTime.Now - 현재).TotalMilliseconds);
                //if (시간.Count >= 300)
                //{
                //    Int32 최소 = (Int32)시간.Min();
                //    Int32 최대 = (Int32)시간.Max();
                //    Int32 평균 = (Int32)시간.Average();
                //    시간.Clear();
                //    Task.Run(() => {
                //        Global.정보로그(로그영역, "PLC 동작정보", $"Count={횟수}, Min={최소}, Max={최대}, Avg={평균}", false);
                //    });
                //}
                //#endif
            }

            Global.정보로그(로그영역, "PLC 통신", $"통신이 종료되었습니다.", false);
            this.연결종료();
        }

        private void 입출자료리셋()
        {
            foreach (정보주소 주소 in typeof(정보주소).GetEnumValues())
            {
                Debug.WriteLine(정보읽기(주소), 주소.ToString());
                AddressAttribute a = Utils.GetAttribute<AddressAttribute>(주소);
                if (a.Default < 0) continue;
                Int32 value = a.Default;
                if (주소 == 정보주소.생산수량) value = Global.모델자료.선택모델.전체갯수;
                정보쓰기(주소, value);
            }
        }
        #endregion

        #region Get / Set 함수
        private Int32[] ReadDeviceRandom(String[] 주소, out Int32 오류)
        {
            Int32[] 자료 = new Int32[주소.Length];
            오류 = PLC.ReadDeviceRandom(String.Join("\n", 주소), 주소.Length, out 자료[0]);
            return 자료;
        }

        private Int32 GetDevice(String address, out Int32 오류)
        {
            Int32 value = 0;
            오류 = PLC.GetDevice(address, out value);
            return value;
        }

        private Boolean SetDevice(String address, Int32 data, out Int32 오류)
        {
            오류 = PLC.SetDevice(address, data);
            return 오류 == 0;
        }

        private Int32 ReadDoubleWord(String address, out Int32 오류) =>
            ReadDoubleWord(PLC, address, out 오류);

        private Boolean WriteDoubleWord(String address, Int32 data, out Int32 오류) =>
            WriteDoubleWord(PLC, address, data, out 오류);

        public static Int32 ReadDoubleWord(ActUtlType64 plc, String address, out Int32 오류)
        {
            Int32[] data = new Int32[2];
            오류 = plc.ReadDeviceBlock(address, 2, out data[0]);
            return FromWords(data);
        }

        public static Boolean WriteDoubleWord(ActUtlType64 plc, String address, Int32 value, out Int32 오류)
        {
            Int32[] data = ToWords(value);
            오류 = plc.WriteDeviceBlock(address, 2, ref data[0]);
            return 오류 == 0;
        }

        public static Int32[] ReadBlocks(ActUtlType64 plc, String address, Int32 size, out Int32 오류)
        {
            Int32[] data = new Int32[size];
            오류 = plc.ReadDeviceBlock(address, size, out data[0]);
            return data;
        }

        public static Boolean WriteBlocks(ActUtlType64 plc, String address, Int32[] data, out Int32 오류)
        {
            오류 = plc.WriteDeviceBlock(address, data.Length, ref data[0]);
            return 오류 == 0;
        }

        public static Int32 FromWords(Int32[] words) => (words[1] << 16) | words[0];
        public static Int32[] ToWords(Int32 value) => new Int32[] { value & 0xFFFF, (value >> 16) & 0xFFFF };

        /*
        private Int16 GetDevice2(String Address, out Int32 오류코드)
        {
            Int16 value;
            오류코드 = PLC.GetDevice2(Address, out value);
            return value;
        }

        private Boolean SetDevice2(String Address, Int16 Data, out Int32 오류코드)
        {
            오류코드 = PLC.SetDevice2(Address, Data);
            return 오류코드 == 0;
        }
        */
        #endregion

        #region 기본 클래스 및 함수
        private static UInt16 ToUInt16(BitArray bits)
        {
            UInt16 res = 0;
            for (int i = 0; i < 16; i++)
                if (bits[i]) res |= (UInt16)(1 << i);
            return res;
        }
        private static BitArray FromUInt16(UInt16 val) => new BitArray(BitConverter.GetBytes(val));

        internal class AddressAttribute : Attribute
        {
            public String Address = String.Empty;
            public Int32 Delay = 0;               // Raise 간격
            public Int32 Default = -1;            // 초기값
            public Boolean IsIO = false;          // IO 여부
            public AddressAttribute(String address) : this(address, 0) { }
            public AddressAttribute(String address, Int32 delay) : this(address, delay, false) { }
            public AddressAttribute(String address, Int32 delay, Int32 value) : this(address, delay, value, false) { }
            public AddressAttribute(String address, Int32 delay, Boolean io)  : this(address, delay, -1, io) { }
            public AddressAttribute(String address, Int32 delay, Int32 value, Boolean io)
            {
                this.Address = address;
                this.Delay = delay;
                this.Default = value;
                this.IsIO = io;
            }
        }

        private class 통신정보
        {
            public 정보주소 구분;
            public Int32 순번 = 0;
            public Int32 정보 = 0;
            public String 주소 = String.Empty;
            public DateTime 시간 = DateTime.MinValue;
            public Int32 지연 = 0;
            public Boolean 변경 = false;

            public 통신정보(정보주소 구분)
            {
                this.구분 = 구분;
                this.순번 = (Int32)구분;
                AddressAttribute a = Utils.GetAttribute<AddressAttribute>(구분);
                this.주소 = a.Address;
                this.지연 = a.Delay;
            }

            public Boolean Passed()
            {
                if (this.지연 <= 0) return true;
                return (DateTime.Now - 시간).TotalMilliseconds >= this.지연;
            }

            public Boolean Set(Int32 val, Boolean force = false)
            {
                if (this.정보.Equals(val) || !force && !this.Passed())
                {
                    this.변경 = false;
                    return false;
                }

                this.정보 = val;
                this.시간 = DateTime.Now;
                this.변경 = true;
                return true;
            }
        }
        private class 통신자료 : Dictionary<정보주소, 통신정보>
        {
            private Action<정보주소, Int32> Transmit;
            public String[] 주소목록;
            public 통신자료()
            {
                List<String> 주소 = new List<String>();
                foreach (정보주소 구분 in typeof(정보주소).GetEnumValues())
                {
                    통신정보 정보 = new 통신정보(구분);
                    if (정보.순번 < 0) continue;
                    this.Add(구분, 정보);
                    주소.Add(정보.주소);
                }
                this.주소목록 = 주소.ToArray();
            }

            public void Init(Action<정보주소, Int32> transmit) => this.Transmit = transmit;

            public String Address(정보주소 구분)
            {
                if (!this.ContainsKey(구분)) return String.Empty;
                return this[구분].주소;
            }

            public Int32 Get(정보주소 구분)
            {
                if (!this.ContainsKey(구분)) return 0;
                return this[구분].정보;
            }

            public void Set(Int32[] 자료)
            {
                foreach (통신정보 정보 in this.Values)
                {
                    Int32 val = 자료[정보.순번];
                    Boolean 변경 = 정보.Set(val);
                    //if (변경) Debug.WriteLine($"{Utils.FormatDate(DateTime.Now, "{0:HH:mm:ss}")} {(주소구분)정보.순번} = {정보.현재}", "주소자료변경");
                }
            }

            // Return : Changed
            public Boolean Set(정보주소 구분, Int32 value)
            {
                if (!this[구분].Set(value, true)) return false;
                this.Transmit?.Invoke(구분, value);
                return true;
            }

            public void SetDelay(정보주소 구분, Int32 value, Int32 resetTime)
            {
                if (resetTime <= 0)
                {
                    if (!this[구분].Set(value, true)) return;
                    this.Transmit?.Invoke(구분, value);
                }
                Task.Run(() => {
                    Task.Delay(resetTime).Wait();
                    if (this[구분].Set(value, true))
                        this.Transmit?.Invoke(구분, value);
                });
            }

            public Boolean Changed(정보주소 구분) => this[구분].변경;
            public Boolean Firing(정보주소 구분, Boolean 상태) => this[구분].변경 && ToBool(this[구분].정보) == 상태;
            public Dictionary<정보주소, Int32> Changes(정보주소 시작, 정보주소 종료) => this.Changes((Int32)시작, (Int32)종료);
            public Dictionary<정보주소, Int32> Changes(Int32 시작, Int32 종료)
            {
                Dictionary<정보주소, Int32> 변경 = new Dictionary<정보주소, Int32>();
                foreach (정보주소 구분 in typeof(정보주소).GetEnumValues())
                {
                    Int32 번호 = (Int32)구분;
                    if (번호 < 시작 || 번호 > 종료 || !this[구분].변경) continue;
                    변경.Add(구분, this[구분].정보);
                }
                return 변경;
            }
        }

        private class 위치정보 : Dictionary<위치주소, Double>
        {
            private const Double Factor = 10000;
            private ActUtlType64 PLC = null;

            public 위치정보()
            {
                foreach (위치주소 구분 in typeof(위치주소).GetEnumValues())
                    this.Add(구분, Double.NaN);
            }

            public static String Address(위치주소 주소)
            {
                AddressAttribute a = Utils.GetAttribute<AddressAttribute>(주소);
                return a != null ? a.Address : String.Empty;
            }
            public void Init(ActUtlType64 plc) => this.PLC = plc;

            public Boolean 좌측위치쓰기(Double r, Double x, Double y)
            {
                this[위치주소.좌측위치R] = r;
                this[위치주소.좌측위치X] = x;
                this[위치주소.좌측위치Y] = y;
                List<Int32> data = new List<Int32>();
                data.AddRange(장치통신.ToWords(Convert.ToInt32(r * Factor)));
                data.AddRange(장치통신.ToWords(Convert.ToInt32(x * Factor)));
                data.AddRange(장치통신.ToWords(Convert.ToInt32(y * Factor)));
                return 장치통신.WriteBlocks(PLC, Address(위치주소.좌측위치R), data.ToArray(), out Int32 오류);
            }

            public Boolean 우측위치쓰기(Double r, Double x, Double y)
            {
                this[위치주소.우측위치R] = r;
                this[위치주소.우측위치X] = x;
                this[위치주소.우측위치Y] = y;
                List<Int32> data = new List<Int32>();
                data.AddRange(장치통신.ToWords(Convert.ToInt32(r * Factor)));
                data.AddRange(장치통신.ToWords(Convert.ToInt32(x * Factor)));
                data.AddRange(장치통신.ToWords(Convert.ToInt32(y * Factor)));
                return 장치통신.WriteBlocks(PLC, Address(위치주소.우측위치R), data.ToArray(), out Int32 오류);
            }

            public Boolean 좌측원점읽기()
            {
                Int32[] 원점 = 장치통신.ReadBlocks(PLC, Address(위치주소.좌측원점R), 6, out Int32 오류);
                if (오류 != 0) return false;
                this[위치주소.좌측원점R] = (Double)장치통신.FromWords(new Int32[] { 원점[0], 원점[1] }) / Factor;
                this[위치주소.좌측원점X] = (Double)장치통신.FromWords(new Int32[] { 원점[2], 원점[3] }) / Factor;
                this[위치주소.좌측원점Y] = (Double)장치통신.FromWords(new Int32[] { 원점[4], 원점[5] }) / Factor;
                return true;
            }

            public Boolean 우측원점읽기()
            {
                Int32[] 원점 = 장치통신.ReadBlocks(PLC, Address(위치주소.우측원점R), 6, out Int32 오류);
                if (오류 != 0) return false;
                this[위치주소.우측원점R] = (Double)장치통신.FromWords(new Int32[] { 원점[0], 원점[1] }) / Factor;
                this[위치주소.우측원점X] = (Double)장치통신.FromWords(new Int32[] { 원점[2], 원점[3] }) / Factor;
                this[위치주소.우측원점Y] = (Double)장치통신.FromWords(new Int32[] { 원점[4], 원점[5] }) / Factor;
                return true;
            }

            public Double Get(위치주소 구분)
            {
                if (!this.ContainsKey(구분)) return Double.NaN;
                return this[구분];
            }
        }
        #endregion
    }
}