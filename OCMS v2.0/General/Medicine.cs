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
    public partial class Medicine : MetroForm
    {
        connection obj = new connection();
        DataTable dbdataset = new DataTable();
        public Medicine()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(saveBtn, "Save");
            metroToolTip1.SetToolTip(updateBtn, "Update");
            dgv();
        }
        void dgv()
        {
            try
            {
                MySqlConnection condatabse = new MySqlConnection(obj.myConnection);
                String quray = "SELECT *  FROM mydb.medicine ";
                MySqlCommand cmdDataBase = new MySqlCommand(quray, condatabse);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;

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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (txt_med_id.Text != "" && txt_med_type.Text != "" && txt_med_name.Text != "")
            {
                try
                {
                    MySqlConnection myConn = new MySqlConnection(obj.myConnection);


                    String query = "insert into mydb.medicine (med_id,med_name,type) values (@1,@2,@3);";
                    MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    SelectCommand.Parameters.Add(new MySqlParameter("@1", this.txt_med_id.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@2", this.txt_med_name.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@3", this.txt_med_type.Text));
                    myReader = SelectCommand.ExecuteReader();
                    while (myReader.Read()) { }
                    myConn.Close();
                    MetroMessageBox.Show(this, "\n" + "Data Has Been Saved", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv();


                }

                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MetroMessageBox.Show(this, "\n" + "Please Fill All The Fields", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void txt_searchby_TextChanged(object sender, EventArgs e)
        {
            if (searchCriteriaCombo.SelectedIndex == 0)
            {

                DataView DV = new DataView(dbdataset);
                DV.RowFilter = string.Format("med_id LIKE '%{0}%'", txt_searchby.Text);
                metroGrid1.DataSource = DV;

            }
            else if (searchCriteriaCombo.SelectedIndex == 1)
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = "med_name like '%" + txt_searchby.Text + "%'";
                metroGrid1.DataSource = DV;

            }
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txt_med_id.Text = this.metroGrid1.CurrentRow.Cells[0].Value.ToString();
            this.txt_med_name.Text = this.metroGrid1.CurrentRow.Cells[1].Value.ToString();
            txt_med_type.Text = this.metroGrid1.CurrentRow.Cells[2].Value.ToString();
            saveBtn.Visible = false;
            updateBtn.Visible = true;
            txt_med_id.Enabled = false;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String query;
                MySqlConnection myConn = new MySqlConnection(obj.myConnection);
                query = "update  mydb.medicine set med_name=@2 ,type=@1 where med_id=@3;";
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                SelectCommand.Parameters.Add(new MySqlParameter("@1", txt_med_type.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@3", txt_med_id.Text));
                SelectCommand.Parameters.Add(new MySqlParameter("@2", txt_med_name.Text));
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read()) { }
                myConn.Close();
                MetroMessageBox.Show(this, "\n" + "Record Has Been Updated", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.metroGrid1.DataSource = null;

                dgv();

                txt_med_id.Clear();
                txt_med_type.ResetText();
                txt_med_name.Clear();
                this.updateBtn.Visible = false;
                saveBtn.Visible = true;
                txt_med_id.Enabled = true;

            }

            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + "Record Did Not Update", ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
    }
}
