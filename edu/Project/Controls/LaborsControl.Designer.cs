using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Project.Controls
{
    partial class LaborsControl
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
            this.LaborId = new DataGridViewTextBoxColumn();
            this.LaborDate = new CalendarColumn();
            this.Hours = new DataGridViewTextBoxColumn();
            ((ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new DataGridViewColumn[] {
            this.LaborId,
            this.LaborDate,
            this.Hours});
            this.dgvItems.Dock = DockStyle.Fill;
            this.dgvItems.Location = new Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 30;
            this.dgvItems.Size = new Size(262, 211);
            this.dgvItems.TabIndex = 6;
            this.dgvItems.RowValidating += new DataGridViewCellCancelEventHandler(this.dgvItems_RowValidating);
            this.dgvItems.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvLabors_EditingControlShowing);
            // 
            // LaborId
            // 
            this.LaborId.HeaderText = "LaborId";
            this.LaborId.MinimumWidth = 20;
            this.LaborId.Name = "LaborId";
            this.LaborId.Visible = false;
            this.LaborId.Width = 20;
            // 
            // LaborDate
            // 
            this.LaborDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.LaborDate.HeaderText = "Дата работы";
            this.LaborDate.MinimumWidth = 90;
            this.LaborDate.Name = "LaborDate";
            this.LaborDate.Resizable = DataGridViewTriState.True;
            this.LaborDate.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Hours
            // 
            this.Hours.HeaderText = "Часы работы";
            this.Hours.MinimumWidth = 70;
            this.Hours.Name = "Hours";
            this.Hours.Width = 70;
            // 
            // LaborsControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Name = "LaborsControl";
            this.Size = new Size(262, 211);
            ((ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DataGridView dgvItems;
        private DataGridViewTextBoxColumn LaborId;
        private CalendarColumn LaborDate;
        private DataGridViewTextBoxColumn Hours;
    }
}
