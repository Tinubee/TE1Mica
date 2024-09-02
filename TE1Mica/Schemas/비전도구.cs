using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.QuickBuild;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.ToolGroup;
using Cogutils;
using MvUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TE1.Schemas
{
    public class 비전도구
    {
        #region 기본설정
        public String 로그영역 = "Vision Tool";
        public 모델구분 모델구분 = 모델구분.UPR3P24S;
        public 카메라구분 카메라 = 카메라구분.None;
        public 사진형식 마스터형식 { get; set; } = 사진형식.Bmp;
        public String 도구명칭 => this.카메라.ToString();
        public String 도구경로 => Path.Combine(Global.환경설정.도구경로, ((Int32)모델구분).ToString("d2"), $"{도구명칭}.vpp");
        public String 마스터경로 => Path.Combine(Global.환경설정.마스터사진, $"{((Int32)모델구분).ToString("d2")}.{도구명칭}.{마스터형식.ToString()}");
        public 그랩장치 그랩장치 => Global.그랩제어.GetItem(카메라);

        public CogJob Job = null;
        public CogToolBlock ToolBlock = null;
        public CogToolBlock AlignTools => this.GetTool("AlignTools") as CogToolBlock;
        public ICogImage InputImage { get => this.Input<ICogImage>("InputImage"); set => this.Input("InputImage", value); }
        public ICogImage OutputImage => 비전검사.Output<ICogImage>(this.AlignTools, "OutputImage");
        public String ViewerRecodName => "AlignTools.OutImage.OutputImage";

        public DateTime 검사시작 = DateTime.Today;
        public DateTime 검사종료 = DateTime.Today;
        public Double 검사시간 => (this.검사종료 - this.검사시작).TotalMilliseconds;
        public RecordDisplay Display = null;
        public RecordsDisplay RecordsDisplay = null;

        public 비전도구(모델구분 모델, 카메라구분 카메라)
        {
            this.모델구분 = 모델;
            this.카메라 = 카메라;
        }

        public void SetDisplay(RecordsDisplay display) => this.RecordsDisplay = display;
        public void RemoveDisplay() => this.RecordsDisplay = null;

        public ICogTool GetTool(String name) => 비전검사.GetTool(ToolBlock, name);
        public T Input<T>(String name) => 비전검사.Input<T>(ToolBlock, name);
        public Boolean Input(String name, Object value) => 비전검사.Input(ToolBlock, name, value);
        public T Output<T>(String name) => 비전검사.Output<T>(ToolBlock, name);
        public Double OriginX => 비전검사.Input<Double>(this.AlignTools, "OriginX");
        public Double OriginY => 비전검사.Input<Double>(this.AlignTools, "OriginY");

        public void Init() => this.Load();
        public void Load()
        {
            Debug.WriteLine(this.도구경로, this.카메라.ToString());
            if (File.Exists(this.도구경로))
            {
                this.Job = CogSerializer.LoadObjectFromFile(this.도구경로) as CogJob;
                this.Job.Name = $"Job{도구명칭}";
                this.ToolBlock = (this.Job.VisionTool as CogToolGroup).Tools[0] as CogToolBlock;
            }
            else
            {
                this.Job = new CogJob($"Job{도구명칭}");
                CogToolGroup group = new CogToolGroup() { Name = $"Group{도구명칭}" };
                this.ToolBlock = new CogToolBlock();
                this.ToolBlock.Name = this.도구명칭;
                group.Tools.Add(this.ToolBlock);
                this.Job.VisionTool = group;
                this.ToolBlock.Tools.Add(new CogToolBlock() { Name = "AlignTools" });
                this.Save();
            }

            if (this.ToolBlock != null) this.ToolBlock.DataBindings.Clear();
            else this.ToolBlock = new CogToolBlock();
            this.ToolBlock.Name = this.도구명칭;

            if (카메라 >= 카메라구분.SheetL)
            {
                Input("InputImage", new CogImage8Grey(new System.Drawing.Bitmap(Path.Combine(Global.환경설정.마스터사진, "Gray.bmp"))));
                return;
            }
            // 파라미터 체크
            비전검사.AddInput(this.ToolBlock, "InputImage", typeof(CogImage8Grey));
            //비전검사.AddInput(this.ToolBlock, "Results", typeof(String));
            비전검사.AddInput(this.AlignTools, "InputImage", typeof(CogImage8Grey));
            비전검사.AddInput(this.AlignTools, "OriginX", (Double)0);
            비전검사.AddInput(this.AlignTools, "OriginY", (Double)0);
            비전검사.AddOutput(this.AlignTools, "OutputImage", typeof(CogImage8Grey));
        }

        public void Save()
        {
            CogSerializer.SaveObjectToFile(this.Job, this.도구경로, typeof(BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            Global.정보로그(this.로그영역, "Save", $"[{Utils.GetDescription(this.카메라)}] It was saved.", true);
        }
        #endregion

        #region 도구설정, 마스터
        public void 도구설정() => 비전검사.도구설정(this);
        public Boolean 마스터저장()
        {
            if (this.InputImage == null) return false;
            Boolean r = false;
            String error = String.Empty;
            if      (this.마스터형식 == 사진형식.Bmp) r = Common.ImageSaveBmp(this.InputImage, this.마스터경로, out error);
            else if (this.마스터형식 == 사진형식.Png) r = Common.ImageSavePng(this.InputImage, this.마스터경로, out error);
            else if (this.마스터형식 == 사진형식.Jpg) r = Common.ImageSaveJpeg(this.InputImage, this.마스터경로, out error);
            else return false;
            if (!r) Utils.WarningMsg("마스터 이미지 등록실패!!!\n" + error);
            return r;
        }
        public Boolean 마스터로드(Boolean autoCalibration = false)
        {
            Boolean result = 이미지로드(this.마스터경로);
            if (result && AlignTools.RunStatus.Result == CogToolResultConstants.Accept)
            {
                Double x = Math.Round(비전검사.Output<Double>(AlignTools, "X"), 3);
                Double y = Math.Round(비전검사.Output<Double>(AlignTools, "Y"), 3);
                Double r = Math.Round(비전검사.Output<Double>(AlignTools, "R"), 3);
                비전검사.Input(AlignTools, "OriginX", x);
                비전검사.Input(AlignTools, "OriginY", y);
                if (카메라 == 카메라구분.Cam01 || 카메라 == 카메라구분.Cam03 || 카메라 == 카메라구분.Cam05 || 카메라 == 카메라구분.Cam07)
                {
                    비전검사.Input(AlignTools, "Radius", r);
                    //Debug.WriteLine($"X={x}, Y={y}, Radius={r}");
                }

                if (autoCalibration)
                {
                    //그랩장치 장치 = Global.그랩제어.GetItem(카메라);
                    //if (장치 != null)
                    //{
                    //    장치.교정X = rX;
                    //    //장치.교정Y = rY;
                    //}
                }
            }
            return result;
        }
        public Boolean 이미지로드() => 이미지로드(Common.GetImageFile());
        public Boolean 이미지로드(String path)
        {
            if (!File.Exists(path)) return false;
            return 이미지검사(Common.LoadImage(path, false));
        }
        public Boolean 이미지검사(ICogImage image)
        {
            //if (image == null) return false;
            //this.Run(image, Global.검사자료.현재검사찾기(카메라));
            //return true;


            if (image == null) return false;
            if (Global.그랩제어[카메라].회전 == 회전구분.None) return true;

            //Global.그랩제어[카메라].RotateImage(image, (CogIPOneImageFlipRotateOperationConstants)Global.그랩제어[카메라].회전);

            this.Run(Global.그랩제어[카메라].RotateImage(image, (CogIPOneImageFlipRotateOperationConstants)Global.그랩제어[카메라].회전), Global.검사자료.현재검사찾기(카메라));
            return true;
        }
        public Boolean 다시검사()
        {
            this.Run(null, Global.검사자료.현재검사찾기(카메라));
            return true;
        }
        #endregion

        #region Run
        public Boolean IsAccepted()
        {
            return this.AlignTools.RunStatus.Result == CogToolResultConstants.Accept;
            //foreach (ICogTool tool in this.AlignTools.Tools)
            //    if (tool.RunStatus.Result != CogToolResultConstants.Accept) return false;
            //foreach (ICogTool tool in this.ToolBlock.Tools)
            //    if (tool.RunStatus.Result != CogToolResultConstants.Accept) return false;
            //return true;
        }

        public Boolean Run(ICogImage image, 검사정보 검사)
        {
            Debug.WriteLine("수동런진입");
            Boolean accepted = false;
            try
            {
                if (image != null) this.InputImage = image;
                if (this.InputImage == null) return false;
                this.검사시작 = DateTime.Now;
                this.ToolBlock.Run();
                accepted = this.IsAccepted();
                검사?.SetResults(this);
                this.검사종료 = DateTime.Now;
                DisplayResult(검사);
                Global.검사자료.검사완료체크(this.카메라, 검사);
                //Global.캘리브?.AddNew(this.ToolBlock, this.카메라);
            }
            catch (Exception ex) { Global.오류로그(로그영역, "Run", $"[{this.카메라.ToString()}] {ex.Message}", true); }
            return accepted;
        }

        public Dictionary<String, Object> GetResults()
        {
            Dictionary<String, Object> results = new Dictionary<String, Object>();
            foreach (CogToolBlockTerminal terminal in this.ToolBlock.Outputs)
            {
                if (terminal.ValueType != typeof(Double)) continue;
                Double value = terminal.Value == null ? Double.NaN : (Double)terminal.Value;
                results.Add(terminal.Name, value);
            }
            return results;
        }

        public void DisplayResult(검사정보 검사)
        {
            try
            {
                ICogRecord records = this.ToolBlock.CreateLastRunRecord();
                ICogRecord record = null;
                if (records != null && records.SubRecords != null && records.SubRecords.ContainsKey(this.ViewerRecodName))
                    record = records.SubRecords[this.ViewerRecodName];

                if (this.OutputImage != null)
                {
                    this.Display?.SetImage(this.OutputImage, record, null);
                    if (!Global.장치상태.자동수동)
                        this.RecordsDisplay?.ViewResultImage(this.OutputImage, records, this.ViewerRecodName);
                }
                else
                {
                    this.Display?.SetImage(this.InputImage, record, null);
                    if (!Global.장치상태.자동수동)
                        this.RecordsDisplay?.ViewResultImage(this.InputImage, records, String.Empty);
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message, "DisplayResult"); }
        }
        #endregion
    }
}