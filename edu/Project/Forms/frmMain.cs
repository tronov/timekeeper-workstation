using System;
using System.Threading;
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
            var frmId = -1;
            for (var i = 0; i < MdiChildren.Length; i++)
            {
                if (MdiChildren[i].GetType() == type)
                {
                    frmId = i;
                }
            }
            if (frmId == -1)
            {
                var form = (Form)Activator.CreateInstance(type);
                form.MdiParent = this;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            else MdiChildren[frmId].Focus();
        }

        private void mainMenuExit_Click(object sender, EventArgs e)
        {
            Close();
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
            var form = new frmAbout();
            form.ShowDialog(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var splash = new frmSplash();
            splash.Show();
            Thread.Sleep(2000);
            splash.Close();
            TopMost = true;
            TopMost = false;
        }
    }
}
