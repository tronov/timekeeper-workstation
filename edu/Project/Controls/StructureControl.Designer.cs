using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Project.Controls
{
    partial class StructureControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

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
            this.components = new Container();
            ToolStripSeparator cmAreaSeparator;
            this.cmAreaView = new ContextMenuStrip(this.components);
            this.miBrigadeAdd = new ToolStripMenuItem();
            this.miAreaEdit = new ToolStripMenuItem();
            this.miAreaDelete = new ToolStripMenuItem();
            this.cmBrigadeView = new ContextMenuStrip(this.components);
            this.miBrigadeEdit = new ToolStripMenuItem();
            this.miBrigadeDelete = new ToolStripMenuItem();
            this.gbStructure = new GroupBox();
            this.tvStructure = new TreeView();
            this.cmBrigadeSelect = new ContextMenuStrip(this.components);
            this.miBrigadeSelect = new ToolStripMenuItem();
            this.gbOperations = new GroupBox();
            this.bAreaNew = new Button();
            this.scMain = new SplitContainer();
            cmAreaSeparator = new ToolStripSeparator();
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
            cmAreaSeparator.Size = new Size(170, 6);
            // 
            // cmAreaView
            // 
            this.cmAreaView.Items.AddRange(new ToolStripItem[] {
   this.miBrigadeAdd,
   cmAreaSeparator,
   this.miAreaEdit,
   this.miAreaDelete});
            this.cmAreaView.Name = "cmArea";
            this.cmAreaView.Size = new Size(174, 76);
            // 
            // miBrigadeAdd
            // 
            this.miBrigadeAdd.Name = "miBrigadeAdd";
            this.miBrigadeAdd.Size = new Size(173, 22);
            this.miBrigadeAdd.Text = "Добавить бригаду";
            this.miBrigadeAdd.Click += new EventHandler(this.miBrigadeAdd_Click);
            // 
            // miAreaEdit
            // 
            this.miAreaEdit.Name = "miAreaEdit";
            this.miAreaEdit.Size = new Size(173, 22);
            this.miAreaEdit.Text = "Редактировать";
            this.miAreaEdit.Click += new EventHandler(this.miAreaEdit_Click);
            // 
            // miAreaDelete
            // 
            this.miAreaDelete.Name = "miAreaDelete";
            this.miAreaDelete.Size = new Size(173, 22);
            this.miAreaDelete.Text = "Удалить";
            this.miAreaDelete.Click += new EventHandler(this.miAreaDelete_Click);
            // 
            // cmBrigadeView
            // 
            this.cmBrigadeView.Items.AddRange(new ToolStripItem[] {
   this.miBrigadeEdit,
   this.miBrigadeDelete});
            this.cmBrigadeView.Name = "cmBrigade";
            this.cmBrigadeView.Size = new Size(155, 48);
            // 
            // miBrigadeEdit
            // 
            this.miBrigadeEdit.Name = "miBrigadeEdit";
            this.miBrigadeEdit.Size = new Size(154, 22);
            this.miBrigadeEdit.Text = "Редактировать";
            this.miBrigadeEdit.Click += new EventHandler(this.miBrigadeEdit_Click);
            // 
            // miBrigadeDelete
            // 
            this.miBrigadeDelete.Name = "miBrigadeDelete";
            this.miBrigadeDelete.Size = new Size(154, 22);
            this.miBrigadeDelete.Text = "Удалить";
            this.miBrigadeDelete.Click += new EventHandler(this.miBrigadeDelete_Click);
            // 
            // gbStructure
            // 
            this.gbStructure.Controls.Add(this.tvStructure);
            this.gbStructure.Dock = DockStyle.Fill;
            this.gbStructure.Location = new Point(0, 0);
            this.gbStructure.Name = "gbStructure";
            this.gbStructure.Size = new Size(350, 146);
            this.gbStructure.TabIndex = 2;
            this.gbStructure.TabStop = false;
            this.gbStructure.Text = "Подразделения";
            // 
            // tvStructure
            // 
            this.tvStructure.Dock = DockStyle.Fill;
            this.tvStructure.HideSelection = false;
            this.tvStructure.Location = new Point(3, 16);
            this.tvStructure.Name = "tvStructure";
            this.tvStructure.Size = new Size(344, 127);
            this.tvStructure.TabIndex = 1;
            this.tvStructure.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.tvStructure_NodeMouseDoubleClick);
            this.tvStructure.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.tvStructure_NodeMouseClick);
            this.tvStructure.BeforeSelect += new TreeViewCancelEventHandler(this.tvStructure_BeforeSelect);
            // 
            // cmBrigadeSelect
            // 
            this.cmBrigadeSelect.Items.AddRange(new ToolStripItem[] {
   this.miBrigadeSelect});
            this.cmBrigadeSelect.Name = "cmsBrigadeSelect";
            this.cmBrigadeSelect.Size = new Size(122, 26);
            // 
            // miBrigadeSelect
            // 
            this.miBrigadeSelect.Name = "miBrigadeSelect";
            this.miBrigadeSelect.Size = new Size(121, 22);
            this.miBrigadeSelect.Text = "Выбрать";
            this.miBrigadeSelect.Click += new EventHandler(this.miBrigadeSelect_Click);
            // 
            // gbOperations
            // 
            this.gbOperations.Controls.Add(this.bAreaNew);
            this.gbOperations.Dock = DockStyle.Fill;
            this.gbOperations.Location = new Point(0, 0);
            this.gbOperations.MinimumSize = new Size(300, 50);
            this.gbOperations.Name = "gbOperations";
            this.gbOperations.Padding = new Padding(2);
            this.gbOperations.Size = new Size(350, 50);
            this.gbOperations.TabIndex = 4;
            this.gbOperations.TabStop = false;
            this.gbOperations.Text = "Операции с подразделениями";
            // 
            // bAreaNew
            // 
            this.bAreaNew.Location = new Point(5, 18);
            this.bAreaNew.Name = "bAreaNew";
            this.bAreaNew.Size = new Size(124, 23);
            this.bAreaNew.TabIndex = 8;
            this.bAreaNew.Text = "Добавить участок";
            this.bAreaNew.UseVisualStyleBackColor = true;
            this.bAreaNew.Click += new EventHandler(this.bAreaNew_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = DockStyle.Fill;
            this.scMain.FixedPanel = FixedPanel.Panel2;
            this.scMain.Location = new Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbStructure);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbOperations);
            this.scMain.Panel2MinSize = 50;
            this.scMain.Size = new Size(350, 200);
            this.scMain.SplitterDistance = 146;
            this.scMain.TabIndex = 5;
            // 
            // StructureControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.MinimumSize = new Size(350, 200);
            this.Name = "StructureControl";
            this.Size = new Size(350, 200);
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

        private ContextMenuStrip cmAreaView;
        private ToolStripMenuItem miBrigadeAdd;
        private ContextMenuStrip cmBrigadeView;
        private ToolStripMenuItem miBrigadeEdit;
        private ToolStripMenuItem miBrigadeDelete;
        private GroupBox gbStructure;
        private ToolStripMenuItem miAreaEdit;
        private ToolStripMenuItem miAreaDelete;
        private ContextMenuStrip cmBrigadeSelect;
        private ToolStripMenuItem miBrigadeSelect;
        public GroupBox gbOperations;
        public Button bAreaNew;
        private SplitContainer scMain;
        public TreeView tvStructure;
    }
}
