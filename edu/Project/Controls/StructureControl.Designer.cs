namespace Project.Controls
{
    partial class StructureControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator cmAreaSeparator;
            this.cmAreaView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miBrigadeAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miAreaEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miAreaDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmBrigadeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miBrigadeEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrigadeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gbStructure = new System.Windows.Forms.GroupBox();
            this.tvStructure = new System.Windows.Forms.TreeView();
            this.cmBrigadeSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miBrigadeSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.gbOperations = new System.Windows.Forms.GroupBox();
            this.bAreaNew = new System.Windows.Forms.Button();
            this.scMain = new System.Windows.Forms.SplitContainer();
            cmAreaSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cmAreaView.SuspendLayout();
            this.cmBrigadeView.SuspendLayout();
            this.gbStructure.SuspendLayout();
            this.cmBrigadeSelect.SuspendLayout();
            this.gbOperations.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmAreaSeparator
            // 
            cmAreaSeparator.Name = "cmAreaSeparator";
            cmAreaSeparator.Size = new System.Drawing.Size(170, 6);
            // 
            // cmAreaView
            // 
            this.cmAreaView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
   this.miBrigadeAdd,
   cmAreaSeparator,
   this.miAreaEdit,
   this.miAreaDelete});
            this.cmAreaView.Name = "cmArea";
            this.cmAreaView.Size = new System.Drawing.Size(174, 76);
            // 
            // miBrigadeAdd
            // 
            this.miBrigadeAdd.Name = "miBrigadeAdd";
            this.miBrigadeAdd.Size = new System.Drawing.Size(173, 22);
            this.miBrigadeAdd.Text = "Добавить бригаду";
            this.miBrigadeAdd.Click += new System.EventHandler(this.miBrigadeAdd_Click);
            // 
            // miAreaEdit
            // 
            this.miAreaEdit.Name = "miAreaEdit";
            this.miAreaEdit.Size = new System.Drawing.Size(173, 22);
            this.miAreaEdit.Text = "Редактировать";
            this.miAreaEdit.Click += new System.EventHandler(this.miAreaEdit_Click);
            // 
            // miAreaDelete
            // 
            this.miAreaDelete.Name = "miAreaDelete";
            this.miAreaDelete.Size = new System.Drawing.Size(173, 22);
            this.miAreaDelete.Text = "Удалить";
            this.miAreaDelete.Click += new System.EventHandler(this.miAreaDelete_Click);
            // 
            // cmBrigadeView
            // 
            this.cmBrigadeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
   this.miBrigadeEdit,
   this.miBrigadeDelete});
            this.cmBrigadeView.Name = "cmBrigade";
            this.cmBrigadeView.Size = new System.Drawing.Size(155, 48);
            // 
            // miBrigadeEdit
            // 
            this.miBrigadeEdit.Name = "miBrigadeEdit";
            this.miBrigadeEdit.Size = new System.Drawing.Size(154, 22);
            this.miBrigadeEdit.Text = "Редактировать";
            this.miBrigadeEdit.Click += new System.EventHandler(this.miBrigadeEdit_Click);
            // 
            // miBrigadeDelete
            // 
            this.miBrigadeDelete.Name = "miBrigadeDelete";
            this.miBrigadeDelete.Size = new System.Drawing.Size(154, 22);
            this.miBrigadeDelete.Text = "Удалить";
            this.miBrigadeDelete.Click += new System.EventHandler(this.miBrigadeDelete_Click);
            // 
            // gbStructure
            // 
            this.gbStructure.Controls.Add(this.tvStructure);
            this.gbStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStructure.Location = new System.Drawing.Point(0, 0);
            this.gbStructure.Name = "gbStructure";
            this.gbStructure.Size = new System.Drawing.Size(350, 146);
            this.gbStructure.TabIndex = 2;
            this.gbStructure.TabStop = false;
            this.gbStructure.Text = "Подразделения";
            // 
            // tvStructure
            // 
            this.tvStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStructure.HideSelection = false;
            this.tvStructure.Location = new System.Drawing.Point(3, 16);
            this.tvStructure.Name = "tvStructure";
            this.tvStructure.Size = new System.Drawing.Size(344, 127);
            this.tvStructure.TabIndex = 1;
            this.tvStructure.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvStructure_NodeMouseDoubleClick);
            this.tvStructure.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvStructure_NodeMouseClick);
            this.tvStructure.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvStructure_BeforeSelect);
            // 
            // cmBrigadeSelect
            // 
            this.cmBrigadeSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
   this.miBrigadeSelect});
            this.cmBrigadeSelect.Name = "cmsBrigadeSelect";
            this.cmBrigadeSelect.Size = new System.Drawing.Size(122, 26);
            // 
            // miBrigadeSelect
            // 
            this.miBrigadeSelect.Name = "miBrigadeSelect";
            this.miBrigadeSelect.Size = new System.Drawing.Size(121, 22);
            this.miBrigadeSelect.Text = "Выбрать";
            this.miBrigadeSelect.Click += new System.EventHandler(this.miBrigadeSelect_Click);
            // 
            // gbOperations
            // 
            this.gbOperations.Controls.Add(this.bAreaNew);
            this.gbOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOperations.Location = new System.Drawing.Point(0, 0);
            this.gbOperations.MinimumSize = new System.Drawing.Size(300, 50);
            this.gbOperations.Name = "gbOperations";
            this.gbOperations.Padding = new System.Windows.Forms.Padding(2);
            this.gbOperations.Size = new System.Drawing.Size(350, 50);
            this.gbOperations.TabIndex = 4;
            this.gbOperations.TabStop = false;
            this.gbOperations.Text = "Операции с подразделениями";
            // 
            // bAreaNew
            // 
            this.bAreaNew.Location = new System.Drawing.Point(5, 18);
            this.bAreaNew.Name = "bAreaNew";
            this.bAreaNew.Size = new System.Drawing.Size(124, 23);
            this.bAreaNew.TabIndex = 8;
            this.bAreaNew.Text = "Добавить участок";
            this.bAreaNew.UseVisualStyleBackColor = true;
            this.bAreaNew.Click += new System.EventHandler(this.bAreaNew_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbStructure);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbOperations);
            this.scMain.Panel2MinSize = 50;
            this.scMain.Size = new System.Drawing.Size(350, 200);
            this.scMain.SplitterDistance = 146;
            this.scMain.TabIndex = 5;
            // 
            // StructureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "StructureControl";
            this.Size = new System.Drawing.Size(350, 200);
            this.cmAreaView.ResumeLayout(false);
            this.cmBrigadeView.ResumeLayout(false);
            this.gbStructure.ResumeLayout(false);
            this.cmBrigadeSelect.ResumeLayout(false);
            this.gbOperations.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmAreaView;
        private System.Windows.Forms.ToolStripMenuItem miBrigadeAdd;
        private System.Windows.Forms.ContextMenuStrip cmBrigadeView;
        private System.Windows.Forms.ToolStripMenuItem miBrigadeEdit;
        private System.Windows.Forms.ToolStripMenuItem miBrigadeDelete;
        private System.Windows.Forms.GroupBox gbStructure;
        private System.Windows.Forms.ToolStripMenuItem miAreaEdit;
        private System.Windows.Forms.ToolStripMenuItem miAreaDelete;
        private System.Windows.Forms.ContextMenuStrip cmBrigadeSelect;
        private System.Windows.Forms.ToolStripMenuItem miBrigadeSelect;
        public System.Windows.Forms.GroupBox gbOperations;
        public System.Windows.Forms.Button bAreaNew;
        private System.Windows.Forms.SplitContainer scMain;
        public System.Windows.Forms.TreeView tvStructure;
    }
}
