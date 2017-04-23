using System.ComponentModel;
using System.Windows.Forms;

namespace Project
{
    partial class frmProfession
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
            this.mtbCode = new System.Windows.Forms.MaskedTextBox();
            this.lCode = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lRank1 = new System.Windows.Forms.Label();
            this.tbRank1 = new System.Windows.Forms.TextBox();
            this.tbRank2 = new System.Windows.Forms.TextBox();
            this.lRank2 = new System.Windows.Forms.Label();
            this.tbRank3 = new System.Windows.Forms.TextBox();
            this.lRank3 = new System.Windows.Forms.Label();
            this.tbRank4 = new System.Windows.Forms.TextBox();
            this.lRank4 = new System.Windows.Forms.Label();
            this.tbRank5 = new System.Windows.Forms.TextBox();
            this.lRank5 = new System.Windows.Forms.Label();
            this.tbRank6 = new System.Windows.Forms.TextBox();
            this.lRank6 = new System.Windows.Forms.Label();
            this.gbTariff = new System.Windows.Forms.GroupBox();
            this.gbTariff.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtbCode
            // 
            this.mtbCode.Location = new System.Drawing.Point(51, 11);
            this.mtbCode.Margin = new System.Windows.Forms.Padding(2);
            this.mtbCode.Mask = "000";
            this.mtbCode.Name = "mtbCode";
            this.mtbCode.Size = new System.Drawing.Size(26, 20);
            this.mtbCode.TabIndex = 0;
            this.mtbCode.Validating += new System.ComponentModel.CancelEventHandler(this.mtbCode_Validating);
            this.mtbCode.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbCode_MaskInputRejected);
            // 
            // lCode
            // 
            this.lCode.AutoSize = true;
            this.lCode.Location = new System.Drawing.Point(11, 14);
            this.lCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCode.Name = "lCode";
            this.lCode.Size = new System.Drawing.Size(36, 13);
            this.lCode.TabIndex = 1;
            this.lCode.Text = "Шифр";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(108, 14);
            this.lTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(57, 13);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "Название";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(167, 12);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(256, 20);
            this.tbTitle.TabIndex = 1;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(249, 102);
            this.bSave.Margin = new System.Windows.Forms.Padding(2);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(85, 23);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(338, 102);
            this.bCancel.Margin = new System.Windows.Forms.Padding(2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(85, 23);
            this.bCancel.TabIndex = 9;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lRank1
            // 
            this.lRank1.AutoSize = true;
            this.lRank1.Location = new System.Drawing.Point(6, 16);
            this.lRank1.Name = "lRank1";
            this.lRank1.Size = new System.Drawing.Size(52, 13);
            this.lRank1.TabIndex = 8;
            this.lRank1.Text = "1 разряд";
            // 
            // tbRank1
            // 
            this.tbRank1.Location = new System.Drawing.Point(9, 31);
            this.tbRank1.Margin = new System.Windows.Forms.Padding(2);
            this.tbRank1.Name = "tbRank1";
            this.tbRank1.Size = new System.Drawing.Size(49, 20);
            this.tbRank1.TabIndex = 2;
            this.tbRank1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRank_KeyPress);
            // 
            // tbRank2
            // 
            this.tbRank2.Location = new System.Drawing.Point(78, 31);
            this.tbRank2.Margin = new System.Windows.Forms.Padding(2);
            this.tbRank2.Name = "tbRank2";
            this.tbRank2.Size = new System.Drawing.Size(49, 20);
            this.tbRank2.TabIndex = 3;
            this.tbRank2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRank_KeyPress);
            // 
            // lRank2
            // 
            this.lRank2.AutoSize = true;
            this.lRank2.Location = new System.Drawing.Point(75, 16);
            this.lRank2.Name = "lRank2";
            this.lRank2.Size = new System.Drawing.Size(52, 13);
            this.lRank2.TabIndex = 10;
            this.lRank2.Text = "2 разряд";
            // 
            // tbRank3
            // 
            this.tbRank3.Location = new System.Drawing.Point(148, 31);
            this.tbRank3.Margin = new System.Windows.Forms.Padding(2);
            this.tbRank3.Name = "tbRank3";
            this.tbRank3.Size = new System.Drawing.Size(49, 20);
            this.tbRank3.TabIndex = 4;
            this.tbRank3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRank_KeyPress);
            // 
            // lRank3
            // 
            this.lRank3.AutoSize = true;
            this.lRank3.Location = new System.Drawing.Point(145, 16);
            this.lRank3.Name = "lRank3";
            this.lRank3.Size = new System.Drawing.Size(52, 13);
            this.lRank3.TabIndex = 12;
            this.lRank3.Text = "3 разряд";
            // 
            // tbRank4
            // 
            this.tbRank4.Location = new System.Drawing.Point(218, 31);
            this.tbRank4.Margin = new System.Windows.Forms.Padding(2);
            this.tbRank4.Name = "tbRank4";
            this.tbRank4.Size = new System.Drawing.Size(49, 20);
            this.tbRank4.TabIndex = 5;
            this.tbRank4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRank_KeyPress);
            // 
            // lRank4
            // 
            this.lRank4.AutoSize = true;
            this.lRank4.Location = new System.Drawing.Point(215, 16);
            this.lRank4.Name = "lRank4";
            this.lRank4.Size = new System.Drawing.Size(52, 13);
            this.lRank4.TabIndex = 14;
            this.lRank4.Text = "4 разряд";
            // 
            // tbRank5
            // 
            this.tbRank5.Location = new System.Drawing.Point(287, 31);
            this.tbRank5.Margin = new System.Windows.Forms.Padding(2);
            this.tbRank5.Name = "tbRank5";
            this.tbRank5.Size = new System.Drawing.Size(49, 20);
            this.tbRank5.TabIndex = 6;
            this.tbRank5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRank_KeyPress);
            // 
            // lRank5
            // 
            this.lRank5.AutoSize = true;
            this.lRank5.Location = new System.Drawing.Point(284, 16);
            this.lRank5.Name = "lRank5";
            this.lRank5.Size = new System.Drawing.Size(52, 13);
            this.lRank5.TabIndex = 16;
            this.lRank5.Text = "5 разряд";
            // 
            // tbRank6
            // 
            this.tbRank6.Location = new System.Drawing.Point(356, 31);
            this.tbRank6.Margin = new System.Windows.Forms.Padding(2);
            this.tbRank6.Name = "tbRank6";
            this.tbRank6.Size = new System.Drawing.Size(49, 20);
            this.tbRank6.TabIndex = 7;
            this.tbRank6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRank_KeyPress);
            // 
            // lRank6
            // 
            this.lRank6.AutoSize = true;
            this.lRank6.Location = new System.Drawing.Point(353, 16);
            this.lRank6.Name = "lRank6";
            this.lRank6.Size = new System.Drawing.Size(52, 13);
            this.lRank6.TabIndex = 18;
            this.lRank6.Text = "6 разряд";
            // 
            // gbTariff
            // 
            this.gbTariff.Controls.Add(this.lRank1);
            this.gbTariff.Controls.Add(this.tbRank6);
            this.gbTariff.Controls.Add(this.tbRank1);
            this.gbTariff.Controls.Add(this.lRank6);
            this.gbTariff.Controls.Add(this.lRank2);
            this.gbTariff.Controls.Add(this.tbRank5);
            this.gbTariff.Controls.Add(this.tbRank2);
            this.gbTariff.Controls.Add(this.lRank5);
            this.gbTariff.Controls.Add(this.lRank3);
            this.gbTariff.Controls.Add(this.tbRank4);
            this.gbTariff.Controls.Add(this.tbRank3);
            this.gbTariff.Controls.Add(this.lRank4);
            this.gbTariff.Location = new System.Drawing.Point(9, 37);
            this.gbTariff.Name = "gbTariff";
            this.gbTariff.Size = new System.Drawing.Size(414, 60);
            this.gbTariff.TabIndex = 20;
            this.gbTariff.TabStop = false;
            this.gbTariff.Text = "Тариф";
            // 
            // frmProfession
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(430, 135);
            this.Controls.Add(this.gbTariff);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lCode);
            this.Controls.Add(this.mtbCode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmProfession";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новая профессия";
            this.gbTariff.ResumeLayout(false);
            this.gbTariff.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedTextBox mtbCode;
        private Label lCode;
        private Label lTitle;
        private TextBox tbTitle;
        private Button bSave;
        private Button bCancel;
        private Label lRank1;
        private TextBox tbRank1;
        private TextBox tbRank2;
        private Label lRank2;
        private TextBox tbRank3;
        private Label lRank3;
        private TextBox tbRank4;
        private Label lRank4;
        private TextBox tbRank5;
        private Label lRank5;
        private TextBox tbRank6;
        private Label lRank6;
        private GroupBox gbTariff;
    }
}