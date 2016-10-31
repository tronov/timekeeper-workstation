using System;
using System.ComponentModel;
using System.Windows.Forms;
using Project.Data;

namespace Project
{
    public partial class frmProfession : Form
    {
        private Profession _Profession;
        private string _Code
        {
            get { return this.mtbCode.Text; }
        }

        private string _Title
        {
            get { return this.tbTitle.Text.Trim(); }
        }

        public frmProfession()
        {
            InitializeComponent();
        }

        public frmProfession(Profession item)
        {
            InitializeComponent();
            this.Text = "Изменение данных о профессии.";
            this._Profession = item;
            this.mtbCode.Text = item.Code.ToString("D3");
            this.tbTitle.Text = item.Title;
            this.tbRank1.Text = item.Rank1.ToString();
            this.tbRank2.Text = item.Rank2.ToString();
            this.tbRank3.Text = item.Rank3.ToString();
            this.tbRank4.Text = item.Rank4.ToString();
            this.tbRank5.Text = item.Rank5.ToString();
            this.tbRank6.Text = item.Rank6.ToString();
        }

        private bool Check()
        {
            if (this._Code.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать код профессии.", this, mtbCode.Location, 2000);
                mtbCode.Focus();
                return false;
            }
            if (this._Title.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать название профессии.", this, tbTitle.Location, 2000);
                tbTitle.Focus();
                return false;
            }
            if (this.tbRank1.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать тариф 1 разряда.", this, tbRank1.Location, 2000);
                tbRank1.Focus();
                return false;
            }
            if (this.tbRank2.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать тариф 2 разряда.", this, tbRank2.Location, 2000);
                tbRank2.Focus();
                return false;
            }
            if (this.tbRank3.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать тариф 3 разряда.", this, tbRank3.Location, 2000);
                tbRank3.Focus();
                return false;
            }
            if (this.tbRank4.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать тариф 4 разряда.", this, tbRank4.Location, 2000);
                tbRank4.Focus();
                return false;
            }
            if (this.tbRank5.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать тариф 5 разряда.", this, tbRank5.Location, 2000);
                tbRank5.Focus();
                return false;
            }
            if (this.tbRank6.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать тариф 6 разряда.", this, tbRank6.Location, 2000);
                tbRank6.Focus();
                return false;
            }
            return true;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Profession profession = new Profession(
                 Convert.ToInt16(this._Code),
                 this._Title,
                 Convert.ToSingle(this.tbRank1.Text),
                 Convert.ToSingle(this.tbRank2.Text),
                 Convert.ToSingle(this.tbRank3.Text),
                 Convert.ToSingle(this.tbRank4.Text),
                 Convert.ToSingle(this.tbRank5.Text),
                 Convert.ToSingle(this.tbRank6.Text)
                 );
                if (this._Profession == null)
                    Databases.Tables.Professions.Insert(profession);
                else this._Profession.Update(profession);

                this.Close();
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtbCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            (new ToolTip()).Show("Код вида оплаты должен состоять из трех цифр.", this, mtbCode.Location, 2000);
        }

        private void mtbCode_Validating(object sender, CancelEventArgs e)
        {
            if (mtbCode.Text.Length != 0)
            {
                short code;
                if (!Int16.TryParse(mtbCode.Text, out code))
                {
                    (new ToolTip()).Show("Код профессии должен состоять из трех цифр.", this, mtbCode.Location, 2000);
                    mtbCode.Clear();
                    mtbCode.Focus();
                    mtbCode.BringToFront();
                }
                else mtbCode.Text = code.ToString("D3");
            }
        }

        private void tbRank_KeyPress(object sender, KeyPressEventArgs e)
        {
            string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            TextBox ctrl = (TextBox)sender;

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
    }
}
