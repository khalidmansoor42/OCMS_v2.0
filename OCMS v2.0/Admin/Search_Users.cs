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
    public partial class Search_Users : MetroForm
    {
        string checks;
        connection obj = new connection();
        internal string Parameter1 { get; private set; }
        public Search_Users(string check)
        {
            InitializeComponent();
            this.FocusMe();
            searchCriteriaCombo.Select();
            metroToolTip1.SetToolTip(searchCriteriaCombo, "Select Search Criteria From Here");
            checks = check;
            dvg1();
        }
        DataTable dbdataset;
        void dvg1()
        {

            try
            {
                MySqlConnection condatabse = new MySqlConnection(obj.myConnection);

                String query = "SELECT employee_id AS ID,full_name AS Name,f_name AS Father_Name,address AS Address,mob AS Mobile,cnic AS CNIC,date_registration AS Joining_Date,user_type AS User_Type,user_name AS User_Name FROM mydb.user_registration ;";

                MySqlCommand cmdDataBase = new MySqlCommand(query, condatabse);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;

                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void txt_searchby_TextChanged(object sender, EventArgs e)
        {
            if (searchCriteriaCombo.SelectedIndex == 0)
            {

                DataView DV = new DataView(dbdataset);
                DV.RowFilter = string.Format("Convert([ID], System.String) LIKE '%{0}%'", txt_searchby.Text);
                dataGridView1.DataSource = DV;

            }
            else if (searchCriteriaCombo.SelectedIndex == 1)
            {

                DataView DV = new DataView(dbdataset);
                DV.RowFilter = "Name like '%" + txt_searchby.Text + "%'";
                dataGridView1.DataSource = DV;

            }
            else if (searchCriteriaCombo.SelectedIndex == 2)
            {

                DataView DV = new DataView(dbdataset);
                DV.RowFilter = "Mobile like '%" + txt_searchby.Text + "%'";
                dataGridView1.DataSource = DV;

            }
            else if (searchCriteriaCombo.SelectedIndex == 3)
            {

                DataView DV = new DataView(dbdataset);
                DV.RowFilter = "CNIC like '%" + txt_searchby.Text + "%'";
                dataGridView1.DataSource = DV;

            }
        }

        private void txt_searchby_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (searchCriteriaCombo.SelectedIndex == 2)
            {
                txt_searchby.MaxLength = 13;

                if (ch != 08)
                {
                    if (txt_searchby.Text.Length == 4)
                    {
                        txt_searchby.Text += "-";
                        txt_searchby.Select(txt_searchby.Text.Length, 4);
                    }

                }

                if (!char.IsDigit(ch) && ch != 8)
                {

                    e.Handled = true;
                }
            }
            else if (searchCriteriaCombo.SelectedIndex == 0)
            {
                txt_searchby.MaxLength = 30;
                if (!char.IsDigit(ch) && ch != 8)
                {

                    e.Handled = true;
                }
            }
            else if (searchCriteriaCombo.SelectedIndex == 3)
            {
                txt_searchby.MaxLength = 15;
                if (ch != 08)
                {

                    if (txt_searchby.Text.Length == 5 || txt_searchby.Text.Length == 13)
                    {
                        txt_searchby.Text += "-";
                        txt_searchby.Select(txt_searchby.Text.Length, 0);
                    }



                }

                if (!char.IsDigit(ch) && ch != 8)
                {

                    e.Handled = true;
                }
            }
            else if (searchCriteriaCombo.SelectedIndex == 1)
            {
                txt_searchby.MaxLength = 30;
                if (char.IsDigit(ch) && ch != 8)
                {

                    e.Handled = true;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checks == "chpass")
            {
                Parameter1 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;

            }

            if (checks == "updateuser")
            {
                Parameter1 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
