using System.ComponentModel;
using System.Windows.Forms;

namespace Project
{
    partial class PersonForm
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
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.mtbCode = new System.Windows.Forms.MaskedTextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.lCode = new System.Windows.Forms.Label();
            this.tbMiddleName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.lFirstName = new System.Windows.Forms.Label();
            this.lMiddleName = new System.Windows.Forms.Label();
            this.lLastName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(350, 78);
            this.bSave.Margin = new System.Windows.Forms.Padding(2);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(85, 23);
            this.bSave.TabIndex = 5;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(441, 78);
            this.bCancel.Margin = new System.Windows.Forms.Padding(2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(85, 23);
            this.bCancel.TabIndex = 6;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // mtbCode
            // 
            this.mtbCode.Location = new System.Drawing.Point(113, 7);
            this.mtbCode.Margin = new System.Windows.Forms.Padding(2);
            this.mtbCode.Mask = "0000";
            this.mtbCode.Name = "mtbCode";
            this.mtbCode.Size = new System.Drawing.Size(30, 20);
            this.mtbCode.TabIndex = 0;
            this.mtbCode.Validating += new System.ComponentModel.CancelEventHandler(this.mtbCode_Validating);
            this.mtbCode.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbCode_MaskInputRejected);
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(226, 42);
            this.tbFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.tbFirstName.MaxLength = 31;
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(108, 20);
            this.tbFirstName.TabIndex = 2;
            // 
            // lCode
            // 
            this.lCode.AutoSize = true;
            this.lCode.Location = new System.Drawing.Point(13, 9);
            this.lCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCode.Name = "lCode";
            this.lCode.Size = new System.Drawing.Size(99, 13);
            this.lCode.TabIndex = 7;
            this.lCode.Text = "Табельный номер";
            // 
            // tbMiddleName
            // 
            this.tbMiddleName.Location = new System.Drawing.Point(405, 42);
            this.tbMiddleName.Margin = new System.Windows.Forms.Padding(2);
            this.tbMiddleName.MaxLength = 31;
            this.tbMiddleName.Name = "tbMiddleName";
            this.tbMiddleName.Size = new System.Drawing.Size(121, 20);
            this.tbMiddleName.TabIndex = 3;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(71, 42);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(2);
            this.tbLastName.MaxLength = 31;
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(107, 20);
            this.tbLastName.TabIndex = 1;
            // 
            // lFirstName
            // 
            this.lFirstName.AutoSize = true;
            this.lFirstName.Location = new System.Drawing.Point(193, 45);
            this.lFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFirstName.Name = "lFirstName";
            this.lFirstName.Size = new System.Drawing.Size(29, 13);
            this.lFirstName.TabIndex = 7;
            this.lFirstName.Text = "Имя";
            // 
            // lMiddleName
            // 
            this.lMiddleName.AutoSize = true;
            this.lMiddleName.Location = new System.Drawing.Point(347, 45);
            this.lMiddleName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMiddleName.Name = "lMiddleName";
            this.lMiddleName.Size = new System.Drawing.Size(54, 13);
            this.lMiddleName.TabIndex = 8;
            this.lMiddleName.Text = "Отчество";
            // 
            // lLastName
            // 
            this.lLastName.AutoSize = true;
            this.lLastName.Location = new System.Drawing.Point(13, 45);
            this.lLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lLastName.Name = "lLastName";
            this.lLastName.Size = new System.Drawing.Size(56, 13);
            this.lLastName.TabIndex = 8;
            this.lLastName.Text = "Фамилия";
            // 
            // PersonForm
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(537, 114);
            this.Controls.Add(this.lLastName);
            this.Controls.Add(this.lMiddleName);
            this.Controls.Add(this.lFirstName);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbMiddleName);
            this.Controls.Add(this.lCode);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.mtbCode);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PersonForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый сотрудник";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bSave;
        private Button bCancel;
        private MaskedTextBox mtbCode;
        private TextBox tbFirstName;
        private Label lCode;
        private TextBox tbMiddleName;
        private TextBox tbLastName;
        private Label lFirstName;
        private Label lMiddleName;
        private Label lLastName;
    }
}