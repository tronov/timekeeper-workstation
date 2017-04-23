using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Tables
{
    public partial class frmPersonProfessions : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedId
        {
            get { return ctrlPersonProfessions.SelectedId; }
        }

        public frmPersonProfessions()
        {
            InitializeComponent();
            ctrlPersonProfessions.CatalogMode = CatalogMode.Select;
        }
    }
}
