using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2._0.Class
{
    class LoginDetail
    {
        connectionDb cons = new connectionDb();
        password pass = new Class.password();
        Class.ModalClass modal = new Class.ModalClass();
        //Login log = new Login();

        public void loginsdetail(string userName,string password)
        {
            string userType = "";
            string Name = "";
            try
            {
                //cons.connectionOpen();
                //String query = "SELECT user_type,full_name,user_name,activeinactive FROM mydb.user_registration where user_name=@userName And password =@password;";
                //MySqlCommand SelectCommand = new MySqlCommand(query, cons.myConn);
                //SelectCommand.Parameters.Add(new MySqlParameter("@userName", userName));
                //SelectCommand.Parameters.Add(new MySqlParameter("@password", pass.MD5Hash(password)));
                //MySqlDataReader myReader;
                //myReader = SelectCommand.ExecuteReader();
                 MySqlConnection myConn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=''");                
                String query = "SELECT * FROM mydb.user_registration where user_name=@1 And password =@2;";
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                SelectCommand.Parameters.Add(new MySqlParameter("@1", userName));
                SelectCommand.Parameters.Add(new MySqlParameter("@2", pass.MD5Hash(password)));
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();  
                int count = 0;
                if (myReader.Read())
                {
                    userType = myReader.GetString("user_type");
                    Name = myReader.GetString("full_name");

                    string username = myReader.GetString("user_name");
                    if (myReader.GetBoolean("activeinactive"))
                    {
                        //LoginHistory(username);
                        if (userType == "Doctor")
                        {
                            //this.Hide();
                            //Doctor obj = new Doctor(name, userstype, username);
                            //obj.ShowDialog();
                            //this.Close();
                            MessageBox.Show("Doctor");

                        }
                        else if (userType == "Administrator")
                        {
                            //this.Hide();
                            //Administration obj = new Administration(name, userstype, username);
                            //obj.ShowDialog();
                            //this.Close();
                            MessageBox.Show("Admin");

                        }
                        else if (userType == "Staff")
                        {
                            //this.Hide();
                            //Receptionist obj = new Receptionist(name, userstype, username);
                            //obj.ShowDialog();
                            //this.Close();
                            MessageBox.Show("Staff");

                        }
                    }
                    else
                    {
                        MessageBox.Show("your account is inactive please contact administrator");
                    }

                }
                else if (count == 0)
                {
                    MessageBox.Show("your username and password is incorrect");
                }

                cons.connectionClose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoginHistory(string username)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST

            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            String query = "insert into mydb.login_history (user_name,login,ip_address,hostName)VALUES(@userName,@dateTime,@Ip,@hostName) ;";
            modal.insertData(query);
            modal.SelectCommand.Parameters.Add(new MySqlParameter("@userName", username));
            modal.SelectCommand.Parameters.Add(new MySqlParameter("@dateTime", DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss tt")));
            modal.SelectCommand.Parameters.Add(new MySqlParameter("@Ip", myIP));
            modal.SelectCommand.Parameters.Add(new MySqlParameter("@hostName", hostName));

        }
    }
}
