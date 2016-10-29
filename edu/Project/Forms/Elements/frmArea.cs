using System.Windows.Forms;
using Project.Databases;
using System.Linq;

namespace Project.Forms.Elements
{
 public partial class frmArea : Form
 {
  private Area _Area;

  public frmArea()
  {
   InitializeComponent();
  }

  public frmArea(Area area)
  {
   InitializeComponent();
   this.Text = "Изменение данных об участке.";
   this._Area = area;
   this.mtbCode.Text = area.Code.ToString("D2");
   this.tbTitle.Text = area.Title;
  }

  private bool Check()
  {
   byte code = System.Convert.ToByte(mtbCode.Text);
   string title = tbTitle.Text;
   if (code == 0)
   {
    (new ToolTip()).Show("Шифр 00 не допускается", this, this.mtbCode.Location, 2000);
    return false;
   }
   else if (!Data.Tables.Areas.Active.Where(r => r.Code == code).Count().Equals(0))
   {
    (new ToolTip()).Show("Участок с таким шифром уже существует.", this, this.mtbCode.Location, 2000);
    return false;
   }
   else if (!Data.Tables.Areas.Active.Where(r => r.Title.Equals(title)).Count().Equals(0))
   {
    (new ToolTip()).Show("Участок с таким названием уже существует.", this, this.mtbCode.Location, 2000);
    return false;
   }
   else return true;
  }

  private void bSave_Click(object sender, System.EventArgs e)
  {
   if (Check())
   {
    Area area = new Area(System.Convert.ToByte(mtbCode.Text), tbTitle.Text.Trim());
    if (this._Area == null) Data.Tables.Areas.Insert(area);
    else this._Area.Update(area);
    this.DialogResult = DialogResult.OK;
    this.Close();
   }
  }

  private void bCancel_Click(object sender, System.EventArgs e)
  {
   this.DialogResult = DialogResult.Cancel;
   this.Close();
  }
 }
}
