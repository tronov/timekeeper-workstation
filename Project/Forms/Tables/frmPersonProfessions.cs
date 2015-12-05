using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Tables
{
 public partial class frmPersonProfessions : Form
 {
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public int SelectedId
  {
   get { return this.ctrlPersonProfessions.SelectedId; }
  }

  public frmPersonProfessions()
  {
   InitializeComponent();
   this.ctrlPersonProfessions.CatalogMode = CatalogMode.Select;
  }
 }
}
