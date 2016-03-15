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
            if (this.text_Eid.Text != "")
            {
                try
                {
                    MySqlConnection myConn = new MySqlConnection(cons.myConnection);


                    String query = "SELECT user_type,user_name FROM mydb.user_registration where employee_id=@1;";
                    MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                    SelectCommand.Parameters.Add(new MySqlParameter("@1", this.text_Eid.Text));

                    MySqlDataReader myReader;
                    myConn.Open();
                    myReader = SelectCommand.ExecuteReader();



                    while (myReader.Read())
                    {
                        this.text_user_type.Text = myReader.GetString("user_type");
                        this.text_user_name.Text = myReader.GetString("user_name");

                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Admin.Search_Users obj = new Admin.Search_Users("chpass");

                if (obj.ShowDialog(this) == DialogResult.OK)
                {
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
                MessageBox.Show("Data is save");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            null_field();
        }
    }
}
