using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Databases;
using Project.Forms.Tables;

namespace Project.Controls
{
 public partial class BrigadePersonsControl : TableControl
 {
  private DataGridViewColumn _Id = new DataGridViewTextBoxColumn();
  private DataGridViewColumn _PersonCode = new DataGridViewTextBoxColumn();
  private DataGridViewColumn _PersonFirstName = new DataGridViewTextBoxColumn();
  private DataGridViewColumn _PersonMiddleName = new DataGridViewTextBoxColumn();
  private DataGridViewColumn _PersonLastName = new DataGridViewTextBoxColumn();

  private int _BrigadeId = 0;
  private List<BrigadePerson> _Deletions = new List<BrigadePerson>();

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public int BrigadeId
  {
   get { return this._BrigadeId; }
   set
   {
    this._BrigadeId = value;
    Init();
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public List<BrigadePerson> Deletions
  {
   get { return this._Deletions; }
   set
   {
    this._Deletions = value;
    Init();
   }
  }

  public BrigadePersonsControl()
  {
   InitializeComponent();

   this.gbFilter.Text = "Фильтр персонала";
   this.gbItems.Text = "Персонал подразделения";
   this.gbOperations.Text = "Операции с персоналом";

   this._Id.Name = "Id";
   this._Id.Visible = false;

   this._PersonCode.Name = "PersonCode";
   this._PersonCode.HeaderText = "Таб. №";

   this._PersonLastName.Name = "PersonLastName";
   this._PersonLastName.HeaderText = "Фамилия";

   this._PersonFirstName.Name = "PersonFirstName";
   this._PersonFirstName.HeaderText = "Имя";

   this._PersonMiddleName.Name = "PersonMiddleName";
   this._PersonMiddleName.HeaderText = "Отчество";
   this._PersonMiddleName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


   this.dgvItems.Columns.Add(this._Id);
   this.dgvItems.Columns.Add(this._PersonCode);
   this.dgvItems.Columns.Add(this._PersonLastName);
   this.dgvItems.Columns.Add(this._PersonFirstName);
   this.dgvItems.Columns.Add(this._PersonMiddleName);


   this.dgvFilter.Columns.Add((DataGridViewColumn)this._PersonCode.Clone());
   this.dgvFilter.Columns.Add((DataGridViewColumn)this._PersonLastName.Clone());
   this.dgvFilter.Columns.Add((DataGridViewColumn)this._PersonFirstName.Clone());
   this.dgvFilter.Columns.Add((DataGridViewColumn)this._PersonMiddleName.Clone());
   this.dgvFilter.Rows.Add();

   this.bNew.Text = "Добавить";
   this.bDelete.Text = "Исключить";
   this.bDelete.Location = this.bEdit.Location;
   this.bEdit.Visible = false;

   Init();
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public override void New()
  {
   if (this.BrigadeId != 0)
   {
    Brigade brigade = Data.Tables.Brigades[BrigadeId];
    frmPersons form = new frmPersons();

    form.ctrlPersons.Deletions = (from person in Data.Tables.Persons.Active
             from brigadePerson in Data.Tables.BrigadePersons.Active
             where person.Equals(brigadePerson.Person)
             select person).ToList();
     
    form.CatalogMode = CatalogMode.Select;
    form.ShowDialog();
    if (form.SelectedPersonId != 0)
    {
     BrigadePerson brigadePerson = new BrigadePerson(this.BrigadeId, form.SelectedPersonId);
     Data.Tables.BrigadePersons.Insert(brigadePerson);
    }
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
     BrigadePerson brigadePerson = Data.Tables.BrigadePersons[this.CurrentId];
     brigadePerson.Delete();
     Init();
    }
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public override void Init()
  {
   this.dgvItems.DataSource = (from brigadePerson in Data.Tables.BrigadePersons.Active.Except(this.Deletions.AsEnumerable())
          where
          (brigadePerson.BrigadeId == this.BrigadeId) &&
          brigadePerson.Person.Code.ToString().Contains(this.GetFilter("PersonCode")) &&
          brigadePerson.Person.FirstName.ToUpper().Contains(this.GetFilter("PersonFirstName").ToUpper()) &&
          brigadePerson.Person.MiddleName.ToUpper().Contains(this.GetFilter("PersonMiddleName").ToUpper()) &&
          brigadePerson.Person.LastName.ToUpper().Contains(this.GetFilter("PersonLastName").ToUpper())
          select new
          {
           Id = brigadePerson.Id,
           PersonCode = brigadePerson.Person.Code,
           PersonFirstName = brigadePerson.Person.FirstName,
           PersonMiddleName = brigadePerson.Person.MiddleName,
           PersonLastName = brigadePerson.Person.LastName
          }).ToList();

   foreach (DataGridViewColumn column in this.dgvItems.Columns)
   {
    column.DataPropertyName = column.Name;
   }
  }
 }
}
