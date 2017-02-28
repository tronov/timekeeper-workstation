using System;
using System.Windows.Forms;

namespace Project.Controls
{
    public partial class LaborsControl : UserControl
    {
        public LaborsControl()
        {
            InitializeComponent();
        }

        private void dgvLabors_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvItems.Columns[dgvItems.CurrentCell.ColumnIndex].Name != "Hours") return;

            var cell = (DataGridViewTextBoxEditingControl)e.Control;
            cell.KeyPress += hours_KeyPress;
        }

        private static void hours_KeyPress(object sender, KeyPressEventArgs e)
        {
            var separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            var ctrl = sender as DataGridViewTextBoxEditingControl;

            // to avoid NRE
            if (ctrl == null) return;

            if (ctrl.Text.Contains(separator) &&
                (e.KeyChar != (char) Keys.Back) &&
                ctrl.SelectionLength == 0 &&
                ctrl.Text.Substring(ctrl.Text.IndexOf(separator, StringComparison.Ordinal)).Length > 1)
                e.Handled = true;

            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.') && (e.KeyChar != ','))
                e.Handled = true;

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

        private void dgvItems_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = (sender as DataGridView)?.CurrentRow;

            if (row == null) return;

            foreach (DataGridViewCell cell in row.Cells)
                if (cell.Value == null) e.Cancel = true;
            if (row.Cells["LaborId"].Value == null) e.Cancel = false;
        }
    }
}
