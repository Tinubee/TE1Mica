using Cognex.VisionPro;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using MvUtils;
using System;
using System.Diagnostics;
using TE1.Schemas;

namespace TE1.UI.Controls
{
    public partial class CamViewer : XtraUserControl
    {
        public CamViewer()
        {
            InitializeComponent();
        }

        public enum ViewType { Inspect, Viewer }

        private const String 로그영역 = "Cam Viewer";
        private 카메라구분 카메라 = 카메라구분.None;
        private Boolean 수동제어 => !Global.장치상태.자동수동 && Global.환경설정.사용권한 == 유저권한구분.시스템;

        public void Init(카메라구분 카메라, ViewType type)
        {
            this.카메라 = 카메라;
            this.b카메라명.Caption = Global.그랩제어.GetItem(카메라).설명;// Utils.GetDescription(this.카메라);
            this.e뷰어.Init(false);
            if (type == ViewType.Inspect)
                Global.비전검사.SetDisplay(this.카메라, this.e뷰어);

            if (type != ViewType.Inspect || Global.환경설정.사용권한 != 유저권한구분.시스템)
            {
                this.b스냅.Visibility = BarItemVisibility.Never;
                this.b영상.Visibility = BarItemVisibility.Never;
                this.b조명.Visibility = BarItemVisibility.Never;
                this.b비전.Visibility = BarItemVisibility.Never;
                return;
            }

            this.b스냅.ItemClick += 스냅촬영;
            this.b영상.CheckedChanged += 연속촬영;
            this.b조명.CheckedChanged += 조명제어;
            this.b비전.ItemClick += 비전설정;
            동작상태알림();
            Global.그랩제어.그랩완료보고 += 그랩완료보고;
            Global.장치통신.동작상태알림 += 동작상태알림;
            this.연속촬영(b영상, null);
            this.조명제어(b조명, null);
        }

        private void 동작상태알림()
        {
            if (Global.장치상태.자동수동) return;
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(동작상태알림));
                return;
            }
            this.b스냅.Enabled = 수동제어;
            this.b영상.Enabled = 수동제어;
            this.b조명.Enabled = 수동제어;
            this.b비전.Enabled = 수동제어;
        }

        private Stopwatch 연속촬영시간 = new Stopwatch();
        private void 그랩완료보고(그랩장치 장치)
        {
            if (Global.장치상태.자동수동 || 장치.구분 != 카메라) return;
            if (!장치.연속촬영여부)
            {
                Global.비전검사.Run(카메라, 장치.CogImage(), Global.검사자료.현재검사찾기(장치.구분));
                return;
            }

            this.e뷰어.Image = 장치.CogImage();
            this.AddCrosLine();
            if (this.연속촬영시간.ElapsedMilliseconds > 3000)
            {
                GC.Collect();
                this.연속촬영시간.Restart();
            }
        }

        private void AddCrosLine()
        {
            if (e뷰어.Image == null) return;
            if(this.e뷰어.StaticGraphics.ZOrderGroups.Count < 1)
            {
                this.e뷰어.InteractiveGraphics.Clear();
                this.e뷰어.StaticGraphics.Clear();


                if (Global.그랩제어[카메라].회전 == 회전구분.FlipAndRotate90Deg || Global.그랩제어[카메라].회전 == 회전구분.FlipAndRotate270Deg || Global.그랩제어[카메라].회전 == 회전구분.Rotate90Deg || Global.그랩제어[카메라].회전 == 회전구분.Rotate270Deg)
                {
                    this.e뷰어.StaticGraphics.Add(new CogLine() { X = e뷰어.Image.Height / 2, Y = e뷰어.Image.Width / 2, Rotation = 0 }, "Lines");
                    this.e뷰어.StaticGraphics.Add(new CogLine() { X = e뷰어.Image.Height / 2, Y = e뷰어.Image.Width / 2, Rotation = Math.PI / 2 }, "Lines");
                    return;
                }
                this.e뷰어.StaticGraphics.Add(new CogLine() { X = e뷰어.Image.Width / 2, Y = e뷰어.Image.Height / 2, Rotation = 0 }, "Lines");
                this.e뷰어.StaticGraphics.Add(new CogLine() { X = e뷰어.Image.Width / 2, Y = e뷰어.Image.Height / 2, Rotation = Math.PI / 2 }, "Lines");
            }
        }

        private void 스냅촬영(object sender, ItemClickEventArgs e)
        {
            if (Global.장치상태.자동수동) return;
            if (Global.환경설정.동작구분 == 동작구분.Live)
                Global.그랩제어.스냅촬영(카메라);
            else Global.비전검사[카메라].마스터로드();
        }

        private void 연속촬영(object sender, ItemClickEventArgs e)
        {
            if (Global.장치상태.자동수동 || Global.환경설정.동작구분 != 동작구분.Live) return;
            BarCheckItem button = sender as BarCheckItem;
            if (button.Checked)
            {
                this.e뷰어.InteractiveGraphics.Clear();
                this.e뷰어.StaticGraphics.Clear();
                this.연속촬영시간.Restart();
                Global.그랩제어.연속촬영(카메라, true);
            }
            else
            {
                this.연속촬영시간.Stop();
                Global.그랩제어.연속촬영(카메라, false);
                GC.Collect();
            }
            상태색상변경(button);
        }

        private void 조명제어(object sender, ItemClickEventArgs e)
        {
            if (Global.장치상태.자동수동 || Global.환경설정.동작구분 != 동작구분.Live) return;
            BarCheckItem button = sender as BarCheckItem;
            if (button.Checked) Global.조명제어.TurnOn(this.카메라);
            else Global.조명제어.TurnOff(this.카메라);
            상태색상변경(button);
        }

        private void 상태색상변경(BarCheckItem button)
        {
            if (button.Checked) button.ImageOptions.SvgImage = Utils.SetSvgStyle(button.ImageOptions.SvgImage, Utils.SvgStyles.Yellow);
            else button.ImageOptions.SvgImage = Utils.SetSvgStyle(button.ImageOptions.SvgImage, Utils.SvgStyles.White);
        }

        private void 비전설정(object sender, ItemClickEventArgs e)
        {
            //if (Global.장치상태.자동수동) return;
            Global.비전검사.도구설정(카메라);
        }
    }
}
