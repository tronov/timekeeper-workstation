using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Databases;
using Project.Forms.Tables;

namespace Project.Controls
{
    public partial class ExecutorsControl : UserControl
    {
        private int _BrigadeId = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BrigadeId
        {
            get { return this._BrigadeId; }
            set
            {
                this._BrigadeId = value;
            }
        }

        public ExecutorsControl()
        {
            InitializeComponent();
        }

        private void dgvExecutors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridView grid = (DataGridView)sender;
                DataGridViewColumn column = grid.Columns[e.ColumnIndex];
                DataGridViewRow row = grid.Rows[e.RowIndex];
                DataGridViewCell cell = grid[e.ColumnIndex, e.RowIndex];
                switch (column.Name)
                {
                    case "PersonCode":
                        frmBrigadePersons fbp = new frmBrigadePersons();
                        fbp.CatalogMode = CatalogMode.Select;
                        fbp.ctrlBrigadePersons.BrigadeId = this.BrigadeId;

                        List<BrigadePerson> deletions = new List<BrigadePerson>();
                        List<short> deletionsCodes = new List<short>();

                        foreach (DataGridViewRow r in this.dgvItems.Rows)
                        {
                            deletionsCodes.Add(Convert.ToInt16(r.Cells["PersonCode"].Value));
                        }
                        foreach (short deletionCode in deletionsCodes)
                        {
                            deletions.AddRange(Data.Tables.BrigadePersons.Active.Where(r => r.Person.Code == deletionCode).AsEnumerable());
                        }
                        fbp.ctrlBrigadePersons.Deletions = deletions;
                        fbp.ShowDialog();

                        if (fbp.ctrlBrigadePersons.SelectedId != 0)
                        {
                            BrigadePerson brigadePerson = Data.Tables.BrigadePersons[fbp.ctrlBrigadePersons.SelectedId];
                            DataGridViewButtonCell button = (DataGridViewButtonCell)cell;
                            button.Value = brigadePerson.Person.Code.ToString();
                            button.Tag = brigadePerson.Person;
                            row.Cells["PersonLastName"].Value = brigadePerson.Person.LastName;
                            row.Cells["PersonFirstName"].Value = brigadePerson.Person.FirstName;
                            row.Cells["PersonMiddleName"].Value = brigadePerson.Person.MiddleName;
                        }
                        break;
                    case "ProfessionCode":
                        if (row.Cells["PersonCode"].Value != null)
                        {
                            frmPersonProfessions ppf = new frmPersonProfessions();
                            Person p = ((DataGridViewButtonCell)row.Cells["PersonCode"]).Tag as Person;
                            ppf.ctrlPersonProfessions.PersonId = p.Id;
                            ppf.ShowDialog();
                            if (ppf.SelectedId != 0)
                            {
                                PersonProfession pp = Data.Tables.PersonProfessions[ppf.SelectedId];
                                DataGridViewButtonCell b = (DataGridViewButtonCell)cell;
                                b.Tag = pp;
                                b.Value = pp.Profession.Code.ToString();
                                grid.CurrentCell = row.Cells["Rank"];
                                grid.BeginEdit(true);
                                DataGridViewTextBoxEditingControl rankControl = (DataGridViewTextBoxEditingControl)grid.EditingControl;
                                rankControl.Text = pp.Rank.ToString();
                                grid.EndEdit();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void dgvItems_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            foreach (DataGridViewCell cell in row.Cells)
                if (cell.Value == null) e.Cancel = true;
            if (row.Cells["ExecutorId"].Value == null) e.Cancel = false;
        }

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvItems.Columns[dgvItems.CurrentCell.ColumnIndex].Name == "Rank")
            {
                DataGridViewTextBoxEditingControl ctrl = (DataGridViewTextBoxEditingControl)e.Control;
                ctrl.KeyPress += new KeyPressEventHandler(rankCell_KeyPress);
            }
        }

        void rankCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c != (char)1 &&
             c != (char)2 &&
             c != (char)3 &&
             c != (char)4 &&
             c != (char)5 &&
             c != (char)6)
                e.Handled = true;
        }
    }
}
