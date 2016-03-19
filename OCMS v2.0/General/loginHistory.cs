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
    public partial class loginHistory : MetroForm
    {
        string userName = "";
        int a = 0;
        connection cons = new connection();
        Label[] Login = new Label[100];
        Label[] Logout = new Label[100];
        Label[] number = new Label[100];
        Label[] Ip_Address = new Label[100];
        Label[] HostName = new Label[100];
        public loginHistory(string user_name)
        {
            InitializeComponent();
            userName = user_name;
            login();
        }
        void login()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                string query = "SELECT * FROM mydb.login_history where mydb.login_history.user_name ='" + userName + "' order by mydb.login_history.login desc limit 0,100  ;";

                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();


                while (myReader.Read())
                {
                    number[a] = new Label();
                    number[a].Text = Convert.ToString(a + 1);
                    number[a].Size = new Size(50, 20);
                    number[a].Location = new Point(25, a * 40);
                    panel1.Controls.Add(number[a]);
                    Login[a] = new Label();
                    Login[a].Text = myReader.GetString("login");
                    Login[a].Size = new Size(100, 20);
                    Login[a].Location = new Point(100, a * 40);
                    panel1.Controls.Add(Login[a]);
                    Logout[a] = new Label();

                    string c = myReader.GetString("logout");
                    string b = "0000-00-00 00:00:00";

                    if (c == b)
                    {
                        Logout[a].Text = "";
                        Logout[a].Size = new Size(100, 20);
                        Logout[a].Location = new Point(250, a * 40);
                        panel1.Controls.Add(Logout[a]);
                    }
                    else
                    {
                        Logout[a].Text = c;
                        Logout[a].Size = new Size(200, 20);
                        Logout[a].Location = new Point(250, a * 40);
                        panel1.Controls.Add(Logout[a]);

                    }

                    Ip_Address[a] = new Label();
                    Ip_Address[a].Text = myReader.GetString("ip_address");
                    Ip_Address[a].Size = new Size(100, 20);
                    Ip_Address[a].Location = new Point(450, a * 40);
                    panel1.Controls.Add(Ip_Address[a]);

                    HostName[a] = new Label();
                    HostName[a].Text = myReader.GetString("hostName");
                    HostName[a].Size = new Size(150, 20);
                    HostName[a].Location = new Point(600, a * 40);
                    panel1.Controls.Add(HostName[a]);
                    a++;
                }

                myConn.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
