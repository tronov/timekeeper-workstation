using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Project.Data;
using Project.Forms.Tables;

namespace Project
{
    public partial class PersonProfessionForm : Form
    {
        private Person _person;
        private PersonProfession _personProfession;

        public PersonProfessionForm(Person person)
        {
            InitializeComponent();
            _person = person;
        }

        public PersonProfessionForm(PersonProfession personProfession)
        {
            InitializeComponent();
            Text = "Изменение квалификации сотрудника.";
            _personProfession = personProfession;
            _person = personProfession.Person;
            bProfessionCode.Text = personProfession.Profession.Code.ToString();
            bProfessionCode.Tag = personProfession.Profession;
            tbProfessionTitle.Text = personProfession.Profession.Title;
            cbRank.Text = personProfession.Rank.ToString();
        }

        private void bProfessionCode_Click(object sender, EventArgs e)
        {
            ProfessionsForm f = new ProfessionsForm();

            f.professionsControl.CatalogMode = CatalogMode.Select;

            IEnumerable<Profession> ds = f.professionsControl.dgvItems.DataSource as IEnumerable<Profession>;
            var nds = ds.Except(_person.PersonProfessions.Select(r => r.Profession)).ToList();
            f.professionsControl.dgvItems.DataSource = nds;
            f.ShowDialog(this);
            if (f.professionsControl.CurrentId != 0)
            {
                Profession p = Databases.Tables.Professions[f.professionsControl.CurrentId];
                bProfessionCode.Text = p.Code.ToString();
                bProfessionCode.Tag = p;
                tbProfessionTitle.Text = p.Title;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                int personId = _person.Id;
                int professionId = (bProfessionCode.Tag as Profession).Id;
                byte rank = Convert.ToByte(cbRank.Text);
                PersonProfession personProfession = new PersonProfession(personId, professionId, rank);

                if (_personProfession == null)
                    Databases.Tables.PersonProfessions.Insert(personProfession);
                else _personProfession.Update(personProfession);

                Close();
            }
        }

        private bool Check()
        {
            bool x1 = bProfessionCode.Text.Length.Equals(0) ? false : true;
            bool x2 = cbRank.Text.Length.Equals(0) ? false : true;
            return (x1 && x2);
        }
    }
}
