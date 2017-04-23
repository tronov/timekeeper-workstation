using System;
using System.Threading;
using System.Windows.Forms;
using Project.Forms.Elements;
using Project.Forms.Tables;

namespace Project.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
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
            ShowChild(typeof(ProfessionsForm));
        }

        private void miPersons_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(PersonsForm));
        }

        private void miStructure_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(StructureForm));
        }

        private void miWarranties_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(WarrantiesForm));
        }

        private void miTables_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(TableForm));
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var splash = new SplashForm();
            splash.Show();
            Thread.Sleep(2000);
            splash.Close();
            TopMost = true;
            TopMost = false;
        }
    }
}
