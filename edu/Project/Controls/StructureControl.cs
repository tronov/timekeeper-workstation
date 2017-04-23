using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Data;
using Project.Forms.Elements;

namespace Project.Controls
{
    public partial class StructureControl : UserControl
    {
        private CatalogMode _CatalogMode;
        private ContextMenuStrip _cmArea = new ContextMenuStrip();
        private ContextMenuStrip _cmBrigade = new ContextMenuStrip();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedAreaId { get; private set; } = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedBrigadeId { get; private set; } = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CatalogMode CatalogMode
        {
            get { return _CatalogMode; }
            set
            {
                _CatalogMode = value;
                if (value == CatalogMode.Select)
                {
                    scMain.Panel2Collapsed = true;
                    Height = scMain.Panel1.Height;
                    _cmArea = new ContextMenuStrip();
                    _cmBrigade = this.cmBrigadeSelect;

                }
                if (value == CatalogMode.View)
                {
                    scMain.Panel2Collapsed = false;
                    _cmArea = cmAreaView;
                    _cmBrigade = cmBrigadeView;
                }
                Init();
            }
        }

        public StructureControl()
        {
            InitializeComponent();
            CatalogMode = CatalogMode.View;
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void NewArea()
        {
            var form = new frmArea();
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void EditArea()
        {
            if (SelectedAreaId == 0) return;

            var area = Databases.Tables.Areas[SelectedAreaId];
            var form = new frmArea(area);
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DeleteArea()
        {
            if (SelectedAreaId == 0) return;

            if (!MessageBox
                .Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.OKCancel)
                .Equals(DialogResult.OK)) return;

            var area = Databases.Tables.Areas[this.SelectedAreaId];
            area.Delete();
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void NewBrigade()
        {
            if (SelectedAreaId == 0) return;

            var area = Databases.Tables.Areas[SelectedAreaId];
            var form = new frmBrigade(area);
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void EditBrigade()
        {
            if (SelectedBrigadeId == 0) return;

            var brigade = Databases.Tables.Brigades[SelectedBrigadeId];
            var form = new frmBrigade(brigade);
            form.ShowDialog(this);
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DeleteBrigade()
        {
            if (SelectedBrigadeId == 0) return;

            if (!MessageBox
                .Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.OKCancel)
                .Equals(DialogResult.OK)) return;

            Databases.Tables.Brigades[SelectedBrigadeId].Delete();
            Init();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual void Init()
        {
            if (tvStructure.Nodes.Count != 0) tvStructure.Nodes.Clear();

            var areas = Databases.Tables.Areas;

            foreach (var area in areas.OrderBy(a => a.Code))
            {
                var areaNode = new TreeNode
                {
                    Text = $"{area.Code:D2}  {area.Title}",
                    Tag = area
                };

                tvStructure.Nodes.Add(areaNode);

                foreach (var brigade in area.Brigades)
                {
                    if (!brigade.IsActive) continue;

                    var brigadeNode = new TreeNode
                    {
                        Text = $"{brigade.Code:D2}  {brigade.Title}",
                        Tag = brigade
                    };

                    areaNode.Nodes.Add(brigadeNode);
                }
            }
            tvStructure.ExpandAll();
        }

        private void tvStructure_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var tv = sender as TreeView;
            if (tv == null) return;

            tv.SelectedNode = e.Node;
            var node = e.Node;

            if (!e.Button.Equals(MouseButtons.Right)) return;

            if (node.Tag is Area)
            {
                _cmArea.Show(tv, e.Location);
            }
            else if (node.Tag is Brigade)
            {
                _cmBrigade.Show(tv, e.Location);
            }
        }

        private void miBrigadeSelect_Click(object sender, EventArgs e)
        {
            var brigade = tvStructure.SelectedNode.Tag as Brigade;
            if (brigade != null) SelectedBrigadeId = brigade.Id;
            FindForm()?.Close();
        }

        private void tvStructure_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (CatalogMode != CatalogMode.Select || !(tvStructure.SelectedNode.Tag is Brigade)) return;

            SelectedBrigadeId = ((Brigade)tvStructure.SelectedNode.Tag).Id;
            FindForm()?.Close();
        }

        private void miBrigadeAdd_Click(object sender, EventArgs e)
        {
            NewBrigade();
        }

        private void miAreaEdit_Click(object sender, EventArgs e)
        {
            EditArea();
        }

        private void miAreaDelete_Click(object sender, EventArgs e)
        {
            DeleteArea();
        }

        private void miBrigadeEdit_Click(object sender, EventArgs e)
        {
            EditBrigade();
        }

        private void miBrigadeDelete_Click(object sender, EventArgs e)
        {
            DeleteBrigade();
        }

        private void tvStructure_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Area)
            {
                SelectedAreaId = (e.Node.Tag as Area).Id;
                SelectedBrigadeId = 0;
            }
            if (e.Node.Tag is Brigade)
            {
                SelectedBrigadeId = (e.Node.Tag as Brigade).Id;
            }
        }

        private void bAreaNew_Click(object sender, EventArgs e)
        {
            var form = new frmArea();
            if (form.ShowDialog() == DialogResult.OK)
                Init();
        }
    }
}
