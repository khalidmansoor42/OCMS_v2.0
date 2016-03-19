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

namespace OCMS_v2_0.Admin
{
    public partial class Add_Enum_And_Set_Value : MetroForm
    {
        string cmdTexst;
        string query;
        connection cons = new connection();
        public Add_Enum_And_Set_Value()
        {
            InitializeComponent();
            this.FocusMe();
            com_name.Select();
            metroToolTip1.SetToolTip(updateBtn, "Update");
            metroToolTip1.SetToolTip(addBtn, "Add");
            metroToolTip1.SetToolTip(retrieveBtn, "Retrieve Data");
            metroToolTip1.SetToolTip(deleteBtn, "Delete");
        }

        void table(string query1)
        {

            MySqlConnection condatabases = new MySqlConnection(cons.myConnection);
            MySqlCommand cmddatabase = new MySqlCommand(query1, condatabases);
            MySqlDataReader myreader;
            try
            {

                condatabases.Open();
                myreader = cmddatabase.ExecuteReader();
                MetroMessageBox.Show(this, "\n" + "Data Has Been Saved", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                while (myreader.Read())
                {
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Data Could Not Be Saved", ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }

        private void com_name_Click(object sender, EventArgs e)
        {
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'complaint_deaseses' and column_name = 'complaint_name';";
            query = "alter table mydb.complaint_deaseses modify column complaint_name ENUM";
        }

        private void qualification_Click(object sender, EventArgs e)
        {
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'docotor_registration' and column_name = 'qualification';";
            query = "alter table mydb.docotor_registration modify column qualification SET ";
        }

        private void Location_Click(object sender, EventArgs e)
        {
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'complaint_deaseses' and column_name = 'location';";
            query = "alter table mydb.complaint_deaseses modify column location ENUM ";
        }

        private void quality_Click(object sender, EventArgs e)
        {
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'complaint_deaseses' and column_name = 'quality';";
            query = "alter table mydb.complaint_deaseses modify column quality ENUM ";
        }

        private void severity_Click(object sender, EventArgs e)
        {
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'complaint_deaseses' and column_name = 'severity';";
            query = "alter table mydb.complaint_deaseses modify column mydb.complaint_deaseses.severity ENUM";
        }

        private void specialization_Click(object sender, EventArgs e)
        {
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'docotor_registration' and column_name = 'specialization';";
            query = "alter table mydb.docotor_registration modify column specialization SET";
        }

        private void att_relation_Click(object sender, EventArgs e)
        {
            cmdTexst = "select substring(column_type,6) from information_schema.COLUMNS where TABLE_SCHEMA = 'mydb' and table_name = 'patient_registration' and column_name = 'attendant_relation';";
            query = "alter table mydb.patient_registration modify  column attendant_relation ENUM";
        }

        private void retrieveBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection condatabase = new MySqlConnection(cons.myConnection);
            MySqlCommand cmddatabase = new MySqlCommand(cmdTexst, condatabase);
            try
            {

                string muaz;
                condatabase.Open();
                muaz = cmddatabase.ExecuteScalar().ToString();
                string[] name = muaz.Split(')');
                string result = string.Join("", name);
                textBox1.Text = result;
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + "Could Not Retrieve Value", ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string[] name = textBox1.Text.Split('\'');
            int count = 0;
            foreach (string m in name)
            {
                if (m != textBox2.Text)
                {
                }
                else
                {
                    count++;
                    MetroMessageBox.Show(this, "\n" + "Value Already Exists", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
            if (count == 0)
            {
                if (textBox1.Text == "")
                {

                    textBox1.Text = "'" + textBox2.Text + "'";
                }
                else
                {
                    string x = "'";
                    string y = ",";
                    string all = string.Concat(y, x, textBox2.Text, x);
                    all = string.Concat(textBox1.Text, all);
                    textBox1.Text = all;
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string x = "'";
            string y = ",";
            string all = "";
            string all1 = "";
            List<string> array = new List<string>();
            string[] name = textBox1.Text.Split('\'');
            foreach (string m in name)
            {

                if (m == textBox3.Text)
                {
                }
                else
                {
                    array.Add(m);

                }

            }
            int count = 0;
            foreach (string m in array)
            {

                if (m == "," || m == "")
                {
                }
                else
                {

                    all = string.Concat(x, m, x);
                    if (count == 0)
                    {
                        all1 = string.Concat(all1, all);
                        count++;
                    }
                    else
                    {
                        all1 = string.Concat(all1, y, all);
                    }
                }

            }

            textBox1.Text = all1;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string add = textBox1.Text;
            string concatinate = query + "(" + add + ")";
            MetroMessageBox.Show(this, "\n" + concatinate, ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            table(concatinate);
        }
    }
}
