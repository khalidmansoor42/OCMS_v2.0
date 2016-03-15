using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class Problem_List_And_Diagnoses : MetroForm
    {
        connectionDb cons = new connectionDb();
        Class.ModalClass modal = new Class.ModalClass();
        Class.getInformation info = new Class.getInformation();
        ArrayList list;
        MetroFramework.Controls.MetroComboBox[] c1 = new MetroFramework.Controls.MetroComboBox[12];
        MetroFramework.Controls.MetroComboBox[] c2 = new MetroFramework.Controls.MetroComboBox[12];
        MetroFramework.Controls.MetroComboBox[] com = new MetroFramework.Controls.MetroComboBox[12];
        MetroFramework.Controls.MetroComboBox[] com2 = new MetroFramework.Controls.MetroComboBox[12];
        MetroFramework.Controls.MetroButton[] btn1 = new MetroFramework.Controls.MetroButton[12];
        MetroFramework.Controls.MetroButton[] btn = new MetroFramework.Controls.MetroButton[12];
        MetroFramework.Controls.MetroLabel[] lab = new MetroFramework.Controls.MetroLabel[12];
        MetroFramework.Controls.MetroLabel[] star = new MetroFramework.Controls.MetroLabel[12];
        MetroFramework.Controls.MetroDateTime[] d1 = new MetroFramework.Controls.MetroDateTime[12];
        MetroFramework.Controls.MetroDateTime[] dat = new MetroFramework.Controls.MetroDateTime[12];
        MetroFramework.Controls.MetroDateTime[] dat2 = new MetroFramework.Controls.MetroDateTime[12];
        string descode;
        int a = 0;
        int b = 0;
        string[] patientInfo = new string[4];
        DataSet ds = new DataSet();

        public Problem_List_And_Diagnoses(string username, String usertype, string patientid)
        {
            InitializeComponent();
            this.KeyPreview = true;
            metroToolTip1.SetToolTip(metroButton2, "Add");
            metroToolTip1.SetToolTip(saveButton, "Save");
            metroToolTip1.SetToolTip(metroButton7, "Delete");
            metroToolTip1.SetToolTip(metroButton5, "Add Disease");
            metroToolTip1.SetToolTip(metroButton1, "Previous Form");
            metroToolTip1.SetToolTip(rightButtton, "Next Form");
            this.patient_reg.Text = patientid;
            this.userName.Text = username;
            this.type.Text = usertype;
            ProblemList();            
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
                getproblem();
                getpreviosprolem();
                metroButton2_Click(null, null);
            }
        }

        void ProblemList()
        {
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn = new MySqlConnection(cons.myConnection);
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT Diseases_code,Diseases_name FROM mydb.diseases", conn);
                da.Fill(ds, "diseases");              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            addField();
        }
        void addField()
        {
            a++;

            com[a] = new MetroFramework.Controls.MetroComboBox();
            com[a].Size = new Size(300, 21);
            com[a].Location = new Point(45, a * 40);
            //com[a].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            // com[a].AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //com[a].AutoCompleteSource = AutoCompleteSource.ListItems;
            com[a].DataSource = ds.Tables["diseases"];
            com[a].BindingContext = new BindingContext();
            com[a].ValueMember = "Diseases_code";
            com[a].DisplayMember = "Diseases_name";
            com[a].Name = Convert.ToString(a);
            string a1 = com[a].Name;
            com[a].SelectedIndexChanged += (senders, s) => { combox(null, null, a1); };
            metroPanel1.Controls.Add(com[a]);


            com2[a] = new MetroFramework.Controls.MetroComboBox();
            com2[a].Size = new Size(87, 21);
            com2[a].Location = new Point(350, a * 40);
            com2[a].Items.Add("OS");
            com2[a].Items.Add("OU");
            com2[a].Items.Add("OD");
            metroPanel1.Controls.Add(com2[a]);

            dat[a] = new MetroFramework.Controls.MetroDateTime();
            dat[a].MaxDate = DateTime.Now;
            this.dat[a].Location = new System.Drawing.Point(454, a * 40);
            this.dat[a].Size = new System.Drawing.Size(184, 30);
            dat[a].MaxDate = DateTime.Now;
            metroPanel1.Controls.Add(dat[a]);


            lab[a] = new MetroFramework.Controls.MetroLabel();
            lab[a].Text = Convert.ToString(a);
            lab[a].BackColor = Color.Red;
            lab[a].Size = new Size(100, 20);
            lab[a].Location = new Point(6, a * 40);
            lab[a].Font = new Font(lab[a].Font, FontStyle.Bold);
            metroPanel1.Controls.Add(lab[a]);


            star[a] = new MetroFramework.Controls.MetroLabel();
            star[a].Size = new Size(20, 20);
            star[a].Text = "*";
            star[a].Font = new Font("tahoma", 15);
            star[a].BackColor = Color.Transparent;
            star[a].Visible = false;
            star[a].ForeColor = System.Drawing.Color.Red;
            star[a].Name = Convert.ToString(a);
            string l1 = star[a].Name + "l";
            star[a].Location = new Point(824, a * 40);
            metroPanel1.Controls.Add(star[a]);
        }
        void combox(object sender, EventArgs e, string n)
        {
            int value = Convert.ToInt32(n);
            string name = n + "1";
            Boolean match1 = false;
            List<int> authors = new List<int>();
            List<int> invisi = new List<int>();
            if (a != 1)
            {
                for (int v = 1; v <= a; v++)
                {
                    match1 = false;
                    for (int x1 = 1; x1 <= a; x1++)
                    {
                        if (v != x1)
                        {
                            if (com[v].Text == com[x1].Text)
                            {
                                match1 = true;
                            }
                        }
                    }
                    if (match1 == false)
                    {
                        invisi.Add(v);
                    }
                    else
                    {
                        authors.Add(v);
                    }
                }
            }
            foreach (int author in authors)
            {
                star[author].Visible = true;
            }
            foreach (int author in invisi)
            {
                star[author].Visible = false;
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            if (a == b)
            {
            }
            else
            {
                com[a].Dispose();
                com2[a].Dispose();
                dat[a].Dispose();
                lab[a].Dispose();
                star[a].Dispose();
                a--;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (patient_reg.Text == "")
            {
                MessageBox.Show("Please select patient");
            }
            else
            {
                Boolean os = false;
                for (int i = 1; i <= a; i++)
                {
                    if (com[i].Text == "" || com2[i].Text == "" || star[i].Visible == true)
                    {
                        os = true;
                    }
                }
                if (os)
                {
                    MetroMessageBox.Show(this, "\n" + "Some Entery are duplicated or Blank", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int k = 1; k <= b; k++)
                    {
                        try
                        {
                            String query = "update  mydb.problem_list_and_diagnoses SET location='" + com2[k].Text + "',Diagnose_date='" + d1[k].Value.ToString("yyyy-MM-dd") + "' where patient_reg='" + patient_reg.Text + "' and Diseases_code='" + com[k].SelectedValue + "' ;";
                            modal.insertData(query);
                        }
                        catch (Exception)
                        {
                            MetroMessageBox.Show(this, "\n" + "Failed to update record", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        }
                    }
                    for (int j = b + 1; j <= a; j++)
                    {
                        Boolean deasmatch = false;
                        for (int x = 0; x < list.Count; x++)
                        {
                            if (com[j].Text == Convert.ToString(list[x]))
                            {
                                deasmatch = true;
                            }
                        }
                        if (deasmatch == true)
                        {
                            try
                            {
                                String query = "update  mydb.problem_list_and_diagnoses SET inactive_Date='0000-00-00',location='" + com2[j].Text + "',Diagnose_date='" + dat[j].Value.ToString("yyyy-MM-dd") + "'  where patient_reg='" + patient_reg.Text + "' and Diseases_code='" + com[j].SelectedValue + "' ;";
                                modal.insertData(query);
                            }
                            catch (Exception ex)
                            {
                                MetroMessageBox.Show(this, "\n" + ex.Message, ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            try
                            {
                                string query = "insert into mydb.problem_list_and_diagnoses(patient_reg,Diseases_code,location,Diagnose_date,inactive_Date)value('" + Convert.ToInt32(patient_reg.Text) + "','" + Convert.ToInt32(com[j].SelectedValue) + "','" + com2[j].Text + "','" + dat[j].Value.ToString("yyyy-MM-dd") + "','"+ "0000-00-00" + "');";
                                modal.insertData(query);
                            }
                            catch (Exception)
                            {
                                MetroMessageBox.Show(this, "\n" + "Failed to save data", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    MetroMessageBox.Show(this, "\n" + "Problem record has been saved", ":/");
                    metroPanel1.Controls.Clear();
                    a = 0;
                    b = 0;
                    getproblem();
                }

            }
        }

        void getproblem()
        {
            try
            {
                String query = "SELECT * FROM mydb.problem_list_and_diagnoses, mydb.diseases WHERE  problem_list_and_diagnoses.Diseases_code = diseases.Diseases_code and problem_list_and_diagnoses.inactive_Date='0000-00-00' and problem_list_and_diagnoses.patient_reg='" + patient_reg.Text + "'";
                MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    a++;
                    b = a;
                    com[b] = new MetroFramework.Controls.MetroComboBox();
                    com[b].Size = new Size(300, 21);
                    com[b].Location = new Point(45, b * 40);
                    com[b].DataSource = ds.Tables["diseases"];
                    com[b].BindingContext = new BindingContext();
                    com[b].ValueMember = "Diseases_code";
                    com[b].DisplayMember = "Diseases_name";
                    com[b].Text = myReader.GetString("Diseases_name");
                    com[b].Enabled = false;

                    metroPanel1.Controls.Add(com[b]);


                    com2[b] = new MetroFramework.Controls.MetroComboBox();
                    com2[b].Size = new Size(87, 21);
                    com2[b].Location = new Point(350, b * 40);
                    com2[b].Items.Add("OS");
                    com2[b].Items.Add("OD");
                    com2[b].Items.Add("OU");
                    com2[b].Text = myReader.GetString("location");                   
                    metroPanel1.Controls.Add(com2[b]);

                    d1[b] = new MetroFramework.Controls.MetroDateTime();
                    this.d1[b].Location = new System.Drawing.Point(454, b * 40);
                    this.d1[b].Size = new System.Drawing.Size(184, 30);
                    d1[b].Text = myReader.GetString("Diagnose_date");
                    d1[b].MaxDate = DateTime.Now;
                    metroPanel1.Controls.Add(d1[b]);

                    btn1[b] = new MetroFramework.Controls.MetroButton();
                    this.btn1[b].Location = new System.Drawing.Point(660, b * 40);
                    this.btn1[b].Size = new System.Drawing.Size(130, 22);
                    this.btn1[b].Text = "Inactive";
                    this.btn1[b].Name = Convert.ToString(b);
                    string ab = this.btn1[b].Name;
                    btn1[b].Click += (sender, e) => { updateDate(sender, e, ab); };
                    metroPanel1.Controls.Add(btn1[b]);

                    lab[a] = new MetroFramework.Controls.MetroLabel();
                    lab[a].Text = Convert.ToString(a);
                    lab[a].Size = new Size(100, 20);
                    lab[a].Location = new Point(6, a * 40);
                    lab[a].Font = new Font(lab[a].Font, FontStyle.Bold);
                    metroPanel1.Controls.Add(lab[a]);

                    star[b] = new MetroFramework.Controls.MetroLabel();
                    star[b].Size = new Size(20, 20);
                    star[b].Text = "*";
                    star[b].Font = new Font("tahoma", 15);
                    star[b].Visible = false;
                    star[b].ForeColor = System.Drawing.Color.Red;
                    star[b].Name = Convert.ToString(b);
                    string l1 = star[b].Name + "l";
                    star[b].Location = new Point(824, b * 40);
                    metroPanel1.Controls.Add(star[b]);
                }
                if (a == 0)
                {
                    metroButton2_Click(new object(), new EventArgs());

                }
                cons.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void getpreviosprolem()
        {
            try
            {
                list = new ArrayList();
                String query = "SELECT * FROM mydb.problem_list_and_diagnoses, mydb.diseases WHERE  problem_list_and_diagnoses.Diseases_code = diseases.Diseases_code and problem_list_and_diagnoses.inactive_Date!='0000-00-00' and problem_list_and_diagnoses.patient_reg='" + patient_reg.Text + "'";
                MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    list.Add(myReader.GetString("Diseases_name"));
                }
                cons.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        void updateDate(object sender, EventArgs e, string n)
        {
            int index = Convert.ToInt32(n);
            try
            {
                String query = "update  mydb.problem_list_and_diagnoses SET inactive_Date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where patient_reg='" + patient_reg.Text + "' and Diseases_code='" + com[index].SelectedValue + "' and Diagnose_date='" + d1[index].Value.ToString("yyyy-MM-dd") + "';";
                modal.insertData(query);
                metroPanel1.Controls.Clear();
                a = 0;
                b = 0;
                getpreviosprolem();
                getproblem();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            // Do some stuff       
        }


        private void Problem_List_And_Diagnoses_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.Control && e.Shift && e.KeyCode == Keys.X)
                {
                    this.Close();
                }
                if (e.Control && e.KeyCode == Keys.A)
                {
                    metroButton2_Click(sender, e);
                }
                if (e.Control && e.KeyCode == Keys.Z)
                {
                    metroButton7_Click(sender, e);
                }

                if (e.Control && e.KeyCode == Keys.Right)
                {
                    rightButtton_Click(sender, e);

                }
                if (e.Control && e.KeyCode == Keys.S)
                {
                    saveButton_Click(sender, e);
                }
        }

        private void rightButtton_Click(object sender, EventArgs e)
        {

        }
    }
}
