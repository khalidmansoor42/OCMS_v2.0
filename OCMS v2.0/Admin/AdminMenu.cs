using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2_0.Admin
{
    public partial class AdminMenu : MetroForm
    {
        connection obj = new connection();
        public AdminMenu(string username, string usertype)
        {
            InitializeComponent();
            this.FocusMe();
            userName.Select();
            notifyIcon1.BalloonTipText = "Application Minimized";
            notifyIcon1.BalloonTipTitle = "Eminence";
            dateLabel.Text = DateTime.Now.ToString("dddd  dd, MMM yyyy");
            company.Text = "© Techagentx";
            userNameLabel.Text = username;
            userTypeLabel.Text = usertype;
            loggedInTimeLabel.Text = DateTime.Now.ToShortTimeString();
            userName.Text = username;
            get_pic();
        }

        void get_pic()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(obj.myConnection);
                String query = "SELECT image FROM mydb.user_registration where user_name =@1;";
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                SelectCommand.Parameters.Add(new MySqlParameter("@1", this.userNameLabel.Text));
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count++;
                    byte[] imgg = (byte[])(myReader["image"]);
                    if (imgg != null)
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }
                myConn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("donot Find Form ic");
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
            menuProgressBar.Value = menuProgressBar.Value + 10;
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

        private void button2_Click(object sender, EventArgs e)
        {
            General.MyProfile myProfile = new General.MyProfile(userNameLabel.Text, userTypeLabel.Text);
            myProfile.Show();
        }

        private void inventoryTile_Click(object sender, EventArgs e)
        {
            Admin.User_Registration regUser = new Admin.User_Registration(userNameLabel.Text, userTypeLabel.Text);
            regUser.ShowDialog();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            General.Add_City addCity = new General.Add_City();
            addCity.ShowDialog();
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            General.Add_Diseases addDisease = new General.Add_Diseases();
            addDisease.ShowDialog();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            General.Medicine addMedicine = new General.Medicine();
            addMedicine.ShowDialog();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            Admin.Search_Users searchUser = new Admin.Search_Users("");
            searchUser.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            General.Search_Patients searchPatients = new General.Search_Patients("");
            searchPatients.ShowDialog();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            General.Doctor_Registration addDoctor = new General.Doctor_Registration(userNameLabel.Text, userTypeLabel.Text);
            addDoctor.ShowDialog();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            Admin.Clinic_Name clinicName = new Admin.Clinic_Name();
            clinicName.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin.Add_Enum_And_Set_Value restrictedText = new Admin.Add_Enum_And_Set_Value();
            restrictedText.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin.Inactive_User userManage = new Admin.Inactive_User();
            userManage.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Admin.adminSettings settings = new adminSettings(userNameLabel.Text, userTypeLabel.Text);
            settings.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            General.Reports reports = new General.Reports();
            reports.Show();
        }

        private void userName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userName.SelectedIndex == 0)
            {
                General.Login login = new General.Login();
                this.Hide();
                login.Show();
            }
            else if (userName.SelectedIndex == 1)
            {
                General.changePassword changePassword = new General.changePassword(userNameLabel.Text, userTypeLabel.Text);
                changePassword.Show();
            }
            else if (userName.SelectedIndex == 2)
            {
                Environment.Exit(1);
            }
        }

    }
}
