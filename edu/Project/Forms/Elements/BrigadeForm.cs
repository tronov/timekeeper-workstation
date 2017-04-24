using System;
using System.Linq;
using System.Windows.Forms;
using Project.Data;

namespace Project.Forms.Elements
{
    public partial class BrigadeForm : Form
    {
        private Area _area;
        private Brigade _brigade;

        public BrigadeForm(Brigade brigade)
        {
            InitializeComponent();
            Text = "Изменение данных о бригаде.";
            _area = brigade.Area;
            _brigade = brigade;
            mtbCode.Text = brigade.Code.ToString("D2");
            tbTitle.Text = brigade.Title;
        }

        public BrigadeForm(Area area)
        {
            InitializeComponent();
            _area = area;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Brigade brigade = new Brigade(_area.Id, Convert.ToByte(mtbCode.Text), tbTitle.Text);
                if (_brigade == null)
                    Databases.Tables.Brigades.Insert(brigade);
                else
                    _brigade.Update(brigade);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool Check()
        {
            if (mtbCode.Text.Length == 0 && tbTitle.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать шифр и название бригады", this, bSave.Location, 2000);
                return false;
            }
            if (mtbCode.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать шифр бригады", this, mtbCode.Location, 2000);
                return false;
            }
            if (tbTitle.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать название бригады", this, tbTitle.Location, 2000);
                return false;
            }
            byte code = Convert.ToByte(mtbCode.Text);
            string title = tbTitle.Text;
            if (code == 0)
            {
                (new ToolTip()).Show("Шифр 00 не допускается", this, mtbCode.Location, 2000);
                return false;
            }
            if (!_area.Brigades.Where(r => r.Code == code && r.IsActive).Count().Equals(0))
            {
                (new ToolTip()).Show("Бригада с таким шифром уже существует на участке", this, mtbCode.Location, 2000);
                return false;
            }
            if (!_area.Brigades.Where(r => r.Title.Equals(title)).Count().Equals(0))
            {
                (new ToolTip()).Show("Бригада с таким названием уже существует на участке", this, mtbCode.Location, 2000);
                return false;
            }
            return true;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
