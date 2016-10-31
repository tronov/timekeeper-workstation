using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Project.Data;
using Project.Forms.Tables;

namespace Project
{
    public partial class frmPersonProfession : Form
    {
        private Person _Person;
        private PersonProfession _PersonProfession;

        public frmPersonProfession(Person person)
        {
            InitializeComponent();
            this._Person = person;
        }

        public frmPersonProfession(PersonProfession personProfession)
        {
            InitializeComponent();
            this.Text = "Изменение квалификации сотрудника.";
            this._PersonProfession = personProfession;
            this._Person = personProfession.Person;
            this.bProfessionCode.Text = personProfession.Profession.Code.ToString();
            this.bProfessionCode.Tag = personProfession.Profession;
            this.tbProfessionTitle.Text = personProfession.Profession.Title;
            this.cbRank.Text = personProfession.Rank.ToString();
        }

        private void bProfessionCode_Click(object sender, EventArgs e)
        {
            frmProfessions f = new frmProfessions();

            f.professionsControl.CatalogMode = CatalogMode.Select;

            IEnumerable<Profession> ds = f.professionsControl.dgvItems.DataSource as IEnumerable<Profession>;
            var nds = ds.Except(this._Person.PersonProfessions.Select(r => r.Profession)).ToList();
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
                int PersonId = this._Person.Id;
                int ProfessionId = (this.bProfessionCode.Tag as Profession).Id;
                byte Rank = Convert.ToByte(cbRank.Text);
                PersonProfession personProfession = new PersonProfession(PersonId, ProfessionId, Rank);

                if (this._PersonProfession == null)
                    Databases.Tables.PersonProfessions.Insert(personProfession);
                else this._PersonProfession.Update(personProfession);

                this.Close();
            }
        }

        private bool Check()
        {
            bool x1 = this.bProfessionCode.Text.Length.Equals(0) ? false : true;
            bool x2 = this.cbRank.Text.Length.Equals(0) ? false : true;
            return (x1 && x2);
        }
    }
}
