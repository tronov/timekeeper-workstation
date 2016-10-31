using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Data;

namespace Project
{
    public partial class PersonProfessionsControl : TableControl
    {
        private int _PersonId = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PersonId
        {
            get { return this._PersonId; }
            set
            {
                this._PersonId = value;
                Init();
            }
        }

        private DataGridViewColumn _Id = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _ProfessionCode = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _ProfessionTitle = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Rank = new DataGridViewTextBoxColumn();

        public PersonProfessionsControl()
        {
            InitializeComponent();

            this._Id.Name = "Id";
            this._Id.Visible = false;

            this._ProfessionCode.Name = "ProfessionCode";
            this._ProfessionCode.HeaderText = "Шифр профессии";

            this._ProfessionTitle.Name = "ProfessionTitle";
            this._ProfessionTitle.HeaderText = "Наименование профессии";
            this._ProfessionTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this._Rank.Name = "Rank";
            this._Rank.HeaderText = "Разряд";

            this.dgvItems.Columns.Add(this._Id);
            this.dgvItems.Columns.Add(this._ProfessionCode);
            this.dgvItems.Columns.Add(this._ProfessionTitle);
            this.dgvItems.Columns.Add(this._Rank);

            this.dgvFilter.Columns.Add((DataGridViewColumn)this._ProfessionCode.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._ProfessionTitle.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Rank.Clone());
            this.dgvFilter.Rows.Add();

            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void New()
        {
            if (_PersonId != 0)
            {
                Person person = Databases.Tables.Persons[_PersonId];
                frmPersonProfession form = new frmPersonProfession(person);
                form.ShowDialog(this);
                Init();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Edit()
        {
            if (this.CurrentId != 0)
            {
                PersonProfession personProfession = Databases.Tables.PersonProfessions[this.CurrentId];
                frmPersonProfession form = new frmPersonProfession(personProfession);
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
                    PersonProfession personProfession = Databases.Tables.PersonProfessions[this.CurrentId];
                    personProfession.Delete();
                    Init();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Init()
        {
            this.dgvItems.DataSource = (from personProfession in Databases.Tables.PersonProfessions
                                        where
                                        personProfession.PersonId.Equals(_PersonId) &&
                                        personProfession.Profession.Code.ToString().Contains(this.GetFilter("ProfessionCode")) &&
                                        personProfession.Profession.Title.ToUpper().Contains(this.GetFilter("ProfessionTitle").ToUpper()) &&
                                        personProfession.Rank.ToString().Contains(this.GetFilter("Rank"))
                                        select new
                                        {
                                            Id = personProfession.Id,
                                            ProfessionCode = personProfession.Profession.Code,
                                            ProfessionTitle = personProfession.Profession.Title,
                                            Rank = personProfession.Rank
                                        }).ToList();

            foreach (DataGridViewColumn column in this.dgvItems.Columns)
            {
                column.DataPropertyName = column.Name;
            }
        }
    }
}
