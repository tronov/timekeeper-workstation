using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    partial class TableControl
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
            this.components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            this.bNew = new Button();
            this.miEdit = new ToolStripMenuItem();
            this.cmsView = new ContextMenuStrip(this.components);
            this.miDelete = new ToolStripMenuItem();
            this.bDelete = new Button();
            this.bEdit = new Button();
            this.gbFilter = new GroupBox();
            this.dgvFilter = new DataGridView();
            this.gbOperations = new GroupBox();
            this.scMain = new SplitContainer();
            this.gbItems = new GroupBox();
            this.dgvItems = new DataGridView();
            this.cmsSelect = new ContextMenuStrip(this.components);
            this.miSelect = new ToolStripMenuItem();
            this.cmsView.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((ISupportInitialize)(this.dgvFilter)).BeginInit();
            this.gbOperations.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbItems.SuspendLayout();
            ((ISupportInitialize)(this.dgvItems)).BeginInit();
            this.cmsSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // bNew
            // 
            this.bNew.Location = new Point(5, 18);
            this.bNew.Name = "bNew";
            this.bNew.Size = new Size(86, 23);
            this.bNew.TabIndex = 0;
            this.bNew.Text = "Добавить";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new EventHandler(this.bNew_Click);
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new Size(154, 22);
            this.miEdit.Text = "Редактировать";
            this.miEdit.Click += new EventHandler(this.miEdit_Click);
            // 
            // cmsView
            // 
            this.cmsView.Items.AddRange(new ToolStripItem[] {
   this.miEdit,
   this.miDelete});
            this.cmsView.Name = "cmsView";
            this.cmsView.Size = new Size(155, 48);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new Size(154, 22);
            this.miDelete.Text = "Удалить";
            this.miDelete.Click += new EventHandler(this.miDelete_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new Point(189, 18);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new Size(86, 23);
            this.bDelete.TabIndex = 2;
            this.bDelete.Text = "Удалить";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new EventHandler(this.bDelete_Click);
            // 
            // bEdit
            // 
            this.bEdit.Location = new Point(97, 18);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new Size(86, 23);
            this.bEdit.TabIndex = 1;
            this.bEdit.Text = "Изменить";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new EventHandler(this.bEdit_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.dgvFilter);
            this.gbFilter.Dock = DockStyle.Top;
            this.gbFilter.Font = new Font("Microsoft Sans Serif", 8.25F);
            this.gbFilter.Location = new Point(2, 2);
            this.gbFilter.Margin = new Padding(8);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Padding = new Padding(4);
            this.gbFilter.Size = new Size(476, 42);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            this.dgvFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFilter.ColumnHeadersHeight = 35;
            this.dgvFilter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFilter.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            this.dgvFilter.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFilter.Dock = DockStyle.Fill;
            this.dgvFilter.Location = new Point(4, 17);
            this.dgvFilter.MultiSelect = false;
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.RowHeadersVisible = false;
            this.dgvFilter.Size = new Size(468, 21);
            this.dgvFilter.TabIndex = 0;
            this.dgvFilter.CellValueChanged += new DataGridViewCellEventHandler(this.dgvFilter_CellValueChanged);
            this.dgvFilter.KeyUp += new KeyEventHandler(this.dgvFilter_KeyUp);
            // 
            // gbOperations
            // 
            this.gbOperations.Controls.Add(this.bDelete);
            this.gbOperations.Controls.Add(this.bEdit);
            this.gbOperations.Controls.Add(this.bNew);
            this.gbOperations.Dock = DockStyle.Fill;
            this.gbOperations.Location = new Point(2, 2);
            this.gbOperations.MinimumSize = new Size(300, 50);
            this.gbOperations.Name = "gbOperations";
            this.gbOperations.Padding = new Padding(2);
            this.gbOperations.Size = new Size(476, 52);
            this.gbOperations.TabIndex = 0;
            this.gbOperations.TabStop = false;
            this.gbOperations.Text = "Операции";
            // 
            // scMain
            // 
            this.scMain.Dock = DockStyle.Fill;
            this.scMain.FixedPanel = FixedPanel.Panel2;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbItems);
            this.scMain.Panel1.Controls.Add(this.gbFilter);
            this.scMain.Panel1.Padding = new Padding(2);
            this.scMain.Panel1MinSize = 100;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbOperations);
            this.scMain.Panel2.Padding = new Padding(2);
            this.scMain.Panel2MinSize = 50;
            this.scMain.Size = new Size(480, 320);
            this.scMain.SplitterDistance = 262;
            this.scMain.SplitterWidth = 2;
            this.scMain.TabIndex = 15;
            // 
            // gbItems
            // 
            this.gbItems.Controls.Add(this.dgvItems);
            this.gbItems.Dock = DockStyle.Fill;
            this.gbItems.Font = new Font("Microsoft Sans Serif", 8.25F);
            this.gbItems.Location = new Point(2, 44);
            this.gbItems.Margin = new Padding(8);
            this.gbItems.MinimumSize = new Size(0, 45);
            this.gbItems.Name = "gbItems";
            this.gbItems.Padding = new Padding(4);
            this.gbItems.Size = new Size(476, 216);
            this.gbItems.TabIndex = 15;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Перечень";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = DockStyle.Fill;
            this.dgvItems.Location = new Point(4, 17);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new Size(468, 195);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellMouseUp += new DataGridViewCellMouseEventHandler(this.dgvItems_CellMouseUp);
            this.dgvItems.CellMouseDown += new DataGridViewCellMouseEventHandler(this.dgvItems_CellMouseDown);
            this.dgvItems.ColumnWidthChanged += new DataGridViewColumnEventHandler(this.dgvItems_ColumnWidthChanged);
            // 
            // cmsSelect
            // 
            this.cmsSelect.Items.AddRange(new ToolStripItem[] {
   this.miSelect});
            this.cmsSelect.Name = "cmsSelect";
            this.cmsSelect.Size = new Size(122, 26);
            // 
            // miSelect
            // 
            this.miSelect.Name = "miSelect";
            this.miSelect.Size = new Size(121, 22);
            this.miSelect.Text = "Выбрать";
            this.miSelect.Click += new EventHandler(this.miSelect_Click);
            // 
            // TableControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Font = new Font("Microsoft Sans Serif", 8.25F);
            this.Name = "TableControl";
            this.Size = new Size(480, 320);
            this.cmsView.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            ((ISupportInitialize)(this.dgvFilter)).EndInit();
            this.gbOperations.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.gbItems.ResumeLayout(false);
            ((ISupportInitialize)(this.dgvItems)).EndInit();
            this.cmsSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Button bNew;
        public ToolStripMenuItem miEdit;
        public ContextMenuStrip cmsView;
        public ToolStripMenuItem miDelete;
        public Button bDelete;
        public Button bEdit;
        public GroupBox gbFilter;
        public GroupBox gbOperations;
        public SplitContainer scMain;
        public DataGridView dgvFilter;
        public GroupBox gbItems;
        private ContextMenuStrip cmsSelect;
        private ToolStripMenuItem miSelect;
        public DataGridView dgvItems;
    }
}
