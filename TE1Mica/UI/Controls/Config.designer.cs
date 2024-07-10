
namespace TE1.UI.Controls
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.d기본경로 = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.BindLocalization = new System.Windows.Forms.BindingSource(this.components);
            this.b설정저장 = new DevExpress.XtraEditors.SimpleButton();
            this.g환경설정 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.e원본일수 = new DevExpress.XtraEditors.SpinEdit();
            this.e사본경로 = new DevExpress.XtraEditors.ButtonEdit();
            this.e소수자리 = new DevExpress.XtraEditors.SpinEdit();
            this.e원본경로 = new DevExpress.XtraEditors.ButtonEdit();
            this.e결과일수 = new DevExpress.XtraEditors.SpinEdit();
            this.e로그일수 = new DevExpress.XtraEditors.SpinEdit();
            this.e기본경로 = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.d원본저장 = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.d사본저장 = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Bind환경설정 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g환경설정)).BeginInit();
            this.g환경설정.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e원본일수.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e사본경로.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e소수자리.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e원본경로.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e결과일수.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e로그일수.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e기본경로.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind환경설정)).BeginInit();
            this.SuspendLayout();
            // 
            // BindLocalization
            // 
            this.BindLocalization.DataSource = typeof(TE1.UI.Controls.Config.LocalizationConfig);
            // 
            // b설정저장
            // 
            this.b설정저장.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.b설정저장.Appearance.Options.UseFont = true;
            this.b설정저장.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "설정저장", true));
            this.b설정저장.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b설정저장.ImageOptions.SvgImage")));
            this.b설정저장.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.b설정저장.Location = new System.Drawing.Point(329, 248);
            this.b설정저장.Name = "b설정저장";
            this.b설정저장.Size = new System.Drawing.Size(168, 30);
            this.b설정저장.StyleController = this.layoutControl1;
            this.b설정저장.TabIndex = 1;
            this.b설정저장.Text = "저  장";
            // 
            // g환경설정
            // 
            this.g환경설정.Controls.Add(this.layoutControl1);
            this.g환경설정.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g환경설정.Location = new System.Drawing.Point(0, 0);
            this.g환경설정.Name = "g환경설정";
            this.g환경설정.Padding = new System.Windows.Forms.Padding(10);
            this.g환경설정.Size = new System.Drawing.Size(523, 329);
            this.g환경설정.TabIndex = 7;
            this.g환경설정.Text = "환경설정";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.b설정저장);
            this.layoutControl1.Controls.Add(this.e원본일수);
            this.layoutControl1.Controls.Add(this.e사본경로);
            this.layoutControl1.Controls.Add(this.e소수자리);
            this.layoutControl1.Controls.Add(this.e원본경로);
            this.layoutControl1.Controls.Add(this.e결과일수);
            this.layoutControl1.Controls.Add(this.e로그일수);
            this.layoutControl1.Controls.Add(this.e기본경로);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(12, 37);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(499, 280);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // e원본일수
            // 
            this.e원본일수.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bind환경설정, "원본보관일수", true));
            this.e원본일수.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.e원본일수.EnterMoveNextControl = true;
            this.e원본일수.Location = new System.Drawing.Point(115, 98);
            this.e원본일수.Name = "e원본일수";
            this.e원본일수.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e원본일수.Properties.Appearance.Options.UseFont = true;
            this.e원본일수.Properties.Appearance.Options.UseTextOptions = true;
            this.e원본일수.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e원본일수.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e원본일수.Properties.IsFloatValue = false;
            this.e원본일수.Properties.MaskSettings.Set("mask", "N00");
            this.e원본일수.Properties.MaxValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.e원본일수.Size = new System.Drawing.Size(132, 28);
            this.e원본일수.StyleController = this.layoutControl1;
            this.e원본일수.TabIndex = 16;
            // 
            // e사본경로
            // 
            this.e사본경로.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bind환경설정, "사진저장", true));
            this.e사본경로.EnterMoveNextControl = true;
            this.e사본경로.Location = new System.Drawing.Point(115, 34);
            this.e사본경로.Name = "e사본경로";
            this.e사본경로.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.e사본경로.Properties.Appearance.Options.UseFont = true;
            this.e사본경로.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.e사본경로.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.e사본경로.Size = new System.Drawing.Size(382, 28);
            this.e사본경로.StyleController = this.layoutControl1;
            this.e사본경로.TabIndex = 6;
            // 
            // e소수자리
            // 
            this.e소수자리.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bind환경설정, "결과자릿수", true));
            this.e소수자리.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.e소수자리.EnterMoveNextControl = true;
            this.e소수자리.Location = new System.Drawing.Point(364, 98);
            this.e소수자리.Name = "e소수자리";
            this.e소수자리.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e소수자리.Properties.Appearance.Options.UseFont = true;
            this.e소수자리.Properties.Appearance.Options.UseTextOptions = true;
            this.e소수자리.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e소수자리.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e소수자리.Properties.IsFloatValue = false;
            this.e소수자리.Properties.MaskSettings.Set("mask", "N00");
            this.e소수자리.Properties.MaxValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.e소수자리.Size = new System.Drawing.Size(133, 28);
            this.e소수자리.StyleController = this.layoutControl1;
            this.e소수자리.TabIndex = 15;
            // 
            // e원본경로
            // 
            this.e원본경로.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bind환경설정, "원본보관폴더", true));
            this.e원본경로.EnterMoveNextControl = true;
            this.e원본경로.Location = new System.Drawing.Point(115, 66);
            this.e원본경로.Name = "e원본경로";
            this.e원본경로.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e원본경로.Properties.Appearance.Options.UseFont = true;
            this.e원본경로.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.e원본경로.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.e원본경로.Size = new System.Drawing.Size(382, 28);
            this.e원본경로.StyleController = this.layoutControl1;
            this.e원본경로.TabIndex = 11;
            // 
            // e결과일수
            // 
            this.e결과일수.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bind환경설정, "결과보관", true));
            this.e결과일수.EditValue = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.e결과일수.EnterMoveNextControl = true;
            this.e결과일수.Location = new System.Drawing.Point(115, 130);
            this.e결과일수.Name = "e결과일수";
            this.e결과일수.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e결과일수.Properties.Appearance.Options.UseFont = true;
            this.e결과일수.Properties.Appearance.Options.UseTextOptions = true;
            this.e결과일수.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e결과일수.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e결과일수.Properties.IsFloatValue = false;
            this.e결과일수.Properties.MaskSettings.Set("mask", "N00");
            this.e결과일수.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.e결과일수.Properties.MinValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.e결과일수.Size = new System.Drawing.Size(132, 28);
            this.e결과일수.StyleController = this.layoutControl1;
            this.e결과일수.TabIndex = 9;
            // 
            // e로그일수
            // 
            this.e로그일수.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bind환경설정, "로그보관", true));
            this.e로그일수.EditValue = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.e로그일수.EnterMoveNextControl = true;
            this.e로그일수.Location = new System.Drawing.Point(364, 130);
            this.e로그일수.Name = "e로그일수";
            this.e로그일수.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e로그일수.Properties.Appearance.Options.UseFont = true;
            this.e로그일수.Properties.Appearance.Options.UseTextOptions = true;
            this.e로그일수.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.e로그일수.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e로그일수.Properties.IsFloatValue = false;
            this.e로그일수.Properties.MaskSettings.Set("mask", "N00");
            this.e로그일수.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.e로그일수.Properties.MinValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.e로그일수.Size = new System.Drawing.Size(133, 28);
            this.e로그일수.StyleController = this.layoutControl1;
            this.e로그일수.TabIndex = 6;
            // 
            // e기본경로
            // 
            this.e기본경로.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Bind환경설정, "기본경로", true));
            this.e기본경로.EnterMoveNextControl = true;
            this.e기본경로.Location = new System.Drawing.Point(115, 2);
            this.e기본경로.Name = "e기본경로";
            this.e기본경로.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.e기본경로.Properties.Appearance.Options.UseFont = true;
            this.e기본경로.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.e기본경로.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.e기본경로.Size = new System.Drawing.Size(382, 28);
            this.e기본경로.StyleController = this.layoutControl1;
            this.e기본경로.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(499, 280);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.e기본경로;
            this.layoutControlItem1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "기본경로", true));
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(499, 32);
            this.layoutControlItem1.Text = "설정 저장 경로";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(101, 17);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.e사본경로;
            this.layoutControlItem4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "사진저장", true));
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(499, 32);
            this.layoutControlItem4.Text = "사본 저장 경로";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(101, 17);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.e결과일수;
            this.layoutControlItem6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "결과보관", true));
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 128);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(249, 32);
            this.layoutControlItem6.Text = "검사 자료 보관일";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(101, 17);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.e로그일수;
            this.layoutControlItem3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "로그보관", true));
            this.layoutControlItem3.Location = new System.Drawing.Point(249, 128);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(250, 32);
            this.layoutControlItem3.Text = "로그 보관일";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(101, 17);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.e원본경로;
            this.layoutControlItem8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "원본보관폴더", true));
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(499, 32);
            this.layoutControlItem8.Text = "원본 저장 경로";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(101, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.e소수자리;
            this.layoutControlItem2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "결과자릿수", true));
            this.layoutControlItem2.Location = new System.Drawing.Point(249, 96);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(250, 32);
            this.layoutControlItem2.Text = "검사 결과 자릿수";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(101, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.e원본일수;
            this.layoutControlItem5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindLocalization, "원본보관일수", true));
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(249, 32);
            this.layoutControlItem5.Text = "원본 보관 일수";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(101, 17);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.b설정저장;
            this.layoutControlItem7.Location = new System.Drawing.Point(327, 246);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(172, 34);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 160);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(499, 86);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 246);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(327, 34);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Bind환경설정
            // 
            this.Bind환경설정.DataSource = typeof(TE1.Schemas.환경설정);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.g환경설정);
            this.Name = "Config";
            this.Size = new System.Drawing.Size(523, 329);
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g환경설정)).EndInit();
            this.g환경설정.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e원본일수.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e사본경로.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e소수자리.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e원본경로.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e결과일수.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e로그일수.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e기본경로.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind환경설정)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.XtraFolderBrowserDialog d기본경로;
        private System.Windows.Forms.BindingSource Bind환경설정;
        private DevExpress.XtraEditors.SimpleButton b설정저장;
        private System.Windows.Forms.BindingSource BindLocalization;
        private DevExpress.XtraEditors.GroupControl g환경설정;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog d원본저장;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog d사본저장;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SpinEdit e원본일수;
        private DevExpress.XtraEditors.ButtonEdit e사본경로;
        private DevExpress.XtraEditors.SpinEdit e소수자리;
        private DevExpress.XtraEditors.ButtonEdit e원본경로;
        private DevExpress.XtraEditors.SpinEdit e결과일수;
        private DevExpress.XtraEditors.SpinEdit e로그일수;
        private DevExpress.XtraEditors.ButtonEdit e기본경로;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}
