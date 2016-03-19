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

namespace OCMS_v2_0.Admin
{
    public partial class Clinic_Name : MetroForm
    {
        connection obj = new connection();
        public Clinic_Name()
        {
            InitializeComponent();
            this.FocusMe();
            txt_Companyname.Select();
            metroToolTip1.SetToolTip(saveBtn, "Save");
            metroToolTip1.SetToolTip(updateBtn, "Update");
            metroToolTip1.SetToolTip(browseBtn, "Upload Picture");
            companyinfo();
        }

        void companyinfo()
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(obj.myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("select * from mydb.address", myConn);
                MySqlDataReader myReader;
                myConn.Open();


                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    this.saveBtn.Visible = false;
                    this.updateBtn.Visible = true;
                    txt_Companyname.Text = myReader.GetString("header");
                    txt_address.Text = myReader.GetString("address");
                    txt_phone.Text = myReader.GetString("mob1");
                    txt_mobile.Text = myReader.GetString("mob2");
                    this.txt_email.Text = myReader.GetString("email");


                    this.ph.Text = myReader.GetString("mob3");

                    this.specialization.Text = myReader.GetString("specialization");

                    this.summary.Text = myReader.GetString("sumery");

                    this.drname.Text = myReader.GetString("name");

                    byte[] imgg = (byte[])(myReader["image"]);
                    MemoryStream mstream = new MemoryStream(imgg);
                    pictureBox1.Image = System.Drawing.Image.FromStream(mstream);

                }

                myConn.Close();

            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Oops... It Seems We Encountered A Problem", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        void save(string query)
        {
            try
            {

                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.text_Pic_location.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);
                MySqlConnection myConn = new MySqlConnection(obj.myConnection);

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                SelectCommand.Parameters.Add(new MySqlParameter("@1", this.txt_Companyname.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@4", this.txt_address.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@2", this.txt_phone.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@3", this.txt_mobile.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@5", this.txt_email.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@6", imageBt));
                SelectCommand.Parameters.Add(new MySqlParameter("@7", ph.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@8", specialization.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@9", summary.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@10", drname.Text));

                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                { }
                MetroMessageBox.Show(this, "\n" + "Data Has Been Saved", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myConn.Close();

            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Could Not Save Data", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string query = "insert into mydb.address (header,mob1,mob2,email,address,image,mob3,specialization,sumery,name)value(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10);";
            save(query);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            string query;
            try
            {
                if (text_Pic_location.Text == "")
                {
                    query = "update mydb.address set header=@1,mob1=@2,mob2=@3,email=@5,address=@4,mob3=@7,specialization=@8,sumery=@9,name=@10 where id='1';";

                }
                else
                {

                    FileStream fstream = new FileStream(this.text_Pic_location.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imageBt = br.ReadBytes((int)fstream.Length);
                    query = "update mydb.address set header=@1,mob1=@2,mob2=@3,email=@5,address=@4,image=@6 where id='1';";

                }
                MySqlConnection myConn = new MySqlConnection(obj.myConnection);

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                SelectCommand.Parameters.Add(new MySqlParameter("@1", this.txt_Companyname.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@2", this.txt_phone.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@3", this.txt_mobile.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@4", this.txt_address.Text));

                SelectCommand.Parameters.Add(new MySqlParameter("@5", this.txt_email.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@6", imageBt));
                SelectCommand.Parameters.Add(new MySqlParameter("@7", ph.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@8", specialization.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@9", summary.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@10", drname.Text));
                myConn.Open();

                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                { }
                MetroMessageBox.Show(this, "\n" + "Data Has Been Updated", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myConn.Close();

            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Could Not Update Data", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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
            }
        }
    }
}
