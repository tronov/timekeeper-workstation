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

  private CatalogMode _CatalogMode;
  private int _SelectedId = 0;
  
  private ContextMenuStrip cms = new ContextMenuStrip();

  /// <summary>
  /// Возвращает идентификатор строки выделенной в текущий момент
  /// </summary>
  public int CurrentId
  {
   get
   {
    if (!this.dgvItems.SelectedRows.Count.Equals(0))
     return (int)this.dgvItems.SelectedRows[0].Cells["Id"].Value;
    else return 0;
   }
  }

  /// <summary>
  /// Возвращает идентификатор выбранной строки
  /// </summary>
  public int SelectedId
  {
   get
   {
    return this._SelectedId;
   }
  }

  /// <summary>
  /// Возвращает или задает режим просмотра справочника
  /// </summary>
  public CatalogMode CatalogMode
  {
   get
   {
    return this._CatalogMode;
   }
   set
   {
    this._CatalogMode = value;
    if (value == CatalogMode.Select)
    {
     scMain.Panel2Collapsed = true;
     cms = cmsSelect;
     dgvItems.MouseDoubleClick += new MouseEventHandler(dgvItems_MouseDoubleClick);
    }
    if (value == CatalogMode.View)
    {
     scMain.Panel2Collapsed = false;     
     cms = cmsView;
     dgvItems.MouseDoubleClick -= new MouseEventHandler(dgvItems_MouseDoubleClick);
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
    DataGridViewCell cell = dgvFilter.Rows[0].Cells[columnName];
    return cell.Value == null ? String.Empty : cell.Value.ToString().Trim();
   }
   catch
   {
    return String.Empty;
   }
  }

  private void dgvFilter_KeyUp(object sender, KeyEventArgs e)
  {
   if (e.KeyCode == Keys.Delete)
    dgvFilter.SelectedCells[0].Value = null;
  }
  private void dgvItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
  {
   if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
   {
    DataGridView grid = (DataGridView)sender;
    DataGridViewRow row = grid.Rows[e.RowIndex];
    row.ContextMenuStrip = cms;
    row.Selected = true;
   }
  }
  private void dgvItems_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
  {
   if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.Button == MouseButtons.Right)
    ((DataGridView)sender).Rows[e.RowIndex].ContextMenuStrip.Show();
  }

  private void miSelect_Click(object sender, EventArgs e)
  {
   if (this.CurrentId != 0)
    this._SelectedId = this.CurrentId;
   this.FindForm().Close();
  }

  private void bNew_Click(object sender, EventArgs e) { New(); }

  private void bEdit_Click(object sender, EventArgs e) { Edit(); }

  private void bDelete_Click(object sender, EventArgs e) { Delete(); }

  private void miEdit_Click(object sender, EventArgs e) { Edit(); }

  private void miDelete_Click(object sender, EventArgs e) { Delete(); }

  private void dgvFilter_CellValueChanged(object sender, DataGridViewCellEventArgs e) { Init(); }

  private void dgvItems_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
  {
   dgvFilter.Columns[e.Column.Name].Width = dgvItems.Columns[e.Column.Name].Width;
  }

  void dgvItems_MouseDoubleClick(object sender, MouseEventArgs e)
  {
   if (this.CurrentId != 0)
   {
    this._SelectedId = this.CurrentId;
    this.FindForm().Close();
   }
  }
 }
}
