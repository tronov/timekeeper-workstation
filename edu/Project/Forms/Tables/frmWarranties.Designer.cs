using System.ComponentModel;
using Project.Controls;

namespace Project.Forms.Tables
{
    partial class frmWarranties
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
            this.ctrlWarranties = new Project.Controls.WarrantiesControl();
            this.SuspendLayout();
            // 
            // ctrlWarranties
            // 
            this.ctrlWarranties.CatalogMode = Project.CatalogMode.View;
            this.ctrlWarranties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWarranties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctrlWarranties.Location = new System.Drawing.Point(4, 4);
            this.ctrlWarranties.Name = "ctrlWarranties";
            this.ctrlWarranties.Size = new System.Drawing.Size(576, 354);
            this.ctrlWarranties.TabIndex = 0;
            // 
            // frmWarranties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.ctrlWarranties);
            this.Name = "frmWarranties";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Справочник нарядов";
            this.ResumeLayout(false);

        }

        #endregion

        public WarrantiesControl ctrlWarranties;
    }
}