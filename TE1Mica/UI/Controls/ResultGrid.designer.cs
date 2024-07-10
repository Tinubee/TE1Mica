namespace TE1.UI.Controls
{
    partial class ResultGrid
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.Bind검사정보 = new System.Windows.Forms.BindingSource(this.components);
            this.GridControl1 = new MvUtils.CustomGrid();
            this.GridView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.col일시 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col일시 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col모델 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col모델 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col시트 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col시트 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col상태 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col상태 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col원점R = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col원점R = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col원점X = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col원점X = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col원점Y = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col원점Y = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col보정R = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col위치R = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col보정X = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col위치X = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col보정Y = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col위치Y = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.Item1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.e분류 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind검사정보)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col일시)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col모델)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col시트)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col상태)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col원점R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col원점X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col원점Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col위치R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col위치X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col위치Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e분류)).BeginInit();
            this.SuspendLayout();
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
            this.barDockControlTop.Size = new System.Drawing.Size(275, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 543);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(275, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 543);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(275, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 543);
            // 
            // Bind검사정보
            // 
            this.Bind검사정보.DataSource = typeof(System.Collections.Generic.List<TE1.Schemas.검사정보>);
            // 
            // GridControl1
            // 
            this.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl1.Location = new System.Drawing.Point(0, 0);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.e분류});
            this.GridControl1.Size = new System.Drawing.Size(275, 543);
            this.GridControl1.TabIndex = 4;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // GridView1
            // 
            this.GridView1.Appearance.FieldCaption.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.GridView1.Appearance.FieldCaption.Options.UseFont = true;
            this.GridView1.Appearance.FieldEditingValue.Font = new System.Drawing.Font("맑은 고딕", 14.25F);
            this.GridView1.Appearance.FieldEditingValue.Options.UseFont = true;
            this.GridView1.Appearance.FieldValue.Font = new System.Drawing.Font("맑은 고딕", 14.25F);
            this.GridView1.Appearance.FieldValue.Options.UseFont = true;
            this.GridView1.CardMinSize = new System.Drawing.Size(263, 400);
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.col일시,
            this.col모델,
            this.col시트,
            this.col상태,
            this.col원점R,
            this.col원점X,
            this.col원점Y,
            this.col보정R,
            this.col보정X,
            this.col보정Y});
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.Editable = false;
            this.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.GridView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.GridView1.OptionsCustomization.AllowSort = false;
            this.GridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.GridView1.OptionsPrint.UsePrintStyles = false;
            this.GridView1.OptionsSingleRecordMode.StretchCardToViewHeight = true;
            this.GridView1.OptionsSingleRecordMode.StretchCardToViewWidth = true;
            this.GridView1.OptionsView.ContentAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.GridView1.OptionsView.ShowCardCaption = false;
            this.GridView1.OptionsView.ShowCardFieldBorders = true;
            this.GridView1.OptionsView.ShowHeaderPanel = false;
            this.GridView1.TemplateCard = this.layoutViewCard1;
            // 
            // col일시
            // 
            this.col일시.AppearanceCell.Options.UseTextOptions = true;
            this.col일시.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col일시.DisplayFormat.FormatString = "{0:yyyy-MM-dd HH:mm:ss}";
            this.col일시.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col일시.FieldName = "일시";
            this.col일시.LayoutViewField = this.layoutViewField_col일시;
            this.col일시.Name = "col일시";
            // 
            // layoutViewField_col일시
            // 
            this.layoutViewField_col일시.EditorPreferredWidth = 204;
            this.layoutViewField_col일시.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_col일시.Name = "layoutViewField_col일시";
            this.layoutViewField_col일시.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col일시.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col일시.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col일시.TextSize = new System.Drawing.Size(34, 15);
            // 
            // col모델
            // 
            this.col모델.AppearanceCell.Options.UseTextOptions = true;
            this.col모델.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col모델.FieldName = "모델";
            this.col모델.LayoutViewField = this.layoutViewField_col모델;
            this.col모델.Name = "col모델";
            // 
            // layoutViewField_col모델
            // 
            this.layoutViewField_col모델.EditorPreferredWidth = 204;
            this.layoutViewField_col모델.Location = new System.Drawing.Point(0, 34);
            this.layoutViewField_col모델.Name = "layoutViewField_col모델";
            this.layoutViewField_col모델.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col모델.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col모델.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col모델.TextSize = new System.Drawing.Size(34, 15);
            // 
            // col시트
            // 
            this.col시트.AppearanceCell.Options.UseTextOptions = true;
            this.col시트.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col시트.FieldName = "시트";
            this.col시트.LayoutViewField = this.layoutViewField_col시트;
            this.col시트.Name = "col시트";
            // 
            // layoutViewField_col시트
            // 
            this.layoutViewField_col시트.EditorPreferredWidth = 204;
            this.layoutViewField_col시트.Location = new System.Drawing.Point(0, 68);
            this.layoutViewField_col시트.Name = "layoutViewField_col시트";
            this.layoutViewField_col시트.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col시트.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col시트.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col시트.TextSize = new System.Drawing.Size(34, 15);
            // 
            // col상태
            // 
            this.col상태.AppearanceCell.Options.UseTextOptions = true;
            this.col상태.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col상태.FieldName = "상태";
            this.col상태.LayoutViewField = this.layoutViewField_col상태;
            this.col상태.Name = "col상태";
            // 
            // layoutViewField_col상태
            // 
            this.layoutViewField_col상태.EditorPreferredWidth = 204;
            this.layoutViewField_col상태.Location = new System.Drawing.Point(0, 102);
            this.layoutViewField_col상태.Name = "layoutViewField_col상태";
            this.layoutViewField_col상태.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col상태.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col상태.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col상태.TextSize = new System.Drawing.Size(34, 15);
            // 
            // col원점R
            // 
            this.col원점R.AppearanceCell.Options.UseTextOptions = true;
            this.col원점R.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col원점R.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col원점R.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col원점R.FieldName = "원점R";
            this.col원점R.LayoutViewField = this.layoutViewField_col원점R;
            this.col원점R.Name = "col원점R";
            // 
            // layoutViewField_col원점R
            // 
            this.layoutViewField_col원점R.EditorPreferredWidth = 204;
            this.layoutViewField_col원점R.Location = new System.Drawing.Point(0, 136);
            this.layoutViewField_col원점R.Name = "layoutViewField_col원점R";
            this.layoutViewField_col원점R.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col원점R.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col원점R.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col원점R.TextSize = new System.Drawing.Size(34, 15);
            // 
            // col원점X
            // 
            this.col원점X.AppearanceCell.Options.UseTextOptions = true;
            this.col원점X.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col원점X.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col원점X.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col원점X.FieldName = "원점X";
            this.col원점X.LayoutViewField = this.layoutViewField_col원점X;
            this.col원점X.Name = "col원점X";
            // 
            // layoutViewField_col원점X
            // 
            this.layoutViewField_col원점X.EditorPreferredWidth = 204;
            this.layoutViewField_col원점X.Location = new System.Drawing.Point(0, 170);
            this.layoutViewField_col원점X.Name = "layoutViewField_col원점X";
            this.layoutViewField_col원점X.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col원점X.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col원점X.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col원점X.TextSize = new System.Drawing.Size(34, 15);
            // 
            // col원점Y
            // 
            this.col원점Y.AppearanceCell.Options.UseTextOptions = true;
            this.col원점Y.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col원점Y.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col원점Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col원점Y.FieldName = "원점Y";
            this.col원점Y.LayoutViewField = this.layoutViewField_col원점Y;
            this.col원점Y.Name = "col원점Y";
            // 
            // layoutViewField_col원점Y
            // 
            this.layoutViewField_col원점Y.EditorPreferredWidth = 204;
            this.layoutViewField_col원점Y.Location = new System.Drawing.Point(0, 204);
            this.layoutViewField_col원점Y.Name = "layoutViewField_col원점Y";
            this.layoutViewField_col원점Y.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col원점Y.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col원점Y.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col원점Y.TextSize = new System.Drawing.Size(34, 15);
            // 
            // col보정R
            // 
            this.col보정R.AppearanceCell.Options.UseTextOptions = true;
            this.col보정R.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col보정R.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col보정R.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col보정R.FieldName = "보정R";
            this.col보정R.LayoutViewField = this.layoutViewField_col위치R;
            this.col보정R.Name = "col보정R";
            // 
            // layoutViewField_col위치R
            // 
            this.layoutViewField_col위치R.EditorPreferredWidth = 204;
            this.layoutViewField_col위치R.Location = new System.Drawing.Point(0, 238);
            this.layoutViewField_col위치R.Name = "layoutViewField_col위치R";
            this.layoutViewField_col위치R.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col위치R.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col위치R.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col위치R.TextSize = new System.Drawing.Size(34, 15);
            // 
            // col보정X
            // 
            this.col보정X.AppearanceCell.Options.UseTextOptions = true;
            this.col보정X.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col보정X.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col보정X.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col보정X.FieldName = "보정X";
            this.col보정X.LayoutViewField = this.layoutViewField_col위치X;
            this.col보정X.Name = "col보정X";
            // 
            // layoutViewField_col위치X
            // 
            this.layoutViewField_col위치X.EditorPreferredWidth = 204;
            this.layoutViewField_col위치X.Location = new System.Drawing.Point(0, 272);
            this.layoutViewField_col위치X.Name = "layoutViewField_col위치X";
            this.layoutViewField_col위치X.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col위치X.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col위치X.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col위치X.TextSize = new System.Drawing.Size(34, 15);
            // 
            // col보정Y
            // 
            this.col보정Y.AppearanceCell.Options.UseTextOptions = true;
            this.col보정Y.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col보정Y.DisplayFormat.FormatString = "{0:#,0.0000}";
            this.col보정Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col보정Y.FieldName = "보정Y";
            this.col보정Y.LayoutViewField = this.layoutViewField_col위치Y;
            this.col보정Y.Name = "col보정Y";
            // 
            // layoutViewField_col위치Y
            // 
            this.layoutViewField_col위치Y.EditorPreferredWidth = 204;
            this.layoutViewField_col위치Y.Location = new System.Drawing.Point(0, 306);
            this.layoutViewField_col위치Y.Name = "layoutViewField_col위치Y";
            this.layoutViewField_col위치Y.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField_col위치Y.Size = new System.Drawing.Size(255, 34);
            this.layoutViewField_col위치Y.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_col위치Y.TextSize = new System.Drawing.Size(34, 15);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_col일시,
            this.layoutViewField_col모델,
            this.layoutViewField_col시트,
            this.layoutViewField_col상태,
            this.layoutViewField_col원점R,
            this.layoutViewField_col원점X,
            this.layoutViewField_col원점Y,
            this.layoutViewField_col위치R,
            this.layoutViewField_col위치X,
            this.layoutViewField_col위치Y,
            this.Item1});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // Item1
            // 
            this.Item1.AllowHotTrack = false;
            this.Item1.CustomizationFormText = "Item1";
            this.Item1.Location = new System.Drawing.Point(0, 340);
            this.Item1.Name = "Item1";
            this.Item1.Size = new System.Drawing.Size(255, 10);
            this.Item1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // e분류
            // 
            this.e분류.AutoHeight = false;
            this.e분류.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e분류.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("명칭", "명칭")});
            this.e분류.DisplayMember = "명칭";
            this.e분류.Name = "e분류";
            this.e분류.NullText = "[Category]";
            this.e분류.ShowHeader = false;
            this.e분류.ValueMember = "코드";
            // 
            // ResultGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ResultGrid";
            this.Size = new System.Drawing.Size(275, 543);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind검사정보)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col일시)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col모델)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col시트)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col상태)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col원점R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col원점X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col원점Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col위치R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col위치X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col위치Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e분류)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource Bind검사정보;
        private MvUtils.CustomGrid GridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit e분류;
        private DevExpress.XtraGrid.Views.Layout.LayoutView GridView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col일시;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col모델;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col시트;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col상태;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col원점R;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col원점X;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col원점Y;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col보정R;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col보정X;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col보정Y;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col일시;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col모델;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col시트;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col상태;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col원점R;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col원점X;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col원점Y;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col위치R;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col위치X;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col위치Y;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.EmptySpaceItem Item1;
    }
}
