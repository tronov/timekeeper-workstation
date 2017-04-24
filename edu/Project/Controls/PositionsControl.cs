using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Project.Data;

namespace Project.Controls
{
    public partial class PositionsControl : UserControl
    {
        public PositionsControl()
        {
            InitializeComponent();
        }

        private void dgvItems_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvItems.Rows[e.RowIndex];

            var title = row.Cells["Title"].Value != null;
            var draw = row.Cells["Draw"].Value != null;
            var matherial = row.Cells["Matherial"].Value != null;
            var number = row.Cells["Number"].Value != null;
            var mass = row.Cells["Mass"].Value != null;
            var norm = row.Cells["Norm"].Value != null;

            if (title && draw && matherial && number && mass && norm) e.Cancel = false;
            else if (title || draw || matherial || number || mass || norm) e.Cancel = true;
        }

        private static void floatCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            var ctrl = (DataGridViewTextBoxEditingControl)sender;

            if (ctrl.Text.Contains(separator) && (e.KeyChar != (char)Keys.Back) && ctrl.SelectionLength == 0)
            {
                if (ctrl.Text.Substring(ctrl.Text.IndexOf(separator)).Length > 3) e.Handled = true;
            }

            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.') && (e.KeyChar != ',')) e.Handled = true;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!ctrl.Text.Contains(separator) && ctrl.Text.Length != 0)
                {
                    ctrl.Text += separator;
                    ctrl.SelectionStart = ctrl.Text.Length;
                }
                e.Handled = true;
            }
            if (e.KeyChar == '0' && ctrl.Text.Equals("0")) e.Handled = true;
        }

        private static void intCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ctrl = (DataGridViewTextBoxEditingControl)sender;

            if (
             (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back)) ||
             (ctrl.Text.Length == 0 && e.KeyChar == '0')
             )
                e.Handled = true;
        }

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var column = dgvItems.Columns[dgvItems.CurrentCell.ColumnIndex];
            var acsCollection = new AutoCompleteStringCollection();
            List<string> strings;

            var ctrl = (DataGridViewTextBoxEditingControl)e.Control;

            switch (column.Name)
            {
                case "Title":
                    {
                        ctrl.AutoCompleteMode = AutoCompleteMode.Append;
                        ctrl.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        strings = (from position in Databases.Tables.Positions
                                   select position.Title).ToList();
                        foreach (var str in strings) acsCollection.Add(str);
                        ctrl.AutoCompleteCustomSource = acsCollection;
                        ctrl.KeyPress -= floatCell_KeyPress;
                        ctrl.KeyPress -= intCell_KeyPress;
                    }
                    break;
                case "Draw":
                    {
                        ctrl.AutoCompleteMode = AutoCompleteMode.Append;
                        ctrl.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        strings = (from position in Databases.Tables.Positions
                                   select position.Draw).ToList();
                        foreach (string str in strings) acsCollection.Add(str);
                        ctrl.AutoCompleteCustomSource = acsCollection;
                        ctrl.KeyPress -= floatCell_KeyPress;
                        ctrl.KeyPress -= intCell_KeyPress;
                    }
                    break;
                case "Matherial":
                    {
                        ctrl.AutoCompleteMode = AutoCompleteMode.Append;
                        ctrl.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        strings = (from position in Databases.Tables.Positions
                                   select position.Matherial).ToList();
                        foreach (var str in strings) acsCollection.Add(str);
                        ctrl.AutoCompleteCustomSource = acsCollection;
                        ctrl.KeyPress -= floatCell_KeyPress;
                        ctrl.KeyPress -= intCell_KeyPress;
                    }
                    break;
                case "Number":
                    {
                        ctrl.KeyPress -= floatCell_KeyPress;
                        ctrl.KeyPress += intCell_KeyPress;
                    }
                    break;
                case "Mass":
                case "Norm":
                case "Price":
                    {
                        ctrl.KeyPress -= intCell_KeyPress;
                        ctrl.KeyPress += floatCell_KeyPress;
                    }
                    break;
            }
        }
    }
}
