using DevExpress.Office.Crypto;
using HelixToolkit.Wpf;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace TE1.Schemas
{
    public class UPR3P24S : Viewport
    {
        #region 초기화
        public override String StlPath => Global.환경설정.기본경로;
        public override String StlFile => Path.Combine(StlPath, "UPR3P24S.stl");
        public override Double Scale => 1;
        //private String SubFile => Path.Combine(StlPath, "VDA590TPA.C.stl");
        internal override void LoadStl()
        {
            Debug.WriteLine(StlFile);
            if (!File.Exists(StlFile)) return;
            Point3D p = Center3D();
            Transform3DGroup transform = new Transform3DGroup();
            transform.Children.Add(new TranslateTransform3D(p.X * Scale, p.Y * Scale, -4 * Scale));
            transform.Children.Add(new ScaleTransform3D(Scale, Scale, Scale));

            StLReader reader = new StLReader();
            Model3DGroup groups = reader.Read(StlFile);
            MainModel = groups.Children[0] as GeometryModel3D;
            MainModel.Transform = transform;
            MainModel.SetName(nameof(MainModel));
            MainModel.Material = FrontMaterial;
            MainModel.BackMaterial = BackMaterial;
            ModelGroup.Children.Add(MainModel);

            //GeometryModel3D sub = LoadSubStl(transform);
            //if (sub != null) ModelGroup.Children.Add(sub);
        }
        //private GeometryModel3D LoadSubStl(Transform3DGroup transform)
        //{
        //    if (!File.Exists(SubFile)) return null;
        //    StLReader reader = new StLReader();
        //    Model3DGroup groups = reader.Read(SubFile);
        //    GeometryModel3D model = groups.Children[0] as GeometryModel3D;
        //    model.Transform = transform;
        //    model.SetName("Cover");
        //    model.Material = BlackMaterial;
        //    model.BackMaterial = BlackMaterial;
        //    return model;
        //}
        #endregion

        #region 기본 설정
        private List<Base3D> InspItems = new List<Base3D>();
        private List<GeometryModel3D> SurfaceItems = new List<GeometryModel3D>();
        private Material SurfaceMaterial = MaterialHelper.CreateMaterial(Colors.Red, 0.5);
        internal String InspectionName(검사항목 항목)
        {
            검사정보 정보 = Global.모델자료.선택모델.검사설정.GetItem(항목);
            if (정보 == null) return String.Empty;
            return 정보.검사명칭;
        }
        internal override void InitModel()
        {
            if (MainModel == null) return;
            //Children.Add(new GridLinesVisual3D
            //{
            //    MajorDistance = 10, // 주 그리드 간격
            //    MinorDistance = 5,  // 보조 그리드 간격
            //    Thickness = 1, // Scale,    // 그리드 두께
            //    Center = new Point3D(0, 0, 0),
            //    Material = GridMaterial,
            //});

            Rect3D r = MainModel.Bounds;
            Debug.WriteLine($"{r.SizeY}, {r.SizeX}, {r.SizeZ}", "Rectangle3D"); // 217, 562.16
            Double hx = r.SizeX / 2;
            Double hy = r.SizeY / 2;
            //Double tz = 0.5;

            //AddText3D(new Point3D(-hx - 60, 0, 0), "L", 48, MajorColors.FrameColor);
            //AddText3D(new Point3D(+hx + 60, 0, 0), "R", 48, MajorColors.FrameColor);
            //AddArrowLine(new Point3D(-hx, 0, tz), new Point3D(hx, 0, tz), MajorColors.FrameColor); // Front ~ Rear Center
            //AddArrowLine(new Point3D(0, -hy, tz), new Point3D(0, hy, tz), MajorColors.FrameColor); // Width Center

            //InspItems.Add(new Width3D(검사항목.DistC1) { Point = new Point3D(-200.00,  -62.0, tz + 0.2), PointS = new Point3D(-200, -hy, tz), PointE = new Point3D(-200, hy, tz), Name = "C1C5", LabelS = "C1", LabelE = "C5", LabelMargin = 6, LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Width3D(검사항목.DistC2) { Point = new Point3D( -70.00,  -62.0, tz + 0.2), PointS = new Point3D( -70, -hy, tz), PointE = new Point3D( -70, hy, tz), Name = "C2C6", LabelS = "C2", LabelE = "C6", LabelMargin = 6, LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Width3D(검사항목.DistC3) { Point = new Point3D( +70.00,  -62.0, tz + 0.2), PointS = new Point3D( +70, -hy, tz), PointE = new Point3D( +70, hy, tz), Name = "C3C7", LabelS = "C3", LabelE = "C7", LabelMargin = 6, LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Width3D(검사항목.DistC4) { Point = new Point3D(+200.00,  -62.0, tz + 0.2), PointS = new Point3D(+200, -hy, tz), PointE = new Point3D(+200, hy, tz), Name = "C4C8", LabelS = "C4", LabelE = "C8", LabelMargin = 6, LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.Disth1) { Point = new Point3D(-278.68,  +45.0, tz), Origin = new Point3D(-278.68 - 10,  +45.0, tz), Name = "h1", LabelStyle = NamePrintType.Left });
            //InspItems.Add(new Label3D(검사항목.Disth2) { Point = new Point3D(-278.68,  -45.0, tz), Origin = new Point3D(-278.68 - 10,  -45.0, tz), Name = "h2", LabelStyle = NamePrintType.Left });
            //InspItems.Add(new Label3D(검사항목.Disth3) { Point = new Point3D(+278.68,  +45.0, tz), Origin = new Point3D(+278.68 + 10,  +45.0, tz), Name = "h3", LabelStyle = NamePrintType.Right });
            //InspItems.Add(new Label3D(검사항목.Disth4) { Point = new Point3D(+278.68,  -45.0, tz), Origin = new Point3D(+278.68 + 10,  -45.0, tz), Name = "h4", LabelStyle = NamePrintType.Right });

            //InspItems.Add(new Label3D(검사항목.THKfa)  { Point = new Point3D(-264.00, +112.5, tz), Origin = new Point3D(-264.00, +112.5 + 20, tz), Name = "fa",  LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKf01) { Point = new Point3D(-228.50, +112.5, tz), Origin = new Point3D(-228.50, +112.5 + 20, tz), Name = "f01", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKf02) { Point = new Point3D(-183.75, +112.5, tz), Origin = new Point3D(-183.75, +112.5 + 20, tz), Name = "f02", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKf03) { Point = new Point3D( -93.75, +112.5, tz), Origin = new Point3D( -93.75, +112.5 + 20, tz), Name = "f03", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKf04) { Point = new Point3D( -46.15, +112.5, tz), Origin = new Point3D( -46.15, +112.5 + 20, tz), Name = "f04", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKf05) { Point = new Point3D( +46.15, +112.5, tz), Origin = new Point3D( +46.15, +112.5 + 20, tz), Name = "f05", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKf06) { Point = new Point3D( +93.75, +112.5, tz), Origin = new Point3D( +93.75, +112.5 + 20, tz), Name = "f06", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKf07) { Point = new Point3D(+183.75, +112.5, tz), Origin = new Point3D(+183.75, +112.5 + 20, tz), Name = "f07", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKf08) { Point = new Point3D(+228.50, +112.5, tz), Origin = new Point3D(+228.50, +112.5 + 20, tz), Name = "f08", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKfb)  { Point = new Point3D(+264.00, +112.5, tz), Origin = new Point3D(+264.00, +112.5 + 20, tz), Name = "fb",  LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Label3D(검사항목.THKfc)  { Point = new Point3D(-264.00, -112.5, tz), Origin = new Point3D(-264.00, -112.5 - 20, tz), Name = "fc",  LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Label3D(검사항목.THKf09) { Point = new Point3D(-228.50, -112.5, tz), Origin = new Point3D(-228.50, -112.5 - 20, tz), Name = "f09", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Label3D(검사항목.THKf10) { Point = new Point3D(-183.75, -112.5, tz), Origin = new Point3D(-183.75, -112.5 - 20, tz), Name = "f10", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Label3D(검사항목.THKf11) { Point = new Point3D( -93.75, -112.5, tz), Origin = new Point3D( -93.75, -112.5 - 20, tz), Name = "f11", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Label3D(검사항목.THKf12) { Point = new Point3D( -46.15, -112.5, tz), Origin = new Point3D( -46.15, -112.5 - 20, tz), Name = "f12", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Label3D(검사항목.THKf13) { Point = new Point3D( +46.15, -112.5, tz), Origin = new Point3D( +46.15, -112.5 - 20, tz), Name = "f13", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Label3D(검사항목.THKf14) { Point = new Point3D( +93.75, -112.5, tz), Origin = new Point3D( +93.75, -112.5 - 20, tz), Name = "f14", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Label3D(검사항목.THKf15) { Point = new Point3D(+183.75, -112.5, tz), Origin = new Point3D(+183.75, -112.5 - 20, tz), Name = "f15", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Label3D(검사항목.THKf16) { Point = new Point3D(+228.50, -112.5, tz), Origin = new Point3D(+228.50, -112.5 - 20, tz), Name = "f16", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Label3D(검사항목.THKfd)  { Point = new Point3D(+264.00, -112.5, tz), Origin = new Point3D(+264.00, -112.5 - 20, tz), Name = "fd",  LabelStyle = NamePrintType.Down });

            //InspItems.Add(new Circle3D(검사항목.Flata1) { Point = new Point3D(-200, +105, tz), Name = "a1", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Circle3D(검사항목.Flata2) { Point = new Point3D(-200,    0, tz), Name = "a2", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.Flata3) { Point = new Point3D(-200, -105, tz), Name = "a3", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.Flata4) { Point = new Point3D(   0,  +90, tz), Name = "a4", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Circle3D(검사항목.Flata5) { Point = new Point3D(   0,  -90, tz), Name = "a5", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.Flata6) { Point = new Point3D(+230, +105, tz), Name = "a6", LabelStyle = NamePrintType.Down });
            //InspItems.Add(new Circle3D(검사항목.Flata7) { Point = new Point3D(+230,    0, tz), Name = "a7", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.Flata8) { Point = new Point3D(+230, -105, tz), Name = "a8", LabelStyle = NamePrintType.Up });

            //InspItems.Add(new Circle3D(검사항목.Flatm1) { Point = new Point3D( -40,   0, tz + 6), Name = "m1", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.Flatm2) { Point = new Point3D( +60,   0, tz + 6), Name = "m2", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.Flatm3) { Point = new Point3D(+125,   0, tz + 6), Name = "m3", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.GapsG1) { Point = new Point3D( -92, +25, tz + 6), Name = "G1", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.GapsG2) { Point = new Point3D( -92, -25, tz + 6), Name = "G2", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.GapsG3) { Point = new Point3D(+190, +25, tz + 6), Name = "G3", LabelStyle = NamePrintType.Up });
            //InspItems.Add(new Circle3D(검사항목.GapsG4) { Point = new Point3D(+190, -25, tz + 6), Name = "G4", LabelStyle = NamePrintType.Up });

            //InspItems.Add(new Rectangle3D(검사항목.QrLegibility) { Point = new Point3D(-261.26, -19.75, tz), Width = 35, Height = 19, Name = "QR", FontHeight = 18, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center,
            //    Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), -90), -261.26, -19.75, tz)
            //});
            //InspItems.Add(new Rectangle3D(검사항목.Imprinted)    { Point = new Point3D(-263.00, +19.00, tz), Width = 36, Height = 14, Name = "NORMAL", FontHeight = 10, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center, 
            //    Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), -90), -263.00, +19.00, tz)
            //});
            //InspItems.Add(new Rectangle3D(검사항목.Plus)  { Point = new Point3D(-263, +45, tz), Width = 14, Height = 14, Name = "╋", FontHeight = 14, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });
            //InspItems.Add(new Rectangle3D(검사항목.Minus) { Point = new Point3D(-263, -45, tz), Width = 14, Height = 14, Name = "│", FontHeight = 14, Value = Decimal.MinValue, LabelStyle = NamePrintType.Center });

            //InspItems.Add(new Label3D(검사항목.Profile1) { Name = InspectionName(검사항목.Profile1), Point = new Point3D(-100, 96, tz) });
            //InspItems.Add(new Label3D(검사항목.Profile2) { Name = InspectionName(검사항목.Profile2), Point = new Point3D(-100, 84, tz) });
            //InspItems.Add(new Label3D(검사항목.Profile3) { Name = InspectionName(검사항목.Profile3), Point = new Point3D(-100, 72, tz) });
            //InspItems.Add(new Label3D(검사항목.Profile4) { Name = InspectionName(검사항목.Profile4), Point = new Point3D(-100, 60, tz) });
            InspItems.ForEach(e => e.Create(Children));
        }
        #endregion

        public virtual Color GetColor(결과구분 결과) => 결과 == 결과구분.OK ? MajorColors.GoodColor : MajorColors.BadColor;
        public void SetResults(검사결과 결과)
        {
            foreach(Base3D 항목 in InspItems)
            {
                검사정보 정보 = 결과.GetItem(항목.Type);
                if (정보 == null)
                {
                    항목.Draw(Decimal.MinValue, 결과구분.PS);
                    continue;
                }
                try
                {

                }
                catch (Exception ex) { Debug.WriteLine(ex.Message); }
            }
            foreach(var item in SurfaceItems)
                Remove(item);
        }
        // 점들을 중심을 기준으로 시계 방향으로 회전하는 함수
        private Point2f RotateClockwise(Point2f point, Double radian)
        {
            Single x = (Single)(point.X * Math.Cos(radian) - point.Y * Math.Sin(radian));
            Single y = (Single)(point.X * Math.Sin(radian) + point.Y * Math.Cos(radian));
            return new Point2f(x, y);
        }

        private class 변환정보
        {
            public Vector3D 위치 { get; set; }
            public Double 각도 { get; set; }
            public Single 비율Y { get; set; }
            public Single 비율X { get; set; }

            public static 변환정보 Get(카메라구분 카메라)
            {
                //if (카메라 == 카메라구분.Bottom) return new 변환정보() { 위치 = new Vector3D(1, -1, 7.8), 각도 = -Math.PI / 2, 비율X = 0.074155330f, 비율Y = 0.074995964f };
                return new 변환정보() { 위치 = new Vector3D(1, -1, 7.8), 각도 = -Math.PI / 2, 비율X = 0.074155330f, 비율Y = 0.074995964f };
            }
        }
    }
}
