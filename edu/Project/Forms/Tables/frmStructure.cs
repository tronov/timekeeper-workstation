using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Tables
{
 public partial class frmStructure : Form
 {
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public CatalogMode CatalogMode
  {
   set
   {
    this.ctrlStructure.CatalogMode = value;
    if (value == CatalogMode.Select)
    {
     this.scMain.Panel2Collapsed = true;
    }
    if (value == CatalogMode.View)
    {
     this.scMain.Panel2Collapsed = false;
    }
   }
  }

  public frmStructure()
  {
   InitializeComponent();
   this.ctrlStructure.tvStructure.AfterSelect += new TreeViewEventHandler(tvStructure_AfterSelect);
  }

  void tvStructure_AfterSelect(object sender, TreeViewEventArgs e)
  {
   this.ctrlBrigadePersons.BrigadeId = this.ctrlStructure.SelectedBrigadeId;
  }
 }
}
