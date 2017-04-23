using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Data;

namespace Project
{
    public partial class PersonProfessionsControl : TableControl
    {
        private int _personId;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PersonId
        {
            get { return _personId; }
            set
            {
                _personId = value;
                Init();
            }
        }

        public PersonProfessionsControl()
        {
            InitializeComponent();

            DataGridViewColumn id = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                Visible = false
            };

            DataGridViewColumn professionCode = new DataGridViewTextBoxColumn
            {
                Name = "ProfessionCode",
                HeaderText = "Шифр профессии"
            };

            DataGridViewColumn professionTitle = new DataGridViewTextBoxColumn
            {
                Name = "ProfessionTitle",
                HeaderText = "Наименование профессии",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DataGridViewColumn rank = new DataGridViewTextBoxColumn
            {
                Name = "Rank",
                HeaderText = "Разряд"
            };

            dgvItems.Columns.Add(id);
            dgvItems.Columns.Add(professionCode);
            dgvItems.Columns.Add(professionTitle);
            dgvItems.Columns.Add(rank);

            dgvFilter.Columns.Add(professionCode.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(professionTitle.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(rank.Clone() as DataGridViewColumn);
            dgvFilter.Rows.Add();

            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void New()
        {
            if (_personId == 0) return;
            var person = Databases.Tables.Persons[_personId];
            var form = new frmPersonProfession(person);
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Edit()
        {
            if (CurrentId == 0) return;
            var personProfession = Databases.Tables.PersonProfessions[CurrentId];
            var form = new frmPersonProfession(personProfession);
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Delete()
        {
            if (CurrentId == 0) return;
            if (!MessageBox
                .Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.OKCancel)
                .Equals(DialogResult.OK)) return;
            var personProfession = Databases.Tables.PersonProfessions[CurrentId];
            personProfession.Delete();
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Init()
        {
            dgvItems.DataSource = (from personProfession in Databases.Tables.PersonProfessions
                where
                personProfession.PersonId.Equals(_personId) &&
                personProfession.Profession.Code.ToString().Contains(GetFilter("ProfessionCode")) &&
                personProfession.Profession.Title.ToUpper().Contains(GetFilter("ProfessionTitle").ToUpper()) &&
                personProfession.Rank.ToString().Contains(GetFilter("Rank"))
                select new
                {
                    personProfession.Id,
                    ProfessionCode = personProfession.Profession.Code,
                    ProfessionTitle = personProfession.Profession.Title,
                    personProfession.Rank
                }).ToList();

            foreach (DataGridViewColumn column in dgvItems.Columns)
            {
                column.DataPropertyName = column.Name;
            }
        }
    }
}
