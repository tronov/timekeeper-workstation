using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Tables
{
    public partial class PersonsForm : Form
    {
        private CatalogMode _catalogMode = CatalogMode.View;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedPersonId
        {
            get
            {
                return ctrlPersons.SelectedId;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CatalogMode CatalogMode
        {
            get
            {
                return _catalogMode;
            }
            set
            {
                _catalogMode = value;
                ctrlPersons.CatalogMode = value;
                scMain.Panel2Collapsed = value == CatalogMode.Select ? true : false;
            }
        }

        public PersonsForm()
        {
            InitializeComponent();
            ctrlPersons.dgvItems.SelectionChanged += personsControl_SelectionChanged;
        }

        private void personsControl_SelectionChanged(object sender, EventArgs e)
        {
            ctrlPersonProfessions.PersonId = ctrlPersons.CurrentId;
        }
    }
}
