using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.ToolBlock;
using MvLibs;
using Newtonsoft.Json;
using OpenCvSharp;
using System;
using System.Diagnostics;

namespace TE1.SheetL
{
    // 중심 기준
    public static class SheetInfo
    {
        public static Size2d ImageSize = new Size(600, 1200);
        public static Size2d SheetS = new Size2d(388.88, 295.00);
        public static Double OffsetY = -392.50 + SheetS.Height / 2;
        public static Point2d SheetL = new Point2d(-194.44, -SheetS.Height / 2);
        public static Point2d SheetR = new Point2d(+194.44, -SheetS.Height / 2);
        public static Point2d DatumB = new Point2d(+63.00, +487.25 - OffsetY);
        public static Point2d DatumC = new Point2d(+63.00, -486.25 - OffsetY);
        public static Point2d Translation => new Point2d(ImageSize.Width / 2, ImageSize.Height / 2 + OffsetY);
    }

    internal class Differance
    {
        public Double BX = 0;
        public Double BY = 0;
        public Double CX = 0;
        public Double CY = 0;
        public Double LX = 0;
        public Double LY = 0;
        public Double RX = 0;
        public Double RY = 0;

        public void SetPositions()
        {
            BX += SheetInfo.DatumB.X;
            BY += SheetInfo.DatumB.Y;
            CX += SheetInfo.DatumC.X;
            CY += SheetInfo.DatumC.Y;
            LX += SheetInfo.SheetL.X;
            LY += SheetInfo.SheetL.Y;
            RX += SheetInfo.SheetR.X;
            RY += SheetInfo.SheetR.Y;
        }
    }

    public class MainTools : BaseTool
    {
        public MainTools(CogToolBlock tool) : base(tool) { }
        public override Cameras Camera => Cameras.SheetL;
    }

    public class AlignTools : BaseTool
    {
        public AlignTools(CogToolBlock tool) : base(tool) { }
        public override Cameras Camera => Cameras.SheetL;

        public override void StartedRun()
        {
            base.StartedRun();
            SetPositions();
        }

        internal virtual CogFixtureTool Fixture => GetTool("Fixture") as CogFixtureTool;
        internal virtual CogTransform2DLinear Transform => Fixture.RunParams.UnfixturedFromFixturedTransform as CogTransform2DLinear;
        internal virtual CogCreateSegmentTool DatumBC => GetTool("DatumBC") as CogCreateSegmentTool;
        internal virtual CogCreateSegmentTool SheetLR => GetTool("SheetLR") as CogCreateSegmentTool;
        internal virtual CogBlobTool Sheet => GetTool("Sheet") as CogBlobTool;

        internal virtual void SetPositions()
        {
            Transform.TranslationX = SheetInfo.Translation.X;
            Transform.TranslationY = SheetInfo.Translation.Y;
            Transform.Rotation = 0;
            DatumBC.Segment.StartX = SheetInfo.DatumC.X;
            DatumBC.Segment.StartY = SheetInfo.DatumC.Y;
            DatumBC.Segment.EndX = SheetInfo.DatumB.X;
            DatumBC.Segment.EndY = SheetInfo.DatumB.Y;
            SheetLR.Segment.StartX = SheetInfo.SheetL.X;
            SheetLR.Segment.StartY = SheetInfo.SheetL.Y;
            SheetLR.Segment.EndX = SheetInfo.SheetR.X;
            SheetLR.Segment.EndY = SheetInfo.SheetR.Y;
            CogRectangleAffine r = Sheet.Region as CogRectangleAffine;
            r.CenterX = 0;
            r.CenterY = 0;
            r.SideXLength = SheetInfo.SheetS.Width;
            r.SideYLength = SheetInfo.SheetS.Height;
        }
    }

    public class Calculator : BaseTool
    {
        public Calculator(CogToolBlock tool) : base(tool) { }
        public override Cameras Camera => Cameras.SheetL;
        public override void StartedRun()
        {
            base.StartedRun();
            SetPositions();
        }
        public override void AfterToolRun(ICogTool tool, CogToolResultConstants result)
        {
            if (tool == Cross) CalCenter();
            else if (tool == Rotate) SetFixture();
        }
        public override void FinistedRun()
        {
            base.FinistedRun();
            Calculat();
        }

        internal Differance Diff;
        internal virtual String Differance { get => Input<String>("Differance"); set => Input("Differance", value); }
        internal virtual CogFixtureTool Fixture => GetTool("Fixture") as CogFixtureTool;
        internal virtual CogTransform2DLinear Transform => Fixture.RunParams.UnfixturedFromFixturedTransform as CogTransform2DLinear;
        internal virtual CogCreateSegmentTool DatumBC => GetTool("DatumBC") as CogCreateSegmentTool;
        internal virtual CogCreateSegmentTool SheetLR => GetTool("SheetLR") as CogCreateSegmentTool;
        internal virtual CogIntersectLineLineTool Cross => GetTool("Cross") as CogIntersectLineLineTool;
        internal virtual CogCreateLineParallelTool CenterBC => GetTool("CenterBC") as CogCreateLineParallelTool;
        internal virtual CogCreateLinePerpendicularTool CenterLR => GetTool("CenterLR") as CogCreateLinePerpendicularTool;
        internal virtual CogIntersectLineLineTool Center => GetTool("Center") as CogIntersectLineLineTool;
        internal virtual CogCreateSegmentTool Rotate => GetTool("Rotate") as CogCreateSegmentTool;

        internal virtual Differance LoadData()
        {
            String json = Differance;
            if (String.IsNullOrEmpty(json)) return new Differance();
            try { return JsonConvert.DeserializeObject<Differance>(json); }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "Differance");
                return new Differance();
            }
        }

        internal virtual void SetPositions()
        {
            Diff = LoadData();
            Diff.SetPositions();
            DatumBC.Segment.StartX = Diff.CX;
            DatumBC.Segment.StartY = Diff.CY;
            DatumBC.Segment.EndX = Diff.BX;
            DatumBC.Segment.EndY = Diff.BY;
            SheetLR.Segment.StartX = Diff.LX;
            SheetLR.Segment.StartY = Diff.LY;
            SheetLR.Segment.EndX = Diff.RX;
            SheetLR.Segment.EndY = Diff.RY;
        }
        internal virtual void CalCenter()
        {
            CenterBC.X = Cross.X - SheetInfo.DatumB.X;
            CenterBC.Y = Diff.BY - SheetInfo.DatumB.Y;
            CenterLR.X = Cross.X;
            CenterLR.Y = CenterBC.Y;
        }
        internal virtual void SetFixture()
        {
            Transform.TranslationX = Center.X;
            Transform.TranslationY = Center.Y;
            Transform.Rotation = -Rotate.Segment.Rotation;
        }
        internal virtual void Calculat()
        {
            Point2d c = Base.PointTransform(InputImage, Fixture.RunParams.FixturedSpaceName, 0, 0);
            Point2d b = Base.PointTransform(InputImage, Fixture.RunParams.FixturedSpaceName, SheetInfo.DatumB);
            Point2d l = Base.PointTransform(InputImage, Fixture.RunParams.FixturedSpaceName, SheetInfo.SheetL);
            Double r = Transform.Rotation;
            Double x = l.X - SheetInfo.SheetL.X;
            Double y = b.Y - SheetInfo.DatumB.Y;
            //Debug.WriteLine($"R={Transform.Rotation}, X={Transform.RotationX}, Y={Transform.RotationY}");
            Debug.WriteLine($"R={r}, B={b}, L={l}, C={c}");
            Output("R", r);
            Output("X", x);
            Output("Y", y);
            Differance = String.Empty;
        }

        internal static Double Value(Double v) => Math.Round(v, 4);
    }

    public class Verification : BaseTool
    {
        public Verification(CogToolBlock tool) : base(tool) { }
        public override Cameras Camera => Cameras.SheetL;

        public override void StartedRun()
        {
            base.StartedRun();
            SetPositions();
        }

        internal Differance Diff;
        internal virtual String Differance { get => Input<String>("Differance"); set => Input("Differance", value); }
        internal virtual CogFixtureTool Fixture => GetTool("Fixture") as CogFixtureTool;
        internal virtual CogTransform2DLinear Transform => Fixture.RunParams.UnfixturedFromFixturedTransform as CogTransform2DLinear;
        internal virtual CogCreateSegmentTool DatumBC => GetTool("DatumBC") as CogCreateSegmentTool;
        internal virtual CogCreateSegmentTool SheetLR => GetTool("SheetLR") as CogCreateSegmentTool;
        internal virtual CogBlobTool Sheet => GetTool("Sheet") as CogBlobTool;

        internal virtual Differance LoadData()
        {
            String json = Differance;
            if (String.IsNullOrEmpty(json)) return new Differance();
            try { return JsonConvert.DeserializeObject<Differance>(json); }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "Differance");
                return new Differance();
            }
        }
        internal virtual void SetPositions()
        {
            Diff = LoadData();
            Diff.SetPositions();
            Double X = Input<Double>("X");
            Double Y = Input<Double>("Y");
            DatumBC.Segment.StartX = Diff.CX + X;
            DatumBC.Segment.StartY = Diff.CY + Y;
            DatumBC.Segment.EndX = Diff.BX + X;
            DatumBC.Segment.EndY = Diff.BY + Y;
            SheetLR.Segment.StartX = Diff.LX + X;
            SheetLR.Segment.StartY = Diff.LY + Y;
            SheetLR.Segment.EndX = Diff.RX + X;
            SheetLR.Segment.EndY = Diff.RY + Y;
            CogRectangleAffine r = Sheet.Region as CogRectangleAffine;
            r.CenterX = X;
            r.CenterY = Y;
            r.SideXLength = SheetInfo.SheetS.Width;
            r.SideYLength = SheetInfo.SheetS.Height;
            Differance = String.Empty;
        }
    }
}
