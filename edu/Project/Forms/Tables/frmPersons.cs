using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Tables
{
    public partial class frmPersons : Form
    {
        private CatalogMode _CatalogMode = CatalogMode.View;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedPersonId
        {
            get
            {
                return this.ctrlPersons.SelectedId;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CatalogMode CatalogMode
        {
            get
            {
                return this._CatalogMode;
            }
            set
            {
                this._CatalogMode = value;
                this.ctrlPersons.CatalogMode = value;
                this.scMain.Panel2Collapsed = value == CatalogMode.Select ? true : false;
            }
        }

        public frmPersons()
        {
            InitializeComponent();
            this.ctrlPersons.dgvItems.SelectionChanged += new EventHandler(personsControl_SelectionChanged);
        }

        private void personsControl_SelectionChanged(object sender, EventArgs e)
        {
            this.ctrlPersonProfessions.PersonId = this.ctrlPersons.CurrentId;
        }
    }
}
