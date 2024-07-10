﻿using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using MvLibs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TE1
{
    public class BaseTool
    {
        public BaseTool(CogToolBlock tool)
        {
            ToolBlock = tool;
            InitOutputs();
        }

        public static System.Drawing.Font LabelFont = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold);
        public CogToolBlock ToolBlock;
        public virtual Cameras Camera => Cameras.None;
        public virtual String ViewerRecodName => "AlignTools.Fixture.OutputImage";
        public virtual String Results { get => Input<String>("Results"); set => Input("Results", value); }
        public ICogImage InputImage => Input<ICogImage>("InputImage");
        public ICogTool GetTool(String name) => Base.GetTool(ToolBlock, name);
        public T Input<T>(String name) => Base.Input<T>(ToolBlock, name);
        public Boolean Input(String name, Object value) => Base.Input(ToolBlock, name, value);
        public T Output<T>(String name) => Base.Output<T>(ToolBlock, name);
        public Boolean Output(String name, Object value) => Base.Output(ToolBlock, name, value);

        // Outputs 초기화
        public virtual void InitOutputs() => Base.InitOutputs(ToolBlock);
        // GroupRun 이 수행되기 이전에 실행 할 내역
        public virtual void StartedRun()
        {
            Results = String.Empty;
            InitOutputs();
        }
        // CogToolBlock 내의 Tool 이 하나 씩 수행 되기 전 실행 할 내역
        public virtual void BeforeToolRun(ICogTool tool) { }
        // CogToolBlock 내의 Tool 이 하나 씩 수행 된 수 실행 할 내역
        public virtual void AfterToolRun(ICogTool tool, CogToolResultConstants result) { }
        // CogToolBlock 의 Tools 모두가 수행 된 후 수행 할 내역
        public virtual void FinistedRun() { }

        public virtual void ModifyLastRunRecord(ICogRecord lastRecord) { }
        public virtual void DebugRecords(ICogRecord record, Int32 depth = 0, String preKey = "")
        {
            if (record == null) return;
            if (String.IsNullOrEmpty(preKey)) preKey = record.RecordKey;
            else preKey = $"{preKey}.{record.RecordKey}";
            if (record.SubRecords.Count < 1)
            {
                Debug.WriteLine($"[{record.Annotation}] [{record.RecordUsage}] [{record.ContentType.ToString()}]", preKey);
                //if (record.ContentType == typeof(ICogGraphicInteractive))
                //{
                //    ICogGraphicInteractive g = record.Content as ICogGraphicInteractive;
                //    Debug.WriteLine($"\t{g.TipText}: {String.Join(", ", g.StateFlags.Names)}");
                //}
            }
            else
            {
                foreach (ICogRecord r in record.SubRecords)
                    DebugRecords(r, depth, preKey);
                depth++;
            }
        }
    }

    public class DisplayResult
    {
        public String KeyName = String.Empty;
        public String Display = String.Empty;
        public CogColorConstants Color = CogColorConstants.Green;
        public List<Double> Rect = new List<Double>();
    }

    public enum Models : Int32 { None = 0, UPR3P24S, UPR2P36S }
    public enum Sheets : Int32 { Left = 0, Right = 1 }
    public enum Cameras : Int32 { None = 0, Cam01, Cam02, Cam03, Cam04, Cam05, Cam06, Cam07, Cam08, SheetL, SheetR }
}
