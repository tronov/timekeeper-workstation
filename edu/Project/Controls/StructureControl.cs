using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Project.Databases;
using Project.Forms.Elements;

namespace Project.Controls
{
 public partial class StructureControl : UserControl
 {
  private CatalogMode _CatalogMode;
  private ContextMenuStrip _cmArea = new ContextMenuStrip();
  private ContextMenuStrip _cmBrigade = new ContextMenuStrip();
  private int _SelectedAreaId = 0;
  private int _SelectedBrigadeId = 0;

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public int SelectedAreaId
  {
   get
   {
    return this._SelectedAreaId;
   }
   private set
   {
    this._SelectedAreaId = value;
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public int SelectedBrigadeId
  {
   get
   {
    return this._SelectedBrigadeId;
   }
   private set
   {
    this._SelectedBrigadeId = value;
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public CatalogMode CatalogMode
  {
   get { return this._CatalogMode; }
   set
   {
    this._CatalogMode = value;
    if (value == CatalogMode.Select)
    {
     this.scMain.Panel2Collapsed = true;
     this.Height = this.scMain.Panel1.Height;
     this._cmArea = new ContextMenuStrip();
     this._cmBrigade = this.cmBrigadeSelect;

    }
    if (value == CatalogMode.View)
    {
     this.scMain.Panel2Collapsed = false;
     this._cmArea = cmAreaView;
     this._cmBrigade = cmBrigadeView;
    }
    Init();
   }
  }

  public StructureControl()
  {
   InitializeComponent();
   this.CatalogMode = CatalogMode.View;
   Init();
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public void NewArea()
  {
   frmArea form = new frmArea();
   form.ShowDialog(this);
   Init();
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public void EditArea()
  {
   if (this.SelectedAreaId != 0)
   {
    Area area = Data.Tables.Areas[this.SelectedAreaId];
    frmArea form = new frmArea(area);
    form.ShowDialog(this);
    Init();
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public void DeleteArea()
  {
   if (this.SelectedAreaId != 0)
   {
    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.OKCancel).Equals(DialogResult.OK))
    {
     Area area = Data.Tables.Areas[this.SelectedAreaId];
     area.Delete();
     Init();
    }
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public void NewBrigade()
  {
   if (this.SelectedAreaId != 0)
   {
    Area area = Data.Tables.Areas[this.SelectedAreaId];
    frmBrigade form = new frmBrigade(area);
    form.ShowDialog(this);
    Init();
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public void EditBrigade()
  {
   if (this.SelectedBrigadeId != 0)
   {
    Brigade brigade = Data.Tables.Brigades[this.SelectedBrigadeId];
    frmBrigade form = new frmBrigade(brigade);
    form.ShowDialog(this);
    Init();
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public void DeleteBrigade()
  {
   if (this.SelectedBrigadeId != 0)
   {
    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.OKCancel).Equals(DialogResult.OK))
    {
     Data.Tables.Brigades[this.SelectedBrigadeId].Delete();
     Init();
    }
   }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public virtual void Init()
  {
   if (tvStructure.Nodes.Count != 0) tvStructure.Nodes.Clear();
   Areas areas = Data.Tables.Areas.Active;

   foreach (Area area in areas.OrderBy(r => r.Code))
   {
    TreeNode areaNode = new TreeNode();
    areaNode.Text = String.Format("{0}  {1}", area.Code.ToString("D2"), area.Title);
    areaNode.Tag = area;

    this.tvStructure.Nodes.Add(areaNode);

    foreach (Brigade brigade in area.Brigades)
    {
     if (brigade.IsActive)
     {
      TreeNode brigadeNode = new TreeNode();
      brigadeNode.Text = String.Format("{0}  {1}", brigade.Code.ToString("D2"), brigade.Title);

      brigadeNode.Tag = brigade;

      areaNode.Nodes.Add(brigadeNode);
     }
    }
   }
   this.tvStructure.ExpandAll();
  }

  private void tvStructure_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
  {
   TreeView tv = (TreeView)sender;
   tv.SelectedNode = e.Node;
   TreeNode node = e.Node;   
   
   if (e.Button.Equals(MouseButtons.Right))
   {
    if (node.Tag is Area)
    {
     _cmArea.Show(tv, e.Location);
    }
    if (node.Tag is Brigade)
    {
     _cmBrigade.Show(tv, e.Location);
    }
   }
  }

  private void miBrigadeSelect_Click(object sender, EventArgs e)
  {
   this.SelectedBrigadeId = ((Brigade)tvStructure.SelectedNode.Tag).Id;
   this.FindForm().Close();
  }

  private void tvStructure_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
  {
   if (this.CatalogMode == CatalogMode.Select && tvStructure.SelectedNode.Tag is Brigade)
   {
    this.SelectedBrigadeId = ((Brigade)tvStructure.SelectedNode.Tag).Id;
    this.FindForm().Close();
   }

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
   frmArea form = new frmArea();
   if (form.ShowDialog() == DialogResult.OK)
    Init();
  }
 }
}
