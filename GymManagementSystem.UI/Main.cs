using Gym.Members;
using System;
using System.Windows.Forms;

namespace GymManagementSystem.UI
{
    public partial class Main : Form
    {       

        public Main()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaxmize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void _LoadUserControl(UserControl uc)
        {
            pnlContainer.Controls.Clear();

            uc.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            _LoadUserControl(new ucMembersList());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }
    }
}

