using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2._0
{
    public partial class Login : MetroForm
    {
        Class.LoginDetail login = new Class.LoginDetail();

        public Login()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(usernameTxt, "Enter credentials here");
            metroToolTip1.SetToolTip(passwordTxt, "Enter credentials here");
            panel1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string[] array = new string[3];
            array=login.loginsdetail(this.usernameTxt.Text,this.passwordTxt.Text);
            if (array[1] == null)
            {
               MetroMessageBox.Show(this, "\n" + "your username and password is incorrect", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                string Name = array[0];
                string userType = array[1];
                string userName = array[2];
                if (array[1] == "Doctor")
                {
                    this.Hide();
                    Menu obj = new Menu(Name, userType, userName);
                    obj.ShowDialog();
                    this.Close();
                }
                else if (array[1] == "Administrator")
                {
                    //this.Hide();
                    //Administration obj = new Administration(name, userstype, username);
                    //obj.ShowDialog();
                    //this.Close();

                }
                else if (array[1] == "Staff")
                {
                    //this.Hide();
                    //Receptionist obj = new Receptionist(name, userstype, username);
                    //obj.ShowDialog();
                    //this.Close();
                    MessageBox.Show("Staff");
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
