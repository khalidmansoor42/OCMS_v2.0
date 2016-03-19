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
    public partial class Add_Diseases : MetroForm
    {
        connection cons = new connection();
        DataTable dbdataset = new DataTable();
        public Add_Diseases()
        {
            InitializeComponent();
            this.FocusMe();
            Diseases_code.Select();
            metroToolTip1.SetToolTip(saveBtn, "Save");
            metroToolTip1.SetToolTip(clearBtn, "Clear");
            metroToolTip1.SetToolTip(updateBtn, "Update");
            dgv();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (Diseases_code.Text != "" || Diseases_name.Text != "")
            {
                try
                {
                    MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                    String query = "insert into mydb.diseases(Diseases_code,Diseases_name)value(@1,@2);";

                    MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    SelectCommand.Parameters.Add(new MySqlParameter("@1", Diseases_code.Text));
                    SelectCommand.Parameters.Add(new MySqlParameter("@2", Diseases_name.Text));
                    myReader = SelectCommand.ExecuteReader();
                    while (myReader.Read()) { }
                    myConn.Close();
                    MetroMessageBox.Show(this, "\n" + "Data Has Been Saved", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Diseases_code.Clear();
                    Diseases_name.Clear();
                    dgv();

                }

                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, "\n" + "Record Not Saved", ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + "Please Fill Disease Code And Disease Name", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }
        void dgv()
        {
            //dataGridView1.Rows.Clear();
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                String quray = "SELECT Diseases_code as Code, Diseases_name as Name  FROM mydb.diseases ORDER BY Diseases_name  ";
                MySqlCommand cmdDataBase = new MySqlCommand(quray, myConn);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                metroGrid1.DataSource = bsource;
                sda.Update(dbdataset);
                DataGridViewColumn column = metroGrid1.Columns[0];
                column = metroGrid1.Columns[1];
                metroGrid1.Refresh();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message, ":(", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            radio_Diseases_Code.Visible = true;
            radio_Diseases_name.Visible = true;
            this.Diseases_code.Text = this.metroGrid1.CurrentRow.Cells[0].Value.ToString();
            this.Diseases_name.Text = this.metroGrid1.CurrentRow.Cells[1].Value.ToString();
            saveBtn.Visible = false;
            updateBtn.Visible = true;
        }

        private void txt_searchby_TextChanged(object sender, EventArgs e)
        {
            if (searchCriteriaCombo.SelectedIndex == 0)
            {

                DataView DV = new DataView(dbdataset);
                DV.RowFilter = string.Format("Code LIKE '%{0}%'", txt_searchby.Text);
                metroGrid1.DataSource = DV;

            }
            else if (searchCriteriaCombo.SelectedIndex == 1)
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = "Name like '%" + txt_searchby.Text + "%'";
                metroGrid1.DataSource = DV;

            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Diseases_code.Clear();
            Diseases_name.Clear();
            radio_Diseases_Code.Visible = false;
            radio_Diseases_name.Visible = false;
            saveBtn.Visible = true;
            updateBtn.Visible = false;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (radio_Diseases_Code.Checked == true || radio_Diseases_name.Checked == true)
            {
                if (Diseases_code.Text != "" || Diseases_name.Text != "")
                {
                    try
                    {
                        String query;
                        MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                        if (radio_Diseases_Code.Checked == true)
                        {
                            query = "update  mydb.diseases set Diseases_code=@1 where Diseases_name=@2;";
                        }
                        else
                        {
                            query = "update  mydb.diseases set Diseases_name=@2 where Diseases_code=@1;";

                        }

                        MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                        MySqlDataReader myReader;
                        myConn.Open();
                        SelectCommand.Parameters.Add(new MySqlParameter("@1", Diseases_code.Text));
                        SelectCommand.Parameters.Add(new MySqlParameter("@2", Diseases_name.Text));




                        myReader = SelectCommand.ExecuteReader();


                        while (myReader.Read()) { }
                        myConn.Close();
                        MetroMessageBox.Show(this, "\n" + "Record Has Been Updated", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.metroGrid1.DataSource = null;
                        metroGrid1.Refresh();
                        metroGrid1.DataSource = null;
                        metroGrid1.Rows.Clear();
                        Diseases_code.Clear();
                        Diseases_name.Clear();

                        radio_Diseases_Code.Visible = false;
                        radio_Diseases_name.Visible = false;
                        dgv();
                    }

                    catch (Exception ex)
                    {
                        MetroMessageBox.Show(this, "\n" + "Record Could Not Be Updated", ":/", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "\n" + "Please Fill Disease Code And Disease Name", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + "Please Fill Select Option First", ":/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void Diseases_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) && ch != 8)
            {

                e.Handled = true;
            }
        }

        private void radio_Diseases_Code_Click(object sender, EventArgs e)
        {
            Diseases_code.Enabled = true;
            Diseases_name.Enabled = false;
        }

        private void radio_Diseases_name_Click(object sender, EventArgs e)
        {
            Diseases_code.Enabled = false;
            Diseases_name.Enabled = true;
        }
    }
}
