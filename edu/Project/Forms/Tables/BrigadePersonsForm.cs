using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Tables
{
    public partial class BrigadePersonsForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CatalogMode CatalogMode
        {
            set
            {
                ctrlBrigadePersons.CatalogMode = value;
            }
        }

        public BrigadePersonsForm()
        {
            InitializeComponent();
        }
    }
}
