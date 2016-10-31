namespace Project.Forms
{
 partial class frmMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miStructure = new System.Windows.Forms.ToolStripMenuItem();
            this.miCatalogs = new System.Windows.Forms.ToolStripMenuItem();
            this.miPersons = new System.Windows.Forms.ToolStripMenuItem();
            this.miProfessions = new System.Windows.Forms.ToolStripMenuItem();
            this.miDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.miWarranties = new System.Windows.Forms.ToolStripMenuItem();
            this.miTables = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(792, 25);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // mainMenuExit
            // 
            this.mainMenuExit.Name = "mainMenuExit";
            this.mainMenuExit.Size = new System.Drawing.Size(113, 22);
            this.mainMenuExit.Text = "Выход";
            this.mainMenuExit.Click += new System.EventHandler(this.mainMenuExit_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStructure,
            this.miCatalogs,
            this.miDocuments});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // miStructure
            // 
            this.miStructure.Name = "miStructure";
            this.miStructure.Size = new System.Drawing.Size(215, 22);
            this.miStructure.Text = "Структура организации";
            this.miStructure.Click += new System.EventHandler(this.miStructure_Click);
            // 
            // miCatalogs
            // 
            this.miCatalogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPersons,
            this.miProfessions});
            this.miCatalogs.Name = "miCatalogs";
            this.miCatalogs.Size = new System.Drawing.Size(215, 22);
            this.miCatalogs.Text = "Справочники";
            // 
            // miPersons
            // 
            this.miPersons.Name = "miPersons";
            this.miPersons.Size = new System.Drawing.Size(145, 22);
            this.miPersons.Text = "Сотрудники";
            this.miPersons.Click += new System.EventHandler(this.miPersons_Click);
            // 
            // miProfessions
            // 
            this.miProfessions.Name = "miProfessions";
            this.miProfessions.Size = new System.Drawing.Size(145, 22);
            this.miProfessions.Text = "Профессии";
            this.miProfessions.Click += new System.EventHandler(this.miProfessions_Click);
            // 
            // miDocuments
            // 
            this.miDocuments.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miWarranties,
            this.miTables});
            this.miDocuments.Name = "miDocuments";
            this.miDocuments.Size = new System.Drawing.Size(215, 22);
            this.miDocuments.Text = "Документы";
            // 
            // miWarranties
            // 
            this.miWarranties.Name = "miWarranties";
            this.miWarranties.Size = new System.Drawing.Size(123, 22);
            this.miWarranties.Text = "Наряды";
            this.miWarranties.Click += new System.EventHandler(this.miWarranties_Click);
            // 
            // miTables
            // 
            this.miTables.Name = "miTables";
            this.miTables.Size = new System.Drawing.Size(123, 22);
            this.miTables.Text = "Табели";
            this.miTables.Click += new System.EventHandler(this.miTables_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(158, 22);
            this.miAbout.Text = "О программе";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 544);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(792, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АРМ табельщика";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.MenuStrip menuStrip;
  private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
  private System.Windows.Forms.ToolStripMenuItem mainMenuExit;
  private System.Windows.Forms.StatusStrip statusStrip;
  private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
  private System.Windows.Forms.ToolStripStatusLabel status;
  private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
  private System.Windows.Forms.ToolStripMenuItem miCatalogs;
  private System.Windows.Forms.ToolStripMenuItem miProfessions;
  private System.Windows.Forms.ToolStripMenuItem miDocuments;
  private System.Windows.Forms.ToolStripMenuItem miWarranties;
  private System.Windows.Forms.ToolStripMenuItem miTables;
  private System.Windows.Forms.ToolStripMenuItem miPersons;
  private System.Windows.Forms.ToolStripMenuItem miStructure;
  private System.Windows.Forms.ToolStripMenuItem miAbout;



 }
}