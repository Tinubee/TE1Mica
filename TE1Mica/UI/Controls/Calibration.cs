﻿using DevExpress.XtraEditors;
using MvUtils;
using System;

namespace TE1.UI.Controls
{
    public partial class Calibration : XtraUserControl
    {
        public Calibration()
        {
            InitializeComponent();
        }

        public void Init()
        {
            e시작.DateTime = DateTime.Today;
            e종료.DateTime = DateTime.Today;
            b검색.ImageOptions.SvgImage = Resources.GetSvgImage(SvgImageType.검색);
            //this.b검색.Click += B검색_Click;

            this.GridView1.Init(this.barManager1);
            //this.GridView1.AddDeleteMenuItem(정보삭제);
            this.GridView1.AddSelectPopMenuItems();
            this.GridView1.OptionsBehavior.Editable = true;
            this.GridView1.OptionsView.ColumnAutoWidth = false;
            //this.GridControl1.DataSource = Global.캘리브;
        }
        public void Close() { }

        public void BestFit() => this.GridView1.BestFitColumns();

        //private void B검색_Click(object sender, EventArgs e) =>
        //    Global.캘리브.Load(this.e시작.DateTime, this.e종료.DateTime);

        //private void 정보삭제(object sender, ItemClickEventArgs e)
        //{
        //    if (this.GridView1.SelectedRowsCount < 1) return;
        //    if (!Global.Confirm(this.FindForm(), Localization.선택삭제.GetString())) return;
        //    ArrayList 자료 = this.GridView1.SelectedData() as ArrayList;
        //    List<캘리브정보> rows = new List<캘리브정보>();
        //    foreach (캘리브정보 정보 in 자료) rows.Add(정보);
        //    Global.캘리브.Removes(rows);
        //    this.GridView1.DeleteSelectedRows();
        //}
    }
}
