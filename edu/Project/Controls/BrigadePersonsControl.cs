using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Data;
using Project.Forms.Tables;

namespace Project.Controls
{
    public partial class BrigadePersonsControl : TableControl
    {
        private int _brigadeId;
        private List<BrigadePerson> _deletions = new List<BrigadePerson>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BrigadeId
        {
            get { return _brigadeId; }
            set
            {
                _brigadeId = value;
                Init();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<BrigadePerson> Deletions
        {
            get { return _deletions; }
            set
            {
                _deletions = value;
                Init();
            }
        }

        public BrigadePersonsControl()
        {
            InitializeComponent();

            gbFilter.Text = "Фильтр персонала";
            gbItems.Text = "Персонал подразделения";
            gbOperations.Text = "Операции с персоналом";

            var id = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                Visible = false
            };

            var personCode = new DataGridViewTextBoxColumn
            {
                Name = "PersonCode",
                HeaderText = "Таб. №"
            };

            var personLastName = new DataGridViewTextBoxColumn
            {
                Name = "PersonLastName",
                HeaderText = "Фамилия"
            };

            var personFirstName = new DataGridViewTextBoxColumn
            {
                Name = "PersonFirstName",
                HeaderText = "Имя"
            };

            var personMiddleName = new DataGridViewTextBoxColumn
            {
                Name = "PersonMiddleName",
                HeaderText = "Отчество",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgvItems.Columns.Add(id);
            dgvItems.Columns.Add(personCode);
            dgvItems.Columns.Add(personLastName);
            dgvItems.Columns.Add(personFirstName);
            dgvItems.Columns.Add(personMiddleName);


            dgvFilter.Columns.Add(personCode.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(personLastName.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(personFirstName.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(personMiddleName.Clone() as DataGridViewColumn);
            dgvFilter.Rows.Add();

            bNew.Text = "Добавить";
            bDelete.Text = "Исключить";
            bDelete.Location = bEdit.Location;
            bEdit.Visible = false;

            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void New()
        {
            if (BrigadeId == 0) return;
            var form = new PersonsForm
            {
                ctrlPersons =
                {
                    Deletions = (from person in Databases.Tables.Persons
                        from brigadePerson in Databases.Tables.BrigadePersons
                        where person.Equals(brigadePerson.Person)
                        select person).ToList()
                },
                CatalogMode = CatalogMode.Select
            };


            form.ShowDialog();
            if (form.SelectedPersonId != 0)
            {
                var brigadePerson = new BrigadePerson(BrigadeId, form.SelectedPersonId);
                Databases.Tables.BrigadePersons.Insert(brigadePerson);
            }
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Delete()
        {
            if (CurrentId == 0) return;
            if (!MessageBox
                .Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.OKCancel)
                .Equals(DialogResult.OK)) return;

            var brigadePerson = Databases.Tables.BrigadePersons[CurrentId];
            brigadePerson.Delete();
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Init()
        {
            dgvItems.DataSource = (from brigadePerson in Databases.Tables.BrigadePersons.Except(Deletions.AsEnumerable())
                                        where
                                        (brigadePerson.BrigadeId == BrigadeId) &&
                                        brigadePerson.Person.Code.ToString().Contains(GetFilter("PersonCode")) &&
                                        brigadePerson.Person.FirstName.ToUpper().Contains(GetFilter("PersonFirstName").ToUpper()) &&
                                        brigadePerson.Person.MiddleName.ToUpper().Contains(GetFilter("PersonMiddleName").ToUpper()) &&
                                        brigadePerson.Person.LastName.ToUpper().Contains(GetFilter("PersonLastName").ToUpper())
                                        select new
                                        {
                                            brigadePerson.Id,
                                            PersonCode = brigadePerson.Person.Code,
                                            PersonFirstName = brigadePerson.Person.FirstName,
                                            PersonMiddleName = brigadePerson.Person.MiddleName,
                                            PersonLastName = brigadePerson.Person.LastName
                                        }).ToList();

            foreach (DataGridViewColumn column in dgvItems.Columns)
            {
                column.DataPropertyName = column.Name;
            }
        }
    }
}
