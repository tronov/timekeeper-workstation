using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Tables
{
    public partial class frmStructure : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CatalogMode CatalogMode
        {
            set
            {
                ctrlStructure.CatalogMode = value;
                if (value == CatalogMode.Select)
                {
                    scMain.Panel2Collapsed = true;
                }
                if (value == CatalogMode.View)
                {
                    scMain.Panel2Collapsed = false;
                }
            }
        }

        public frmStructure()
        {
            InitializeComponent();
            ctrlStructure.tvStructure.AfterSelect += tvStructure_AfterSelect;
        }

        void tvStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ctrlBrigadePersons.BrigadeId = ctrlStructure.SelectedBrigadeId;
        }
    }
}
