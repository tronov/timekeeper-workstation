using System;
using System.Windows.Forms;
using Project.Forms.Elements;
using Project.Forms.Tables;

namespace Project.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowChild(Type type)
        {
            int frmId = -1;
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].GetType().Equals(type))
                {
                    frmId = i;
                }
            }
            if (frmId == -1)
            {
                Form form = (Form)Activator.CreateInstance(type);
                form.MdiParent = this;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            else this.MdiChildren[frmId].Focus();
        }

        private void mainMenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miProfessions_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(frmProfessions));
        }

        private void miPersons_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(frmPersons));
        }

        private void miStructure_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(frmStructure));
        }

        private void miWarranties_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(frmWarranties));
        }

        private void miTables_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(frmTable));
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            frmAbout form = new frmAbout();
            form.ShowDialog(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmSplash splash = new frmSplash();
            splash.Show();
            System.Threading.Thread.Sleep(2000);
            splash.Close();
            this.TopMost = true;
            this.TopMost = false;
        }
    }
}
