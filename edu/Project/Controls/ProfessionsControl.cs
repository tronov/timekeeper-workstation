using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Data;

namespace Project
{
    public partial class ProfessionsControl : TableControl
    {
        private DataGridViewColumn _Id = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Code = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Title = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Rank1 = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Rank2 = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Rank3 = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Rank4 = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Rank5 = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Rank6 = new DataGridViewTextBoxColumn();

        public ProfessionsControl()
        {
            InitializeComponent();

            this._Id.Name = "Id";
            this._Id.Visible = false;

            this._Code.Name = "Code";
            this._Code.Width = 70;
            this._Code.HeaderText = "Шифр";

            this._Title.Name = "Title";
            this._Title.HeaderText = "Наименование";
            this._Title.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this._Rank1.Name = "Rank1";
            this._Rank1.Width = 80;
            this._Rank1.HeaderText = "1 разряд";

            this._Rank2.Name = "Rank2";
            this._Rank2.Width = 80;
            this._Rank2.HeaderText = "2 разряд";

            this._Rank3.Name = "Rank3";
            this._Rank3.Width = 80;
            this._Rank3.HeaderText = "3 разряд";

            this._Rank4.Name = "Rank4";
            this._Rank4.Width = 80;
            this._Rank4.HeaderText = "4 разряд";

            this._Rank5.Name = "Rank5";
            this._Rank5.Width = 80;
            this._Rank5.HeaderText = "5 разряд";

            this._Rank6.Name = "Rank6";
            this._Rank6.Width = 80;
            this._Rank6.HeaderText = "6 разряд";

            this.dgvItems.Columns.Add(this._Id);
            this.dgvItems.Columns.Add(this._Code);
            this.dgvItems.Columns.Add(this._Title);
            this.dgvItems.Columns.Add(this._Rank1);
            this.dgvItems.Columns.Add(this._Rank2);
            this.dgvItems.Columns.Add(this._Rank3);
            this.dgvItems.Columns.Add(this._Rank4);
            this.dgvItems.Columns.Add(this._Rank5);
            this.dgvItems.Columns.Add(this._Rank6);

            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Code.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Title.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Rank1.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Rank2.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Rank3.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Rank4.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Rank5.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Rank6.Clone());
            this.dgvFilter.Rows.Add();

            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void New()
        {
            frmProfession form = new frmProfession();
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Edit()
        {
            if (this.CurrentId != 0)
            {
                Profession profession = Databases.Tables.Professions[this.CurrentId];
                frmProfession form = new frmProfession(profession);
                form.ShowDialog(this);
                Init();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Delete()
        {
            if (this.CurrentId != 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.OKCancel).Equals(DialogResult.OK))
                {
                    Profession profession = Databases.Tables.Professions[this.CurrentId];
                    profession.Delete();
                    Init();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Init()
        {
            this.dgvItems.DataSource = Databases.Tables.Professions.Where(r =>
              r.Code.ToString().Contains(this.GetFilter("Code")) &&
              r.Title.ToUpper().Contains(this.GetFilter("Title").ToUpper()) &&
              r.Rank1.ToString().Contains(this.GetFilter("Rank1")) &&
              r.Rank2.ToString().Contains(this.GetFilter("Rank2")) &&
              r.Rank3.ToString().Contains(this.GetFilter("Rank3")) &&
              r.Rank4.ToString().Contains(this.GetFilter("Rank4")) &&
              r.Rank5.ToString().Contains(this.GetFilter("Rank5")) &&
              r.Rank6.ToString().Contains(this.GetFilter("Rank6"))
              ).ToList();

            foreach (DataGridViewColumn column in this.dgvItems.Columns)
            {
                column.DataPropertyName = column.Name;
            }
        }
    }
}
