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
    public partial class adminSettings : MetroForm
    {
        string userName = "", userType = "";
        public adminSettings(string user_name, string user_type)
        {
            InitializeComponent();
            this.FocusMe();
            metroTile2.Select();
            userName = user_name;
            userType = user_type;
        }

        private void metroTile2_MouseEnter(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile2_MouseLeave(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Green;
        }

        private void metroTile1_MouseEnter(object sender, EventArgs e)
        {
            metroTile1.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile1_MouseLeave(object sender, EventArgs e)
        {
            metroTile1.Style = MetroFramework.MetroColorStyle.Silver;
        }

        private void metroTile3_MouseEnter(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile3_MouseLeave(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Teal;
        }

        private void metroTile4_MouseEnter(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile4_MouseLeave(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Blue;
        }

        private void metroTile5_MouseEnter(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile5_MouseLeave(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Purple;
        }

        private void metroTile6_MouseEnter(object sender, EventArgs e)
        {
            metroTile6.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile6_MouseLeave(object sender, EventArgs e)
        {
            metroTile6.Style = MetroFramework.MetroColorStyle.Yellow;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Database_Backup myBackup = new Database_Backup();
            myBackup.dbBackup();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            General.loginHistory loginHistory = new General.loginHistory(userName);
            loginHistory.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            General.changePassword changePass = new General.changePassword(userName, userType);
            changePass.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            Admin.Inactive_User userManage = new Admin.Inactive_User();
            userManage.ShowDialog();
        }

    }
}
