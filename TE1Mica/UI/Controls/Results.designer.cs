
namespace TE1.UI.Controls
{
    partial class Results
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Results));
            this.GridControl1 = new MvUtils.CustomGrid();
            this.Bind검사자료 = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new MvUtils.CustomView();
            this.col일시 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col모델 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col시트 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col원점R = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col원점X = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col원점Y = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col보정R = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col보정X = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col보정Y = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col상태 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BindLocalization = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.e종료일자 = new DevExpress.XtraEditors.DateEdit();
            this.b엑셀파일 = new DevExpress.XtraEditors.SimpleButton();
            this.b자료조회 = new DevExpress.XtraEditors.SimpleButton();
            this.e시작일자 = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind검사자료)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e종료일자.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e종료일자.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작일자.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작일자.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.Bind검사자료;
            this.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl1.Location = new System.Drawing.Point(0, 40);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.MenuManager = this.barManager1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.Size = new System.Drawing.Size(1213, 693);
            this.GridControl1.TabIndex = 4;
            this.GridControl1.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // Bind검사자료
            // 
            this.Bind검사자료.DataSource = typeof(TE1.Schemas.검사자료);
            // 
            // GridView1
            // 
            this.GridView1.AllowColumnMenu = true;
            this.GridView1.AllowCustomMenu = true;
            this.GridView1.AllowExport = true;
            this.GridView1.AllowPrint = true;
            this.GridView1.AllowSettingsMenu = false;
            this.GridView1.AllowSummaryMenu = true;
            this.GridView1.ApplyFocusedRow = true;
            this.GridView1.Caption = "";
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col일시,
            this.col모델,
            this.col시트,
            this.col원점R,
            this.col원점X,
            this.col원점Y,
            this.col보정R,
            this.col보정X,
            this.col보정Y,
            this.col상태});
            this.GridView1.FooterPanelHeight = 21;
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.GroupRowHeight = 21;
            this.GridView1.IndicatorWidth = 44;
            this.GridView1.MinColumnRowHeight = 24;
            this.GridView1.MinRowHeight = 16;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.Editable = false;
            this.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.GridView1.OptionsCustomization.AllowColumnMoving = false;
            this.GridView1.OptionsCustomization.AllowGroup = false;
            this.GridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.GridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.GridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.GridView1.OptionsMenu.EnableFooterMenu = false;
            this.GridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.GridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.GridView1.OptionsPrint.AutoWidth = false;
            this.GridView1.OptionsPrint.UsePrintStyles = false;
            this.GridView1.OptionsSelection.MultiSelect = true;
            this.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            this.GridView1.OptionsView.ShowAutoFilterRow = true;
            this.GridView1.OptionsView.ShowGroupPanel = false;
            this.GridView1.RowHeight = 20;
            // 
            // col일시
            // 
            this.col일시.AppearanceHeader.Options.UseTextOptions = true;
            this.col일시.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col일시.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.col일시.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col일시.FieldName = "일시";
            this.col일시.Name = "col일시";
            this.col일시.Visible = true;
            this.col일시.VisibleIndex = 0;
            // 
            // col모델
            // 
            this.col모델.AppearanceHeader.Options.UseTextOptions = true;
            this.col모델.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col모델.FieldName = "모델";
            this.col모델.Name = "col모델";
            this.col모델.Visible = true;
            this.col모델.VisibleIndex = 1;
            // 
            // col시트
            // 
            this.col시트.AppearanceHeader.Options.UseTextOptions = true;
            this.col시트.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col시트.FieldName = "시트";
            this.col시트.Name = "col시트";
            this.col시트.Visible = true;
            this.col시트.VisibleIndex = 2;
            // 
            // col원점R
            // 
            this.col원점R.AppearanceHeader.Options.UseTextOptions = true;
            this.col원점R.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col원점R.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col원점R.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col원점R.FieldName = "원점R";
            this.col원점R.Name = "col원점R";
            this.col원점R.Visible = true;
            this.col원점R.VisibleIndex = 3;
            // 
            // col원점X
            // 
            this.col원점X.AppearanceHeader.Options.UseTextOptions = true;
            this.col원점X.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col원점X.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col원점X.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col원점X.FieldName = "원점X";
            this.col원점X.Name = "col원점X";
            this.col원점X.Visible = true;
            this.col원점X.VisibleIndex = 4;
            // 
            // col원점Y
            // 
            this.col원점Y.AppearanceHeader.Options.UseTextOptions = true;
            this.col원점Y.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col원점Y.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col원점Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col원점Y.FieldName = "원점Y";
            this.col원점Y.Name = "col원점Y";
            this.col원점Y.Visible = true;
            this.col원점Y.VisibleIndex = 5;
            // 
            // col보정R
            // 
            this.col보정R.AppearanceHeader.Options.UseTextOptions = true;
            this.col보정R.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col보정R.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col보정R.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col보정R.FieldName = "보정R";
            this.col보정R.Name = "col보정R";
            this.col보정R.Visible = true;
            this.col보정R.VisibleIndex = 6;
            // 
            // col보정X
            // 
            this.col보정X.AppearanceHeader.Options.UseTextOptions = true;
            this.col보정X.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col보정X.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col보정X.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col보정X.FieldName = "보정X";
            this.col보정X.Name = "col보정X";
            this.col보정X.Visible = true;
            this.col보정X.VisibleIndex = 7;
            // 
            // col보정Y
            // 
            this.col보정Y.AppearanceHeader.Options.UseTextOptions = true;
            this.col보정Y.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col보정Y.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col보정Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col보정Y.FieldName = "보정Y";
            this.col보정Y.Name = "col보정Y";
            this.col보정Y.Visible = true;
            this.col보정Y.VisibleIndex = 8;
            // 
            // col상태
            // 
            this.col상태.AppearanceHeader.Options.UseTextOptions = true;
            this.col상태.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col상태.FieldName = "상태";
            this.col상태.Name = "col상태";
            this.col상태.Visible = true;
            this.col상태.VisibleIndex = 9;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1213, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 733);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1213, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 733);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1213, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 733);
            // 
            // BindLocalization
            // 
            this.BindLocalization.DataSource = typeof(TE1.UI.Controls.Results.LocalizationResults);
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.e종료일자);
            this.layoutControl1.Controls.Add(this.b엑셀파일);
            this.layoutControl1.Controls.Add(this.b자료조회);
            this.layoutControl1.Controls.Add(this.e시작일자);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1213, 40);
            this.layoutControl1.TabIndex = 14;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // e종료일자
            // 
            this.e종료일자.EditValue = new System.DateTime(2023, 12, 20, 19, 0, 0, 0);
            this.e종료일자.EnterMoveNextControl = true;
            this.e종료일자.Location = new System.Drawing.Point(246, 9);
            this.e종료일자.Name = "e종료일자";
            this.e종료일자.Properties.Appearance.Options.UseTextOptions = true;
            this.e종료일자.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e종료일자.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e종료일자.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e종료일자.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.e종료일자.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.e종료일자.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.e종료일자.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.e종료일자.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm:ss");
            this.e종료일자.Size = new System.Drawing.Size(155, 22);
            this.e종료일자.StyleController = this.layoutControl1;
            this.e종료일자.TabIndex = 20;
            // 
            // b엑셀파일
            // 
            this.b엑셀파일.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "엑셀버튼", true));
            this.b엑셀파일.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b엑셀파일.ImageOptions.SvgImage")));
            this.b엑셀파일.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.b엑셀파일.Location = new System.Drawing.Point(612, 9);
            this.b엑셀파일.Name = "b엑셀파일";
            this.b엑셀파일.Size = new System.Drawing.Size(174, 22);
            this.b엑셀파일.StyleController = this.layoutControl1;
            this.b엑셀파일.TabIndex = 6;
            this.b엑셀파일.Text = "Export to Excel";
            // 
            // b자료조회
            // 
            this.b자료조회.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "조회버튼", true));
            this.b자료조회.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b자료조회.ImageOptions.SvgImage")));
            this.b자료조회.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.b자료조회.Location = new System.Drawing.Point(409, 9);
            this.b자료조회.Name = "b자료조회";
            this.b자료조회.Size = new System.Drawing.Size(112, 22);
            this.b자료조회.StyleController = this.layoutControl1;
            this.b자료조회.TabIndex = 5;
            this.b자료조회.Text = "Search";
            // 
            // e시작일자
            // 
            this.e시작일자.EditValue = new System.DateTime(2023, 12, 20, 7, 0, 0, 0);
            this.e시작일자.EnterMoveNextControl = true;
            this.e시작일자.Location = new System.Drawing.Point(46, 9);
            this.e시작일자.Name = "e시작일자";
            this.e시작일자.Properties.Appearance.Options.UseTextOptions = true;
            this.e시작일자.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e시작일자.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e시작일자.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e시작일자.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.e시작일자.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.e시작일자.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.e시작일자.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.e시작일자.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm:ss");
            this.e시작일자.Size = new System.Drawing.Size(155, 22);
            this.e시작일자.StyleController = this.layoutControl1;
            this.e시작일자.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.Root.Size = new System.Drawing.Size(1213, 40);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.e시작일자;
            this.layoutControlItem1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "시작일자", true));
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(200, 30);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(200, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem1.Size = new System.Drawing.Size(200, 30);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Start";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(25, 15);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(785, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(418, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.b자료조회;
            this.layoutControlItem3.Location = new System.Drawing.Point(400, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(120, 30);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(120, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem3.Size = new System.Drawing.Size(120, 30);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.b엑셀파일;
            this.layoutControlItem2.Location = new System.Drawing.Point(603, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(182, 30);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(182, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem2.Size = new System.Drawing.Size(182, 30);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(520, 0);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(83, 0);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(83, 10);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(83, 30);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.e종료일자;
            this.layoutControlItem5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "종료일자", true));
            this.layoutControlItem5.Location = new System.Drawing.Point(200, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(200, 30);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(200, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem5.Size = new System.Drawing.Size(200, 30);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "End";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(25, 15);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Results";
            this.Size = new System.Drawing.Size(1213, 733);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind검사자료)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e종료일자.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e종료일자.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작일자.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작일자.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private MvUtils.CustomGrid GridControl1;
        private MvUtils.CustomView GridView1;
        private System.Windows.Forms.BindingSource Bind검사자료;
        private System.Windows.Forms.BindingSource BindLocalization;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit e종료일자;
        private DevExpress.XtraEditors.SimpleButton b엑셀파일;
        private DevExpress.XtraEditors.SimpleButton b자료조회;
        private DevExpress.XtraEditors.DateEdit e시작일자;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn col일시;
        private DevExpress.XtraGrid.Columns.GridColumn col모델;
        private DevExpress.XtraGrid.Columns.GridColumn col시트;
        private DevExpress.XtraGrid.Columns.GridColumn col원점R;
        private DevExpress.XtraGrid.Columns.GridColumn col원점X;
        private DevExpress.XtraGrid.Columns.GridColumn col원점Y;
        private DevExpress.XtraGrid.Columns.GridColumn col보정R;
        private DevExpress.XtraGrid.Columns.GridColumn col보정X;
        private DevExpress.XtraGrid.Columns.GridColumn col보정Y;
        private DevExpress.XtraGrid.Columns.GridColumn col상태;
    }
}
