﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Project.Controls;
using Project.Data;
using Project.Forms.Tables;

namespace Project.Forms.Elements
{
    public partial class WarrantyForm : Form
    {
        private Warranty _warranty;

        private int WarrantyId
        {
            get
            {
                if (_warranty == null) return 0;
                return _warranty.Id;
            }
        }

        private int _newExecutorId = -1;
        private int _newLaborId = -1;
        private int _newPositionId = -1;
        private float ChainTariff
        {
            get
            {
                float summMoney = 0F;
                float chainTariff = 0F;
                foreach (DataGridViewRow row in ctrlExecutors.dgvItems.Rows)
                {
                    if (row.Cells["ProfessionCode"].Tag != null && row.Cells["Rank"].Value != null)
                    {
                        Profession profession = (row.Cells["ProfessionCode"].Tag as PersonProfession).Profession;
                        float personTariff = 0F;
                        switch (Convert.ToByte(row.Cells["Rank"].Value))
                        {
                            case 1:
                                personTariff = profession.Rank1;
                                break;
                            case 2:
                                personTariff = profession.Rank2;
                                break;
                            case 3:
                                personTariff = profession.Rank3;
                                break;
                            case 4:
                                personTariff = profession.Rank4;
                                break;
                            case 5:
                                personTariff = profession.Rank5;
                                break;
                            case 6:
                                personTariff = profession.Rank6;
                                break;
                            default:
                                break;
                        }
                        summMoney += personTariff;
                    }
                }
                chainTariff = (float)Math.Round(summMoney / (ctrlExecutors.dgvItems.Rows.Count - 1), 3);
                return chainTariff;
            }
        }
        private float Percent
        {
            get
            {
                float summaryLaborTime = 0F;
                float summaryNormTime = 0F;
                foreach (DataGridViewRow row in ctrlLabors.dgvItems.Rows)
                {
                    if (row.Cells["Hours"].Value != null)
                        summaryLaborTime += Convert.ToSingle(row.Cells["Hours"].Value);
                }
                summaryLaborTime = summaryLaborTime * (ctrlExecutors.dgvItems.Rows.Count - 1);
                foreach (DataGridViewRow row in ctrlPositions.dgvItems.Rows)
                {
                    if (row.Cells["Number"].Value != null && row.Cells["Norm"].Value != null)
                        summaryNormTime +=
                         Convert.ToSingle(row.Cells["Number"].Value) *
                         Convert.ToSingle(row.Cells["Norm"].Value);
                }
                return
                 summaryLaborTime != 0 ?
                 (float)Math.Round((double)summaryNormTime * 100 / summaryLaborTime, 3) : 0;
            }
        }

        public WarrantyForm()
        {
            InitializeComponent();
            ctrlExecutors.Enabled = false;
            ctrlLabors.Enabled = false;
            ctrlPositions.Enabled = false;
            bSave.Enabled = false;
            Sinc();
        }

        private void Sinc()
        {
            ctrlExecutors.dgvItems.CellValueChanged += Executors_CellValueChanged;
            ctrlExecutors.dgvItems.UserAddedRow += Executors_UserAddedRow;
            ctrlExecutors.dgvItems.RowsRemoved += PriceNeeded;
            ctrlLabors.dgvItems.CellValueChanged += Labors_CellValueChanged;
            ctrlLabors.dgvItems.UserAddedRow += Labors_UserAddedRow;
            ctrlLabors.dgvItems.RowsRemoved += PriceNeeded;
            ctrlPositions.dgvItems.CellValueChanged += Positions_CellValueChanged;
            ctrlPositions.dgvItems.UserAddedRow += Positions_UserAddedRow;
        }

        void PriceNeeded(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculatePrice();
        }

        void CalculatePrice()
        {
            foreach (DataGridViewRow row in ctrlPositions.dgvItems.Rows)
            {
                if (row.Cells["Norm"].Value != null)
                {
                    float norm = Convert.ToSingle(row.Cells["Norm"].Value);
                    row.Cells["Price"].Value = (float)Math.Round((double)norm * ChainTariff, 3);
                }
            }
            lPercentTitle.Visible = true;
            lPercent.Text = String.Format("{0}%", Percent);
        }

        public WarrantyForm(Warranty warranty)
        {
            InitializeComponent();
            Text = "Изменение наряда.";
            _warranty = warranty;
            List<Position> positions = warranty.Positions.ToList();
            List<Executor> executors = warranty.Executors.ToList();
            List<Labor> labors = warranty.Labors.ToList();

            tbCustomer.Text = warranty.Customer;
            mtbOrder.Text = warranty.Order.ToString("D4");
            Brigade brigade = Databases.Tables.Brigades[warranty.BrigadeId];
            bBrigade.Tag = brigade;
            bBrigade.Text = String.Format("{0} / {1}", brigade.Area.Code.ToString("D2"), brigade.Code.ToString("D2"));

            foreach (Executor executor in executors)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell executorId = new DataGridViewTextBoxCell();
                DataGridViewCell personCode = new DataGridViewButtonCell();
                DataGridViewCell personLastName = new DataGridViewTextBoxCell();
                DataGridViewCell personFirstName = new DataGridViewTextBoxCell();
                DataGridViewCell personMiddleName = new DataGridViewTextBoxCell();
                DataGridViewCell professionCode = new DataGridViewButtonCell();
                DataGridViewCell rank = new DataGridViewTextBoxCell();

                executorId.Value = executor.Id;
                personCode.Value = executor.Person.Code;
                personCode.Tag = executor.Person;
                personLastName.Value = executor.Person.LastName;
                personFirstName.Value = executor.Person.FirstName;
                personMiddleName.Value = executor.Person.MiddleName;
                professionCode.Tag = Databases.Tables.PersonProfessions.First(r => r.Profession.Code == executor.Profession.Code);
                professionCode.Value = executor.Profession.Code;
                rank.Value = executor.Rank;

                row.Cells.Add(executorId);
                row.Cells.Add(personCode);
                row.Cells.Add(personLastName);
                row.Cells.Add(personFirstName);
                row.Cells.Add(personMiddleName);
                row.Cells.Add(professionCode);
                row.Cells.Add(rank);

                ctrlExecutors.dgvItems.Rows.Add(row);
            }
            foreach (Labor labor in labors)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewCell laborId = new DataGridViewTextBoxCell();
                DataGridViewCell laborDate = new CalendarCell();
                DataGridViewCell hours = new DataGridViewTextBoxCell();

                laborId.Value = labor.Id;
                laborDate.Value = labor.LaborDate;
                hours.Value = labor.Hours;

                row.Cells.Add(laborId);
                row.Cells.Add(laborDate);
                row.Cells.Add(hours);
                ctrlLabors.dgvItems.Rows.Add(row);
            }
            foreach (Position position in positions)
            {
                ctrlPositions.dgvItems.Rows
                 .Add(position.Id, position.Title, position.Draw, position.Matherial, position.Number, position.Mass, position.Norm, position.Price);
            }
            Sinc();
            CalculatePrice();
        }

        private void bBrigade_Click(object sender, EventArgs e)
        {
            StructureForm f = new StructureForm();
            f.CatalogMode = CatalogMode.Select;
            f.ShowDialog();
            if (f.ctrlStructure.SelectedBrigadeId != 0)
            {
                Brigade brigade = Databases.Tables.Brigades[f.ctrlStructure.SelectedBrigadeId];
                bBrigade.Text = String.Format("{0} / {1}", brigade.Area.Code.ToString("D2"), brigade.Code.ToString("D2"));

                if (bBrigade.Tag != null)
                    if (!(bBrigade.Tag as Brigade).Equals(brigade))
                    {
                        ctrlExecutors.dgvItems.Rows.Clear();
                        ctrlLabors.dgvItems.Rows.Clear();
                    }

                bBrigade.Tag = brigade;
                ctrlExecutors.BrigadeId = brigade.Id;
                ctrlExecutors.Enabled = true;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                string customer = tbCustomer.Text;
                short order = Convert.ToInt16(mtbOrder.Text);
                DateTime warrantyDate = DateTime.Now.Date;
                int areaId = (bBrigade.Tag as Brigade).AreaId;
                int brigadeId = (bBrigade.Tag as Brigade).Id;
                float percent = Percent;

                Warranty warranty = new Warranty(customer, order, percent, warrantyDate, areaId, brigadeId);

                if (WarrantyId == 0)
                {
                    Databases.Tables.Warranties.Insert(warranty);
                    _warranty = warranty;
                }
                else
                {
                    if (!warranty.Equals(_warranty))
                        _warranty.Update(warranty);
                }

                List<Executor> executors = new List<Executor>();
                List<Labor> labors = new List<Labor>();
                List<Position> positions = new List<Position>();

                foreach (DataGridViewRow executorsRow in ctrlExecutors.dgvItems.Rows)
                {
                    if (executorsRow.Cells["ExecutorId"].Value != null)
                    {
                        int executorId = Convert.ToInt32(executorsRow.Cells["ExecutorId"].Value);
                        int personId = (executorsRow.Cells["PersonCode"].Tag as Person).Id;
                        int professionId = (executorsRow.Cells["ProfessionCode"].Tag as PersonProfession).ProfessionId;
                        byte rank = Convert.ToByte(executorsRow.Cells["Rank"].Value);

                        Executor executor = new Executor(WarrantyId, personId, professionId, rank);

                        if (executorId < 0)
                        {
                            Databases.Tables.Executors.Insert(executor);
                            executors.Add(executor);
                        }
                        else if (executorId > 0)
                        {
                            Databases.Tables.Executors[executorId].Update(executor);
                            executors.Add(executor);
                        }
                    }
                }

                foreach (DataGridViewRow laborsRow in ctrlLabors.dgvItems.Rows)
                {
                    if (laborsRow.Cells["LaborId"].Value != null)
                    {
                        int laborId = Convert.ToInt32(laborsRow.Cells["LaborId"].Value);
                        DateTime laborDate = Convert.ToDateTime(laborsRow.Cells["LaborDate"].Value).Date;
                        float hours = Convert.ToSingle(laborsRow.Cells["Hours"].Value);

                        Labor labor = new Labor(WarrantyId, laborDate, hours);

                        if (laborId < 0)
                        {
                            Databases.Tables.Labors.Insert(labor);
                            labors.Add(labor);
                        }
                        else if (laborId > 0)
                        {
                            Databases.Tables.Labors[laborId].Update(labor);
                            labors.Add(labor);
                        }
                    }

                }

                foreach (DataGridViewRow positionsRow in ctrlPositions.dgvItems.Rows)
                {
                    if (positionsRow.Cells["Id"].Value != null)
                    {
                        int positionId = Convert.ToInt32(positionsRow.Cells["Id"].Value);
                        string title = positionsRow.Cells["Title"].Value.ToString();
                        string draw = positionsRow.Cells["Draw"].Value.ToString();
                        string matherial = positionsRow.Cells["Matherial"].Value.ToString();
                        int number = Convert.ToInt32(positionsRow.Cells["Number"].Value);
                        float mass = Convert.ToSingle(positionsRow.Cells["Mass"].Value);
                        float norm = Convert.ToSingle(positionsRow.Cells["Norm"].Value);
                        float price = Convert.ToSingle(positionsRow.Cells["Price"].Value);

                        Position position = new Position(WarrantyId, title, draw, matherial, number, mass, norm, price);

                        if (positionId < 0)
                        {
                            Databases.Tables.Positions.Insert(position);
                            positions.Add(position);
                        }
                        else if (positionId > 0)
                        {
                            Databases.Tables.Positions[positionId].Update(position);
                            positions.Add(position);
                        }

                    }
                }

                if (_warranty != null)
                {
                    foreach (Executor executor in _warranty.Executors.ToList().Except(executors.AsEnumerable()))
                        executor.Delete();

                    foreach (Position position in _warranty.Positions.ToList().Except(positions.AsEnumerable()))
                        position.Delete();
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool Check()
        {
            if (tbCustomer.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать заказчика", this, tbCustomer.Location, 2000);
                return false;
            }
            if (mtbOrder.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать номер заказа", this, mtbOrder.Location, 2000);
                return false;
            }
            return true;
        }

        void Executors_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            CalculatePrice();
            ctrlLabors.Enabled = true;
        }

        void Executors_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculatePrice();
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridView grid = sender as DataGridView;
                DataGridViewColumn column = grid.Columns[e.ColumnIndex];
                DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];
                if (column.Name == "PersonCode")
                {
                    row.Cells["ProfessionCode"].Value = null;
                    row.Cells["ProfessionCode"].Tag = null;
                    row.Cells["Rank"].Value = null;
                }
                if (row.Cells["ExecutorId"].Value == null)
                {
                    row.Cells["ExecutorId"].Value = _newExecutorId;
                    _newExecutorId--;
                }
            }
        }

        void Labors_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            CalculatePrice();
            ctrlPositions.Enabled = true;
        }

        void Labors_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculatePrice();
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];

                if (row.Cells["LaborId"].Value == null)
                {
                    row.Cells["LaborId"].Value = _newLaborId;
                    _newLaborId--;
                }
            }
        }

        void Positions_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            CalculatePrice();
            bSave.Enabled = true;
        }

        void Positions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculatePrice();
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridView grid = sender as DataGridView;
                DataGridViewColumn column = grid.Columns[e.ColumnIndex];
                DataGridViewRow row = grid.Rows[e.RowIndex];
                DataGridViewCell cell = grid[e.ColumnIndex, e.RowIndex];
                if (row.Cells["Id"].Value == null)
                {
                    row.Cells["Id"].Value = _newPositionId;
                    _newPositionId--;
                }
            }
        }
    }
}