using DevExpress.XtraEditors;
using TE1.Schemas;
using MvUtils;
using System;

namespace TE1.UI.Controls
{
    public partial class CamSheet : XtraUserControl
    {
        public CamSheet() => InitializeComponent();

        private 시트구분 현재시트 = 시트구분.좌측;
        public void Init(시트구분 시트, CamViewer.ViewType type)
        {
            현재시트 = 시트;
            this.g타이틀.Text = Utils.GetDescription(시트);
            if (시트 == 시트구분.좌측)
            {
                this.e카메라C.Init(카메라구분.Cam01, type);
                this.e카메라L.Init(카메라구분.Cam02, type);
                this.e카메라B.Init(카메라구분.Cam03, type);
                this.e카메라R.Init(카메라구분.Cam04, type);
            }
            else
            {
                this.e카메라C.Init(카메라구분.Cam05, type);
                this.e카메라L.Init(카메라구분.Cam06, type);
                this.e카메라B.Init(카메라구분.Cam07, type);
                this.e카메라R.Init(카메라구분.Cam08, type);
            }
            if (type == CamViewer.ViewType.Inspect)
            {
                this.g타이틀.CustomButtonClick += 비젼설정;
                Global.검사자료.검사완료알림 += 검사완료알림;
            }
        }

        public void Close() { }

        private void 비젼설정(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            카메라구분 카메라 = 현재시트 == 시트구분.좌측 ? 카메라구분.SheetL : 카메라구분.SheetR;
            Global.비전검사.도구설정(카메라);
        }

        private void 검사완료알림(검사정보 검사)
        {
            if (현재시트 != 검사.시트) return;
            if (this.InvokeRequired) { this.BeginInvoke(new Action(() => 검사완료알림(검사))); return; }
            this.Bind검사정보.DataSource = 검사;
            this.Bind검사정보.ResetBindings(false);
        }
    }
}
