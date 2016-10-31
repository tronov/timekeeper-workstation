using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Project.Controls;
using Project.Databases;
using Project.Forms.Tables;

namespace Project.Forms.Elements
{
    public partial class frmWarranty : Form
    {
        private Warranty _Warranty;

        private int _WarrantyId
        {
            get
            {
                if (this._Warranty == null) return 0;
                else return this._Warranty.Id;
            }
        }

        private int _newExecutorId = -1;
        private int _newLaborId = -1;
        private int _newPositionId = -1;
        private float _chainTariff
        {
            get
            {
                float summMoney = 0F;
                float chainTariff = 0F;
                foreach (DataGridViewRow row in this.ctrlExecutors.dgvItems.Rows)
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
                chainTariff = (float)Math.Round((double)(summMoney / (this.ctrlExecutors.dgvItems.Rows.Count - 1)), 3);
                return chainTariff;
            }
        }
        private float _percent
        {
            get
            {
                float summaryLaborTime = 0F;
                float summaryNormTime = 0F;
                foreach (DataGridViewRow row in this.ctrlLabors.dgvItems.Rows)
                {
                    if (row.Cells["Hours"].Value != null)
                        summaryLaborTime += Convert.ToSingle(row.Cells["Hours"].Value);
                }
                summaryLaborTime = summaryLaborTime * (this.ctrlExecutors.dgvItems.Rows.Count - 1);
                foreach (DataGridViewRow row in this.ctrlPositions.dgvItems.Rows)
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

        public frmWarranty()
        {
            InitializeComponent();
            this.ctrlExecutors.Enabled = false;
            this.ctrlLabors.Enabled = false;
            this.ctrlPositions.Enabled = false;
            this.bSave.Enabled = false;
            Sinc();
        }

        private void Sinc()
        {
            this.ctrlExecutors.dgvItems.CellValueChanged += new DataGridViewCellEventHandler(Executors_CellValueChanged);
            this.ctrlExecutors.dgvItems.UserAddedRow += new DataGridViewRowEventHandler(Executors_UserAddedRow);
            this.ctrlExecutors.dgvItems.RowsRemoved += new DataGridViewRowsRemovedEventHandler(PriceNeeded);
            this.ctrlLabors.dgvItems.CellValueChanged += new DataGridViewCellEventHandler(Labors_CellValueChanged);
            this.ctrlLabors.dgvItems.UserAddedRow += new DataGridViewRowEventHandler(Labors_UserAddedRow);
            this.ctrlLabors.dgvItems.RowsRemoved += new DataGridViewRowsRemovedEventHandler(PriceNeeded);
            this.ctrlPositions.dgvItems.CellValueChanged += new DataGridViewCellEventHandler(Positions_CellValueChanged);
            this.ctrlPositions.dgvItems.UserAddedRow += new DataGridViewRowEventHandler(Positions_UserAddedRow);
        }

        void PriceNeeded(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculatePrice();
        }

        void CalculatePrice()
        {
            foreach (DataGridViewRow row in this.ctrlPositions.dgvItems.Rows)
            {
                if (row.Cells["Norm"].Value != null)
                {
                    float norm = Convert.ToSingle(row.Cells["Norm"].Value);
                    row.Cells["Price"].Value = (float)Math.Round((double)norm * this._chainTariff, 3);
                }
            }
            this.lPercentTitle.Visible = true;
            this.lPercent.Text = String.Format("{0}%", this._percent);
        }

        public frmWarranty(Warranty warranty)
        {
            InitializeComponent();
            this.Text = "Изменение наряда.";
            this._Warranty = warranty;
            List<Position> positions = warranty.Positions.ToList();
            List<Executor> executors = warranty.Executors.ToList();
            List<Labor> labors = warranty.Labors.ToList();

            this.tbCustomer.Text = warranty.Customer;
            this.mtbOrder.Text = warranty.Order.ToString("D4");
            Brigade brigade = Data.Tables.Brigades[warranty.BrigadeId];
            this.bBrigade.Tag = brigade;
            this.bBrigade.Text = String.Format("{0} / {1}", brigade.Area.Code.ToString("D2"), brigade.Code.ToString("D2"));

            foreach (Executor executor in executors)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell ExecutorId = new DataGridViewTextBoxCell();
                DataGridViewCell PersonCode = new DataGridViewButtonCell();
                DataGridViewCell PersonLastName = new DataGridViewTextBoxCell();
                DataGridViewCell PersonFirstName = new DataGridViewTextBoxCell();
                DataGridViewCell PersonMiddleName = new DataGridViewTextBoxCell();
                DataGridViewCell ProfessionCode = new DataGridViewButtonCell();
                DataGridViewCell Rank = new DataGridViewTextBoxCell();

                ExecutorId.Value = executor.Id;
                PersonCode.Value = executor.Person.Code;
                PersonCode.Tag = executor.Person;
                PersonLastName.Value = executor.Person.LastName;
                PersonFirstName.Value = executor.Person.FirstName;
                PersonMiddleName.Value = executor.Person.MiddleName;
                ProfessionCode.Tag = Data.Tables.PersonProfessions.First(r => r.Profession.Code == executor.Profession.Code);
                ProfessionCode.Value = executor.Profession.Code;
                Rank.Value = executor.Rank;

                row.Cells.Add(ExecutorId);
                row.Cells.Add(PersonCode);
                row.Cells.Add(PersonLastName);
                row.Cells.Add(PersonFirstName);
                row.Cells.Add(PersonMiddleName);
                row.Cells.Add(ProfessionCode);
                row.Cells.Add(Rank);

                this.ctrlExecutors.dgvItems.Rows.Add(row);
            }
            foreach (Labor labor in labors)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewCell LaborId = new DataGridViewTextBoxCell();
                DataGridViewCell LaborDate = new CalendarCell();
                DataGridViewCell Hours = new DataGridViewTextBoxCell();

                LaborId.Value = labor.Id;
                LaborDate.Value = labor.LaborDate;
                Hours.Value = labor.Hours;

                row.Cells.Add(LaborId);
                row.Cells.Add(LaborDate);
                row.Cells.Add(Hours);
                this.ctrlLabors.dgvItems.Rows.Add(row);
            }
            foreach (Position position in positions)
            {
                this.ctrlPositions.dgvItems.Rows
                 .Add(position.Id, position.Title, position.Draw, position.Matherial, position.Number, position.Mass, position.Norm, position.Price);
            }
            Sinc();
            CalculatePrice();
        }

        private void bBrigade_Click(object sender, EventArgs e)
        {
            frmStructure f = new frmStructure();
            f.CatalogMode = CatalogMode.Select;
            f.ShowDialog();
            if (f.ctrlStructure.SelectedBrigadeId != 0)
            {
                Brigade brigade = Data.Tables.Brigades[f.ctrlStructure.SelectedBrigadeId];
                bBrigade.Text = String.Format("{0} / {1}", brigade.Area.Code.ToString("D2"), brigade.Code.ToString("D2"));

                if (bBrigade.Tag != null)
                    if (!(bBrigade.Tag as Brigade).Equals(brigade))
                    {
                        this.ctrlExecutors.dgvItems.Rows.Clear();
                        this.ctrlLabors.dgvItems.Rows.Clear();
                    }

                bBrigade.Tag = brigade;
                this.ctrlExecutors.BrigadeId = brigade.Id;
                this.ctrlExecutors.Enabled = true;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                string customer = this.tbCustomer.Text;
                short order = Convert.ToInt16(this.mtbOrder.Text);
                DateTime warrantyDate = DateTime.Now.Date;
                int areaId = (this.bBrigade.Tag as Brigade).AreaId;
                int brigadeId = (this.bBrigade.Tag as Brigade).Id;
                float percent = this._percent;

                Warranty warranty = new Warranty(customer, order, percent, warrantyDate, areaId, brigadeId);

                if (this._WarrantyId == 0)
                {
                    Data.Tables.Warranties.Insert(warranty);
                    this._Warranty = warranty;
                }
                else
                {
                    if (!warranty.Equals(this._Warranty))
                        this._Warranty.Update(warranty);
                }

                List<Executor> executors = new List<Executor>();
                List<Labor> labors = new List<Labor>();
                List<Position> positions = new List<Position>();

                foreach (DataGridViewRow executorsRow in this.ctrlExecutors.dgvItems.Rows)
                {
                    if (executorsRow.Cells["ExecutorId"].Value != null)
                    {
                        int executorId = Convert.ToInt32(executorsRow.Cells["ExecutorId"].Value);
                        int personId = (executorsRow.Cells["PersonCode"].Tag as Person).Id;
                        int professionId = (executorsRow.Cells["ProfessionCode"].Tag as PersonProfession).ProfessionId;
                        byte rank = Convert.ToByte(executorsRow.Cells["Rank"].Value);

                        Executor executor = new Executor(this._WarrantyId, personId, professionId, rank);

                        if (executorId < 0)
                        {
                            Data.Tables.Executors.Insert(executor);
                            executors.Add(executor);
                        }
                        else if (executorId > 0)
                        {
                            Data.Tables.Executors[executorId].Update(executor);
                            executors.Add(executor);
                        }
                    }
                }

                foreach (DataGridViewRow laborsRow in this.ctrlLabors.dgvItems.Rows)
                {
                    if (laborsRow.Cells["LaborId"].Value != null)
                    {
                        int laborId = Convert.ToInt32(laborsRow.Cells["LaborId"].Value);
                        DateTime laborDate = Convert.ToDateTime(laborsRow.Cells["LaborDate"].Value).Date;
                        float hours = Convert.ToSingle(laborsRow.Cells["Hours"].Value);

                        Labor labor = new Labor(this._WarrantyId, laborDate, hours);

                        if (laborId < 0)
                        {
                            Data.Tables.Labors.Insert(labor);
                            labors.Add(labor);
                        }
                        else if (laborId > 0)
                        {
                            Data.Tables.Labors[laborId].Update(labor);
                            labors.Add(labor);
                        }
                    }

                }

                foreach (DataGridViewRow positionsRow in this.ctrlPositions.dgvItems.Rows)
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

                        Position position = new Position(this._WarrantyId, title, draw, matherial, number, mass, norm, price);

                        if (positionId < 0)
                        {
                            Data.Tables.Positions.Insert(position);
                            positions.Add(position);
                        }
                        else if (positionId > 0)
                        {
                            Data.Tables.Positions[positionId].Update(position);
                            positions.Add(position);
                        }

                    }
                }

                if (this._Warranty != null)
                {
                    foreach (Executor executor in this._Warranty.Executors.ToList().Except(executors.AsEnumerable()))
                        executor.Delete();

                    foreach (Position position in this._Warranty.Positions.ToList().Except(positions.AsEnumerable()))
                        position.Delete();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool Check()
        {
            if (this.tbCustomer.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать заказчика", this, this.tbCustomer.Location, 2000);
                return false;
            }
            if (this.mtbOrder.Text.Length == 0)
            {
                (new ToolTip()).Show("Необходимо указать номер заказа", this, this.mtbOrder.Location, 2000);
                return false;
            }
            return true;
        }

        void Executors_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            CalculatePrice();
            this.ctrlLabors.Enabled = true;
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
                    row.Cells["ExecutorId"].Value = this._newExecutorId;
                    this._newExecutorId--;
                }
            }
        }

        void Labors_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            CalculatePrice();
            this.ctrlPositions.Enabled = true;
        }

        void Labors_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculatePrice();
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];

                if (row.Cells["LaborId"].Value == null)
                {
                    row.Cells["LaborId"].Value = this._newLaborId;
                    this._newLaborId--;
                }
            }
        }

        void Positions_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            CalculatePrice();
            this.bSave.Enabled = true;
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
                    row.Cells["Id"].Value = this._newPositionId;
                    this._newPositionId--;
                }
            }
        }
    }
}
