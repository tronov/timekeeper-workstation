namespace Project
{
    partial class TableControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bNew = new System.Windows.Forms.Button();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.bDelete = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.dgvFilter = new System.Windows.Forms.DataGridView();
            this.gbOperations = new System.Windows.Forms.GroupBox();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.cmsSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsView.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
            this.gbOperations.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.cmsSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(5, 18);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(86, 23);
            this.bNew.TabIndex = 0;
            this.bNew.Text = "Добавить";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(154, 22);
            this.miEdit.Text = "Редактировать";
            this.miEdit.Click += new System.EventHandler(this.miEdit_Click);
            // 
            // cmsView
            // 
            this.cmsView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
   this.miEdit,
   this.miDelete});
            this.cmsView.Name = "cmsView";
            this.cmsView.Size = new System.Drawing.Size(155, 48);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(154, 22);
            this.miDelete.Text = "Удалить";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(189, 18);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(86, 23);
            this.bDelete.TabIndex = 2;
            this.bDelete.Text = "Удалить";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(97, 18);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(86, 23);
            this.bEdit.TabIndex = 1;
            this.bEdit.Text = "Изменить";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.dgvFilter);
            this.gbFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gbFilter.Location = new System.Drawing.Point(2, 2);
            this.gbFilter.Margin = new System.Windows.Forms.Padding(8);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Padding = new System.Windows.Forms.Padding(4);
            this.gbFilter.Size = new System.Drawing.Size(476, 42);
            this.gbFilter.TabIndex = 12;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Фильтр";
            // 
            // dgvFilter
            // 
            this.dgvFilter.AllowUserToAddRows = false;
            this.dgvFilter.AllowUserToDeleteRows = false;
            this.dgvFilter.AllowUserToResizeColumns = false;
            this.dgvFilter.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFilter.ColumnHeadersHeight = 35;
            this.dgvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFilter.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFilter.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFilter.Location = new System.Drawing.Point(4, 17);
            this.dgvFilter.MultiSelect = false;
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.RowHeadersVisible = false;
            this.dgvFilter.Size = new System.Drawing.Size(468, 21);
            this.dgvFilter.TabIndex = 0;
            this.dgvFilter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilter_CellValueChanged);
            this.dgvFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvFilter_KeyUp);
            // 
            // gbOperations
            // 
            this.gbOperations.Controls.Add(this.bDelete);
            this.gbOperations.Controls.Add(this.bEdit);
            this.gbOperations.Controls.Add(this.bNew);
            this.gbOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOperations.Location = new System.Drawing.Point(2, 2);
            this.gbOperations.MinimumSize = new System.Drawing.Size(300, 50);
            this.gbOperations.Name = "gbOperations";
            this.gbOperations.Padding = new System.Windows.Forms.Padding(2);
            this.gbOperations.Size = new System.Drawing.Size(476, 52);
            this.gbOperations.TabIndex = 0;
            this.gbOperations.TabStop = false;
            this.gbOperations.Text = "Операции";
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbItems);
            this.scMain.Panel1.Controls.Add(this.gbFilter);
            this.scMain.Panel1.Padding = new System.Windows.Forms.Padding(2);
            this.scMain.Panel1MinSize = 100;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbOperations);
            this.scMain.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.scMain.Panel2MinSize = 50;
            this.scMain.Size = new System.Drawing.Size(480, 320);
            this.scMain.SplitterDistance = 262;
            this.scMain.SplitterWidth = 2;
            this.scMain.TabIndex = 15;
            // 
            // gbItems
            // 
            this.gbItems.Controls.Add(this.dgvItems);
            this.gbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gbItems.Location = new System.Drawing.Point(2, 44);
            this.gbItems.Margin = new System.Windows.Forms.Padding(8);
            this.gbItems.MinimumSize = new System.Drawing.Size(0, 45);
            this.gbItems.Name = "gbItems";
            this.gbItems.Padding = new System.Windows.Forms.Padding(4);
            this.gbItems.Size = new System.Drawing.Size(476, 216);
            this.gbItems.TabIndex = 15;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Перечень";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(4, 17);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(468, 195);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvItems_CellMouseUp);
            this.dgvItems.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvItems_CellMouseDown);
            this.dgvItems.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvItems_ColumnWidthChanged);
            // 
            // cmsSelect
            // 
            this.cmsSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
   this.miSelect});
            this.cmsSelect.Name = "cmsSelect";
            this.cmsSelect.Size = new System.Drawing.Size(122, 26);
            // 
            // miSelect
            // 
            this.miSelect.Name = "miSelect";
            this.miSelect.Size = new System.Drawing.Size(121, 22);
            this.miSelect.Text = "Выбрать";
            this.miSelect.Click += new System.EventHandler(this.miSelect_Click);
            // 
            // TableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "TableControl";
            this.Size = new System.Drawing.Size(480, 320);
            this.cmsView.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
            this.gbOperations.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.gbItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.cmsSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button bNew;
        public System.Windows.Forms.ToolStripMenuItem miEdit;
        public System.Windows.Forms.ContextMenuStrip cmsView;
        public System.Windows.Forms.ToolStripMenuItem miDelete;
        public System.Windows.Forms.Button bDelete;
        public System.Windows.Forms.Button bEdit;
        public System.Windows.Forms.GroupBox gbFilter;
        public System.Windows.Forms.GroupBox gbOperations;
        public System.Windows.Forms.SplitContainer scMain;
        public System.Windows.Forms.DataGridView dgvFilter;
        public System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.ContextMenuStrip cmsSelect;
        private System.Windows.Forms.ToolStripMenuItem miSelect;
        public System.Windows.Forms.DataGridView dgvItems;
    }
}
