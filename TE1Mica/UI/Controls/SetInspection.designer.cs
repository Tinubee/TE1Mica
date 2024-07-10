
namespace TE1.UI.Controls
{
    partial class SetInspection
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetInspection));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.GridControl1 = new MvUtils.CustomGrid();
            this.검사설정Bind = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new MvUtils.CustomView();
            this.col시트 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ｅ교정 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.e분류 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Bind검사분류 = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.b도구설정 = new DevExpress.XtraEditors.LookUpEdit();
            this.e모델선택 = new DevExpress.XtraEditors.LookUpEdit();
            this.모델자료Bind = new System.Windows.Forms.BindingSource(this.components);
            this.b설정저장 = new DevExpress.XtraEditors.SimpleButton();
            this.col원점R = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col원점X = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col원점Y = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col보정R = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col보정X = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col보정Y = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.검사설정Bind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ｅ교정)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e분류)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind검사분류)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.b도구설정.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e모델선택.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.모델자료Bind)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.검사설정Bind;
            this.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl1.Location = new System.Drawing.Point(0, 52);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ｅ교정,
            this.e분류});
            this.GridControl1.Size = new System.Drawing.Size(1244, 729);
            this.GridControl1.TabIndex = 0;
            this.GridControl1.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
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
            this.col시트,
            this.col원점R,
            this.col원점X,
            this.col원점Y,
            this.col보정R,
            this.col보정X,
            this.col보정Y});
            this.GridView1.FooterPanelHeight = 21;
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.GroupRowHeight = 21;
            this.GridView1.IndicatorWidth = 44;
            this.GridView1.MinColumnRowHeight = 24;
            this.GridView1.MinRowHeight = 16;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.GridView1.OptionsCustomization.AllowColumnMoving = false;
            this.GridView1.OptionsCustomization.AllowGroup = false;
            this.GridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.GridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.GridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.GridView1.OptionsPrint.AutoWidth = false;
            this.GridView1.OptionsPrint.UsePrintStyles = false;
            this.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            this.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.GridView1.OptionsView.ShowGroupPanel = false;
            this.GridView1.RowHeight = 20;
            // 
            // col시트
            // 
            this.col시트.AppearanceHeader.Options.UseTextOptions = true;
            this.col시트.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col시트.FieldName = "시트";
            this.col시트.Name = "col시트";
            this.col시트.Visible = true;
            this.col시트.VisibleIndex = 0;
            // 
            // ｅ교정
            // 
            this.ｅ교정.AutoHeight = false;
            this.ｅ교정.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ｅ교정.Name = "ｅ교정";
            // 
            // e분류
            // 
            this.e분류.AutoHeight = false;
            this.e분류.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e분류.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("명칭", "Category")});
            this.e분류.DataSource = this.Bind검사분류;
            this.e분류.DisplayMember = "명칭";
            this.e분류.Name = "e분류";
            this.e분류.NullText = "[Category]";
            this.e분류.ShowHeader = false;
            this.e분류.ValueMember = "코드";
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
            this.barDockControlTop.Size = new System.Drawing.Size(1244, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 781);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1244, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 781);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1244, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 781);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.b도구설정);
            this.panelControl1.Controls.Add(this.e모델선택);
            this.panelControl1.Controls.Add(this.b설정저장);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(3);
            this.panelControl1.Size = new System.Drawing.Size(1244, 52);
            this.panelControl1.TabIndex = 5;
            // 
            // b도구설정
            // 
            this.b도구설정.Dock = System.Windows.Forms.DockStyle.Left;
            this.b도구설정.EnterMoveNextControl = true;
            this.b도구설정.Location = new System.Drawing.Point(305, 5);
            this.b도구설정.MenuManager = this.barManager1;
            this.b도구설정.Name = "b도구설정";
            this.b도구설정.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.b도구설정.Properties.Appearance.Options.UseFont = true;
            this.b도구설정.Properties.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
            this.b도구설정.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "도구설정", "도구설정", null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.b도구설정.Properties.NullText = "[카메라 선택]";
            this.b도구설정.Size = new System.Drawing.Size(300, 42);
            this.b도구설정.TabIndex = 10;
            // 
            // e모델선택
            // 
            this.e모델선택.Dock = System.Windows.Forms.DockStyle.Left;
            this.e모델선택.EnterMoveNextControl = true;
            this.e모델선택.Location = new System.Drawing.Point(5, 5);
            this.e모델선택.Name = "e모델선택";
            this.e모델선택.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e모델선택.Properties.Appearance.Options.UseFont = true;
            this.e모델선택.Properties.Appearance.Options.UseTextOptions = true;
            this.e모델선택.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e모델선택.Properties.AppearanceDropDown.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e모델선택.Properties.AppearanceDropDown.Options.UseFont = true;
            this.e모델선택.Properties.AutoHeight = false;
            this.e모델선택.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e모델선택.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("모델구분", "구분", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("모델설명", "설명", 240, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.e모델선택.Properties.DataSource = this.모델자료Bind;
            this.e모델선택.Properties.DisplayMember = "모델구분";
            this.e모델선택.Properties.NullText = "[모델선택]";
            this.e모델선택.Properties.ValueMember = "모델구분";
            this.e모델선택.Size = new System.Drawing.Size(300, 42);
            this.e모델선택.TabIndex = 9;
            this.e모델선택.Visible = false;
            // 
            // b설정저장
            // 
            this.b설정저장.Appearance.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.b설정저장.Appearance.Options.UseFont = true;
            this.b설정저장.Dock = System.Windows.Forms.DockStyle.Right;
            this.b설정저장.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b설정저장.ImageOptions.SvgImage")));
            this.b설정저장.Location = new System.Drawing.Point(1059, 5);
            this.b설정저장.Name = "b설정저장";
            this.b설정저장.Size = new System.Drawing.Size(180, 42);
            this.b설정저장.TabIndex = 0;
            this.b설정저장.Text = "설정저장";
            // 
            // col원점R
            // 
            this.col원점R.AppearanceHeader.Options.UseTextOptions = true;
            this.col원점R.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col원점R.FieldName = "원점R";
            this.col원점R.Name = "col원점R";
            this.col원점R.Visible = true;
            this.col원점R.VisibleIndex = 1;
            // 
            // col원점X
            // 
            this.col원점X.AppearanceHeader.Options.UseTextOptions = true;
            this.col원점X.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col원점X.FieldName = "원점X";
            this.col원점X.Name = "col원점X";
            this.col원점X.Visible = true;
            this.col원점X.VisibleIndex = 2;
            // 
            // col원점Y
            // 
            this.col원점Y.AppearanceHeader.Options.UseTextOptions = true;
            this.col원점Y.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col원점Y.FieldName = "원점Y";
            this.col원점Y.Name = "col원점Y";
            this.col원점Y.Visible = true;
            this.col원점Y.VisibleIndex = 3;
            // 
            // col보정R
            // 
            this.col보정R.AppearanceHeader.Options.UseTextOptions = true;
            this.col보정R.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col보정R.FieldName = "보정R";
            this.col보정R.Name = "col보정R";
            this.col보정R.Visible = true;
            this.col보정R.VisibleIndex = 4;
            // 
            // col보정X
            // 
            this.col보정X.AppearanceHeader.Options.UseTextOptions = true;
            this.col보정X.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col보정X.FieldName = "보정X";
            this.col보정X.Name = "col보정X";
            this.col보정X.Visible = true;
            this.col보정X.VisibleIndex = 5;
            // 
            // col보정Y
            // 
            this.col보정Y.AppearanceHeader.Options.UseTextOptions = true;
            this.col보정Y.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col보정Y.FieldName = "보정Y";
            this.col보정Y.Name = "col보정Y";
            this.col보정Y.Visible = true;
            this.col보정Y.VisibleIndex = 6;
            // 
            // SetInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SetInspection";
            this.Size = new System.Drawing.Size(1244, 781);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.검사설정Bind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ｅ교정)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e분류)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind검사분류)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.b도구설정.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e모델선택.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.모델자료Bind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MvUtils.CustomGrid GridControl1;
        private System.Windows.Forms.BindingSource 검사설정Bind;
        private MvUtils.CustomView GridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton b설정저장;
        private System.Windows.Forms.BindingSource 모델자료Bind;
        private DevExpress.XtraEditors.LookUpEdit e모델선택;
        private DevExpress.XtraEditors.LookUpEdit b도구설정;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ｅ교정;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit e분류;
        private System.Windows.Forms.BindingSource Bind검사분류;
        private DevExpress.XtraGrid.Columns.GridColumn col시트;
        private DevExpress.XtraGrid.Columns.GridColumn col원점R;
        private DevExpress.XtraGrid.Columns.GridColumn col원점X;
        private DevExpress.XtraGrid.Columns.GridColumn col원점Y;
        private DevExpress.XtraGrid.Columns.GridColumn col보정R;
        private DevExpress.XtraGrid.Columns.GridColumn col보정X;
        private DevExpress.XtraGrid.Columns.GridColumn col보정Y;
    }
}
