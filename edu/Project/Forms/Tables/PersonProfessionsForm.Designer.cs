using System.ComponentModel;

namespace Project.Forms.Tables
{
    partial class PersonProfessionsForm
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
            this.ctrlPersonProfessions = new Project.PersonProfessionsControl();
            this.SuspendLayout();
            // 
            // ctrlPersonProfessions
            // 
            this.ctrlPersonProfessions.CatalogMode = Project.CatalogMode.View;
            this.ctrlPersonProfessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPersonProfessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctrlPersonProfessions.Location = new System.Drawing.Point(4, 4);
            this.ctrlPersonProfessions.Name = "ctrlPersonProfessions";
            this.ctrlPersonProfessions.Size = new System.Drawing.Size(524, 267);
            this.ctrlPersonProfessions.TabIndex = 0;
            // 
            // PersonProfessionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 275);
            this.Controls.Add(this.ctrlPersonProfessions);
            this.Name = "PersonProfessionsForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор вида оплаты";
            this.ResumeLayout(false);

        }

        #endregion

        public PersonProfessionsControl ctrlPersonProfessions;

    }
}