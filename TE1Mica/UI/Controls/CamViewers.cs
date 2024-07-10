using DevExpress.XtraEditors;
using TE1.Schemas;

namespace TE1.UI.Controls
{
    public partial class CamViewers : XtraUserControl
    {
        public CamViewers() => InitializeComponent();
        public void Init(CamViewer.ViewType type = CamViewer.ViewType.Inspect)
        {
            e좌측시트.Init(시트구분.좌측, type);
            e우측시트.Init(시트구분.우측, type);
        }
        public void Close() { }
    }
}
