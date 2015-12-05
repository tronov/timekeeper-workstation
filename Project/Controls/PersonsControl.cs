using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Databases;

namespace Project
{
 public partial class PersonsControl : TableControl
 {
  private DataGridViewColumn _Id = new DataGridViewTextBoxColumn();
  private DataGridViewColumn _Code = new DataGridViewTextBoxColumn();
  private DataGridViewColumn _FirstName = new DataGridViewTextBoxColumn();
  private DataGridViewColumn _MiddleName = new DataGridViewTextBoxColumn();
  private DataGridViewColumn _LastName = new DataGridViewTextBoxColumn();
  private List<Person> _Deletions = new List<Person>();

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public List<Person> Deletions
  {
   get { return this._Deletions; }
   set
   {
    this._Deletions = value;
    Init();
   }
  }

  public PersonsControl()
  {
   InitializeComponent();

   this._Id.Name = "Id";
   this._Id.Visible = false;

   this._Code.Name = "Code";
   this._Code.HeaderText = "Таб. №";

   this._LastName.Name = "LastName";
   this._LastName.HeaderText = "Фамилия";

   this._FirstName.Name = "FirstName";
   this._FirstName.HeaderText = "Имя";

   this._MiddleName.Name = "MiddleName";
   this._MiddleName.HeaderText = "Отчество";
   this._MiddleName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

   this.dgvItems.Columns.Add(this._Id);
   this.dgvItems.Columns.Add(this._Code);
   this.dgvItems.Columns.Add(this._LastName);
   this.dgvItems.Columns.Add(this._FirstName);
   this.dgvItems.Columns.Add(this._MiddleName);

   this.dgvFilter.Columns.Add((DataGridViewColumn)this._Code.Clone());
   this.dgvFilter.Columns.Add((DataGridViewColumn)this._LastName.Clone());
   this.dgvFilter.Columns.Add((DataGridViewColumn)this._FirstName.Clone());
   this.dgvFilter.Columns.Add((DataGridViewColumn)this._MiddleName.Clone());
   this.dgvFilter.Rows.Add();

   Init();
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public override void New()
  {
   frmPerson form = new frmPerson();
   form.ShowDialog(this);
   Init();
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public override void Edit()
  {
   if (this.CurrentId != 0)
   {
    Person person = Data.Tables.Persons[this.CurrentId];
    frmPerson form = new frmPerson(person);
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
     Person person = Data.Tables.Persons[this.CurrentId];
     person.Delete();
     Init();
    }
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public override void Init()
  {
   this.dgvItems.DataSource = Data.Tables.Persons.Except(Deletions.AsEnumerable()).Where(r =>
     r.Code.ToString().Contains(this.GetFilter("Code")) &&
     r.FirstName.ToUpper().Contains(this.GetFilter("FirstName").ToUpper()) &&
     r.MiddleName.ToUpper().Contains(this.GetFilter("MiddleName").ToUpper()) &&
     r.LastName.ToUpper().Contains(this.GetFilter("LastName").ToUpper())
     ).ToList();

   foreach (DataGridViewColumn column in this.dgvItems.Columns)
   {
    column.DataPropertyName = column.Name;
   }
  }
 }
}
