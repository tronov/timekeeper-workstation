using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Project.Data;
using Project.Forms.Tables;

namespace Project.Forms.Elements
{
    public partial class frmTable : Form
    {
        public frmTable()
        {
            InitializeComponent();
        }

        void Calculate()
        {
            this.dgvTable.Columns.Clear();

            DataGridViewColumn PersonName = new DataGridViewTextBoxColumn();
            PersonName.Name = "PersonName";
            PersonName.MinimumWidth = 100;
            PersonName.Width = 100;
            PersonName.Frozen = true;
            PersonName.HeaderText = "Ф. И. О.";
            this.dgvTable.Columns.Add(PersonName);

            DataGridViewColumn PersonCode = new DataGridViewTextBoxColumn();
            PersonCode.Name = "PersonCode";
            PersonCode.Width = 70;
            PersonName.Frozen = true;
            PersonCode.HeaderText = "Таб. №";
            this.dgvTable.Columns.Add(PersonCode);

            DataGridViewColumn SummaryHours = new DataGridViewTextBoxColumn();
            SummaryHours.Name = "SummaryHours";
            SummaryHours.Width = 70;
            SummaryHours.HeaderText = "Всего часов";
            SummaryHours.Tag = DateTime.Now;
            this.dgvTable.Columns.Add(SummaryHours);

            DataGridViewColumn SummaryMoney = new DataGridViewTextBoxColumn();
            SummaryMoney.Name = "SummaryMoney";
            SummaryMoney.Width = 70;
            SummaryMoney.HeaderText = "Всего к оплате";
            SummaryMoney.Tag = DateTime.Now;
            this.dgvTable.Columns.Add(SummaryMoney);

            int days = DateTime.DaysInMonth(dtpMonth.Value.Year, dtpMonth.Value.Month);

            for (int day = 1; day <= days; day++)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.Name = day.ToString();
                column.HeaderText = day.ToString();
                column.Width = 25;
                column.Tag = new DateTime(dtpMonth.Value.Year, dtpMonth.Value.Month, day);
                this.dgvTable.Columns.Add(column);
            }

            foreach (BrigadePerson brigadePerson in (bBrigade.Tag as Brigade).BrigadePersons)
            {
                Person person = brigadePerson.Person;
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewCell personName = new DataGridViewTextBoxCell();
                personName.Value = String.Format("{0} {1}. {2}.", person.LastName, person.FirstName[0], person.MiddleName[0]);
                row.Cells.Add(personName);

                DataGridViewCell personCode = new DataGridViewTextBoxCell();
                personCode.Value = person.Code;
                personCode.Tag = person;
                row.Cells.Add(personCode);

                this.dgvTable.Rows.Add(row);
            }

            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                Person person = row.Cells["PersonCode"].Tag as Person;
                List<Warranty> personWarranties = new List<Warranty>();
                float personHours = 0F;
                float personMoney = 0F;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (dgvTable.Columns[cell.ColumnIndex].Tag is DateTime)
                    {
                        DateTime date = (DateTime)dgvTable.Columns[cell.ColumnIndex].Tag;
                        float hours = 0F;
                        float money = 0F;
                        List<Warranty> warranties = (from warranty in Databases.Tables.Warranties
                                                     from executor in warranty.Executors
                                                     from labor in warranty.Labors
                                                     where
                                                     executor.PersonId == person.Id &&
                                                     labor.LaborDate.Equals(date)
                                                     select warranty).ToList();

                        personWarranties.AddRange(warranties.AsEnumerable());
                        foreach (Warranty warranty in warranties)
                        {
                            Executor executor = (from e in warranty.Executors
                                                 where e.Person.Equals(person)
                                                 select e).First();
                            float tariff = 0F;
                            switch (executor.Rank)
                            {
                                case (byte)1:
                                    tariff = executor.Profession.Rank1;
                                    break;
                                case (byte)2:
                                    tariff = executor.Profession.Rank2;
                                    break;
                                case (byte)3:
                                    tariff = executor.Profession.Rank3;
                                    break;
                                case (byte)4:
                                    tariff = executor.Profession.Rank4;
                                    break;
                                case (byte)5:
                                    tariff = executor.Profession.Rank5;
                                    break;
                                case (byte)6:
                                    tariff = executor.Profession.Rank6;
                                    break;
                                default:
                                    break;
                            }

                            foreach (Labor labor in warranty.Labors)
                            {
                                if (labor.LaborDate.Equals(date))
                                    hours += labor.Hours;
                            }

                            money += (warranty.Percent / 100) * tariff;
                        }
                        cell.Tag = warranties;
                        if (hours != 0) cell.Value = hours.ToString();
                        personHours += hours;
                        personMoney += money;
                    }
                }

                personMoney = (float)Math.Round((double)personMoney, 2);

                row.Cells["SummaryHours"].Tag = personWarranties;
                if (personHours != 0) row.Cells["SummaryHours"].Value = personHours;
                row.Cells["SummaryMoney"].Tag = personWarranties;
                if (personMoney != 0) row.Cells["SummaryMoney"].Value = personMoney;
            }
        }

        private void bBrigade_Click(object sender, EventArgs e)
        {
            frmStructure f = new frmStructure();
            f.CatalogMode = CatalogMode.Select;
            f.ShowDialog();
            if (f.ctrlStructure.SelectedBrigadeId != 0)
            {
                Brigade brigade = Databases.Tables.Brigades[f.ctrlStructure.SelectedBrigadeId];
                bBrigade.Text = String.Format("{0} / {1}", brigade.Area.Code.ToString("D2"), brigade.Code.ToString("D2"));
                bBrigade.Tag = brigade;
            }
            if (this.bBrigade.Tag != null)
                Calculate();
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            if (this.bBrigade.Tag != null)
                Calculate();
        }

        private void dgvTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvTable.Columns[e.ColumnIndex];
                DataGridViewCell cell = dgvTable[e.ColumnIndex, e.RowIndex];

                if (e.Button == MouseButtons.Right &&
                 column.Tag is DateTime &&
                 cell.Tag is List<Warranty> &&
                 cell.Value != null
                 )
                {
                    dgvTable.ClearSelection();
                    cell.Selected = true;
                    Rectangle r = dgvTable.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Point location = new Point(r.Location.X + e.Location.X, r.Location.Y + e.Location.Y);
                    this.cmsSelect.Show(dgvTable, location);
                }
            }
        }

        private void miWarranties_Click(object sender, EventArgs e)
        {
            frmWarranties form = new frmWarranties();
            form.ctrlWarranties.scMain.Panel2Collapsed = true;
            form.ctrlWarranties.Includes = (List<Warranty>)dgvTable.SelectedCells[0].Tag;
            form.ShowDialog();
            Calculate();
        }

        private void frmTable_Activated(object sender, EventArgs e)
        {
            if (this.bBrigade.Tag != null) Calculate();
        }
    }
}