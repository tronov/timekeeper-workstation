using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Project.Databases;

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
   DataGridViewRow row = dgvItems.Rows[e.RowIndex];

   bool title = row.Cells["Title"].Value != null ? true : false;
   bool draw = row.Cells["Draw"].Value != null ? true : false;
   bool matherial = row.Cells["Matherial"].Value != null ? true : false;
   bool number = row.Cells["Number"].Value != null ? true : false;
   bool mass = row.Cells["Mass"].Value != null ? true : false;
   bool norm = row.Cells["Norm"].Value != null ? true : false;

   if (title && draw && matherial && number && mass && norm) e.Cancel = false;
   else if (title || draw || matherial || number || mass || norm) e.Cancel = true;

   //if (row.Cells["PositionId"].Value == null) e.Cancel = false;
  }

  void floatCell_KeyPress(object sender, KeyPressEventArgs e)
  {
   string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

   DataGridViewTextBoxEditingControl ctrl = (DataGridViewTextBoxEditingControl)sender;

   if (ctrl.Text.Contains(separator) && (e.KeyChar != (char)Keys.Back) && ctrl.SelectionLength == 0)
   {
    if (ctrl.Text.Substring(ctrl.Text.IndexOf(separator)).Length > 3) e.Handled = true;
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

  void intCell_KeyPress(object sender, KeyPressEventArgs e)
  {
   DataGridViewTextBoxEditingControl ctrl = (DataGridViewTextBoxEditingControl)sender;

   if (
    (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back)) ||
    (ctrl.Text.Length == 0 && e.KeyChar == '0')
    ) e.Handled = true;
  }

  private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
  {
   DataGridViewColumn column = dgvItems.Columns[dgvItems.CurrentCell.ColumnIndex];
   AutoCompleteStringCollection acsCollection = new AutoCompleteStringCollection();
   List<string> strings = new List<string>();

   DataGridViewTextBoxEditingControl ctrl = (DataGridViewTextBoxEditingControl)e.Control;

   switch (column.Name)
   {
    case "Title":
     {
      ctrl.AutoCompleteMode = AutoCompleteMode.Append;
      ctrl.AutoCompleteSource = AutoCompleteSource.CustomSource;
      strings = (from position in Data.Tables.Positions
           select position.Title).ToList();
      foreach (string str in strings) acsCollection.Add(str);
      ctrl.AutoCompleteCustomSource = acsCollection;
      ctrl.KeyPress -= new KeyPressEventHandler(floatCell_KeyPress);
      ctrl.KeyPress -= new KeyPressEventHandler(intCell_KeyPress);
     }
     break;
    case "Draw":
     {
      ctrl.AutoCompleteMode = AutoCompleteMode.Append;
      ctrl.AutoCompleteSource = AutoCompleteSource.CustomSource;
      strings = (from position in Data.Tables.Positions
           select position.Draw).ToList();
      foreach (string str in strings) acsCollection.Add(str);
      ctrl.AutoCompleteCustomSource = acsCollection;
      ctrl.KeyPress -= new KeyPressEventHandler(floatCell_KeyPress);
      ctrl.KeyPress -= new KeyPressEventHandler(intCell_KeyPress);
     }
     break;
    case "Matherial":
     {
      ctrl.AutoCompleteMode = AutoCompleteMode.Append;
      ctrl.AutoCompleteSource = AutoCompleteSource.CustomSource;
      strings = (from position in Data.Tables.Positions
           select position.Matherial).ToList();
      foreach (string str in strings) acsCollection.Add(str);
      ctrl.AutoCompleteCustomSource = acsCollection;
      ctrl.KeyPress -= new KeyPressEventHandler(floatCell_KeyPress);
      ctrl.KeyPress -= new KeyPressEventHandler(intCell_KeyPress);
     }
     break;
    case "Number":
     {
      ctrl.KeyPress -= new KeyPressEventHandler(floatCell_KeyPress);
      ctrl.KeyPress += new KeyPressEventHandler(intCell_KeyPress);
     }
     break;
    case "Mass":
    case "Norm":
    case "Price":
     {
      ctrl.KeyPress -= new KeyPressEventHandler(intCell_KeyPress);
      ctrl.KeyPress += new KeyPressEventHandler(floatCell_KeyPress);
     }
     break;
    default: break;
   }
  }
 }
}
