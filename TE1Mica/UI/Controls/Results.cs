using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using MvUtils;
using System;
using System.Collections;
using TE1.Schemas;

namespace TE1.UI.Controls
{
    public partial class Results : XtraUserControl
    {
        public Results() => InitializeComponent();
        private LocalizationResults 번역 = new LocalizationResults();

        public void Init()
        {
            this.BindLocalization.DataSource = this.번역;
            this.e시작일자.DateTime = DateTime.Today;
            this.e종료일자.DateTime = DateTime.Today;
            this.b자료조회.Click += 자료조회;
            this.b엑셀파일.Click += 엑셀파일;
            this.GridView1.Init(this.barManager1);

            if (Global.환경설정.권한여부(유저권한구분.관리자))
            {
                this.GridView1.AddDeleteMenuItem(정보삭제);
                //this.GridView1.AddExpandMasterPopMenuItems();
                //this.GridView1.AddSelectPopMenuItems();
            }
            else
            {
                this.layoutControl1.Visible = false;
                this.GridView1.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            }

            this.GridControl1.DataSource = Global.검사자료;
        }

        public void Close() { }

        private void 엑셀파일(object sender, EventArgs e) => this.GridView1.BtnXlsExportViewClick(null, null);
        private void 자료조회(object sender, EventArgs e)
        {
            if (Global.장치상태.자동수동)
            {
                Global.Notify("자동 운전 상태에서는 수행하실 수 없습니다.", "Search", AlertControl.AlertTypes.Warning);
                return;
            }
            Global.검사자료.Save();
            Global.검사자료.Load(this.e시작일자.DateTime, this.e종료일자.DateTime);
        }

        private void 정보삭제(object sender, ItemClickEventArgs e)
        {
            if (this.GridView1.SelectedRowsCount < 1) return;
            if (!Global.Confirm(this.FindForm(), 번역.자료삭제)) return;

            ArrayList 자료 = this.GridView1.SelectedData() as ArrayList;
            foreach (검사정보 검사 in 자료)
                Global.검사자료.결과삭제(검사);
        }

        private void 카메라검사보기(GridView view, Int32 RowHandle)
        {
            //검사정보 검사 = view.GetRow(RowHandle) as 검사정보;
            //?.카메라검사보기(검사);
        }

        //private void GridView1_RowCountChanged(object sender, EventArgs e) => (sender as GridView).MoveFirst();
        //private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        //{
        //    if (e.RowHandle < 0) return;
        //    GridView view = sender as GridView;
        //    검사결과 결과 = view.GetRow(e.RowHandle) as 검사결과;
        //    if (결과 == null) return;
        //    결과.SetAppearance(e);
        //}
        //private void GridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        //{
        //    if (e.RowHandle < 0) return;
        //    GridView view = sender as GridView;
        //    검사정보 정보 = view.GetRow(e.RowHandle) as 검사정보;
        //    if (정보 == null) return;
        //    정보.SetAppearance(e);
        //}

        public class LocalizationResults
        {
            private enum Items
            {
                [Translation("Start", "시작")]
                시작일자,
                [Translation("End", "종료")]
                종료일자,
                [Translation("Search", "조  회")]
                조회버튼,
                [Translation("Export to Excel", "엑셀파일로 내보내기")]
                엑셀버튼,
                [Translation("Are you sure you want to delete the selection?", "선택한 검사결과를 삭제하시겠습니까?")]
                자료삭제,
                [Translation("View inspection results", "검사 결과 보기")]
                결과보기,
                [Translation("Enter the QR Code.", "QR Code를 입력하세요.")]
                큐알입력,
                [Translation("No information is available.", "검사정보가 없습니다.")]
                결과없음,
            }

            public String 시작일자 => Localization.GetString(Items.시작일자);
            public String 종료일자 => Localization.GetString(Items.종료일자);
            public String 조회버튼 => Localization.GetString(Items.조회버튼);
            public String 엑셀버튼 => Localization.GetString(Items.엑셀버튼);
            public String 자료삭제 => Localization.GetString(Items.자료삭제);
            public String 결과보기 => Localization.GetString(Items.결과보기);
            public String 큐알입력 => Localization.GetString(Items.큐알입력);
            public String 결과없음 => Localization.GetString(Items.결과없음);
        }
    }
}
