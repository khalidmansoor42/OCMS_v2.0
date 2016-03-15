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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2_0.Admin
{
    public partial class User_Registration : MetroForm
    {
        int cityid;
        connection cons = new connection();
        password pas = new password();
        imageclass imgs = new imageclass();
        string path;
        public User_Registration(string user_name, string user_type)
        {
            InitializeComponent();
            updateBtn.Visible = false;
            metroToolTip1.SetToolTip(searchBtn, "Search User");
            metroToolTip1.SetToolTip(clearBtn, "Clear");
            metroToolTip1.SetToolTip(saveBtn, "Save");
            metroToolTip1.SetToolTip(updateBtn, "Update");

            path = imgs.findimage("select dbimage from mydb.imageaddress", "dbimage");

            this.password.PasswordChar = '*';
            this.password.MaxLength = 30;
            DOB.MaxDate = DateTime.Today;
            UserType();
            city();
            sum();
            users_type.Text = user_type;
            username.Text = user_name;
      
        }

        void sum()
        {
            int sum = 0;
            MySqlConnection conn = new MySqlConnection(cons.myConnection);
            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand("select max(employee_id) from mydb.user_registration", conn);
                string c = command.ExecuteScalar().ToString();
                if (c == "")
                {
                    c = "0";
                }
                sum = Convert.ToInt32(c);
                sum = sum + 1;

                this.employees_id.Text = Convert.ToString(sum);
            }
            finally
            {
                conn.Close();
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
                    city_id.Items.Add(city);

                }
                myConn.Close();
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Could Not Fetch City Name From Database", ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }
        void Select_City_Id(string city_name1)
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
                MetroMessageBox.Show(this, "\n" + "Could Not Fetch City ID From Database", ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
        void UserType()
        {
            String cmdTexst;
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'user_registration' and column_name = 'user_type';";
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
                        user_type.Items.Add(m);

                    }
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Could not fetch Attendant Relation from database", ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (path != "")
            {
                String date = DateTime.Now.ToString("yyyy-MM-dd");
                String strBLOBFilePath = path;//Modify this path as needed.
                byte[] imageBt = null;
                FileStream fstream = new FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);
                if (label16.Visible == false)
                {
                    if (date != DOB.Value.ToString("yyyy-MM-dd") && label15.Visible == false && full_name.Text.Length > 0 && f_name.Text.Length > 0 && mob.Text.Length > 0 && address.Text.Length > 0 && city_id.Text.Length > 0 && user_type.Text.Length > 0)
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
                        Select_City_Id(city_id.Text);

                        try
                        {
                            MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                            String query = "insert into mydb.user_registration(employee_id,full_name,f_name,sex,address,mob,cnic,DOB,email,city_id,date_registration,user_type,user_name,password,image)value(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15);";

                            MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                            MySqlDataReader myReader;
                            myConn.Open();
                            SelectCommand.Parameters.Add(new MySqlParameter("@1", Convert.ToInt32(employees_id.Text)));
                            SelectCommand.Parameters.Add(new MySqlParameter("@2", full_name.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@3", f_name.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@4", sexs));
                            SelectCommand.Parameters.Add(new MySqlParameter("@5", address.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@6", mob.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@7", cnic.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@8", DOB.Value.Date));
                            SelectCommand.Parameters.Add(new MySqlParameter("@9", email.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@10", cityid));
                            SelectCommand.Parameters.Add(new MySqlParameter("@11", date_registration.Value.Date));
                            SelectCommand.Parameters.Add(new MySqlParameter("@12", user_type.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@13", user_name.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@14", pas.MD5Hash(password.Text)));
                            SelectCommand.Parameters.Add(new MySqlParameter("@15", imageBt));
                            myReader = SelectCommand.ExecuteReader();
                            while (myReader.Read()) { }
                            myConn.Close();
                            string savemessage = "User Name : '" + user_name.Text + "'" + " Has Been Registered With Employee ID " + "'" + employees_id.Text + "'";
                            MetroMessageBox.Show(this, "\n" + savemessage, ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sum();
                            clears();
                        }

                        catch (Exception ex)
                        {
                            MetroMessageBox.Show(this, "\n" + "Data Not Saved", ":(", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + "Please Fill The Required Fields", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "\n" + "Please Enter Correct Email Format", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
        }// end of button handler

        void clears()
        {
            full_name.Clear();
            f_name.Clear();
            address.Clear();
            mob.Clear();
            cnic.Clear();
            email.Clear();
            city_id.ResetText();
            user_type.ResetText();
            user_name.Clear();
            password.Clear();
        }

        private void full_name_TextChanged(object sender, EventArgs e)
        {
            string ss = full_name.Text;
            string[] myStringArray = ss.Split(' ');
            string s = string.Join("", myStringArray);
            if (myStringArray[0] == "DR" || myStringArray[0] == "Dr")
            {
                user_name.Text = myStringArray[1] + "_" + employees_id.Text;
            }
            else
            {
                user_name.Text = myStringArray[0] + "_" + employees_id.Text;

            }

            if (full_name.Text.Length > 0)
            {

                label29.Hide();
            }
            else
            {

                label29.Show();

            }
        }

        private void f_name_TextChanged(object sender, EventArgs e)
        {
            if (f_name.Text.Length > 0)
            {

                label6.Hide();
            }
            else
            {

                label6.Show();

            }
        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            if (address.Text.Length > 0)
            {

                label17.Hide();
            }
            else
            {

                label17.Show();

            }
        }

        private void mob_TextChanged(object sender, EventArgs e)
        {
            if (mob.Text.Length > 0)
            {

                label20.Hide();
            }
            else
            {

                label20.Show();

            }
        }

        private void DOB_ValueChanged(object sender, EventArgs e)
        {
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            if (date == DOB.Value.ToString("yyyy-MM-dd"))
            {
                label21.Visible = true;
            }
            else
            {
                label21.Visible = false;
            }
        }

        private void city_id_TextChanged(object sender, EventArgs e)
        {
            if (city_id.Text.Length > 0)
            {

                label22.Hide();
            }
            else
            {

                label22.Show();

            }
        }

        private void user_type_TextChanged(object sender, EventArgs e)
        {
            if (user_type.Text.Length > 0)
            {
                if (user_type.Text == "Doctor")
                {
                    string ss = full_name.Text;
                    string[] myStringArray = ss.Split(' ');
                    if (myStringArray[0] != "Dr")
                    {
                        full_name.Text = "Dr " + full_name.Text;

                    }
                }
                else
                {
                    string[] myStringArray = full_name.Text.Split(' ');

                    if (myStringArray[0] == "Dr" || myStringArray[0] == "DR")
                    {
                        full_name.Text = "";
                        for (int i = 1; i < myStringArray.Length; i++)
                        {
                            if (i == 1)
                            {
                                full_name.Text = myStringArray[i];
                            }
                            else
                            {
                                full_name.Text = full_name.Text + " " + myStringArray[i];
                            }
                        }

                    }

                }

                label23.Hide();
            }
            else
            {

                label23.Show();

            }
        }

        private void mob_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 08)
            {
                if (mob.Text.Length == 4)
                {
                    mob.Text += "-";
                    mob.Select(mob.Text.Length, 4);
                }

            }

            if (!char.IsDigit(ch) && ch != 8)
            {

                e.Handled = true;
            }
        }

        private void cnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 08)
            {
                if (cnic.Text.Length == 5 || cnic.Text.Length == 13)
                {
                    cnic.Text += "-";
                    cnic.Select(cnic.Text.Length, 0);
                }

            }

            if (!char.IsDigit(ch) && ch != 8)
            {

                e.Handled = true;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void full_name_Leave(object sender, EventArgs e)
        {
            full_name.Text = CapitalizeWords(full_name.Text);
        }

        public static string CapitalizeWords(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (value.Length == 0)
                return value;

            StringBuilder result = new StringBuilder(value);
            result[0] = char.ToUpper(result[0]);
            for (int i = 1; i < result.Length; ++i)
            {
                if (char.IsWhiteSpace(result[i - 1]))
                    result[i] = char.ToUpper(result[i]);
                else
                    result[i] = char.ToLower(result[i]);
            }
            return result.ToString();
        }

        private void f_name_Leave(object sender, EventArgs e)
        {
            f_name.Text = CapitalizeWords(f_name.Text);
        }

        private void cnic_KeyUp(object sender, KeyEventArgs e)
        {
            Regex regex = new Regex("^([0-9]{5})[-]([0-9]{7})[-][0-9]{1}$");
            if (regex.IsMatch(cnic.Text))
            {
                label15.Hide();
            }
            else
            {
                label15.Show();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Admin.Search_Users obj = new Admin.Search_Users("chpass");
            if (obj.ShowDialog(this) == DialogResult.OK)
            {
                if (Regex.IsMatch(obj.Parameter1, @"^\d+$"))
                {
                    employees_id.Text = obj.Parameter1;
                    userdetail();
                    updateBtn.Visible = true;
                    saveBtn.Visible = false;

                }
            }
        }

        void userdetail()
        {
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            password.Enabled = false;

            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String query = "select u.employee_id,u.full_name,u.f_name,u.sex,u.address,u.mob,u.cnic,u.DOB,u.email,u.user_type,u.user_name,c.city_name  from mydb.user_registration u,mydb.city c where employee_id=@1 and u.city_id=c.city_id ;";

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                SelectCommand.Parameters.Add(new MySqlParameter("@1", Convert.ToInt32(employees_id.Text)));
                MySqlDataReader myReader;
                myConn.Open();

                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    full_name.Text = myReader.GetString("full_name");
                    f_name.Text = myReader.GetString("f_name");
                    Boolean gender = myReader.GetBoolean("sex");
                    if (gender)
                    {
                        maleRadio.Checked = true;
                    }
                    else
                    {
                        femaleRadio.Checked = true;

                    }
                    address.Text = myReader.GetString("address");
                    mob.Text = myReader.GetString("mob");
                    cnic.Text = myReader.GetString("cnic");
                    DOB.Text = myReader.GetString("DOB");
                    email.Text = myReader.GetString("email");
                    city_id.Text = myReader.GetString("city_name");
                    user_type.Text = myReader.GetString("user_type");
                    user_name.Text = myReader.GetString("user_name");
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + "Data Could Not Be Retrieved", ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            String date = DateTime.Now.ToString("yyyy-MM-dd");

            if (label16.Visible == false)
            {
                if (date != DOB.Value.ToString("yyyy-MM-dd") && label15.Visible == false && full_name.Text.Length > 0 && f_name.Text.Length > 0 && mob.Text.Length > 0 && address.Text.Length > 0 && city_id.Text.Length > 0 && user_type.Text.Length > 0)
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
                    Select_City_Id(city_id.Text);
                    try
                    {
                        MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                        String query = "Update mydb.user_registration set full_name=@2,f_name=@3,sex=@4,address=@5,mob=@6,cnic=@7,DOB=@8,email=@9,city_id=@10,user_type=@11,user_name=@12 where employee_id=@1;";
                        MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                        MySqlDataReader myReader;
                        myConn.Open();
                        SelectCommand.Parameters.Add(new MySqlParameter("@1", this.employees_id.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@2", full_name.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@3", f_name.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@4", sexs));
                        SelectCommand.Parameters.Add(new MySqlParameter("@5", address.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@6", mob.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@7", cnic.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@8", DOB.Value.Date));
                        SelectCommand.Parameters.Add(new MySqlParameter("@9", email.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@10", cityid));
                        SelectCommand.Parameters.Add(new MySqlParameter("@11", user_type.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@12", user_name.Text));
                        myReader = SelectCommand.ExecuteReader();
                        while (myReader.Read()) { }
                        myConn.Close();
                        string updatemessage = "User Name : '" + user_name.Text + "'" + " Has Been Update With Employee ID " + "'" + employees_id.Text + "'";
                        MetroMessageBox.Show(this, "\n" + updatemessage, ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sum();
                        clears();
                        updateBtn.Visible = false;
                        saveBtn.Visible = true;
                        password.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MetroMessageBox.Show(this, "\n" + "Data Not Saved", ":(", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MetroMessageBox.Show(this, "\n" + "Please Fill The Required Fields", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + "Please Enter Correct Email Format", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (email.Text != "")
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)");
                if (regex.IsMatch(email.Text))
                {
                    label16.Hide();
                }
                else
                {
                    label16.Show();
                }
            }
            else
            {
                label16.Hide();
            }
        }

    }
}
