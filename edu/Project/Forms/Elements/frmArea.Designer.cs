namespace Project.Forms.Elements
{
    partial class frmArea
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
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.mtbCode = new System.Windows.Forms.MaskedTextBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.lCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(316, 39);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 11;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(235, 39);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 10;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(161, 6);
            this.tbTitle.MaxLength = 64;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(230, 20);
            this.tbTitle.TabIndex = 9;
            // 
            // mtbCode
            // 
            this.mtbCode.Location = new System.Drawing.Point(54, 6);
            this.mtbCode.Mask = "00";
            this.mtbCode.Name = "mtbCode";
            this.mtbCode.Size = new System.Drawing.Size(20, 20);
            this.mtbCode.TabIndex = 8;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(98, 9);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(57, 13);
            this.lTitle.TabIndex = 7;
            this.lTitle.Text = "Название";
            // 
            // lCode
            // 
            this.lCode.AutoSize = true;
            this.lCode.Location = new System.Drawing.Point(12, 9);
            this.lCode.Name = "lCode";
            this.lCode.Size = new System.Drawing.Size(36, 13);
            this.lCode.TabIndex = 6;
            this.lCode.Text = "Шифр";
            // 
            // frmArea
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(407, 75);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.mtbCode);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmArea";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый участок";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.MaskedTextBox mtbCode;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lCode;
    }
}