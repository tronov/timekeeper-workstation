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
            if (dgvItems.Columns[dgvItems.CurrentCell.ColumnIndex].Name == "Hours")
            {
                DataGridViewTextBoxEditingControl cell = (DataGridViewTextBoxEditingControl)e.Control;
                cell.KeyPress += new KeyPressEventHandler(hours_KeyPress);
            }
        }

        void hours_KeyPress(object sender, KeyPressEventArgs e)
        {
            string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            DataGridViewTextBoxEditingControl ctrl = (DataGridViewTextBoxEditingControl)sender;

            if (ctrl.Text.Contains(separator) && (e.KeyChar != (char)Keys.Back) && ctrl.SelectionLength == 0)
            {
                if (ctrl.Text.Substring(ctrl.Text.IndexOf(separator)).Length > 1) e.Handled = true;
            }

            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.') && (e.KeyChar != ',')) e.Handled = true;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!ctrl.Text.Contains(separator) && !(ctrl.Text.Length == 0))
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
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            foreach (DataGridViewCell cell in row.Cells)
                if (cell.Value == null) e.Cancel = true;
            if (row.Cells["LaborId"].Value == null) e.Cancel = false;
        }
    }
}
