namespace Project.Forms.Tables
{
    partial class frmProfessions
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
            this.professionsControl = new Project.ProfessionsControl();
            this.SuspendLayout();
            // 
            // professionsControl
            // 
            this.professionsControl.CatalogMode = Project.CatalogMode.View;
            this.professionsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.professionsControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.professionsControl.Location = new System.Drawing.Point(4, 4);
            this.professionsControl.Margin = new System.Windows.Forms.Padding(4);
            this.professionsControl.Name = "professionsControl";
            this.professionsControl.Size = new System.Drawing.Size(658, 529);
            this.professionsControl.TabIndex = 0;
            // 
            // frmProfessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 537);
            this.Controls.Add(this.professionsControl);
            this.Name = "frmProfessions";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Справочник профессий";
            this.ResumeLayout(false);

        }

        #endregion

        public ProfessionsControl professionsControl;
    }
}