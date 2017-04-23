using System.ComponentModel;
using System.Windows.Forms;
using Project.Controls;

namespace Project.Forms.Tables
{
    partial class StructureForm
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.ctrlStructure = new Project.Controls.StructureControl();
            this.ctrlBrigadePersons = new Project.Controls.BrigadePersonsControl();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.ctrlStructure);
            this.scMain.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.ctrlBrigadePersons);
            this.scMain.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.scMain.Size = new System.Drawing.Size(676, 606);
            this.scMain.SplitterDistance = 303;
            this.scMain.TabIndex = 2;
            // 
            // ctrlStructure
            // 
            this.ctrlStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlStructure.Location = new System.Drawing.Point(4, 4);
            this.ctrlStructure.MinimumSize = new System.Drawing.Size(350, 200);
            this.ctrlStructure.Name = "ctrlStructure";
            this.ctrlStructure.Size = new System.Drawing.Size(668, 295);
            this.ctrlStructure.TabIndex = 0;
            // 
            // ctrlBrigadePersons
            // 
            this.ctrlBrigadePersons.CatalogMode = Project.CatalogMode.View;
            this.ctrlBrigadePersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlBrigadePersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctrlBrigadePersons.Location = new System.Drawing.Point(4, 4);
            this.ctrlBrigadePersons.MinimumSize = new System.Drawing.Size(350, 200);
            this.ctrlBrigadePersons.Name = "ctrlBrigadePersons";
            this.ctrlBrigadePersons.Size = new System.Drawing.Size(668, 291);
            this.ctrlBrigadePersons.TabIndex = 1;
            // 
            // frmStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 606);
            this.Controls.Add(this.scMain);
            this.Name = "frmStructure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Структура организации";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer scMain;
        public StructureControl ctrlStructure;
        public BrigadePersonsControl ctrlBrigadePersons;
    }
}