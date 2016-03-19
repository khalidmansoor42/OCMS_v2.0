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

namespace OCMS_v2_0.Receptionist
{
    public partial class Assign_Doctor : MetroForm
    {
        string userName = "", userType = "";
        Findage obj = new Findage();
        int doc_id;
        string usernames;
        connection cons = new connection();
        public Assign_Doctor(string un, string cat, int patient_id, string name, string doctype, string username)
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(printBtn, "Print Reciept");
            this.KeyPreview = true;
            this.FocusMe();
            txt_full_name.Select();
            usernames = username;
            userName = un;
            userType = cat;
            txt_patient_reg.Text = Convert.ToString(patient_id);
            getdetail(patient_id);
            getdoctordetail();
            sum();
            receipt();
        }

        void receipt()
        {
            int sum = 0;

            MySqlConnection myConn = new MySqlConnection(cons.myConnection);
            myConn.Open();
            try
            {
                string query = "select max(Receipt_id) from mydb.receipt;";
                MySqlCommand command = new MySqlCommand(query, myConn);

                string c = command.ExecuteScalar().ToString();
                if (c == "")
                {
                    c = "0";

                }



                sum = Convert.ToInt32(c) + 1;

                this.textBox4.Text = Convert.ToString(sum);

            }
            finally
            {
                myConn.Close();
            }

        }
        void sum()
        {
            int sum = 0;

            MySqlConnection myConn = new MySqlConnection(cons.myConnection);
            myConn.Open();
            try
            {
                string query = "select max(token_no) from mydb.receipt where Date='" + DateTime.Today.ToString("yyyy-MM-dd") + "';";
                MySqlCommand command = new MySqlCommand(query, myConn);

                string c = command.ExecuteScalar().ToString();
                if (c == "")
                {
                    c = "0";

                }



                sum = Convert.ToInt32(c);
                sum = sum + 1;
                this.textBox3.Text = Convert.ToString(sum);

            }
            finally
            {
                myConn.Close();
            }

        }
        void getdetail(int patient_id)
        {
            try
            {

                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String query = "SELECT * FROM mydb.patient_registration WHERE patient_reg ='" + txt_patient_reg.Text + "';";

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                string name, fathername, mob;



                while (myReader.Read())
                {
                    name = myReader.GetString("full_name");
                    txt_full_name.Text = name;

                    fathername = myReader.GetString("father_name");
                    txt_father_name.Text = fathername;
                    mob = myReader.GetString("mob");
                    txt_mob.Text = mob;

                    string age = myReader.GetString("DOB");
                    string[] words = age.Split(' ');
                    textBox5.Text = obj.calculateAge(Convert.ToDateTime(words[0]));

                    string s = myReader.GetString("sex");

                    if (Convert.ToBoolean(s) == true)
                    {

                        textBox2.Text = "Male";
                    }

                    else
                    {
                        textBox2.Text = "Female";
                    }

                }


                myConn.Close();


            }
            catch (Exception)
            {

                MessageBox.Show("cant go ");
            }

        }

        void getdoctordetail()
        {
            try
            {

                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String query = "SELECT * FROM mydb.user_registration WHERE user_type='Doctor';";

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                string name;



                while (myReader.Read())
                {
                    name = myReader.GetString("full_name");

                    ref_doctor_id.Items.Add(name);


                }


                myConn.Close();


            }
            catch (Exception)
            {

                MessageBox.Show("cant go ");
            }

        }
        void getdoctorid()
        {
            try
            {

                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String query = "SELECT * FROM mydb.user_registration WHERE user_type='Doctor'&& full_name='" + ref_doctor_id.Text + "';";
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();



                while (myReader.Read())
                {

                    doc_id = Convert.ToInt32(myReader.GetString("employee_id"));



                }


                myConn.Close();


            }
            catch (Exception)
            {

                MessageBox.Show("cant fetch to doctor id ");
            }

        }
        void govisit()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                String query = "insert into mydb.visit(patient_reg,visit_date,visit_no,employee_id,username)values(@1,@2,@3,@4,@5)";

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                getdoctorid();
                SelectCommand.Parameters.Add(new MySqlParameter("@1", Convert.ToInt32(txt_patient_reg.Text)));
                SelectCommand.Parameters.Add(new MySqlParameter("@2", DateTime.Today));
                SelectCommand.Parameters.Add(new MySqlParameter("@3", Convert.ToInt32("1")));
                SelectCommand.Parameters.Add(new MySqlParameter("@4", doc_id));
                SelectCommand.Parameters.Add(new MySqlParameter("@5", usernames));



                myConn.Open();
                myReader = SelectCommand.ExecuteReader();


                while (myReader.Read())
                {

                }


                myConn.Close();




            }
            catch (Exception)
            {


                MessageBox.Show("This Type Of Patient Id Has Not Register Yet ");
            }

        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (txt_patient_reg.Text != "" && ref_doctor_id.Text != "" && textBox1.Text != "")
            {
                govisit();
                try
                {



                    MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                    String query = "insert into mydb.receipt (token_no,patient_reg,employee_id,total,Date,visit_no,receiptdate )values (@1,@2,@3,@4,@5,@6,@7);";

                    getdoctorid();
                    MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();



                    SelectCommand.Parameters.Add(new MySqlParameter("@1", Convert.ToInt32(textBox3.Text)));
                    SelectCommand.Parameters.Add(new MySqlParameter("@2", Convert.ToInt32(txt_patient_reg.Text)));
                    SelectCommand.Parameters.Add(new MySqlParameter("@3", doc_id));
                    SelectCommand.Parameters.Add(new MySqlParameter("@4", Convert.ToInt32(textBox1.Text)));
                    SelectCommand.Parameters.Add(new MySqlParameter("@5", DateTime.Today));
                    SelectCommand.Parameters.Add(new MySqlParameter("@6", 1));
                    SelectCommand.Parameters.Add(new MySqlParameter("@7", DateTime.Today));


                    myReader = SelectCommand.ExecuteReader();


                    while (myReader.Read()) { }
                    myConn.Close();

                    //  MessageBox.Show("Data has saved");
                    //Invoice obj = new Invoice(textBox2.Text, txt_patient_reg.Text, txt_full_name.Text, txt_father_name.Text, textBox1.Text, textBox3.Text, txt_mob.Text, DateTime.Today.ToString("yyyy-MM-dd"), ref_doctor_id.Text, textBox4.Text, label20.Text, 1, textBox5.Text);
                    //obj.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                MessageBox.Show("Fill Required Fields");
            }
        }
    }
}
