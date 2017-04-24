using System.ComponentModel;
using System.Windows.Forms;

namespace Project.Forms.Elements
{
    partial class TableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.lFrom = new System.Windows.Forms.Label();
            this.bBrigade = new System.Windows.Forms.Button();
            this.lBrigade = new System.Windows.Forms.Label();
            this.cmsSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miWarranties = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.cmsSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.AllowUserToResizeColumns = false;
            this.dgvTable.AllowUserToResizeRows = false;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.Location = new System.Drawing.Point(0, 0);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            this.dgvTable.RowHeadersVisible = false;
            this.dgvTable.Size = new System.Drawing.Size(794, 431);
            this.dgvTable.TabIndex = 0;
            this.dgvTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseClick);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.dtpMonth);
            this.scMain.Panel1.Controls.Add(this.lFrom);
            this.scMain.Panel1.Controls.Add(this.bBrigade);
            this.scMain.Panel1.Controls.Add(this.lBrigade);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.dgvTable);
            this.scMain.Size = new System.Drawing.Size(794, 472);
            this.scMain.SplitterDistance = 37;
            this.scMain.TabIndex = 1;
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MMMM yyyy";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(227, 11);
            this.dtpMonth.MaxDate = System.DateTime.Now;
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(103, 20);
            this.dtpMonth.TabIndex = 4;
            this.dtpMonth.Value = new System.DateTime(2012, 6, 5, 13, 29, 36, 417);
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);
            // 
            // lFrom
            // 
            this.lFrom.AutoSize = true;
            this.lFrom.Location = new System.Drawing.Point(181, 13);
            this.lFrom.Name = "lFrom";
            this.lFrom.Size = new System.Drawing.Size(40, 13);
            this.lFrom.TabIndex = 2;
            this.lFrom.Text = "Месяц";
            // 
            // bBrigade
            // 
            this.bBrigade.Location = new System.Drawing.Point(68, 8);
            this.bBrigade.Name = "bBrigade";
            this.bBrigade.Size = new System.Drawing.Size(75, 23);
            this.bBrigade.TabIndex = 1;
            this.bBrigade.UseVisualStyleBackColor = true;
            this.bBrigade.Click += new System.EventHandler(this.bBrigade_Click);
            // 
            // lBrigade
            // 
            this.lBrigade.AutoSize = true;
            this.lBrigade.Location = new System.Drawing.Point(13, 13);
            this.lBrigade.Name = "lBrigade";
            this.lBrigade.Size = new System.Drawing.Size(49, 13);
            this.lBrigade.TabIndex = 0;
            this.lBrigade.Text = "Бригада";
            // 
            // cmsSelect
            // 
            this.cmsSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miWarranties});
            this.cmsSelect.Name = "cmsSelect";
            this.cmsSelect.Size = new System.Drawing.Size(169, 26);
            // 
            // miWarranties
            // 
            this.miWarranties.Name = "miWarranties";
            this.miWarranties.Size = new System.Drawing.Size(168, 22);
            this.miWarranties.Text = "Показать наряды";
            this.miWarranties.Click += new System.EventHandler(this.miWarranties_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Ф. И. О.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Таб. №";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 472);
            this.Controls.Add(this.scMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "TableForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Табель";
            this.Activated += new System.EventHandler(this.frmTable_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.cmsSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvTable;
        private SplitContainer scMain;
        private DateTimePicker dtpMonth;
        private Label lFrom;
        private Button bBrigade;
        private Label lBrigade;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private ContextMenuStrip cmsSelect;
        private ToolStripMenuItem miWarranties;
    }
}