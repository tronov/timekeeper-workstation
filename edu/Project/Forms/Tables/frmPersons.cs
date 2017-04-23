﻿using System;
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
                return ctrlPersons.SelectedId;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CatalogMode CatalogMode
        {
            get
            {
                return _CatalogMode;
            }
            set
            {
                _CatalogMode = value;
                ctrlPersons.CatalogMode = value;
                scMain.Panel2Collapsed = value == CatalogMode.Select ? true : false;
            }
        }

        public frmPersons()
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
