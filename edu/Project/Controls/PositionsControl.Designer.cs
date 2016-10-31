namespace Project.Controls
{
    partial class PositionsControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Draw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matherial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Norm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.Draw,
            this.Matherial,
            this.Number,
            this.Mass,
            this.Norm,
            this.Price});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 30;
            this.dgvItems.Size = new System.Drawing.Size(745, 289);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItems_RowValidating);
            this.dgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvItems_EditingControlShowing);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 20;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 20;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Наименование";
            this.Title.MinimumWidth = 100;
            this.Title.Name = "Title";
            // 
            // Draw
            // 
            this.Draw.DataPropertyName = "Draw";
            this.Draw.HeaderText = "Чертеж";
            this.Draw.MinimumWidth = 100;
            this.Draw.Name = "Draw";
            // 
            // Matherial
            // 
            this.Matherial.DataPropertyName = "Matherial";
            this.Matherial.HeaderText = "Материал";
            this.Matherial.MinimumWidth = 80;
            this.Matherial.Name = "Matherial";
            this.Matherial.Width = 80;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "Количество";
            this.Number.MinimumWidth = 80;
            this.Number.Name = "Number";
            this.Number.Width = 80;
            // 
            // Mass
            // 
            this.Mass.DataPropertyName = "Mass";
            this.Mass.HeaderText = "Масса";
            this.Mass.MinimumWidth = 50;
            this.Mass.Name = "Mass";
            this.Mass.Width = 50;
            // 
            // Norm
            // 
            this.Norm.DataPropertyName = "Norm";
            this.Norm.HeaderText = "Норма времени";
            this.Norm.MinimumWidth = 80;
            this.Norm.Name = "Norm";
            this.Norm.Width = 80;
            // 
            // Price
            // 
            this.Price.HeaderText = "Расценка";
            this.Price.MinimumWidth = 80;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 80;
            // 
            // PositionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Name = "PositionsControl";
            this.Size = new System.Drawing.Size(745, 289);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Draw;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matherial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Norm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}
