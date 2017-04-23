using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Tables
{
    public partial class PersonProfessionsForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedId
        {
            get { return ctrlPersonProfessions.SelectedId; }
        }

        public PersonProfessionsForm()
        {
            InitializeComponent();
            ctrlPersonProfessions.CatalogMode = CatalogMode.Select;
        }
    }
}
