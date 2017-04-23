using System.ComponentModel;
using Project.Controls;

namespace Project.Forms.Tables
{
    partial class BrigadePersonsForm
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
            this.ctrlBrigadePersons = new Project.Controls.BrigadePersonsControl();
            this.SuspendLayout();
            // 
            // ctrlBrigadePersons
            // 
            this.ctrlBrigadePersons.CatalogMode = Project.CatalogMode.View;
            this.ctrlBrigadePersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlBrigadePersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctrlBrigadePersons.Location = new System.Drawing.Point(4, 4);
            this.ctrlBrigadePersons.MinimumSize = new System.Drawing.Size(350, 200);
            this.ctrlBrigadePersons.Name = "ctrlBrigadePersons";
            this.ctrlBrigadePersons.Size = new System.Drawing.Size(585, 287);
            this.ctrlBrigadePersons.TabIndex = 0;
            // 
            // frmBrigadePersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 295);
            this.Controls.Add(this.ctrlBrigadePersons);
            this.Name = "frmBrigadePersons";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBrigadePersons";
            this.ResumeLayout(false);

        }

        #endregion

        public BrigadePersonsControl ctrlBrigadePersons;

    }
}