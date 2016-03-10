using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2_0.Admin
{
    public partial class AdminMenu : MetroForm
    {
        public AdminMenu()
        {
            InitializeComponent();
            notifyIcon1.BalloonTipText = "Application Minimized";
            notifyIcon1.BalloonTipTitle = "Eminence";
            dateLabel.Text = DateTime.Now.ToString("dddd  dd, MMM yyyy");
            company.Text = "© Techagentx";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
            menuProgressBar.Value = menuProgressBar.Value + 5;
            if (menuProgressBar.Value == 100)
            {
                menuProgressBar.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void AdminMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void inventoryTile_MouseEnter(object sender, EventArgs e)
        {
            inventoryTile.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void inventoryTile_MouseLeave(object sender, EventArgs e)
        {
            inventoryTile.Style = MetroFramework.MetroColorStyle.Blue;
        }

        private void metroTile3_MouseEnter(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile3_MouseLeave(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Teal;
        }

        private void metroTile10_MouseEnter(object sender, EventArgs e)
        {
            metroTile10.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile10_MouseLeave(object sender, EventArgs e)
        {
            metroTile10.Style = MetroFramework.MetroColorStyle.Purple;
        }

        private void metroTile2_MouseEnter(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile2_MouseLeave(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Green;
        }

        private void metroTile4_MouseEnter(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile4_MouseLeave(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Silver;
        }

        private void metroTile5_MouseEnter(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Silver;
        }

        private void metroTile5_MouseLeave(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile7_MouseEnter(object sender, EventArgs e)
        {
            metroTile7.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile7_MouseLeave(object sender, EventArgs e)
        {
            metroTile7.Style = MetroFramework.MetroColorStyle.Brown;
        }

        private void metroTile8_MouseEnter(object sender, EventArgs e)
        {
            metroTile8.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile8_MouseLeave(object sender, EventArgs e)
        {
            metroTile8.Style = MetroFramework.MetroColorStyle.Orange;
        }

    }
}
