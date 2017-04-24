using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Data;
using Project.Forms.Elements;

namespace Project.Controls
{
    public partial class WarrantiesControl : TableControl
    {

        private List<Warranty> _includes;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Warranty> Includes
        {
            set
            {
                _includes = value;
                Init();
            }
        }

        public WarrantiesControl()
        {
            InitializeComponent();

            var id = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                Visible = false
            };

            var customer = new DataGridViewTextBoxColumn
            {
                Name = "Customer",
                HeaderText = "Заказчик",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            var order = new DataGridViewTextBoxColumn
            {
                Name = "Order",
                HeaderText = "Заказ"
            };

            var warrantyDate = new DataGridViewTextBoxColumn
            {
                Name = "WarrantyDate",
                HeaderText = "Дата документа"
            };

            var areaCode = new DataGridViewTextBoxColumn
            {
                Name = "AreaCode",
                HeaderText = "Шифр участка"
            };

            var brigadeCode = new DataGridViewTextBoxColumn
            {
                Name = "BrigadeCode",
                HeaderText = "Шифр бригады"
            };

            var percent = new DataGridViewTextBoxColumn
            {
                Name = "Percent",
                HeaderText = "Процент"
            };

            dgvItems.Columns.Add(id);
            dgvItems.Columns.Add(customer);
            dgvItems.Columns.Add(order);
            dgvItems.Columns.Add(warrantyDate);
            dgvItems.Columns.Add(areaCode);
            dgvItems.Columns.Add(brigadeCode);
            dgvItems.Columns.Add(percent);

            dgvFilter.Columns.Add(customer.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(order.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(warrantyDate.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(areaCode.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(brigadeCode.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(percent.Clone() as DataGridViewColumn);
            dgvFilter.Rows.Add();

            Init();

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void New()
        {
            var form = new WarrantyForm();
            if (form.ShowDialog(this) == DialogResult.OK)
                Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Edit()
        {
            if (CurrentId == 0) return;

            var warranty = Databases.Tables.Warranties[CurrentId];
            var form = new WarrantyForm(warranty);
            if (form.ShowDialog(this) == DialogResult.OK)
                Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Delete()
        {
            if (CurrentId == 0) return;

            if (!MessageBox
                .Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.OKCancel)
                .Equals(DialogResult.OK)) return;

            var warranty = Databases.Tables.Warranties[CurrentId];
            warranty.Delete();
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Init()
        {
            var source = _includes ?? Databases.Tables.Warranties.ToList();

            dgvItems.DataSource = (from warranty in source
                                        where
                                        warranty.Customer.ToUpper().Contains(GetFilter("Customer").ToUpper()) &&
                                        warranty.Order.ToString().Contains(GetFilter("Order")) &&
                                        warranty.WarrantyDate.ToString().Contains(GetFilter("WarrantyDate")) &&
                                        warranty.Percent.ToString().Contains(GetFilter("Percent")) &&
                                        Databases.Tables.Areas[warranty.AreaId].Code.ToString().Contains(GetFilter("AreaCode")) &&
                                        Databases.Tables.Brigades[warranty.BrigadeId].Code.ToString().Contains(GetFilter("BrigadeCode"))
                                        select new
                                        {
                                            warranty.Id,
                                            warranty.Customer,
                                            warranty.Order,
                                            WarrantyDate = warranty.WarrantyDate.ToShortDateString(),
                                            AreaCode = Databases.Tables.Areas[warranty.AreaId].Code,
                                            BrigadeCode = Databases.Tables.Brigades[warranty.BrigadeId].Code,
                                            warranty.Percent
                                        }).ToList();

            foreach (DataGridViewColumn column in dgvItems.Columns)
            {
                column.DataPropertyName = column.Name;
            }
        }

    }
}
