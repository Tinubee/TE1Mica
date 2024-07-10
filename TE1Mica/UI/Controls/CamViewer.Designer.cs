
namespace TE1.UI.Controls
{
    partial class CamViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamViewer));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.b카메라명 = new DevExpress.XtraBars.BarStaticItem();
            this.b스냅 = new DevExpress.XtraBars.BarButtonItem();
            this.b영상 = new DevExpress.XtraBars.BarCheckItem();
            this.b조명 = new DevExpress.XtraBars.BarCheckItem();
            this.b비전 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.e뷰어 = new Cogutils.RecordDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e뷰어)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.b카메라명,
            this.b스냅,
            this.b조명,
            this.b영상,
            this.b비전});
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = ((DevExpress.XtraBars.BarCanDockStyle)((DevExpress.XtraBars.BarCanDockStyle.Top | DevExpress.XtraBars.BarCanDockStyle.Bottom)));
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.b카메라명),
            new DevExpress.XtraBars.LinkPersistInfo(this.b스냅),
            new DevExpress.XtraBars.LinkPersistInfo(this.b영상),
            new DevExpress.XtraBars.LinkPersistInfo(this.b조명),
            new DevExpress.XtraBars.LinkPersistInfo(this.b비전, true)});
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // b카메라명
            // 
            this.b카메라명.Caption = "Camera";
            this.b카메라명.Id = 0;
            this.b카메라명.Name = "b카메라명";
            // 
            // b스냅
            // 
            this.b스냅.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.b스냅.Caption = "Snapshot";
            this.b스냅.Hint = "Snapshot";
            this.b스냅.Id = 1;
            this.b스냅.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b스냅.ImageOptions.SvgImage")));
            this.b스냅.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.b스냅.Name = "b스냅";
            // 
            // b영상
            // 
            this.b영상.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.b영상.Caption = "Video";
            this.b영상.Hint = "Video";
            this.b영상.Id = 3;
            this.b영상.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b영상.ImageOptions.SvgImage")));
            this.b영상.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.b영상.Name = "b영상";
            // 
            // b조명
            // 
            this.b조명.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.b조명.Caption = "Lights";
            this.b조명.Hint = "Lights";
            this.b조명.Id = 2;
            this.b조명.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b조명.ImageOptions.SvgImage")));
            this.b조명.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.b조명.Name = "b조명";
            // 
            // b비전
            // 
            this.b비전.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.b비전.Caption = "Settings";
            this.b비전.Hint = "Inspection Settings";
            this.b비전.Id = 4;
            this.b비전.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b비전.ImageOptions.SvgImage")));
            this.b비전.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.b비전.Name = "b비전";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(400, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 400);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(400, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 364);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(400, 36);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 364);
            // 
            // e뷰어
            // 
            this.e뷰어.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.e뷰어.ColorMapLowerRoiLimit = 0D;
            this.e뷰어.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.e뷰어.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.e뷰어.ColorMapUpperRoiLimit = 1D;
            this.e뷰어.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e뷰어.DoubleTapZoomCycleLength = 2;
            this.e뷰어.DoubleTapZoomSensitivity = 2.5D;
            this.e뷰어.Location = new System.Drawing.Point(0, 36);
            this.e뷰어.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.e뷰어.MouseWheelSensitivity = 1D;
            this.e뷰어.Name = "e뷰어";
            this.e뷰어.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("e뷰어.OcxState")));
            this.e뷰어.Size = new System.Drawing.Size(400, 364);
            this.e뷰어.TabIndex = 9;
            // 
            // CamViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.e뷰어);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CamViewer";
            this.Size = new System.Drawing.Size(400, 400);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e뷰어)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem b카메라명;
        private DevExpress.XtraBars.BarButtonItem b스냅;
        private DevExpress.XtraBars.BarCheckItem b조명;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarCheckItem b영상;
        private Cogutils.RecordDisplay e뷰어;
        private DevExpress.XtraBars.BarButtonItem b비전;
    }
}
