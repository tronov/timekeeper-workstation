using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Tables
{
 public partial class frmBrigadePersons : Form
 {
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public CatalogMode CatalogMode
  {
   set
   {
    this.ctrlBrigadePersons.CatalogMode = value;
   }
  }

  public frmBrigadePersons()
  {
   InitializeComponent();
  }
 }
}
