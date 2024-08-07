using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using DevExpress.Utils.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
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
            this.보정R = 보정.R;
            this.보정X = 보정.X;
            this.보정Y = 보정.Y;
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

        public 보정정보 Calculate()
        {
            카메라구분 카메라 = 시트 == 시트구분.좌측 ? 카메라구분.SheetL : 카메라구분.SheetR;
            비전도구 비전 = Global.비전검사[카메라];
            CogToolBlock AlignTools = 비전.GetTool("AlignTools") as CogToolBlock;
            Differance dif = new Differance();
            dif.BX = Param(DB.편차X);
            dif.BY = Param(DB.편차Y);
            dif.CX = Param(DC.편차X);
            dif.CY = Param(DC.편차Y);
            dif.LX = Param(SL.편차X);
            dif.LY = Param(SL.편차Y);
            dif.RX = Param(SR.편차X);
            dif.RY = Param(SR.편차Y);

            // 테스트
            if (Global.환경설정.동작구분 == 동작구분.LocalTest)
            {
                //dif.BX += -10;
                //dif.CX += -10;
                //dif.BY += -10;
                //dif.CY += -10;
            }

            String json = JsonConvert.SerializeObject(dif);
            CogToolBlock Calculator = 비전.GetTool("Calculator") as CogToolBlock;
            비전검사.Input(Calculator, "Differance", json);
            Debug.WriteLine(JsonConvert.SerializeObject(dif, Formatting.Indented));
            CogToolBlock Verification = 비전.GetTool("Verification") as CogToolBlock;
            비전검사.Input(Verification, "Differance", json);

            Double r = 0;
            Double x = 0;
            Double y = 0;
            Boolean s = false;
            try
            {
                비전.ToolBlock.Run();
                s = 비전.ToolBlock.RunStatus.Result == CogToolResultConstants.Accept;
                if (s)
                {
                    r = Common.ToDegree(비전.Output<Double>("R"));
                    x = 비전.Output<Double>("X");
                    y = 비전.Output<Double>("Y");
                }
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message, "위치 계산 오류");
            }

            return new 보정정보() { State = s, R = Value(r), X = Value(x), Y = Value(y) };
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
