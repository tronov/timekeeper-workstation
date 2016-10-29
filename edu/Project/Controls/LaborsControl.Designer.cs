namespace Project.Controls
{
 partial class LaborsControl
 {
  /// <summary> 
  /// Требуется переменная конструктора.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary> 
  /// Освободить все используемые ресурсы.
  /// </summary>
  /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
  protected override void Dispose(bool disposing)
  {
   if (disposing && (components != null))
   {
    components.Dispose();
   }
   base.Dispose(disposing);
  }

  #region Код, автоматически созданный конструктором компонентов

  /// <summary> 
  /// Обязательный метод для поддержки конструктора - не изменяйте 
  /// содержимое данного метода при помощи редактора кода.
  /// </summary>
  private void InitializeComponent()
  {
      this.dgvItems = new System.Windows.Forms.DataGridView();
      this.LaborId = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.LaborDate = new Project.Controls.CalendarColumn();
      this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
      this.SuspendLayout();
      // 
      // dgvItems
      // 
      this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LaborId,
            this.LaborDate,
            this.Hours});
      this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvItems.Location = new System.Drawing.Point(0, 0);
      this.dgvItems.MultiSelect = false;
      this.dgvItems.Name = "dgvItems";
      this.dgvItems.RowHeadersWidth = 30;
      this.dgvItems.Size = new System.Drawing.Size(262, 211);
      this.dgvItems.TabIndex = 6;
      this.dgvItems.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItems_RowValidating);
      this.dgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvLabors_EditingControlShowing);
      // 
      // LaborId
      // 
      this.LaborId.HeaderText = "LaborId";
      this.LaborId.MinimumWidth = 20;
      this.LaborId.Name = "LaborId";
      this.LaborId.Visible = false;
      this.LaborId.Width = 20;
      // 
      // LaborDate
      // 
      this.LaborDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.LaborDate.HeaderText = "Дата работы";
      this.LaborDate.MinimumWidth = 90;
      this.LaborDate.Name = "LaborDate";
      this.LaborDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.LaborDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // Hours
      // 
      this.Hours.HeaderText = "Часы работы";
      this.Hours.MinimumWidth = 70;
      this.Hours.Name = "Hours";
      this.Hours.Width = 70;
      // 
      // LaborsControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.dgvItems);
      this.Name = "LaborsControl";
      this.Size = new System.Drawing.Size(262, 211);
      ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
      this.ResumeLayout(false);

  }

  #endregion

  public System.Windows.Forms.DataGridView dgvItems;
  private System.Windows.Forms.DataGridViewTextBoxColumn LaborId;
  private CalendarColumn LaborDate;
  private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
 }
}
