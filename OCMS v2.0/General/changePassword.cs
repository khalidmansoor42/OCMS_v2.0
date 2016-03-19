using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2_0.General
{
    public partial class changePassword : MetroForm
    {
        string userName = "", userType = "";
        password pas = new password();
        connection cons = new connection();
        public changePassword(string user_name, string user_type)
        {
            InitializeComponent();
            this.FocusMe();
            Previous_pass.Select();
            metroToolTip1.SetToolTip(updateBtn, "Update");
            metroToolTip1.SetToolTip(visibelPassBtn, "Show/Hide Characters");
            userName = user_name;
            userType = user_type;
        }
        void searchid()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String quray = "Select password from mydb.user_registration where user_name=@1  ;";
                MySqlCommand SelectCommand = new MySqlCommand(quray, myConn);
                SelectCommand.Parameters.Add(new MySqlParameter("@1", userName));
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                string id;
                while (myReader.Read())
                {
                    id = myReader.GetString("password");
                    if (id == pas.MD5Hash(Previous_pass.Text))
                    {
                        passwordchange();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + "Previous Password Did Not Match", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }

                }
                myConn.Close();

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void metroTextBox6_TextChanged(object sender, EventArgs e)
        {
            if (new_pass.Text == Conform_pass.Text)
            {
                rightPic.Visible = true;
                wrongPic.Visible = false;
            }
            else
            {
                rightPic.Visible = false;
                wrongPic.Visible = true;
            }
        }
        void passwordchange()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String quray = "update mydb.user_registration set password=@1 where user_name=@2   ;";
                MySqlCommand SelectCommand = new MySqlCommand(quray, myConn);
                MySqlDataReader myReader;
                SelectCommand.Parameters.Add(new MySqlParameter("@1", pas.MD5Hash(new_pass.Text)));
                SelectCommand.Parameters.Add(new MySqlParameter("@2", userName));
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {


                }
                myConn.Close();
                MetroMessageBox.Show(this, "\n" + "Password Changed Successfully", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (new_pass.Text != "" && Conform_pass.Text != "" && Previous_pass.Text != "")
            {
                if (new_pass.Text == Conform_pass.Text)
                {
                    searchid();
                }
                else
                {
                    MetroMessageBox.Show(this, "\n" + "Your New Passwords Do Not Match", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + "Please Fill All Required Fields", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void metroTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (new_pass.Text == Conform_pass.Text)
            {
                rightPic.Visible = true;
                wrongPic.Visible = false;
            }
            else
            {
                rightPic.Visible = false;
                wrongPic.Visible = true;
            }
        }

        private void visibelPassBtn_Click(object sender, EventArgs e)
        {
            if (this.new_pass.PasswordChar == '*')
            {
                this.new_pass.PasswordChar = '\0';
                this.Conform_pass.PasswordChar = '\0';
            }
            else 
            {
                this.new_pass.PasswordChar = '*';
                this.Conform_pass.PasswordChar = '*';
            }

        }

        private void metroTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (new_pass.Text == Conform_pass.Text)
            {
                rightPic.Visible = true;
                wrongPic.Visible = false;
            }
            else
            {
                rightPic.Visible = false;
                wrongPic.Visible = true;
            }
        }
    }
}
