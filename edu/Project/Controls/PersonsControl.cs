using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Data;

namespace Project
{
    public partial class PersonsControl : TableControl
    {

        private List<Person> _deletions = new List<Person>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Person> Deletions
        {
            get { return _deletions; }
            set
            {
                _deletions = value;
                Init();
            }
        }

        public PersonsControl()
        {
            InitializeComponent();

            var id = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                Visible = false
            };

            var code = new DataGridViewTextBoxColumn
            {
                Name = "Code",
                HeaderText = "Таб. №"
            };

            var lastName = new DataGridViewTextBoxColumn
            {
                Name = "LastName",
                HeaderText = "Фамилия"
            };
            var firstName = new DataGridViewTextBoxColumn
            {
                Name = "FirstName",
                HeaderText = "Имя"
            };

            var middleName = new DataGridViewTextBoxColumn
            {
                Name = "MiddleName",
                HeaderText = "Отчество",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };


            dgvItems.Columns.Add(id);
            dgvItems.Columns.Add(code);
            dgvItems.Columns.Add(lastName);
            dgvItems.Columns.Add(firstName);
            dgvItems.Columns.Add(middleName);

            dgvFilter.Columns.Add(code.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(lastName.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(firstName.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(middleName.Clone() as DataGridViewColumn);
            dgvFilter.Rows.Add();

            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void New()
        {
            var form = new PersonForm();
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Edit()
        {
            if (CurrentId == 0) return;

            var person = Databases.Tables.Persons[CurrentId];
            var form = new PersonForm(person);
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

            var person = Databases.Tables.Persons[CurrentId];
            person.Delete();
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Init()
        {
            dgvItems.DataSource = Databases.Tables.Persons.Except(Deletions.AsEnumerable()).Where(r =>
              r.Code.ToString().Contains(GetFilter("Code")) &&
              r.FirstName.ToUpper().Contains(GetFilter("FirstName").ToUpper()) &&
              r.MiddleName.ToUpper().Contains(GetFilter("MiddleName").ToUpper()) &&
              r.LastName.ToUpper().Contains(GetFilter("LastName").ToUpper())
              ).ToList();

            foreach (DataGridViewColumn column in dgvItems.Columns)
            {
                column.DataPropertyName = column.Name;
            }
        }
    }
}
