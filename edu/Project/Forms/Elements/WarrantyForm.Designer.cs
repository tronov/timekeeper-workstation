using System.ComponentModel;
using System.Windows.Forms;
using Project.Controls;

namespace Project.Forms.Elements
{
    partial class WarrantyForm
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
            this.lCustomer = new System.Windows.Forms.Label();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.lOrder = new System.Windows.Forms.Label();
            this.mtbOrder = new System.Windows.Forms.MaskedTextBox();
            this.lBrigade = new System.Windows.Forms.Label();
            this.bBrigade = new System.Windows.Forms.Button();
            this.pWarranty = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lPercent = new System.Windows.Forms.Label();
            this.lPercentTitle = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbExecutors = new System.Windows.Forms.GroupBox();
            this.ctrlLabors = new Project.Controls.LaborsControl();
            this.ctrlExecutors = new Project.Controls.ExecutorsControl();
            this.gbPositions = new System.Windows.Forms.GroupBox();
            this.ctrlPositions = new Project.Controls.PositionsControl();
            this.pWarranty.SuspendLayout();
            this.panel1.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbExecutors.SuspendLayout();
            this.gbPositions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lCustomer
            // 
            this.lCustomer.AutoSize = true;
            this.lCustomer.Location = new System.Drawing.Point(8, 10);
            this.lCustomer.Name = "lCustomer";
            this.lCustomer.Size = new System.Drawing.Size(55, 13);
            this.lCustomer.TabIndex = 0;
            this.lCustomer.Text = "Заказчик";
            // 
            // tbCustomer
            // 
            this.tbCustomer.Location = new System.Drawing.Point(69, 7);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.Size = new System.Drawing.Size(257, 20);
            this.tbCustomer.TabIndex = 1;
            // 
            // lOrder
            // 
            this.lOrder.AutoSize = true;
            this.lOrder.Location = new System.Drawing.Point(341, 10);
            this.lOrder.Name = "lOrder";
            this.lOrder.Size = new System.Drawing.Size(80, 13);
            this.lOrder.TabIndex = 2;
            this.lOrder.Text = "Номер заказа";
            // 
            // mtbOrder
            // 
            this.mtbOrder.Location = new System.Drawing.Point(427, 7);
            this.mtbOrder.Mask = "0000";
            this.mtbOrder.Name = "mtbOrder";
            this.mtbOrder.Size = new System.Drawing.Size(33, 20);
            this.mtbOrder.TabIndex = 3;
            // 
            // lBrigade
            // 
            this.lBrigade.AutoSize = true;
            this.lBrigade.Location = new System.Drawing.Point(483, 10);
            this.lBrigade.Name = "lBrigade";
            this.lBrigade.Size = new System.Drawing.Size(49, 13);
            this.lBrigade.TabIndex = 4;
            this.lBrigade.Text = "Бригада";
            // 
            // bBrigade
            // 
            this.bBrigade.Location = new System.Drawing.Point(538, 5);
            this.bBrigade.Name = "bBrigade";
            this.bBrigade.Size = new System.Drawing.Size(62, 23);
            this.bBrigade.TabIndex = 5;
            this.bBrigade.UseVisualStyleBackColor = true;
            this.bBrigade.Click += new System.EventHandler(this.bBrigade_Click);
            // 
            // pWarranty
            // 
            this.pWarranty.Controls.Add(this.lCustomer);
            this.pWarranty.Controls.Add(this.tbCustomer);
            this.pWarranty.Controls.Add(this.lOrder);
            this.pWarranty.Controls.Add(this.mtbOrder);
            this.pWarranty.Controls.Add(this.lBrigade);
            this.pWarranty.Controls.Add(this.bBrigade);
            this.pWarranty.Dock = System.Windows.Forms.DockStyle.Top;
            this.pWarranty.Location = new System.Drawing.Point(4, 4);
            this.pWarranty.Name = "pWarranty";
            this.pWarranty.Padding = new System.Windows.Forms.Padding(4);
            this.pWarranty.Size = new System.Drawing.Size(852, 34);
            this.pWarranty.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lPercent);
            this.panel1.Controls.Add(this.lPercentTitle);
            this.panel1.Controls.Add(this.bSave);
            this.panel1.Controls.Add(this.bCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 530);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(852, 34);
            this.panel1.TabIndex = 13;
            // 
            // lPercent
            // 
            this.lPercent.AutoSize = true;
            this.lPercent.Location = new System.Drawing.Point(129, 11);
            this.lPercent.Name = "lPercent";
            this.lPercent.Size = new System.Drawing.Size(0, 13);
            this.lPercent.TabIndex = 9;
            // 
            // lPercentTitle
            // 
            this.lPercentTitle.AutoSize = true;
            this.lPercentTitle.Location = new System.Drawing.Point(8, 11);
            this.lPercentTitle.Name = "lPercentTitle";
            this.lPercentTitle.Size = new System.Drawing.Size(115, 13);
            this.lPercentTitle.TabIndex = 8;
            this.lPercentTitle.Text = "Норма выполнена на";
            this.lPercentTitle.Visible = false;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(551, 6);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(145, 23);
            this.bSave.TabIndex = 7;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(702, 6);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(145, 23);
            this.bCancel.TabIndex = 6;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(4, 38);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbExecutors);
            this.scMain.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbPositions);
            this.scMain.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.scMain.Size = new System.Drawing.Size(852, 492);
            this.scMain.SplitterDistance = 241;
            this.scMain.TabIndex = 14;
            // 
            // gbExecutors
            // 
            this.gbExecutors.Controls.Add(this.ctrlLabors);
            this.gbExecutors.Controls.Add(this.ctrlExecutors);
            this.gbExecutors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbExecutors.Location = new System.Drawing.Point(2, 2);
            this.gbExecutors.Name = "gbExecutors";
            this.gbExecutors.Size = new System.Drawing.Size(848, 237);
            this.gbExecutors.TabIndex = 10;
            this.gbExecutors.TabStop = false;
            this.gbExecutors.Text = "Список исполнителей";
            // 
            // ctrlLabors
            // 
            this.ctrlLabors.Location = new System.Drawing.Point(578, 19);
            this.ctrlLabors.Name = "ctrlLabors";
            this.ctrlLabors.Size = new System.Drawing.Size(267, 212);
            this.ctrlLabors.TabIndex = 6;
            // 
            // ctrlExecutors
            // 
            this.ctrlExecutors.Location = new System.Drawing.Point(3, 19);
            this.ctrlExecutors.Name = "ctrlExecutors";
            this.ctrlExecutors.Size = new System.Drawing.Size(569, 212);
            this.ctrlExecutors.TabIndex = 5;
            // 
            // gbPositions
            // 
            this.gbPositions.Controls.Add(this.ctrlPositions);
            this.gbPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPositions.Location = new System.Drawing.Point(2, 2);
            this.gbPositions.Name = "gbPositions";
            this.gbPositions.Size = new System.Drawing.Size(848, 243);
            this.gbPositions.TabIndex = 9;
            this.gbPositions.TabStop = false;
            this.gbPositions.Text = "Перечень позиций";
            // 
            // ctrlPositions
            // 
            this.ctrlPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPositions.Location = new System.Drawing.Point(3, 16);
            this.ctrlPositions.Name = "ctrlPositions";
            this.ctrlPositions.Size = new System.Drawing.Size(842, 224);
            this.ctrlPositions.TabIndex = 8;
            // 
            // WarrantyForm
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(860, 568);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pWarranty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "WarrantyForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый наряд";
            this.pWarranty.ResumeLayout(false);
            this.pWarranty.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.gbExecutors.ResumeLayout(false);
            this.gbPositions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lCustomer;
        private TextBox tbCustomer;
        private Label lOrder;
        private MaskedTextBox mtbOrder;
        private Label lBrigade;
        private Button bBrigade;
        private Panel pWarranty;
        private Panel panel1;
        private Button bSave;
        private Button bCancel;
        private GroupBox gbPositions;
        public PositionsControl ctrlPositions;
        private GroupBox gbExecutors;
        public SplitContainer scMain;
        private ExecutorsControl ctrlExecutors;
        public LaborsControl ctrlLabors;
        private Label lPercentTitle;
        private Label lPercent;
    }
}