using System;
using System.Windows.Forms;

namespace Project
{
    /// <summary>
    /// Режим просмотра справочника
    /// </summary>
    public enum CatalogMode
    {
        View = 0,
        Select = 1
    }

    public partial class TableControl : UserControl
    {
        public virtual void New() { }
        public virtual void Edit() { }
        public virtual void Delete() { }
        public virtual void Init() { }

        private CatalogMode _catalogMode;

        /// <summary>
        /// Context menu for selected row
        /// </summary>
        private ContextMenuStrip _cms = new ContextMenuStrip();

        /// <summary>
        /// Возвращает идентификатор строки выделенной в текущий момент
        /// </summary>
        public int CurrentId => dgvItems.SelectedRows.Count.Equals(0)
            ? 0
            : (int) dgvItems.SelectedRows[0].Cells["Id"].Value;

        /// <summary>
        /// Возвращает идентификатор выбранной строки
        /// </summary>
        public int SelectedId { get; private set; }

        /// <summary>
        /// Возвращает или задает режим просмотра справочника
        /// </summary>
        public CatalogMode CatalogMode
        {
            get { return _catalogMode; }
            set
            {
                _catalogMode = value;

                switch (value)
                {
                    case CatalogMode.Select:
                        scMain.Panel2Collapsed = true;
                        _cms = cmsSelect;
                        dgvItems.MouseDoubleClick += dgvItems_MouseDoubleClick;
                        break;
                    case CatalogMode.View:
                        scMain.Panel2Collapsed = false;
                        _cms = cmsView;
                        dgvItems.MouseDoubleClick -= dgvItems_MouseDoubleClick;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        public TableControl()
        {
            InitializeComponent();
            CatalogMode = CatalogMode.View;
            dgvItems.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Возвращает значение ячейки фильтра в указанном столбце
        /// </summary>
        /// <param name="columnName">
        /// Имя столбца фильтра
        /// </param>
        /// <returns></returns>
        public string GetFilter(string columnName)
        {
            try
            {
                return dgvFilter.Rows[0].Cells[columnName].Value.ToString().Trim();
            }
            catch
            {
                return string.Empty;
            }
        }

        private void dgvFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                dgvFilter.SelectedCells[0].Value = null;
        }

        private void dgvItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            var grid = (DataGridView)sender;
            var row = grid.Rows[e.RowIndex];
            row.ContextMenuStrip = _cms;
            row.Selected = true;
        }

        private void dgvItems_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.Button == MouseButtons.Right)
                ((DataGridView)sender).Rows[e.RowIndex].ContextMenuStrip.Show();
        }

        private void miSelect_Click(object sender, EventArgs e)
        {
            if (CurrentId != 0) SelectedId = CurrentId;
            FindForm()?.Close();
        }

        private void bNew_Click(object sender, EventArgs e) { New(); }

        private void bEdit_Click(object sender, EventArgs e) { Edit(); }

        private void bDelete_Click(object sender, EventArgs e) { Delete(); }

        private void miEdit_Click(object sender, EventArgs e) { Edit(); }

        private void miDelete_Click(object sender, EventArgs e) { Delete(); }

        private void dgvFilter_CellValueChanged(object sender, DataGridViewCellEventArgs e) { Init(); }

        private void dgvItems_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            var dataGridViewColumn = dgvFilter.Columns[e.Column.Name];
            if (dataGridViewColumn == null) return;

            var dgvItemsColumn = dgvItems.Columns[e.Column.Name];
            if (dgvItemsColumn == null) return;

            dataGridViewColumn.Width = dgvItemsColumn.Width;
        }

        private void dgvItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CurrentId == 0) return;
            SelectedId = CurrentId;
            FindForm()?.Close();
        }
    }
}
