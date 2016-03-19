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

namespace OCMS_v2_0.Admin
{
    public partial class Inactive_User : MetroForm
    {
        connection cons = new connection();
        public Inactive_User()
        {
            InitializeComponent();
            this.FocusMe();
            text_Eid.Select();
            metroToolTip1.SetToolTip(saveBtn, "Save");
            metroToolTip1.SetToolTip(searchBtn, "Search User");
        }
        void null_field()
        {
            string empty = "\0";
            this.text_Eid.Text = empty;
            this.text_user_type.Text = empty;
            this.text_user_name.Text = empty;

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Admin.Search_Users obj = new Admin.Search_Users("chpass");

            if (obj.ShowDialog(this) == DialogResult.OK)
            {
                string userId = obj.Parameter1;
                string query = "select user_name, user_type, activeinactive from mydb.user_registration where employee_id = '" + userId + "'";
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.text_user_name.Text = myReader.GetString("user_name");
                    this.text_user_type.Text = myReader.GetString("user_type");
                    string activeInactive = myReader.GetString("activeinactive");
                    if (activeInactive == "True")
                    {
                        active.Checked = true;
                    }
                    else 
                    {
                        inactive.Checked = true;
                    }
                    text_Eid.Text = obj.Parameter1;
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            String quray;
            if (inactive.Checked == true)
            {
                quray = "update mydb.user_registration set activeinactive='" + 0 + "' where employee_id=@1;";


            }
            else
            {
                quray = "update mydb.user_registration set activeinactive='" + 1 + "' where employee_id=@1;";

            }
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                MySqlCommand SelectCommand = new MySqlCommand(quray, myConn);
                SelectCommand.Parameters.Add(new MySqlParameter("@1", this.text_Eid.Text));

                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCommand.ExecuteReader();



                while (myReader.Read())
                {


                }


                myConn.Close();
                MetroMessageBox.Show(this, "\n" + "Data Saved Successfully!", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            null_field();
        }
    }
}
