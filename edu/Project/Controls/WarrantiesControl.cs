using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Databases;
using Project.Forms.Elements;

namespace Project.Controls
{
    public partial class WarrantiesControl : TableControl
    {
        private DataGridViewColumn _Id = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Customer = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Order = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _Percent = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _WarrantyDate = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _AreaCode = new DataGridViewTextBoxColumn();
        private DataGridViewColumn _BrigadeCode = new DataGridViewTextBoxColumn();

        private System.Collections.Generic.List<Warranty> _Includes;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Collections.Generic.List<Warranty> Includes
        {
            set
            {
                this._Includes = value;
                Init();
            }
        }

        public WarrantiesControl()
        {
            InitializeComponent();

            this._Id.Name = "Id";
            this._Id.Visible = false;

            this._Customer.Name = "Customer";
            this._Customer.HeaderText = "Заказчик";
            this._Customer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this._Order.Name = "Order";
            this._Order.HeaderText = "Заказ";

            this._WarrantyDate.Name = "WarrantyDate";
            this._WarrantyDate.HeaderText = "Дата документа";

            this._AreaCode.Name = "AreaCode";
            this._AreaCode.HeaderText = "Шифр участка";

            this._BrigadeCode.Name = "BrigadeCode";
            this._BrigadeCode.HeaderText = "Шифр бригады";

            this._Percent.Name = "Percent";
            this._Percent.HeaderText = "Процент";

            this.dgvItems.Columns.Add(this._Id);
            this.dgvItems.Columns.Add(this._Customer);
            this.dgvItems.Columns.Add(this._Order);
            this.dgvItems.Columns.Add(this._WarrantyDate);
            this.dgvItems.Columns.Add(this._AreaCode);
            this.dgvItems.Columns.Add(this._BrigadeCode);
            this.dgvItems.Columns.Add(this._Percent);

            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Customer.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Order.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._WarrantyDate.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._AreaCode.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._BrigadeCode.Clone());
            this.dgvFilter.Columns.Add((DataGridViewColumn)this._Percent.Clone());
            this.dgvFilter.Rows.Add();

            Init();

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void New()
        {
            frmWarranty form = new frmWarranty();
            if (form.ShowDialog(this) == DialogResult.OK)
                Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Edit()
        {
            if (this.CurrentId != 0)
            {
                Warranty warranty = Data.Tables.Warranties[this.CurrentId];
                frmWarranty form = new frmWarranty(warranty);
                if (form.ShowDialog(this) == DialogResult.OK)
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
                    Warranty warranty = Data.Tables.Warranties[this.CurrentId];
                    warranty.Delete();
                    Init();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Init()
        {
            System.Collections.Generic.List<Warranty> Source;
            if (this._Includes != null) Source = this._Includes;
            else Source = Data.Tables.Warranties.ToList();

            this.dgvItems.DataSource = (from warranty in Source
                                        where
                                        warranty.Customer.ToUpper().Contains(this.GetFilter("Customer").ToUpper()) &&
                                        warranty.Order.ToString().Contains(this.GetFilter("Order")) &&
                                        warranty.WarrantyDate.ToString().Contains(this.GetFilter("WarrantyDate")) &&
                                        warranty.Percent.ToString().Contains(this.GetFilter("Percent")) &&
                                        Data.Tables.Areas[warranty.AreaId].Code.ToString().Contains(this.GetFilter("AreaCode")) &&
                                        Data.Tables.Brigades[warranty.BrigadeId].Code.ToString().Contains(this.GetFilter("BrigadeCode"))
                                        select new
                                        {
                                            Id = warranty.Id,
                                            Customer = warranty.Customer,
                                            Order = warranty.Order,
                                            WarrantyDate = warranty.WarrantyDate.ToShortDateString(),
                                            AreaCode = Data.Tables.Areas[warranty.AreaId].Code,
                                            BrigadeCode = Data.Tables.Brigades[warranty.BrigadeId].Code,
                                            Percent = warranty.Percent
                                        }).ToList();

            foreach (DataGridViewColumn column in this.dgvItems.Columns)
            {
                column.DataPropertyName = column.Name;
            }
        }

    }
}
