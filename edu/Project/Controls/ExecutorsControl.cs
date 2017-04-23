using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Data;
using Project.Forms.Tables;

namespace Project.Controls
{
    public partial class ExecutorsControl : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BrigadeId { get; set; } = 0;

        public ExecutorsControl()
        {
            InitializeComponent();
        }

        private void dgvExecutors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            var grid = sender as DataGridView;
            var column = grid.Columns[e.ColumnIndex];
            var row = grid.Rows[e.RowIndex];
            var cell = grid[e.ColumnIndex, e.RowIndex];

            switch (column.Name)
            {
                case "PersonCode":
                    var fbp = new BrigadePersonsForm();
                    fbp.CatalogMode = CatalogMode.Select;
                    fbp.ctrlBrigadePersons.BrigadeId = BrigadeId;

                    var deletions = new List<BrigadePerson>();
                    var deletionsCodes = new List<short>();

                    foreach (DataGridViewRow r in dgvItems.Rows)
                    {
                        deletionsCodes.Add(Convert.ToInt16(r.Cells["PersonCode"].Value));
                    }
                    foreach (var deletionCode in deletionsCodes)
                    {
                        deletions.AddRange(Databases.Tables.BrigadePersons.Where(r => r.Person.Code == deletionCode).AsEnumerable());
                    }
                    fbp.ctrlBrigadePersons.Deletions = deletions;
                    fbp.ShowDialog();

                    if (fbp.ctrlBrigadePersons.SelectedId != 0)
                    {
                        var brigadePerson = Databases.Tables.BrigadePersons[fbp.ctrlBrigadePersons.SelectedId];
                        var button = (DataGridViewButtonCell)cell;
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
                        var ppf = new PersonProfessionsForm();
                        var p = (row.Cells["PersonCode"] as DataGridViewButtonCell).Tag as Person;
                        ppf.ctrlPersonProfessions.PersonId = p.Id;
                        ppf.ShowDialog();
                        if (ppf.SelectedId != 0)
                        {
                            var pp = Databases.Tables.PersonProfessions[ppf.SelectedId];
                            var b = cell as DataGridViewButtonCell;
                            b.Tag = pp;
                            b.Value = pp.Profession.Code.ToString();
                            grid.CurrentCell = row.Cells["Rank"];
                            grid.BeginEdit(true);
                            var rankControl = grid.EditingControl as DataGridViewTextBoxEditingControl;
                            rankControl.Text = pp.Rank.ToString();
                            grid.EndEdit();
                        }
                    }
                    break;
            }
        }

        private void dgvItems_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = ((DataGridView)sender).CurrentRow;
            foreach (DataGridViewCell cell in row.Cells)
                if (cell.Value == null) e.Cancel = true;
            if (row.Cells["ExecutorId"].Value == null) e.Cancel = false;
        }

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvItems.Columns[dgvItems.CurrentCell.ColumnIndex].Name != "Rank") return;
            var ctrl = (DataGridViewTextBoxEditingControl)e.Control;
            ctrl.KeyPress += rankCell_KeyPress;
        }

        private static void rankCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
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
