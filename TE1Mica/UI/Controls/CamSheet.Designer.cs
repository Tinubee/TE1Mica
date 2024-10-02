namespace TE1.UI.Controls
{
    partial class CamSheet
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamSheet));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.e위치X = new DevExpress.XtraEditors.SpinEdit();
            this.Bind검사정보 = new System.Windows.Forms.BindingSource(this.components);
            this.e위치Y = new DevExpress.XtraEditors.SpinEdit();
            this.e위치R = new DevExpress.XtraEditors.SpinEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.g타이틀 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.e카메라R = new TE1.UI.Controls.CamViewer();
            this.e카메라B = new TE1.UI.Controls.CamViewer();
            this.e카메라C = new TE1.UI.Controls.CamViewer();
            this.e카메라L = new TE1.UI.Controls.CamViewer();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e위치X.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind검사정보)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e위치Y.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e위치R.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g타이틀)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.e위치X);
            this.layoutControl1.Controls.Add(this.e위치Y);
            this.layoutControl1.Controls.Add(this.e위치R);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.AlwaysScrollActiveControlIntoView = false;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(849, 100);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // e위치X
            // 
            this.e위치X.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bind검사정보, "보정X", true));
            this.e위치X.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.e위치X.EnterMoveNextControl = true;
            this.e위치X.Location = new System.Drawing.Point(336, 61);
            this.e위치X.Name = "e위치X";
            this.e위치X.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e위치X.Properties.Appearance.Options.UseFont = true;
            this.e위치X.Properties.Appearance.Options.UseTextOptions = true;
            this.e위치X.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e위치X.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.e위치X.Properties.DisplayFormat.FormatString = "{0:#,0.000}mm";
            this.e위치X.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.e위치X.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.e위치X.Properties.ReadOnly = true;
            this.e위치X.Size = new System.Drawing.Size(226, 28);
            this.e위치X.StyleController = this.layoutControl1;
            this.e위치X.TabIndex = 5;
            // 
            // Bind검사정보
            // 
            this.Bind검사정보.DataSource = typeof(TE1.Schemas.검사정보);
            // 
            // e위치Y
            // 
            this.e위치Y.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bind검사정보, "보정Y", true));
            this.e위치Y.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.e위치Y.EnterMoveNextControl = true;
            this.e위치Y.Location = new System.Drawing.Point(615, 61);
            this.e위치Y.Name = "e위치Y";
            this.e위치Y.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e위치Y.Properties.Appearance.Options.UseFont = true;
            this.e위치Y.Properties.Appearance.Options.UseTextOptions = true;
            this.e위치Y.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e위치Y.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.e위치Y.Properties.DisplayFormat.FormatString = "{0:#,0.000}mm";
            this.e위치Y.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.e위치Y.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.e위치Y.Properties.ReadOnly = true;
            this.e위치Y.Size = new System.Drawing.Size(226, 28);
            this.e위치Y.StyleController = this.layoutControl1;
            this.e위치Y.TabIndex = 6;
            // 
            // e위치R
            // 
            this.e위치R.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bind검사정보, "보정R", true));
            this.e위치R.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.e위치R.EnterMoveNextControl = true;
            this.e위치R.Location = new System.Drawing.Point(57, 61);
            this.e위치R.Name = "e위치R";
            this.e위치R.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e위치R.Properties.Appearance.Options.UseFont = true;
            this.e위치R.Properties.Appearance.Options.UseTextOptions = true;
            this.e위치R.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e위치R.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.e위치R.Properties.DisplayFormat.FormatString = "{0:#,0.000}˚";
            this.e위치R.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.e위치R.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.e위치R.Properties.ReadOnly = true;
            this.e위치R.Size = new System.Drawing.Size(226, 28);
            this.e위치R.StyleController = this.layoutControl1;
            this.e위치R.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.g타이틀});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.Root.Size = new System.Drawing.Size(849, 100);
            this.Root.TextVisible = false;
            // 
            // g타이틀
            // 
            this.g타이틀.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.g타이틀.AppearanceItemCaption.Options.UseFont = true;
            buttonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonImageOptions1.SvgImage")));
            buttonImageOptions1.SvgImageSize = new System.Drawing.Size(24, 24);
            this.g타이틀.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Button", false, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.g타이틀.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.g타이틀.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.g타이틀.Location = new System.Drawing.Point(0, 0);
            this.g타이틀.Name = "g타이틀";
            this.g타이틀.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.g타이틀.Size = new System.Drawing.Size(847, 98);
            this.g타이틀.Text = "MICA Sheet Left";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.e위치X;
            this.layoutControlItem2.Location = new System.Drawing.Point(279, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(279, 35);
            this.layoutControlItem2.Text = "X";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(37, 21);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.e위치Y;
            this.layoutControlItem3.Location = new System.Drawing.Point(558, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(279, 35);
            this.layoutControlItem3.Text = "Y";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(37, 21);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.e위치R;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(279, 35);
            this.layoutControlItem1.Text = "θ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(37, 21);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Controls.Add(this.e카메라R);
            this.tablePanel1.Controls.Add(this.e카메라B);
            this.tablePanel1.Controls.Add(this.e카메라C);
            this.tablePanel1.Controls.Add(this.e카메라L);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 100);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Size = new System.Drawing.Size(849, 817);
            this.tablePanel1.TabIndex = 1;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // e카메라R
            // 
            this.tablePanel1.SetColumn(this.e카메라R, 1);
            this.e카메라R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e카메라R.Location = new System.Drawing.Point(427, 411);
            this.e카메라R.Name = "e카메라R";
            this.tablePanel1.SetRow(this.e카메라R, 1);
            this.e카메라R.Size = new System.Drawing.Size(420, 403);
            this.e카메라R.TabIndex = 4;
            // 
            // e카메라B
            // 
            this.tablePanel1.SetColumn(this.e카메라B, 1);
            this.e카메라B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e카메라B.Location = new System.Drawing.Point(427, 3);
            this.e카메라B.Name = "e카메라B";
            this.tablePanel1.SetRow(this.e카메라B, 0);
            this.e카메라B.Size = new System.Drawing.Size(420, 404);
            this.e카메라B.TabIndex = 3;
            // 
            // e카메라C
            // 
            this.tablePanel1.SetColumn(this.e카메라C, 0);
            this.e카메라C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e카메라C.Location = new System.Drawing.Point(3, 3);
            this.e카메라C.Name = "e카메라C";
            this.tablePanel1.SetRow(this.e카메라C, 0);
            this.e카메라C.Size = new System.Drawing.Size(420, 404);
            this.e카메라C.TabIndex = 2;
            // 
            // e카메라L
            // 
            this.tablePanel1.SetColumn(this.e카메라L, 0);
            this.e카메라L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e카메라L.Location = new System.Drawing.Point(3, 411);
            this.e카메라L.Name = "e카메라L";
            this.tablePanel1.SetRow(this.e카메라L, 1);
            this.e카메라L.Size = new System.Drawing.Size(420, 403);
            this.e카메라L.TabIndex = 1;
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bind검사정보, "일시", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "G"));
            this.textEdit1.Location = new System.Drawing.Point(57, 35);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(784, 22);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 8;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(837, 26);
            this.layoutControlItem4.Text = "Time";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(37, 21);
            // 
            // CamSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.layoutControl1);
            this.Name = "CamSheet";
            this.Size = new System.Drawing.Size(849, 917);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e위치X.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind검사정보)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e위치Y.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e위치R.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g타이틀)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private CamViewer e카메라R;
        private CamViewer e카메라B;
        private CamViewer e카메라C;
        private CamViewer e카메라L;
        private DevExpress.XtraLayout.LayoutControlGroup g타이틀;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SpinEdit e위치X;
        private DevExpress.XtraEditors.SpinEdit e위치Y;
        private DevExpress.XtraEditors.SpinEdit e위치R;
        private System.Windows.Forms.BindingSource Bind검사정보;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
