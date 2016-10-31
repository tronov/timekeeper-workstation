using System;
using System.Linq;
using System.Windows.Forms;
using Project.Data;

namespace Project.Forms.Elements
{
    public partial class frmBrigade : Form
    {
        private Area _Area;
        private Brigade _Brigade;

        public frmBrigade(Brigade brigade)
        {
            InitializeComponent();
            this.Text = "Изменение данных о бригаде.";
            this._Area = brigade.Area;
            this._Brigade = brigade;
            this.mtbCode.Text = brigade.Code.ToString("D2");
            this.tbTitle.Text = brigade.Title;
        }

        public frmBrigade(Area area)
        {
            InitializeComponent();
            this._Area = area;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Brigade brigade = new Brigade(this._Area.Id, Convert.ToByte(mtbCode.Text), tbTitle.Text);
                if (this._Brigade == null)
                    Databases.Tables.Brigades.Insert(brigade);
                else
                    this._Brigade.Update(brigade);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool Check()
        {
            if (mtbCode.Text.Length == 0 && tbTitle.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать шифр и название бригады", this, this.bSave.Location, 2000);
                return false;
            }
            else if (mtbCode.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать шифр бригады", this, this.mtbCode.Location, 2000);
                return false;
            }
            else if (tbTitle.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать название бригады", this, this.tbTitle.Location, 2000);
                return false;
            }
            else
            {
                byte code = Convert.ToByte(mtbCode.Text);
                string title = tbTitle.Text;
                if (code == 0)
                {
                    (new ToolTip()).Show("Шифр 00 не допускается", this, this.mtbCode.Location, 2000);
                    return false;
                }
                else if (!this._Area.Brigades.Where(r => r.Code == code && r.IsActive == true).Count().Equals(0))
                {
                    (new ToolTip()).Show("Бригада с таким шифром уже существует на участке", this, this.mtbCode.Location, 2000);
                    return false;
                }
                else if (!this._Area.Brigades.Active.Where(r => r.Title.Equals(title)).Count().Equals(0))
                {
                    (new ToolTip()).Show("Бригада с таким названием уже существует на участке", this, this.mtbCode.Location, 2000);
                    return false;
                }
                else return true;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
