using System;
using System.Linq;
using System.Windows.Forms;
using Project.Data;

namespace Project.Forms.Elements
{
    public partial class AreaForm : Form
    {
        private readonly Area _area;

        public AreaForm()
        {
            InitializeComponent();
        }

        public AreaForm(Area area)
        {
            InitializeComponent();
            Text = "Изменение данных об участке.";
            _area = area;
            mtbCode.Text = area.Code.ToString("D2");
            tbTitle.Text = area.Title;
        }

        private bool Check()
        {
            byte code = Convert.ToByte(mtbCode.Text);
            string title = tbTitle.Text;
            if (code == 0)
            {
                (new ToolTip()).Show("Шифр 00 не допускается", this, mtbCode.Location, 2000);
                return false;
            }
            if (!Databases.Tables.Areas.Count(r => r.Code == code).Equals(0))
            {
                (new ToolTip()).Show("Участок с таким шифром уже существует.", this, mtbCode.Location, 2000);
                return false;
            }
            if (!Databases.Tables.Areas.Count(r => r.Title.Equals(title)).Equals(0))
            {
                (new ToolTip()).Show("Участок с таким названием уже существует.", this, mtbCode.Location, 2000);
                return false;
            }
            return true;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (!Check()) return;
            var area = new Area(Convert.ToByte(mtbCode.Text), tbTitle.Text.Trim());
            if (_area == null) Databases.Tables.Areas.Insert(area);
            else _area.Update(area);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
