using MetroFramework;
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

namespace OCMS_v2_0.General
{
    public partial class MyProfile : MetroForm
    {
        connection cons = new connection();
        string userName = "";
        string userType = "";
        public MyProfile(string user_name, string user_type)
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(browseBtn, "Browse Picture");
            metroToolTip1.SetToolTip(saveBtn, "Save");
            userName = user_name;
            userType = user_type;

            fill_text_fields();
            this.text_full_Name.Enabled = false;
            this.Text_Father_Name.Enabled = false;
            this.text_gender.Enabled = false;
            this.text_mob.Enabled = false;
            this.text_cnic.Enabled = false;
            this.Text_address.Enabled = false;
            this.text_Email.Enabled = false;
            get_pic();
        }

        void get_pic()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);


                String query = "SELECT * FROM mydb.user_registration where user_name ='" + userName + "';";
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;

                myConn.Open();

                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count++;
                    // this.text_Eid.Text = myReader.GetString("Eid");
                    byte[] imgg = (byte[])(myReader["image"]);
                    if (imgg == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }



                }
                myConn.Close();
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Oops... It Seems We Encountered A Problem", ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }


        }

        void fill_text_fields()
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);


                String query = "SELECT * FROM mydb.user_registration where user_name='" + userName + "';";
                //  MessageBox.Show(query);
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();


                while (myReader.Read())
                {
                    this.text_full_Name.Text = myReader.GetString("full_name");
                    this.Text_Father_Name.Text = myReader.GetString("f_name");
                    Boolean gender = myReader.GetBoolean("sex");
                    if (gender)
                    {
                        this.text_gender.Text = "Male";
                    }
                    else
                    {
                        this.text_gender.Text = "Female";
                    }
                    this.text_mob.Text = myReader.GetString("mob");
                    this.text_cnic.Text = myReader.GetString("cnic");
                    this.text_Email.Text = myReader.GetString("email");
                    this.Text_address.Text = myReader.GetString("address");
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }



        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "Select Employee Picture.";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc = dlg.FileName.ToString();
                this.text_Pic_location.Text = picLoc;
                pictureBox1.ImageLocation = picLoc;
                MetroMessageBox.Show(this, "\n" + "Picture Successfully Updated", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {// **************for PictureBox**************************
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.text_Pic_location.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);
                // **************for PictureBox**************************
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                // **************for PictureBox**************************
                String query = "update mydb.user_registration set image=@IMG  where user_name='" + userName + "' ;";

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                // **************for PictureBox**************************
                SelectCommand.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {

                }
                myConn.Close();

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            get_pic();
        }
    }
}
