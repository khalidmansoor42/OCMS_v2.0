using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2_0.Receptionist
{
    public partial class PatientRegistration : MetroForm
    {
        int cityid, doc_id;
        string userName = "", userType = "", fullName = "";
        connection cons = new connection();
        maxvalue obj = new maxvalue();
        public PatientRegistration(string user_name, string user_type)
        {
            InitializeComponent();
            this.FocusMe();
            full_name.Select();
            this.KeyPreview = true;
            metroToolTip1.SetToolTip(saveBtn, "Save");
            metroToolTip1.SetToolTip(addCityBtn, "Add City");
            metroToolTip1.SetToolTip(searchBtn, "Search");
            metroToolTip1.SetToolTip(addDoctorBtn, "Add Referring Doctor");
            metroToolTip1.SetToolTip(clearBtn, "Clear");
            userName = user_name;
            userType = user_type;
            sum();
            city();
            attendant_relations();
            doctor();
        }

        private void patient_reg_TextChanged(object sender, EventArgs e)
        {

        }

        void doc(string doctor)
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String query = "select  doctorName,doctor_id from mydb.docotor_registration ;";
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string doctorname = myReader.GetString("doctorName");
                    if (doctorname == doctor)
                    {
                        doc_id = Convert.ToInt32(myReader.GetString("doctor_id"));
                    }
                }
                myConn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("donot fetch docotor id");
            }
        }
        void doctor()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String query = "select  d.doctorName from mydb.docotor_registration d";
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    ref_doctor_id.Items.Add(myReader.GetString("doctorName"));

                }
                myConn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Cannot fetch doctor list from doctor registration to referdoctor combobox ");
            }
        }
        void sum()
        {
            int patient_id = Convert.ToInt32(obj.max("select max(patient_reg) from mydb.patient_registration")) + 1;
            //  if (patient_id < 200)
            //{
            patient_reg.Text = Convert.ToString(patient_id);
            //}

        }
        void attendant_relations()
        {
            String cmdTexst;
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'patient_registration' and column_name = 'attendant_relation';";
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
                        att.Items.Add(m);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("cannot fetch attendant relation from enum field");
            }
        }

        void city()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String query = "select  city_name from mydb.city ;";
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    city_id.Items.Add(myReader.GetString("city_name"));
                }
                myConn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("cannot fetch city name from database ");
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
                MessageBox.Show("cannot fetch city id from database ");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            if (date == DOB.Value.ToString("yyyy-MM-dd"))
            {
                label2.Visible = true;
                MessageBox.Show("Fill The Require Field Where * Write");
            }
            else
            {
                string selectName = "Select full_name from mydb.user_registration where user_type = '"+userType+"'";
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                MySqlCommand SelectCommand = new MySqlCommand(selectName, myConn);
                MySqlDataReader reader;
                myConn.Open();
                reader = SelectCommand.ExecuteReader();
                if (reader.Read())
                {
                    fullName = reader.GetString("full_name");
                }
                myConn.Close();

                label2.Visible = false;
                if (full_name.Text.Length > 0 && father_name.Text.Length > 0 && lab_mob.Visible == false && address.Text.Length > 0 && lab_cnic.Visible == false && lab_email.Visible == false && leb_referdoc.Visible == false && lab_city.Visible == false && lab_father.Visible == false)
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
                    s(city_id.Text);
                    doc(ref_doctor_id.Text);
                    try
                    {
                        MySqlConnection con = new MySqlConnection(cons.myConnection);
                        String query = "insert into mydb.patient_registration(patient_reg,cnic,full_name,father_name,sex,address,city_id,mob,email,attendant_name,attendant_relation,attendant_mob,DOB,ref_doctor_id)value(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14);";

                        MySqlCommand SelectCommand1 = new MySqlCommand(query, con);
                        MySqlDataReader myReader1;
                        con.Open();
                        SelectCommand1.Parameters.Add(new MySqlParameter("@1", Convert.ToInt32(patient_reg.Text)));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@2", cnic.Text));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@3", full_name.Text));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@4", father_name.Text));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@5", sexs));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@6", address.Text));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@7", cityid));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@8", mob.Text));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@9", email.Text));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@10", attendant_name.Text));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@11", att.Text));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@12", attendant_mob.Text));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@13", DOB.Value.ToString("yyyy-MM-dd")));
                        SelectCommand1.Parameters.Add(new MySqlParameter("@14", doc_id));
                        myReader1 = SelectCommand1.ExecuteReader();
                        while (myReader1.Read())
                        {
                        }
                        con.Close();
                        Receptionist.Assign_Doctor obj = new Receptionist.Assign_Doctor(fullName, userType, Convert.ToInt32(patient_reg.Text), fullName, userType, userName);
                        obj.ShowDialog();
                        sum();
                        refreshed();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Patient is not register");
                    }

                }
                else
                {
                    MessageBox.Show("Fill The Require Field Where * Write");
                }
            }
        }

        private void full_name_TextChanged(object sender, EventArgs e)
        {
            if (full_name.Text.Length > 0)
            {
                lab_name.Hide();
            }
            else
            {
                lab_name.Show();
            }
        }
        void refreshed()
        {
            cnic.Clear();
            full_name.Clear();
            father_name.Clear();
            address.Clear();
            mob.Clear();
            email.Clear();
            attendant_name.Clear();
            att.ResetText();
            attendant_mob.Clear();
            city_id.ResetText();
            ref_doctor_id.Text = "-----";
        }

        private void father_name_TextChanged(object sender, EventArgs e)
        {
            if (father_name.Text.Length > 0)
            {
                lab_father.Hide();
            }
            else
            {
                lab_father.Show();
            }
        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            if (address.Text.Length > 0)
            {
                lab_address.Hide();
            }
            else
            {
                lab_address.Show();
            }
        }

        private void city_id_TextChanged(object sender, EventArgs e)
        {
            if (city_id.Text.Length > 0)
            {

                lab_city.Hide();
            }
            else
            {
                lab_city.Show();
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

        private void attendant_mob_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 08)
            {
                if (attendant_mob.Text.Length == 4)
                {
                    attendant_mob.Text += "-";
                    attendant_mob.Select(attendant_mob.Text.Length, 4);
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
            refreshed();
            sum();
            saveBtn.Visible = true;
            updateBtn.Visible = false;
        }

        private void full_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
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

        private void father_name_Leave(object sender, EventArgs e)
        {
            father_name.Text = CapitalizeWords(father_name.Text);
        }

        private void attendant_name_Leave(object sender, EventArgs e)
        {
            attendant_name.Text = CapitalizeWords(attendant_name.Text);
        }

        private void email_KeyUp(object sender, KeyEventArgs e)
        {
            if (email.Text != "")
            {

                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)");
                if (regex.IsMatch(email.Text))
                {
                    lab_email.Hide();
                }
                else
                {
                    lab_email.Show();
                }
            }
            else
            {
                lab_email.Hide();
            }
        }

        private void cnic_KeyUp(object sender, KeyEventArgs e)
        {
            if (cnic.Text != "")
            {
                Regex regex = new Regex("^([0-9]{5})[-]([0-9]{7})[-][0-9]{1}$");
                if (regex.IsMatch(cnic.Text))
                {
                    lab_cnic.Hide();
                }
                else
                {
                    lab_cnic.Show();
                }
            }
            else
            {
                lab_cnic.Hide();
            }
        }

        private void mob_KeyUp(object sender, KeyEventArgs e)
        {
            Regex regex = new Regex("^\\d{4}[-]\\d{7,8}$");
            if (regex.IsMatch(mob.Text))
            {
                lab_mob.Hide();
            }
            else
            {
                lab_mob.Show();
            }
        }

        private void ref_doctor_id_TextChanged(object sender, EventArgs e)
        {
            if (ref_doctor_id.Text == "-----")
            {
                leb_referdoc.Hide();
            }
            else
            {

                leb_referdoc.Show();
            }
            if (ref_doctor_id.Text.Length > 0)
            {
                leb_referdoc.Hide();
            }
            else
            {

                leb_referdoc.Show();
            }
        }

        private void father_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            General.Search_Patients obj = new General.Search_Patients("");
            if (obj.ShowDialog(this) == DialogResult.OK)
            {
                if (Regex.IsMatch(obj.Parameter1, @"^\d+$"))
                {
                    patient_reg.Text = obj.Parameter1;
                    patientdetail();
                    updateBtn.Visible = true;
                    saveBtn.Visible = false;
                }
            }
        }
        void patientdetail()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String query = "select  p.cnic,p.full_name,p.father_name,p.sex,p.address,p.mob,p.email,p.attendant_name,p.attendant_relation,p.attendant_mob,p.DOB,mydb.docotor_registration.doctorName,mydb.city.city_name  from mydb.patient_registration p,mydb.docotor_registration,mydb.city where patient_reg=@1 and p.city_id=mydb.city.city_id and mydb.docotor_registration.doctor_id=p.ref_doctor_id;";
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                SelectCommand.Parameters.Add(new MySqlParameter("@1", Convert.ToInt32(patient_reg.Text)));
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    cnic.Text = myReader.GetString("cnic");
                    full_name.Text = myReader.GetString("full_name");
                    father_name.Text = myReader.GetString("father_name");
                    Boolean sexs = myReader.GetBoolean("sex");
                    if (sexs)
                    {
                        maleRadio.Checked = true;
                    }
                    else
                    {
                        femaleRadio.Checked = true;

                    }
                    address.Text = myReader.GetString("address");
                    city_id.Text = myReader.GetString("city_name");
                    mob.Text = myReader.GetString("mob");
                    email.Text = myReader.GetString("email");
                    attendant_name.Text = myReader.GetString("attendant_name");
                    att.Text = myReader.GetString("attendant_relation");
                    attendant_mob.Text = myReader.GetString("attendant_mob");
                    DOB.Text = myReader.GetString("DOB");
                    ref_doctor_id.Text = myReader.GetString("doctorName");
                }
                myConn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("cannot fetch city name from database ");
            }

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            if (date == DOB.Value.ToString("yyyy-MM-dd"))
            {
                label2.Visible = true;
                MessageBox.Show("Fill The Require Field Where * Write");
            }
            else
            {
                label2.Visible = false;
                if (full_name.Text.Length > 0 && father_name.Text.Length > 0 && lab_mob.Visible == false && address.Text.Length > 0 && lab_cnic.Visible == false && lab_email.Visible == false && leb_referdoc.Visible == false && lab_city.Visible == false && lab_father.Visible == false)
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
                    s(city_id.Text);
                    doc(ref_doctor_id.Text);
                    try
                    {
                        MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                        String query = "update mydb.patient_registration set cnic=@2,full_name=@3,father_name=@4,sex=@5,address=@6,city_id=@7,mob=@8,email=@9,attendant_name=@10,attendant_relation=@11,attendant_mob=@12,DOB=@13,ref_doctor_id=@14 where patient_reg=@1;";
                        MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                        MySqlDataReader myReader;
                        myConn.Open();
                        SelectCommand.Parameters.Add(new MySqlParameter("@1", Convert.ToInt32(patient_reg.Text)));
                        SelectCommand.Parameters.Add(new MySqlParameter("@2", cnic.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@3", full_name.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@4", father_name.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@5", sexs));
                        SelectCommand.Parameters.Add(new MySqlParameter("@6", address.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@7", cityid));
                        SelectCommand.Parameters.Add(new MySqlParameter("@8", mob.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@9", email.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@10", attendant_name.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("11", att.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@12", attendant_mob.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@13", DOB.Value.ToString("yyyy-MM-dd")));
                        SelectCommand.Parameters.Add(new MySqlParameter("@14", doc_id));
                        myReader = SelectCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                        }
                        myConn.Close();
                        MessageBox.Show("Data Is  Update");
                        sum();
                        saveBtn.Visible = true;
                        updateBtn.Visible = false;
                        refreshed();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data Is Not Update");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill Requirt Field");

                }
            }
        }

        private void addCityBtn_Click(object sender, EventArgs e)
        {
            General.Add_City obj = new General.Add_City();
            obj.ShowDialog();
            city_id.Items.Clear();

            city();
        }

        private void addDoctorBtn_Click(object sender, EventArgs e)
        {
            General.Doctor_Registration obj = new General.Doctor_Registration(userName, userType);

            obj.ShowDialog();
            ref_doctor_id.Items.Clear();
            doctor();
        }

        private void text_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {

                e.Handled = true;
            }
            DOB.Text = DateTime.Today.ToString("yyyy-MM-dd");
            if (text_age.Text != "")
            {
                string date = DOB.Value.ToString("yyyy-MM-dd");
                string[] words = date.Split('-');
                string dateofbirth = Convert.ToString(Convert.ToInt32(Convert.ToString(words[0])) - Convert.ToInt32(text_age.Text));
                words[0] = dateofbirth;
                DOB.Text = string.Join("-", words);

            }
        }

        private void text_age_TextChanged(object sender, EventArgs e)
        {
            DOB.Text = DateTime.Today.ToString("yyyy-MM-dd");
            if (text_age.Text != "")
            {
                string date = DOB.Value.ToString("yyyy-MM-dd");
                string[] words = date.Split('-');
                string dateofbirth = Convert.ToString(Convert.ToInt32(Convert.ToString(words[0])) - Convert.ToInt32(text_age.Text));
                words[0] = dateofbirth;
                DOB.Text = string.Join("-", words);

            }
        }

        private void text_age_KeyDown(object sender, KeyEventArgs e)
        {
            DOB.Text = DateTime.Today.ToString("yyyy-MM-dd");
            if (text_age.Text != "")
            {
                string date = DOB.Value.ToString("yyyy-MM-dd");
                string[] words = date.Split('-');
                string dateofbirth = Convert.ToString(Convert.ToInt32(Convert.ToString(words[0])) - Convert.ToInt32(text_age.Text));
                words[0] = dateofbirth;
                DOB.Text = string.Join("-", words);

            }
        }

        private void PatientRegistration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (updateBtn.Visible == true)
                {
                    saveBtn_Click(sender, e);
                }
                else
                {
                    updateBtn_Click(sender, e);
                }
            }
        }

        private void ref_doctor_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ref_doctor_id.Text == "")
            {
                leb_referdoc.Show();
            }
            else
            {

                leb_referdoc.Hide();
            }
            if (ref_doctor_id.Text == "-----")
            {
                leb_referdoc.Hide();
            }
            else
            {

                leb_referdoc.Show();
            }
        }

        private void DOB_ValueChanged(object sender, EventArgs e)
        {
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            if (date == DOB.Value.ToString("yyyy-MM-dd"))
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }
    }
}
