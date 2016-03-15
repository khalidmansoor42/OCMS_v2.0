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

namespace OCMS_v2._0
{
    public partial class History : MetroForm
    {
        Class.getInformation info = new Class.getInformation();
        connectionDb cons = new connectionDb();
        Class.maxValue obj1 = new Class.maxValue();
        string[] patientInfo = new string[4];
        DataSet ds = new DataSet();

        int maxvisit;

        public History(string username, String usertype, string patientid)
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(save, "Save");
            metroToolTip1.SetToolTip(update, "Update");
            metroToolTip1.SetToolTip(metroButton1, "Previous Form");
            metroToolTip1.SetToolTip(metroButton6, "Next Form");
            this.patient_reg.Text = patientid;
            this.userName.Text = username;
            this.type.Text = usertype;
            if (patient_reg.Text == "")
            {
                MessageBox.Show("Please select patient first");
            }
            else
            {
                patientInfo = info.information("SELECT a.full_name, a.father_name,a.DOB, b.visit_no FROM mydb.patient_registration a, mydb.visit b  WHERE a.patient_reg = b.patient_reg  AND b.visit_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'And  a.patient_reg ='" + patient_reg.Text + "' And b.patient_reg='" + patient_reg.Text + "';");
                patient_name.Text = patientInfo[0];
                visit.Text = patientInfo[2];
                age.Text = patientInfo[3];
                ocuupation();
            }
        }

        void pasthistory()
        {
            maxvisit = obj1.max("Select max(visit_no) from mydb.gernaral_history where patient_reg='" + patient_reg.Text + "';");
            if (maxvisit == Convert.ToInt32(visit.Text))
            {
                update.Visible = false;
                save.Visible = true;
            }
            else
            {
                save.Visible = false;
                update.Visible = true;
            }

            if (maxvisit > 0)
            {
                try
                {

                    MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                    string query = "SELECT * FROM mydb.gernaral_history where patient_reg='" + patient_reg.Text + "' and visit_no='" + maxvisit + "';";
                    MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    myReader = SelectCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        Family_Disease_ocular.Text = myReader.GetString("Family_Disease_ocular");
                        Family_Disease_systematic.Text = myReader.GetString("Family_Disease_systematic");
                        occupation.Text = myReader.GetString("occupation");
                        if (myReader.GetBoolean("Alcohol"))
                        {
                            radioButton2.Checked = true;
                        }
                        else
                        {
                            radioButton1.Checked = true;
                        }
                        if (myReader.GetBoolean("Smoke"))
                        {
                            radioButton4.Checked = true;
                        }
                        else
                        {
                            radioButton3.Checked = true;
                        }
                        mood_affect.Text = myReader.GetString("mood_affect");
                        other.Text = myReader.GetString("other");
                        if (myReader.GetBoolean("oriented_to_person_place_and_time"))
                        {
                            radioButton6.Checked = true;
                        }
                        else
                        {
                            radioButton5.Checked = true;
                        }
                    }

                    if (myReader.GetBoolean("Daibetes"))
                    {
                        Diabetesyes.Checked = true;
                        Diabetes_duration.Text = myReader.GetString("Daibetes_duration");
                        Diabetes_control.Text = myReader.GetString("Daibetes_control");
                        HbAic.Text = myReader.GetString("hbaic");
                        fbs.Text = myReader.GetString("FBS");
                        if (myReader.GetBoolean("insulin"))
                        {
                            insulinyes.Checked = true;
                            insulin_dosage.Text = myReader.GetString("insulin_dosage");
                        }
                        else
                        {
                            insulinyes.Checked = false;
                            insulin_dosage.Text = "";
                        }
                    }
                    else
                    {
                        Diabetes_duration.Text = "";
                        Diabetes_control.Text = "";
                        HbAic.Text = "";
                        fbs.Text = "";
                        Diabetesyes.Checked = false;
                    }
                    if (myReader.GetBoolean("Hypertension"))
                    {
                        Hypertensionyes.Checked = true;
                        Hypertension_control.Text = myReader.GetString("Hypertension_duration");
                        Hypertension_duration.Text = myReader.GetString("Hypertension_control");
                    }
                    else
                    {
                        Hypertensionyes.Checked = false;
                        Hypertension_control.Text = "";
                        Hypertension_duration.Text = "";
                    }

                    textBox11.Text = myReader.GetString("Cardiac");
                    textBox2.Text = myReader.GetString("Respiratory");
                    textBox13.Text = myReader.GetString("Rinal");
                    textBox4.Text = myReader.GetString("Cancer");
                    textBox3.Text = myReader.GetString("other_illness");
                    myConn.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        void ocuupation()
        {
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn = new MySqlConnection(cons.myConnection);
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM mydb.occupation;", conn);
                da.Fill(ds, "occupation");
                occupation.DataSource = ds.Tables["occupation"];
                occupation.BindingContext = new BindingContext();
                occupation.ValueMember = "occupation";
                occupation.DisplayMember = "occupation";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (patient_reg.Text == "")
            {
                MessageBox.Show("Please select patient");
            }
            else
            {
                if (occupation.Text == "")
                {
                    MessageBox.Show("Please fill occpation Field");

                }
                else
                {

                    try
                    {
                        MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                        String query = "insert into mydb.gernaral_history (patient_reg,visit_no,Family_Disease_ocular,Family_Disease_systematic,occupation,Alcohol,Smoke,mood_affect,other,oriented_to_person_place_and_time,Daibetes,Daibetes_duration,Daibetes_control,hbaic,FBS,insulin,insulin_dosage,Hypertension,Hypertension_duration,Hypertension_control,Cardiac,Respiratory,Rinal,Cancer,other_illness) values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25);";
                        MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                        MySqlDataReader myReader;
                        myConn.Open();
                        SelectCommand.Parameters.Add(new MySqlParameter("@1", Convert.ToUInt32(patient_reg.Text)));
                        SelectCommand.Parameters.Add(new MySqlParameter("@2", Convert.ToUInt32(visit.Text)));
                        SelectCommand.Parameters.Add(new MySqlParameter("@3", Family_Disease_ocular.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@4", Family_Disease_systematic.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@5", occupation.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@8", mood_affect.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@9", other.Text));

                        if (radioButton2.Checked == true)
                        {
                            SelectCommand.Parameters.Add(new MySqlParameter("@6", true));

                        }
                        else
                        {
                            SelectCommand.Parameters.Add(new MySqlParameter("@6", false));
                        }
                        if (radioButton4.Checked == true)
                        {
                            SelectCommand.Parameters.Add(new MySqlParameter("@7", true));
                        }
                        else
                        {
                            SelectCommand.Parameters.Add(new MySqlParameter("@7", false));
                        }

                        if (radioButton6.Checked == true)
                        {
                            SelectCommand.Parameters.Add(new MySqlParameter("@10", true));
                        }
                        else
                        {
                            SelectCommand.Parameters.Add(new MySqlParameter("@10", false));
                        }

                        if (Diabetesyes.Checked == true)
                        {
                            SelectCommand.Parameters.Add(new MySqlParameter("@11", true));
                            SelectCommand.Parameters.Add(new MySqlParameter("@12", Diabetes_duration.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@13", Diabetes_control.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@14", HbAic.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@15", fbs.Text));
                            if (insulinyes.Checked == true)
                            {
                                SelectCommand.Parameters.Add(new MySqlParameter("@16", true));
                                SelectCommand.Parameters.Add(new MySqlParameter("@17", insulin_dosage.Text));

                            }
                            else
                            {
                                SelectCommand.Parameters.Add(new MySqlParameter("@16", false));
                                SelectCommand.Parameters.Add(new MySqlParameter("@17", 0));
                            }

                        }
                        else
                        {

                            SelectCommand.Parameters.Add(new MySqlParameter("@12", ""));
                            SelectCommand.Parameters.Add(new MySqlParameter("@13", ""));
                            SelectCommand.Parameters.Add(new MySqlParameter("@14", ""));
                            SelectCommand.Parameters.Add(new MySqlParameter("@15", ""));
                            SelectCommand.Parameters.Add(new MySqlParameter("@11", false));
                            SelectCommand.Parameters.Add(new MySqlParameter("@16", false));
                            SelectCommand.Parameters.Add(new MySqlParameter("@17", ""));
                        }
                        if (Hypertensionyes.Checked == true)
                        {
                            SelectCommand.Parameters.Add(new MySqlParameter("@18", true));
                            SelectCommand.Parameters.Add(new MySqlParameter("@19", Hypertension_control.Text));
                            SelectCommand.Parameters.Add(new MySqlParameter("@20", Hypertension_duration.Text));

                        }
                        else
                        {
                            SelectCommand.Parameters.Add(new MySqlParameter("@18", false));
                            SelectCommand.Parameters.Add(new MySqlParameter("@19", ""));
                            SelectCommand.Parameters.Add(new MySqlParameter("@20", ""));
                        }

                        SelectCommand.Parameters.Add(new MySqlParameter("@21", textBox11.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@22", textBox2.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@23", textBox13.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@24", textBox4.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@25", textBox3.Text));

                        myReader = SelectCommand.ExecuteReader();


                        while (myReader.Read()) { }
                        myConn.Close();
                        MessageBox.Show("Record has been saved");
                        pasthistory();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save record");
                    }
                }//else end for occupation field
            }//else end for see patient field is empty or no
        }
    }
}
