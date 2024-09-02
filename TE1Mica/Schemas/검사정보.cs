using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Ribbon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Numerics;
using static TE1.Schemas.측정자료;

namespace TE1.Schemas
{
    public enum 카메라구분
    {
        [ListBindable(false)]    None  = 0,
        [Description("Left C")]  Cam01 = 1,
        [Description("Left L")]  Cam02 = 2,
        [Description("Left B")]  Cam03 = 3,
        [Description("Left R")]  Cam04 = 4,
        [Description("Right C")] Cam05 = 5,
        [Description("Right L")] Cam06 = 6,
        [Description("Right B")] Cam07 = 7,
        [Description("Right R")] Cam08 = 8,

        [Description("Sheet L"), ListBindable(false)] SheetL = 21,
        [Description("Sheet R"), ListBindable(false)] SheetR = 22,
    }

    public enum 시트구분
    {
        [Description("MICA Sheet Left")]  좌측,
        [Description("MICA Sheet Right")] 우측,
    }

    [Table("inspd")]
    public class 검사정보
    {
        [Column("idwdt"), JsonProperty("idwdt"), Required, Key, Translation("Time", "일시")]
        public DateTime 일시 { get; set; } = DateTime.Now;
        [Column("idmod"), JsonProperty("idmod"), Translation("Model", "모델")]
        public 모델구분 모델 { get; set; } = 모델구분.None;
        [Column("idset"), JsonProperty("idset"), Translation("Sheet", "시트")]
        public 시트구분 시트 { get; set; } = 시트구분.좌측;
        [Column("idres"), JsonProperty("idres"), Translation("Result", "결과")]
        public Boolean 결과 { get; set; } = false;

        [Column("idogr"), JsonProperty("idogr"), Translation("θ", "θ")]
        public Double 원점R { get; set; } = 0;
        [Column("idogx"), JsonProperty("idogx"), Translation("X", "X")]
        public Double 원점X { get; set; } = 0;
        [Column("idogy"), JsonProperty("idogy"), Translation("Y", "Y")]
        public Double 원점Y { get; set; } = 0;

        [Column("idptr"), JsonProperty("idptr"), Translation("θ`", "θ`")]
        public Double 보정R { get; set; } = 0;
        [Column("idptx"), JsonProperty("idptx"), Translation("X`", "X`")]
        public Double 보정X { get; set; } = 0;
        [Column("idpty"), JsonProperty("idpty"), Translation("Y`", "Y`")]
        public Double 보정Y { get; set; } = 0;


        [JsonIgnore]
        public List<카메라구분> 그랩완료_카메라2_4 = new List<카메라구분>();
        [JsonIgnore]
        public List<카메라구분> 그랩완료_카메라6_8 = new List<카메라구분>();
        [JsonIgnore]
        public List<카메라구분> 그랩완료_카메라1_3 = new List<카메라구분>();
        [JsonIgnore]
        public List<카메라구분> 그랩완료_카메라5_7 = new List<카메라구분>();

        [NotMapped, JsonIgnore]
        public 측정자료 검사내역 = null;




        public static 검사정보 신규검사(시트구분 시트)
        {
            검사정보 검사 = new 검사정보() { 일시 = DateTime.Now, 모델 = Global.환경설정.선택모델, 시트 = 시트 };
            검사.검사내역 = new 측정자료(검사.모델, 검사.시트);
            return 검사;
        }

        public void SetResults(비전도구 도구) => 검사내역.Set(도구);

        public Boolean 결과계산()
        {
            if (Global.환경설정.동작구분 == 동작구분.Live)
            {
                if (this.검사내역.Count < 4) return false;
                Global.장치통신.원점정보갱신(new 시트구분[] { 시트 });
                if (시트 == 시트구분.좌측)
                {
                    this.원점R = Global.장치통신.좌측원점R;
                    this.원점X = Global.장치통신.좌측원점X;
                    this.원점Y = Global.장치통신.좌측원점Y;
                }
                else if (시트 == 시트구분.우측)
                {
                    this.원점R = Global.장치통신.우측원점R;
                    this.원점X = Global.장치통신.우측원점X;
                    this.원점Y = Global.장치통신.우측원점Y;
                }
            }
            else
            {
                //this.원점R = Math.Round(Global.Random.NextDouble(), 3);
                //this.원점X = Math.Round(Global.Random.NextDouble(), 3);
                //this.원점Y = Math.Round(Global.Random.NextDouble(), 3);
            }

            this.결과 = 검사내역.Result;
            if (!this.결과) return false;

            //MvUtils.Utils.DebugSerializeObject(검사내역);
            보정정보 보정 = 검사내역.Calculate();
            MvUtils.Utils.DebugSerializeObject(보정);
            if (!보정.Acceptable) return false;
            //this.보정r = 보정.r;
            //this.보정x = 보정.x;
            //this.보정y = 보정.y;

            this.보정R = 보정.R;
            this.보정X = 보정.X;
            this.보정Y = 보정.Y;

            //this.보정R = 0;
            //this.보정X = 0;
            //this.보정Y = 0;

            Debug.WriteLine($"x: {보정.X}, y: {보정.Y}, r: {보정.R}", "*********보정값*******");
            int a  = 0;

            Debug.WriteLine("a");
            //Global.장치통신.SetDevice("W6", (int)보정.R, out a);
            //Global.장치통신.SetDevice("W8", (int)보정.X, out a);
            //Global.장치통신.SetDevice("Wa", (int)보정.Y, out a);
            Debug.WriteLine("b");
            return true;
        }
    }

    public class 측정정보
    {
        public 카메라구분 카메라 = 카메라구분.None;
        [JsonIgnore]
        public 그랩장치 장치 => Global.그랩제어.GetItem(카메라);
        public Boolean 결과 = false;
        public Double 원점X = 0;
        public Double 원점Y = 0;
        public Double 위치X = 0;
        public Double 위치Y = 0;
        public Double 편차X => (위치X - 원점X) * CalibX;
        public Double 편차Y => (위치Y - 원점Y) * CalibY;
        [JsonIgnore]
        public Double CalibX => 장치 == null ? 0 : 장치.교정X / 1000;
        [JsonIgnore]
        public Double CalibY => 장치 == null ? 0 : 장치.교정Y / 1000;

        public void Init(카메라구분 카메라) => this.카메라 = 카메라;
        public void Set(비전도구 도구)
        {
            if (도구 == null || this.카메라 != 도구.카메라) return;
            결과 = 도구.IsAccepted();
            if (!결과) return;
            var values = 도구.GetResults();
            원점X = 도구.OriginX;
            원점Y = 도구.OriginY;
            위치X = values.ContainsKey("X") ? (Double)values["X"] : 0;
            위치Y = values.ContainsKey("Y") ? (Double)values["Y"] : 0;

            Debug.WriteLine($"{위치X} , {위치Y}",this.카메라.ToString());
        }
    }

    public class 측정자료 : Dictionary<카메라구분, 측정정보>
    {
        public readonly 모델구분 모델;
        public readonly 시트구분 시트;
        public 측정정보 DB = new 측정정보();
        public 측정정보 DC = new 측정정보();
        public 측정정보 SL = new 측정정보();
        public 측정정보 SR = new 측정정보();
        public Boolean Result => DB.결과 && DC.결과 && SL.결과 && SR.결과;

        //[JsonIgnore]
        //public ModelInfo Size => ModelInfo.Get(모델);

        public 측정자료(모델구분 모델, 시트구분 시트)
        {
            this.모델 = 모델;
            this.시트 = 시트;
            if (시트 == 시트구분.좌측)
            {
                this.Add(카메라구분.Cam03, DB);
                this.Add(카메라구분.Cam01, DC);
                this.Add(카메라구분.Cam02, SL);
                this.Add(카메라구분.Cam04, SR);
            }
            else if (시트 == 시트구분.우측)
            {
                this.Add(카메라구분.Cam07, DB);
                this.Add(카메라구분.Cam05, DC);
                this.Add(카메라구분.Cam06, SL);
                this.Add(카메라구분.Cam08, SR);
            }
            this.ForEach(e => e.Value.Init(e.Key));
        }
        public Boolean Set(비전도구 도구)
        {
            if (!this.ContainsKey(도구.카메라)) return false;
            this[도구.카메라].Set(도구);
            return this[도구.카메라].결과;
        }

        //public 보정정보 Calculate()
        //{
        //    Debug.WriteLine("aaa");
        //    카메라구분 카메라 = 시트 == 시트구분.좌측 ? 카메라구분.SheetL : 카메라구분.SheetR;
        //    비전도구 비전 = Global.비전검사[카메라];
        //    CogToolBlock AlignTools = 비전.GetTool("AlignTools") as CogToolBlock;
        //    Differance dif = new Differance();
        //    dif.BX = Param(DB.편차X);
        //    dif.BY = Param(DB.편차Y);
        //    dif.CX = Param(DC.편차X);
        //    dif.CY = Param(DC.편차Y);
        //    dif.LX = Param(SL.편차X);
        //    dif.LY = Param(SL.편차Y);
        //    dif.RX = Param(SR.편차X);
        //    dif.RY = Param(SR.편차Y);

        //    // 테스트
        //    if (Global.환경설정.동작구분 == 동작구분.LocalTest)
        //    {
        //        //dif.BX += -10;
        //        //dif.CX += -10;
        //        //dif.BY += -10;
        //        //dif.CY += -10;
        //    }

        //    String json = JsonConvert.SerializeObject(dif);
        //    CogToolBlock Calculator = 비전.GetTool("Calculator") as CogToolBlock;
        //    비전검사.Input(Calculator, "Differance", json);
        //    Debug.WriteLine(JsonConvert.SerializeObject(dif, Formatting.Indented));
        //    CogToolBlock Verification = 비전.GetTool("Verification") as CogToolBlock;
        //    비전검사.Input(Verification, "Differance", json);
        //    Debug.WriteLine("bbb");
        //    Double r = 0;
        //    Double x = 0;
        //    Double y = 0;
        //    Boolean s = false;
        //    try
        //    {
        //        비전.ToolBlock.Run();
        //        s = 비전.ToolBlock.RunStatus.Result == CogToolResultConstants.Accept;
        //        if (s)
        //        {
        //            r = Common.ToDegree(비전.Output<Double>("R"));
        //            x = 비전.Output<Double>("X");
        //            y = 비전.Output<Double>("Y");
        //        }
        //    }
        //    catch (Exception ex) 
        //    {
        //        Debug.WriteLine(ex.Message, "위치 계산 오류");
        //    }

        //    return new 보정정보() { State = s, R = Value(r), X = Value(x), Y = Value(y) };
        //}
        static Tuple<double, double> RotatePoint(double x, double y, double centerX, double centerY, double angleDegrees)
        {
            // 각도 변환: 도 -> 라디안
            double angleRadians = angleDegrees * (Math.PI / 180.0);

            // 회전 변환
            double rotatedX = centerX + Math.Cos(angleRadians) * (x - centerX) - Math.Sin(angleRadians) * (y - centerY);
            double rotatedY = centerY + Math.Sin(angleRadians) * (x - centerX) + Math.Cos(angleRadians) * (y - centerY);

            // 회전된 좌표 반환
            return Tuple.Create(rotatedX, rotatedY);
        }

        static Tuple<double, double> CheckLineFomula(double x1, double y1, double x2, double y2)
        {
            // 직선의 방정식 계산
            double slope = (y2 - y1) / (x2 - x1);
            double intercept = y1 - slope * x1;

            // 수평선 y=0에서의 각도 계산
            double angleRad = Math.Atan(slope);  // 라디안 단위에서의 각도
            double angleDeg = angleRad * (180 / Math.PI);  // 도 단위로 변환

            // 중간 확인 출력
            Debug.WriteLine($"y = {slope}x + {intercept}");

            Debug.WriteLine($"y=0과의 각도: {Math.Round(angleDeg, 3)}도");

            // 첫번째는 라디안 두번째는 디그리!
            return Tuple.Create(angleRad, angleDeg);
        }



        static Tuple<double, double, double> Alignment(카메라구분 카메라, double x1, double y1, double x2, double y2, double targetX, double targetY, double targetR)
        {
            Tuple<double, double> LineForm = CheckLineFomula(x1, y1, x2, y2);
            double angleDeg = LineForm.Item2;
            double centerX1 = 0;
            double centerY1 = 0;
            double centerX2 = 0;
            double centerY2 = 0;


            //이동해야할 각도 계산
            double diffR = targetR - angleDeg;

            if (카메라 == 카메라구분.SheetL)
            {
                //카메라 2번에서 서보 모터 회전 축 연산데이터
                centerX1 = -1181.06;
                centerY1 = 845.25;

                //카메라 4번에서 서보 모터 회전 축 연산데이터
                centerX2 = -2786.89;
                centerY2 = -2145.51;
            }
            else if(카메라 == 카메라구분.SheetR)
            {
                //카메라 6번에서 서보 모터 회전 축 연산데이터
                centerX1 = -1020.53;
                centerY1 = 638.67;

                //카메라 8번에서 서보 모터 회전 축 연산데이터
                centerX2 = -1571.83;
                centerY2 = -1833.98;
            }
            
            //이동해야할 각도 기준으로 새로운 포인트 생성
            //Tuple<double, double> NewLeftPoint  = RotatePoint(x1, y1, centerX1, centerY1, -angleDeg);
            //Tuple<double, double> NewRightPoint = RotatePoint(x2, y2, centerX2, centerY2, -angleDeg);

            //이동해야할 각도 기준으로 새로운 포인트 생성
            Tuple<double, double> NewLeftPoint = RotatePoint(x1, y1, centerX1, centerY1, diffR);
            Tuple<double, double> NewRightPoint = RotatePoint(x2, y2, centerX2, centerY2, diffR);

            double newX1 = NewLeftPoint.Item1;
            double newY1 = NewLeftPoint.Item2;
            double newX2 = NewRightPoint.Item1;
            double newY2 = NewRightPoint.Item2;

            Debug.WriteLine($"{newX1}, {newY1}",   "왼쪽 회전 뒤 좌표");
            Debug.WriteLine($"{newX2}, {newY2}", "오른쪽 회전 뒤 좌표");

            // 두 좌표의 중심 좌표
            double NewCenterX = Math.Round((newX1 + newX2) / 2, 3);
            double NewCenterY = Math.Round((newY1 + newY2) / 2, 3);
            Debug.WriteLine($"{NewCenterX},{NewCenterY}", "중심좌표");


            Tuple<double,double> newLineForm = CheckLineFomula(newX1, newY1, newX2, newY2);


            //이동해야할 X,Y 생성
            double diffX = targetX - NewCenterX;
            double diffY = targetY - NewCenterY;
            
            
            Debug.WriteLine($"x: {targetX - NewCenterX}, y: {targetY - NewCenterY}, r: {targetR-angleDeg}", "보정해야할 수치!!!");


            return Tuple.Create(diffX, diffY, diffR);
        }
        public 보정정보 Calculate()
        {
            try
            {
                Debug.WriteLine("aaa");
                카메라구분 카메라 = 시트 == 시트구분.좌측 ? 카메라구분.SheetL : 카메라구분.SheetR;
                //비전도구 비전 = Global.비전검사[카메라];
                //CogToolBlock AlignTools = 비전.GetTool("AlignTools") as CogToolBlock;
                Differance dif = new Differance();
                dif.BX = Param(0);
                dif.BY = Param(0);
                dif.CX = Param(0);
                dif.CY = Param(0);
                dif.LX = Param(SL.위치X);
                dif.LY = Param(SL.위치Y);
                dif.RX = Param(SR.위치X);
                dif.RY = Param(SR.위치Y);

                String json = JsonConvert.SerializeObject(dif);
                //CogToolBlock Calculator = 비전.GetTool("Calculator") as CogToolBlock;
                //비전검사.Input(Calculator, "Differance", json);
                Debug.WriteLine(JsonConvert.SerializeObject(dif, Formatting.Indented));
                //CogToolBlock Verification = 비전.GetTool("Verification") as CogToolBlock;
                //비전검사.Input(Verification, "Differance", json);
                Debug.WriteLine("bbb");

                Double r = 0;
                Double x = 0;
                Double y = 0;
                Boolean s = false;

                double targetX = 0;
                double targetY = 0;
                double targetR = 0;


                //if (카메라 == 카메라구분.SheetL)
                //{
                //    targetX = -3050.851;
                //    targetX = -146807.376;
                //    targetR = 0.4211;
                //}
                //if (카메라 == 카메라구분.SheetL)
                //{
                //    targetX = -3050.851;
                //    targetY = -146807.376;
                //    targetR = 0.4211;
                //}
                //                else
                //{
                //    targetX = -4878.635;
                //    targetY = -148220.935;
                //    targetR = 0.642;
                //}
                if (카메라 == 카메라구분.SheetL)
                {
                    targetX = -1808;
                    targetY = -147003;
                    targetR = 0.454;
                }
                else
                {
                    targetX = -2687;
                    targetY = -148197;
                    targetR = 0.645 ;
                }

                Tuple<double, double, double> diff = Alignment(카메라, dif.LX, dif.LY, dif.RX, dif.RY, targetX, targetY, targetR);
                double diffX = diff.Item1;
                double diffY = diff.Item2;
                double diffR = diff.Item3;

                //R은 서보의 양의 방향이 시계방향인지 시계 반시계 방향인지를 기준으로 진행. 프로그램의 경우 반시계 방향이 양이고 PLC가 시계방향이 양이므로 -를 추가해줌.
                return new 보정정보() { State = true, R = Value(-diffR), X = Value(Math.Round(diffX/1000,3)), Y = Value(Math.Round(diffY/1000,3)) };
            }
            catch
            {
                
                return new 보정정보() { State = false, R = Value(0), X = Value(0), Y = Value(0) };
            }
        }

        public static Double Value(Double v) => Math.Round(v, 4);
        public static Double Param(Double v) => Math.Round(v, 6);

        public class 보정정보
        {
            public Boolean State = false;
            public Double R = 0;
            public Double X = 0;
            public Double Y = 0;
            public Boolean Acceptable => State && Math.Abs(X) <= 10 && Math.Abs(Y) <= 10 && Math.Abs(R) < 3;
        }

        private class Differance
        {
            public Double BX = 0;
            public Double BY = 0;
            public Double CX = 0;
            public Double CY = 0;
            public Double LX = 0;
            public Double LY = 0;
            public Double RX = 0;
            public Double RY = 0;
        }
    }
}
