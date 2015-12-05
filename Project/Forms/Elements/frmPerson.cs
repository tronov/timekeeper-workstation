using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Databases;

namespace Project
{
 public partial class frmPerson : Form
 {
  public frmPerson()
  {
   InitializeComponent();
  }

  private Person _Person;

  public frmPerson(Person item)
  {
   InitializeComponent();
   this._Person = item;
   this.Text = "Изменение данных об сотруднике.";
   this.mtbCode.Text = item.Code.ToString("D4");
   this.tbFirstName.Text = item.FirstName;
   this.tbMiddleName.Text = item.MiddleName;
   this.tbLastName.Text = item.LastName;
  }

  private bool Check()
  {
   bool x0 = mtbCode.Text.Length != 0 ? true : false;    // codeIsSet?
   bool x1 = tbFirstName.Text.Trim().Length != 0 ? true : false;  // firstNameIsSet?
   bool x2 = tbMiddleName.Text.Trim().Length != 0 ? true : false; // middleNameIsSet?
   bool x3 = tbLastName.Text.Trim().Length != 0 ? true : false;   // lastNameIsSet?

   bool f1 = x0 && x1 && x2 && x3;        // Form is valid?

   if (!f1)
   {
    bool f2 = x1 && x2 && x3 ||        // Here is not one error?
        x1 && x3 && x0 ||
        x1 && x2 && x0 ||
        x2 && x3 && x0;

    string code = x0 ? "" : " табельный номер";
    string fn = x1 ? "" : " имя";
    string ln = x3 ? "" : " фамилию";
    string mn = x2 ? "" : " отчество";
    string and = " и";

    List<string> mes = new List<string>();

    if (!x0) mes.Add(code);
    if (!x3) mes.Add(ln);
    if (!x1) mes.Add(fn);
    if (!x2) mes.Add(mn);

    int c = mes.Count;

    if (c > 1)
    {
     for (int i = 0; i < c - 2; i++)
     {
      string s = (string)mes[i] + ",";
      mes[i] = s;
     }

     mes.Insert(c - 1, and);
    }

    string message = "Необходимо указать";
    foreach (string s in mes) message += s;
    message += " сотрудника.";

    (new ToolTip()).Show(message, this, bSave.Location, 2000);

    return false;
   }
   else
   {
    short code = Convert.ToInt16(mtbCode.Text);
    string firstName = tbFirstName.Text.Trim();
    string middleName = tbMiddleName.Text.Trim();
    string lastName = tbLastName.Text.Trim();

    if (!Data.Tables.Persons.Count(r => r.Code.Equals(code)).Equals(0) && this._Person == null)
    {
     
      (new ToolTip()).Show("Указанный табельный номер уже присвоен другому сотруднику.", this, bSave.Location, 2000);
     mtbCode.Focus();
     return false;
    }
    else return true;
   }
  }

  private void mtbCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
  {
   (new ToolTip()).Show("Табельный номер сотрудника должен состоять из четырех цифр.", this, mtbCode.Location, 2000);
  }

  private void mtbCode_Validating(object sender, CancelEventArgs e)
  {
   if (mtbCode.Text.Length != 0)
   {
    int code;
    if (!Int32.TryParse(mtbCode.Text, out code))
    {
     (new ToolTip()).Show("Табельный номер сотрудника должен состоять из четырех цифр.", this, mtbCode.Location, 2000);
     mtbCode.Clear();
     mtbCode.Focus();
     mtbCode.BringToFront();
    }
    else mtbCode.Text = code.ToString("D4");
   }
  }

  private void bSave_Click(object sender, EventArgs e)
  {
   if (Check())
   {
    short code = Convert.ToInt16(mtbCode.Text);
    string firstName = tbFirstName.Text;
    string middleName = tbMiddleName.Text;
    string lastName = tbLastName.Text;

    Person person = new Person(code, firstName, middleName, lastName);
    if (this._Person == null) Data.Tables.Persons.Insert(person);
    else this._Person.Update(person);

    this.DialogResult = DialogResult.OK;
    this.Close();
   }
  }

  private void bCancel_Click(object sender, EventArgs e)
  {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
  }
 }
}
