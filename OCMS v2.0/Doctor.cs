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

namespace OCMS_v2._0
{
    public partial class Doctor : MetroForm
    {
        int a = 0;
        string username ="";
        string doctorId = "";
        Class.getImage img = new Class.getImage();
        Class.getId id = new Class.getId();
        connectionDb cons = new connectionDb();
        Class.getInformation info = new Class.getInformation();

        public Doctor(string Name,string userType,string userName,string loginTimes)
        {
            InitializeComponent();
            company.Text = "© Techagentx";
            dateLabel.Text = DateTime.Now.ToString("dddd  dd, MMM yyyy");
            this.name.Text = Name;
            this.loginTime.Text = loginTimes;
            this.type.Text = userType;
            username = userName;
            profilePic.Image = img.get_pic("SELECT * FROM mydb.user_registration where user_name ='" + userName + "';");
            doctorId = id.getid("SELECT * FROM mydb.user_registration where user_name ='" + username + "'");
            listBox();
        }
        public void listBox()
        {
            try
            {
                String query = "SELECT * FROM mydb.patient_registration,mydb.visit where mydb.patient_registration.patient_reg=mydb.visit.patient_reg and employee_id ='" + doctorId + "'and  visit_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND  checks=false;";
                MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                string patientid;
                while (myReader.Read())
                {
                    patientid = myReader.GetString("patient_reg");
                    string visit = myReader.GetString("visit_no");
                    detail(Convert.ToInt32(myReader.GetString("patient_reg")), Convert.ToInt32(visit));
                    a++;
                }
                cons.closeConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void detail(int patientid, int visits)
        {

            string list = "";
            try
            {
                String query = "SELECT patient_registration.full_name, receipt.token_no, visit.patient_reg FROM mydb.patient_registration, mydb.receipt, mydb.visit WHERE patient_registration.patient_reg = receipt.patient_reg AND patient_registration.patient_reg = visit.patient_reg AND (patient_registration.patient_reg = '" + patientid + "') and  visit.visit_date=receipt.Date and visit.visit_no=receipt.visit_no and visit.visit_no='" + visits + "' ORDER BY receipt.token_no ASC";
                MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
                MySqlDataReader myReader;

                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string tokenspace = "";
                    string patientspace = "";
                    int token = myReader.GetString("token_no").Length;
                    int id = myReader.GetString("patient_reg").Length;
                    if (token == 1)
                    {
                        tokenspace = myReader.GetString("token_no").PadRight(21);
                    }
                    else if (token == 2)
                    {
                        tokenspace = myReader.GetString("token_no").PadRight(20);
                    }
                    else if (token == 3)
                    {
                        tokenspace = myReader.GetString("token_no").PadRight(19);
                    }
                    else if (token == 4)
                    {
                        tokenspace = myReader.GetString("token_no").PadRight(18);
                    }
                    else if (token == 5)
                    {
                        tokenspace = myReader.GetString("token_no").PadRight(17);

                    }
                    else if (token == 6)
                    {
                        tokenspace = myReader.GetString("token_no").PadRight(16);
                    }

                    if (id == 1)
                    {
                        patientspace = myReader.GetString("patient_reg").PadRight(21);
                    }
                    else if (id == 2)
                    {
                        patientspace = myReader.GetString("patient_reg").PadRight(20);
                    }
                    else if (id == 3)
                    {
                        patientspace = myReader.GetString("patient_reg").PadRight(19);
                    }
                    else if (id == 4)
                    {
                        patientspace = myReader.GetString("patient_reg").PadRight(18);
                    }
                    else if (id == 5)
                    {
                        patientspace = myReader.GetString("patient_reg").PadRight(17);
                    }
                    else if (id == 6)
                    {
                        patientspace = myReader.GetString("patient_reg").PadRight(16);
                    }
                    list = tokenspace + patientspace + myReader.GetString("full_name");
                }
                listBox1.Items.Add(list);
                listBox1.Sorted = true;
                cons.closeConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("donot Find Form ic");
            }
        }




        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Transparent;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.Transparent;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.Color.Transparent;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = System.Drawing.Color.Transparent;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = System.Drawing.Color.Transparent;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = System.Drawing.Color.Transparent;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = System.Drawing.Color.Transparent;
        }

        private void inventoryTile_MouseEnter(object sender, EventArgs e)
        {
            inventoryTile.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void inventoryTile_MouseLeave(object sender, EventArgs e)
        {
            inventoryTile.Style = MetroFramework.MetroColorStyle.Teal;
        }

        private void metroTile2_MouseEnter(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile2_MouseLeave(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Green;
        }

        private void metroTile3_MouseEnter(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile3_MouseLeave(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Orange;
        }

        private void metroTile4_MouseEnter(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile4_MouseLeave(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Silver;
        }

        private void metroTile5_MouseEnter(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile5_MouseLeave(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Lime;
        }

        private void metroTile7_MouseEnter(object sender, EventArgs e)
        {
            metroTile7.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile7_MouseLeave(object sender, EventArgs e)
        {
            metroTile7.Style = MetroFramework.MetroColorStyle.Brown;
        }

        private void metroTile8_MouseEnter(object sender, EventArgs e)
        {
            metroTile8.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile8_MouseLeave(object sender, EventArgs e)
        {
            metroTile8.Style = MetroFramework.MetroColorStyle.Purple;
        }

        private void metroTile10_MouseEnter(object sender, EventArgs e)
        {
            metroTile10.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile10_MouseLeave(object sender, EventArgs e)
        {
            metroTile10.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile11_MouseEnter(object sender, EventArgs e)
        {
            metroTile11.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile11_MouseLeave(object sender, EventArgs e)
        {
            metroTile11.Style = MetroFramework.MetroColorStyle.Yellow;
        }

        private void metroTile13_MouseEnter(object sender, EventArgs e)
        {
            metroTile13.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile13_MouseLeave(object sender, EventArgs e)
        {
            metroTile13.Style = MetroFramework.MetroColorStyle.Pink;
        }

        private void metroTile14_MouseEnter(object sender, EventArgs e)
        {
            metroTile14.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile14_MouseLeave(object sender, EventArgs e)
        {
            metroTile14.Style = MetroFramework.MetroColorStyle.Blue;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
            menuProgressBar.Value = menuProgressBar.Value + 5;
            if (menuProgressBar.Value == 100)
            {
                menuProgressBar.Visible = false;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Boolean match = false;
            String query = "select max(token_no) FROM mydb.receipt where Date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and employee_id='" + doctorId + "' ";
            MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
            try
            {
                string c = SelectCommand.ExecuteScalar().ToString();
                int i = 0;

                if (c == "")
                {
                    match = true;
                }
                else
                {
                    foreach (var item in listBox1.Items)
                    {
                        string[] words = item.ToString().Split(' ');
                        string ar = words[i];
                        if (c == ar)
                        {
                            match = true;
                            break;
                        }
                    }
                }
                if (match == true)
                {
                }
                else
                {
                    string[] userInfo = new string[2];
                    string query1 = "SELECT mydb.receipt.token_no,mydb.patient_registration.full_name,max(mydb.visit.visit_no),mydb.patient_registration.patient_reg FROM mydb.receipt,mydb.patient_registration,mydb.visit where mydb.patient_registration.patient_reg=mydb.visit.patient_reg and mydb.patient_registration.patient_reg=mydb.receipt.patient_reg and mydb.receipt.token_no='" + c + "'and mydb.visit.visit_date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and mydb.receipt.Date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and mydb.visit.checks='0' ";
                    userInfo=info.getinfo(query1);
                    if (userInfo[0] != null)
                    {
                        listBox1.Items.Add(userInfo[0]);
                        tokenNoti.Icon = SystemIcons.Exclamation;
                        tokenNoti.Visible = true;
                        tokenNoti.ShowBalloonTip(5000, "New Token has Issue", userInfo[1], ToolTipIcon.Info);
                        listBox1.Sorted = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

            listBox1.SelectionMode = SelectionMode.One;
            int i = 1;
            if (listBox1.Items.Count != 0 && listBox1.Text != "")
            {
                string[] words = listBox1.Text.ToString().Split(' ');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        if (i == 1)
                        {
                            tokenNoLeb.Text = word;
                        }
                        if (i == 2)
                        {
                            patientID.Text = word;
                        }
                        i++;
                    }
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count != 0 && listBox1.Text != "")
            {
                int i = 1;
                //DialogResult dialogResult = MessageBox.Show("Patient Check", "Some Title", MessageBoxButtons.YesNo);
                DialogResult dialogResult = MetroMessageBox.Show(this, "\n" + "Patient Check", ":/", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                string token = "";
                string ar = "";
                string[] words = listBox1.Text.ToString().Split(' ');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        if (i == 1)
                        {
                            token = word;
                        }
                        if (i == 2)
                        {
                            ar = word;
                        }
                        i++;
                    }
                }
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "UPDATE mydb.visit SET mydb.visit.checks=true where patient_reg=@1 AND visit_date=@2 and mydb.visit.visit_no=(select visit_no from mydb.receipt where mydb.receipt.token_no=@3 and mydb.receipt.receiptdate=@2)";
                        MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
                        SelectCommand.Parameters.Add(new MySqlParameter("@1", ar));
                        SelectCommand.Parameters.Add(new MySqlParameter("@2", DateTime.Now.ToString("yyyy-MM-dd")));
                        SelectCommand.Parameters.Add(new MySqlParameter("@3", token));
                        MySqlDataReader myReader;
                        myReader = SelectCommand.ExecuteReader();

                        cons.closeConnection();
                        listBox1.Items.Clear();
                        this.patientID.Text = "";
                        listBox();
                    }
                    catch (Exception)
                    {
                        MetroMessageBox.Show(this, "\n" + "Could not checkout patient", ":/", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void SearchPatient_TextChanged(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox1.SelectedItems.Clear();
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.Items[i].ToString().ToLower().Contains(SearchPatient.Text.ToLower()))
                {
                    listBox1.SetSelected(i, true);
                    string[] words = listBox1.Text.ToString().Split(' ');
                    patientID.Text = words[20];
                    tokenNoLeb.Text = words[0];

                }
            }
        }
    }
}
