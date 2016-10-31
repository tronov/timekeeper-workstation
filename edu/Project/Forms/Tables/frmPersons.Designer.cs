namespace Project.Forms.Tables
{
    partial class frmPersons
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpProfessions = new System.Windows.Forms.TabPage();
            this.ctrlPersons = new Project.PersonsControl();
            this.ctrlPersonProfessions = new Project.PersonProfessionsControl();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpProfessions.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.ctrlPersons);
            this.scMain.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.tabControl);
            this.scMain.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.scMain.Size = new System.Drawing.Size(654, 633);
            this.scMain.SplitterDistance = 334;
            this.scMain.SplitterWidth = 2;
            this.scMain.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpProfessions);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(2, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(648, 291);
            this.tabControl.TabIndex = 0;
            // 
            // tpProfessions
            // 
            this.tpProfessions.Controls.Add(this.ctrlPersonProfessions);
            this.tpProfessions.Location = new System.Drawing.Point(4, 22);
            this.tpProfessions.Name = "tpProfessions";
            this.tpProfessions.Padding = new System.Windows.Forms.Padding(3);
            this.tpProfessions.Size = new System.Drawing.Size(640, 265);
            this.tpProfessions.TabIndex = 0;
            this.tpProfessions.Text = "Квалификация";
            this.tpProfessions.UseVisualStyleBackColor = true;
            // 
            // ctrlPersons
            // 
            this.ctrlPersons.CatalogMode = Project.CatalogMode.View;
            this.ctrlPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctrlPersons.Location = new System.Drawing.Point(2, 2);
            this.ctrlPersons.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersons.Name = "ctrlPersons";
            this.ctrlPersons.Size = new System.Drawing.Size(648, 328);
            this.ctrlPersons.TabIndex = 0;
            // 
            // ctrlPersonProfessions
            // 
            this.ctrlPersonProfessions.CatalogMode = Project.CatalogMode.View;
            this.ctrlPersonProfessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPersonProfessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctrlPersonProfessions.Location = new System.Drawing.Point(3, 3);
            this.ctrlPersonProfessions.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonProfessions.Name = "ctrlPersonProfessions";
            this.ctrlPersonProfessions.Size = new System.Drawing.Size(634, 259);
            this.ctrlPersonProfessions.TabIndex = 0;
            // 
            // frmPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 633);
            this.Controls.Add(this.scMain);
            this.Name = "frmPersons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник сотрудников";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpProfessions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpProfessions;
        public PersonsControl ctrlPersons;
        private PersonProfessionsControl ctrlPersonProfessions;
        public System.Windows.Forms.SplitContainer scMain;
    }
}