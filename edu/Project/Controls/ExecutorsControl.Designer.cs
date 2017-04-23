using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Project.Controls
{
    partial class ExecutorsControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvItems = new DataGridView();
            this.ExecutorId = new DataGridViewTextBoxColumn();
            this.PersonCode = new DataGridViewButtonColumn();
            this.PersonLastName = new DataGridViewTextBoxColumn();
            this.PersonFirstName = new DataGridViewTextBoxColumn();
            this.PersonMiddleName = new DataGridViewTextBoxColumn();
            this.ProfessionCode = new DataGridViewButtonColumn();
            this.Rank = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            ((ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new DataGridViewColumn[] {
            this.ExecutorId,
            this.PersonCode,
            this.PersonLastName,
            this.PersonFirstName,
            this.PersonMiddleName,
            this.ProfessionCode,
            this.Rank});
            this.dgvItems.Dock = DockStyle.Fill;
            this.dgvItems.Location = new Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 30;
            this.dgvItems.Size = new Size(568, 212);
            this.dgvItems.TabIndex = 4;
            this.dgvItems.RowValidating += new DataGridViewCellCancelEventHandler(this.dgvItems_RowValidating);
            this.dgvItems.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvItems_EditingControlShowing);
            this.dgvItems.CellContentClick += new DataGridViewCellEventHandler(this.dgvExecutors_CellContentClick);
            // 
            // ExecutorId
            // 
            this.ExecutorId.HeaderText = "ExecutorId";
            this.ExecutorId.MinimumWidth = 20;
            this.ExecutorId.Name = "ExecutorId";
            this.ExecutorId.Visible = false;
            this.ExecutorId.Width = 20;
            // 
            // PersonCode
            // 
            this.PersonCode.HeaderText = "Таб. №";
            this.PersonCode.MinimumWidth = 70;
            this.PersonCode.Name = "PersonCode";
            this.PersonCode.Resizable = DataGridViewTriState.True;
            this.PersonCode.SortMode = DataGridViewColumnSortMode.Automatic;
            this.PersonCode.Width = 70;
            // 
            // PersonLastName
            // 
            this.PersonLastName.HeaderText = "Фамилия";
            this.PersonLastName.MinimumWidth = 100;
            this.PersonLastName.Name = "PersonLastName";
            this.PersonLastName.ReadOnly = true;
            // 
            // PersonFirstName
            // 
            this.PersonFirstName.HeaderText = "Имя";
            this.PersonFirstName.MinimumWidth = 100;
            this.PersonFirstName.Name = "PersonFirstName";
            this.PersonFirstName.ReadOnly = true;
            // 
            // PersonMiddleName
            // 
            this.PersonMiddleName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.PersonMiddleName.HeaderText = "Отчество";
            this.PersonMiddleName.MinimumWidth = 120;
            this.PersonMiddleName.Name = "PersonMiddleName";
            this.PersonMiddleName.ReadOnly = true;
            // 
            // ProfessionCode
            // 
            this.ProfessionCode.HeaderText = "Шифр профессии";
            this.ProfessionCode.MinimumWidth = 80;
            this.ProfessionCode.Name = "ProfessionCode";
            this.ProfessionCode.Resizable = DataGridViewTriState.True;
            this.ProfessionCode.SortMode = DataGridViewColumnSortMode.Automatic;
            this.ProfessionCode.Width = 80;
            // 
            // Rank
            // 
            this.Rank.HeaderText = "Разряд";
            this.Rank.MinimumWidth = 65;
            this.Rank.Name = "Rank";
            this.Rank.Width = 65;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ExecutorId";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 20;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Фамилия";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Отчество";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Разряд";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 65;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Разряд";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 65;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 65;
            // 
            // ExecutorsControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Name = "ExecutorsControl";
            this.Size = new Size(568, 212);
            ((ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        public DataGridView dgvItems;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn ExecutorId;
        private DataGridViewButtonColumn PersonCode;
        private DataGridViewTextBoxColumn PersonLastName;
        private DataGridViewTextBoxColumn PersonFirstName;
        private DataGridViewTextBoxColumn PersonMiddleName;
        private DataGridViewButtonColumn ProfessionCode;
        private DataGridViewTextBoxColumn Rank;
    }
}
