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
    public partial class Doctor_Registration : MetroForm
    {
        int cityid;
        connection cons = new connection();
        public Doctor_Registration(string user_name, string user_type)
        {
            InitializeComponent();
            this.FocusMe();
            txt_doctorName.Select();
            metroToolTip1.SetToolTip(saveBtn, "Save");
            metroToolTip1.SetToolTip(clearBtn, "Clear");
            qualification();
            specialization();
            sum();
            city();
        }

        void sum()
        {
            int sum = 0;
            MySqlConnection conn = new MySqlConnection(cons.myConnection);
            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand("select max(doctor_id) from mydb.docotor_registration", conn);
                string c = command.ExecuteScalar().ToString();
                if (c == "")
                {
                    c = "0";

                }



                sum = Convert.ToInt32(c);
                sum = sum + 1;
                this.txt_doctor_id.Text = Convert.ToString(sum);

            }
            finally
            {
                conn.Close();
            }

        }

        void specialization()
        {
            String cmdTexst;
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'docotor_registration' and column_name = 'specialization';";
            MySqlConnection condatabase = new MySqlConnection(cons.myConnection);
            MySqlCommand cmddatabase = new MySqlCommand(cmdTexst, condatabase);


            try
            {

                string muaz;
                condatabase.Open();
                muaz = cmddatabase.ExecuteScalar().ToString();
                string[] name = muaz.Split('\'');

                foreach (string m in name)
                {

                    if (m == "," || m == "" || m == ")")
                    {
                    }
                    else
                    {

                        cmb_specializations.Items.Add(m);

                    }

                }

            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Could Not Fetch Specialization Field", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        void qualification()
        {
            String cmdTexst;

            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'docotor_registration' and column_name = 'qualification';";
            MySqlConnection condatabase = new MySqlConnection(cons.myConnection);
            MySqlCommand cmddatabase = new MySqlCommand(cmdTexst, condatabase);


            try
            {

                string muaz;
                condatabase.Open();
                muaz = cmddatabase.ExecuteScalar().ToString();
                string[] name = muaz.Split('\'');

                foreach (string m in name)
                {

                    if (m == "," || m == "" || m == ")")
                    {
                    }
                    else
                    {

                        cmb_qualifications.Items.Add(m);

                    }

                }

            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Could Not Fetch Data", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
        void city()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                String query = "select  * from mydb.city ;";

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();


                while (myReader.Read())
                {
                    string city = myReader.GetString("city_name");
                    cmb_city_id.Items.Add(city);

                }


                myConn.Close();


            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Data Could Not Be Saved", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }
        void s(string city_name1)
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                String query = "select  * from mydb.city ;";

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();


                while (myReader.Read())
                {
                    string city = myReader.GetString("city_name");
                    if (city == city_name1)
                    {

                        cityid = Convert.ToInt32(myReader.GetString("city_id"));


                    }

                }


                myConn.Close();


            }
            catch (Exception)
            {

                MetroMessageBox.Show(this, "\n" + "Data Could Not Be Saved", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }




        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (label2.Visible == false && label14.Visible == false && label18.Visible == false && label13.Visible == false && label17.Visible == false && label22.Visible == false && label24.Visible == false)
            {

                Boolean sexs;
                if (maleRadio.Checked)
                {
                    sexs = true;
                }
                else
                {
                    sexs = false;
                }
                s(cmb_city_id.Text);

                try
                {

                    MySqlConnection myConn = new MySqlConnection(cons.myConnection);



                    String query = "insert into mydb.docotor_registration (doctor_id,doctorName,PMDC,sex,clinic_address,mobile,city_id,email,qualification,affiliated_with,specialization) values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11);";



                    MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    SelectCommand.Parameters.Add(new MySqlParameter("@1", Convert.ToInt32(txt_doctor_id.Text)));
                    SelectCommand.Parameters.Add(new MySqlParameter("@2", txt_doctorName.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@3", txt_PMDC.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@4", sexs));
                    SelectCommand.Parameters.Add(new MySqlParameter("@6", txt_mobile.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@5", txt_clinic_address.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@7", cityid));
                    SelectCommand.Parameters.Add(new MySqlParameter("@8", txt_email.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@9", cmb_qualifications.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("10", txt_affiliated_with.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@11", cmb_specializations.Text));


                    myReader = SelectCommand.ExecuteReader();


                    while (myReader.Read()) { }
                    myConn.Close();
                    MetroMessageBox.Show(this, "\n" + "Data Has Been Saved", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sum();
                    ResetTexts();
                }

                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + "Please Fill The Required Fields", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ResetTexts();
        }

        void ResetTexts()
        {

            txt_doctorName.Clear();
            txt_PMDC.Clear();
            txt_mobile.Clear();
            maleRadio.Checked = false;
            femaleRadio.Checked = false;
            cmb_city_id.ResetText();
            txt_clinic_address.Clear();
            txt_email.Clear();
            cmb_qualifications.ResetText();
            txt_affiliated_with.Clear();
            cmb_specializations.ResetText();
        }

        private void txt_doctorName_TextChanged(object sender, EventArgs e)
        {
            if (txt_doctorName.Text.Length > 0)
            {

                label2.Hide();
            }
            else
            {

                label2.Show();

            }
        }

        private void cmb_qualifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_qualifications.Text = cmb_qualifications.Text;
        }

        private void txt_affiliated_with_TextChanged(object sender, EventArgs e)
        {
            if (txt_affiliated_with.Text.Length > 0)
            {

                label14.Hide();
            }
            else
            {

                label14.Show();

            }
        }

        private void txt_clinic_address_TextChanged(object sender, EventArgs e)
        {
            if (txt_clinic_address.Text.Length > 0)
            {

                label18.Hide();
            }
            else
            {

                label18.Show();

            }
        }

        private void txt_mobile_TextChanged(object sender, EventArgs e)
        {
            if (txt_mobile.Text.Length > 0)
            {

                label22.Hide();
            }
            else
            {

                label22.Show();

            }
        }

        private void cmb_qualifications_TextChanged(object sender, EventArgs e)
        {
            if (cmb_qualifications.SelectedItem != null || cmb_qualifications.Text.Length > 0)
            {
                label13.Hide();
            }
            else
            {
                label13.Show();


            }
        }

        private void cmb_specializations_TextChanged(object sender, EventArgs e)
        {
            if (cmb_specializations.Text.Length > 0)
            {

                label17.Hide();
            }
            else
            {

                label17.Show();

            }
        }

        private void cmb_city_id_TextChanged(object sender, EventArgs e)
        {
            if (cmb_city_id.Text.Length > 0)
            {

                label24.Hide();
            }
            else
            {

                label24.Show();

            }
        }

        private void txt_mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 08)
            {
                if (txt_mobile.Text.Length == 4)
                {
                    txt_mobile.Text += "-";
                    txt_mobile.Select(txt_mobile.Text.Length, 4);
                }

            }

            if (!char.IsDigit(ch) && ch != 8)
            {

                e.Handled = true;
            }
        }
    }
}
