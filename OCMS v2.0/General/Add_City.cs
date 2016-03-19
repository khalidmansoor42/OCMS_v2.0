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
    public partial class Add_City : MetroForm
    {
        connection cons = new connection();
        public Add_City()
        {
            InitializeComponent();
            this.FocusMe();
            City_id.Select();
            metroToolTip1.SetToolTip(saveBtn, "Save");
            metroToolTip1.SetToolTip(clearBtn, "Clear");
            metroToolTip1.SetToolTip(updateBtn, "Update");
            sum();
            dgv();
            updateBtn.Visible = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (text_City_Name.Text != " ")
            {
                try
                {
                    MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                    String query = "insert into mydb.city (city_id,city_name) values (@1,@2);";
                    MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    SelectCommand.Parameters.Add(new MySqlParameter("@1", City_id.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@2", text_City_Name.Text));
                    myReader = SelectCommand.ExecuteReader();
                    while (myReader.Read()) { }
                    myConn.Close();
                    MetroMessageBox.Show(this, "\n" + "Data Has Been Saved", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv();
                    City_id.Clear();
                    text_City_Name.Clear();
                    sum();

                }

                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + "Please Write City Name", ":(", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }
        void sum()
        {
            int sum = 0;
            MySqlConnection conn = new MySqlConnection(cons.myConnection);
            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand("select max(city_id) from mydb.city", conn);
                string c = command.ExecuteScalar().ToString();
                if (c == "")
                {
                    c = "0";

                }



                sum = Convert.ToInt32(c);
                sum = sum + 1;
                this.City_id.Text = Convert.ToString(sum);

            }
            finally
            {
                conn.Close();
            }

        }
        void dgv()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                String quray = "SELECT *  FROM mydb.city ";
                //+ "'AND NAME='" + this.text_P_Name.Text + "'AND F_NAME='" + this.text_P_fName.Text +"' 
                // MessageBox.Show(quray);
                MySqlCommand cmdDataBase = new MySqlCommand(quray, myConn);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;

                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                metroGrid1.DataSource = bsource;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (text_City_Name.Text != " ")
            {
                try
                {
                    MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                    String query = "Update mydb.city set  city_name=@2 where city_id=@1;";
                    MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    SelectCommand.Parameters.Add(new MySqlParameter("@1", City_id.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@2", text_City_Name.Text));
                    myReader = SelectCommand.ExecuteReader();
                    while (myReader.Read()) { }
                    myConn.Close();
                    MetroMessageBox.Show(this, "\n" + "Data Has Been Updated", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv();
                    City_id.Clear();
                    text_City_Name.Clear();
                    sum();

                }

                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + "Please Write City Name", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            sum();
            text_City_Name.Clear();
            saveBtn.Visible = true;
            updateBtn.Visible = false;
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            City_id.Text = this.metroGrid1.CurrentRow.Cells[0].Value.ToString();
            text_City_Name.Text = this.metroGrid1.CurrentRow.Cells[1].Value.ToString();
            saveBtn.Visible = false;
            updateBtn.Visible = true;
        }

        private void text_City_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
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

        private void text_City_Name_Leave(object sender, EventArgs e)
        {
            text_City_Name.Text = CapitalizeWords(text_City_Name.Text);
        }
    }
}
