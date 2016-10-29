namespace Project
{
 partial class frmPersonProfession
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
   this.bProfessionCode = new System.Windows.Forms.Button();
   this.tbProfessionTitle = new System.Windows.Forms.TextBox();
   this.lProfession = new System.Windows.Forms.Label();
   this.lRank = new System.Windows.Forms.Label();
   this.cbRank = new System.Windows.Forms.ComboBox();
   this.bSave = new System.Windows.Forms.Button();
   this.bCancel = new System.Windows.Forms.Button();
   this.SuspendLayout();
   // 
   // bProfessionCode
   // 
   this.bProfessionCode.Location = new System.Drawing.Point(83, 12);
   this.bProfessionCode.Name = "bProfessionCode";
   this.bProfessionCode.Size = new System.Drawing.Size(55, 23);
   this.bProfessionCode.TabIndex = 0;
   this.bProfessionCode.UseVisualStyleBackColor = true;
   this.bProfessionCode.Click += new System.EventHandler(this.bProfessionCode_Click);
   // 
   // tbProfessionTitle
   // 
   this.tbProfessionTitle.Location = new System.Drawing.Point(146, 14);
   this.tbProfessionTitle.Name = "tbProfessionTitle";
   this.tbProfessionTitle.ReadOnly = true;
   this.tbProfessionTitle.Size = new System.Drawing.Size(241, 20);
   this.tbProfessionTitle.TabIndex = 1;
   // 
   // lProfession
   // 
   this.lProfession.AutoSize = true;
   this.lProfession.Location = new System.Drawing.Point(12, 17);
   this.lProfession.Name = "lProfession";
   this.lProfession.Size = new System.Drawing.Size(65, 13);
   this.lProfession.TabIndex = 2;
   this.lProfession.Text = "Профессия";
   // 
   // lRank
   // 
   this.lRank.AutoSize = true;
   this.lRank.Location = new System.Drawing.Point(418, 17);
   this.lRank.Name = "lRank";
   this.lRank.Size = new System.Drawing.Size(44, 13);
   this.lRank.TabIndex = 3;
   this.lRank.Text = "Разряд";
   // 
   // cbRank
   // 
   this.cbRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
   this.cbRank.FormattingEnabled = true;
   this.cbRank.Items.AddRange(new object[] {
   "1",
   "2",
   "3",
   "4",
   "5",
   "6"});
   this.cbRank.Location = new System.Drawing.Point(468, 14);
   this.cbRank.Name = "cbRank";
   this.cbRank.Size = new System.Drawing.Size(45, 21);
   this.cbRank.TabIndex = 4;
   // 
   // bSave
   // 
   this.bSave.Location = new System.Drawing.Point(355, 50);
   this.bSave.Name = "bSave";
   this.bSave.Size = new System.Drawing.Size(76, 23);
   this.bSave.TabIndex = 5;
   this.bSave.Text = "Сохранить";
   this.bSave.UseVisualStyleBackColor = true;
   this.bSave.Click += new System.EventHandler(this.bSave_Click);
   // 
   // bCancel
   // 
   this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
   this.bCancel.Location = new System.Drawing.Point(437, 50);
   this.bCancel.Name = "bCancel";
   this.bCancel.Size = new System.Drawing.Size(76, 23);
   this.bCancel.TabIndex = 6;
   this.bCancel.Text = "Отмена";
   this.bCancel.UseVisualStyleBackColor = true;
   // 
   // frmPersonProfession
   // 
   this.AcceptButton = this.bSave;
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.CancelButton = this.bCancel;
   this.ClientSize = new System.Drawing.Size(527, 87);
   this.Controls.Add(this.bCancel);
   this.Controls.Add(this.bSave);
   this.Controls.Add(this.cbRank);
   this.Controls.Add(this.lRank);
   this.Controls.Add(this.lProfession);
   this.Controls.Add(this.tbProfessionTitle);
   this.Controls.Add(this.bProfessionCode);
   this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
   this.MaximizeBox = false;
   this.Name = "frmPersonProfession";
   this.ShowIcon = false;
   this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
   this.Text = "Новая квалификация сотрудника";
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.Button bProfessionCode;
  private System.Windows.Forms.TextBox tbProfessionTitle;
  private System.Windows.Forms.Label lProfession;
  private System.Windows.Forms.Label lRank;
  private System.Windows.Forms.ComboBox cbRank;
  private System.Windows.Forms.Button bSave;
  private System.Windows.Forms.Button bCancel;
 }
}