using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Data;

namespace Project
{
    public partial class ProfessionsControl : TableControl
    {


        public ProfessionsControl()
        {
            InitializeComponent();



            var id = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                Visible = false
            };

            var code = new DataGridViewTextBoxColumn
            {
                Name = "Code",
                Width = 70,
                HeaderText = "Шифр"
            };

            var title = new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Наименование",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            var rank1 = new DataGridViewTextBoxColumn
            {
                Name = "Rank1",
                Width = 80,
                HeaderText = "1 разряд"
            };

            var rank2 = new DataGridViewTextBoxColumn
            {
                Name = "Rank2",
                Width = 80,
                HeaderText = "2 разряд"
            };

            var rank3 = new DataGridViewTextBoxColumn
            {
                Name = "Rank3",
                Width = 80,
                HeaderText = "3 разряд"
            };

            var rank4 = new DataGridViewTextBoxColumn
            {
                Name = "Rank4",
                Width = 80,
                HeaderText = "4 разряд"
            };

            var rank5 = new DataGridViewTextBoxColumn
            {
                Name = "Rank5",
                Width = 80,
                HeaderText = "5 разряд"
            };

            var rank6 = new DataGridViewTextBoxColumn
            {
                Name = "Rank6",
                Width = 80,
                HeaderText = "6 разряд"
            };

            dgvItems.Columns.Add(id);
            dgvItems.Columns.Add(code);
            dgvItems.Columns.Add(title);
            dgvItems.Columns.Add(rank1);
            dgvItems.Columns.Add(rank2);
            dgvItems.Columns.Add(rank3);
            dgvItems.Columns.Add(rank4);
            dgvItems.Columns.Add(rank5);
            dgvItems.Columns.Add(rank6);

            dgvFilter.Columns.Add(code.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(title.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(rank1.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(rank2.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(rank3.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(rank4.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(rank5.Clone() as DataGridViewColumn);
            dgvFilter.Columns.Add(rank6.Clone() as DataGridViewColumn);
            dgvFilter.Rows.Add();

            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void New()
        {
            var form = new ProfessionForm();
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Edit()
        {
            if (CurrentId == 0) return;

            var profession = Databases.Tables.Professions[CurrentId];
            var form = new ProfessionForm(profession);
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Delete()
        {
            if (CurrentId == 0) return;

            if (!MessageBox
                .Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.OKCancel)
                .Equals(DialogResult.OK)) return;

            var profession = Databases.Tables.Professions[CurrentId];
            profession.Delete();
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override void Init()
        {
            dgvItems.DataSource = Databases.Tables.Professions.Where(r =>
              r.Code.ToString().Contains(GetFilter("Code")) &&
              r.Title.ToUpper().Contains(GetFilter("Title").ToUpper()) &&
              r.Rank1.ToString().Contains(GetFilter("Rank1")) &&
              r.Rank2.ToString().Contains(GetFilter("Rank2")) &&
              r.Rank3.ToString().Contains(GetFilter("Rank3")) &&
              r.Rank4.ToString().Contains(GetFilter("Rank4")) &&
              r.Rank5.ToString().Contains(GetFilter("Rank5")) &&
              r.Rank6.ToString().Contains(GetFilter("Rank6"))
              ).ToList();

            foreach (DataGridViewColumn column in dgvItems.Columns)
            {
                column.DataPropertyName = column.Name;
            }
        }
    }
}
