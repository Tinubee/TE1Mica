using DevExpress.XtraEditors;
using System.Collections.Generic;
using TE1.Schemas;

namespace TE1.UI.Controls
{
    public partial class ResultGrid : XtraUserControl
    {
        public ResultGrid() => InitializeComponent();

        private List<검사정보> 검사자료 = new List<검사정보>();
        public void Init()
        {
            Localization.SetColumnCaption(this.GridView1, typeof(검사정보));
            GridControl1.DataSource = 검사자료;
        }

        public void SetResults(검사정보 검사)
        {
            검사자료.Clear();
            검사자료.Add(검사);
            RefreshData();
        }

        public void RefreshData() => GridView1?.RefreshData();
    }
}
