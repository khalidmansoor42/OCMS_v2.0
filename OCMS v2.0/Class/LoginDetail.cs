using MetroFramework;
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
        MySqlDataReader reader = null;
        connectionDb cons = new connectionDb();
        password pass = new Class.password();
        Class.ModalClass modal = new Class.ModalClass();
        //Login log = new Login();

         public string[] loginsdetail(string userName,string password)
        {
            string[] userInfo = new string[3];
            string userType = "";
            string Name = "";
            String query = "SELECT user_type,full_name,user_name,activeinactive FROM mydb.user_registration where user_name=@userName And password =@password;";
            MySqlCommand cmdEmpInfo = new MySqlCommand(query, cons.openConnection());
            cmdEmpInfo.Parameters.Add(new MySqlParameter("@userName", userName));
            cmdEmpInfo.Parameters.Add(new MySqlParameter("@password", pass.MD5Hash(password)));            
            reader = cmdEmpInfo.ExecuteReader(); //execute the reader
            if (reader.Read())
            {
                userType = reader.GetString("user_type");
                Name = reader.GetString("full_name");

                string username = reader.GetString("user_name");
                if (reader.GetBoolean("activeinactive"))
                {
                    LoginHistory(username);
                    userInfo[0] = Name;
                    userInfo[1] = userType;
                    userInfo[2] = username;
                    
                }
                else
                {
                    MessageBox.Show("your account is inactive please contact administrator");
                }
                cons.closeConnection();
            }
            else
            {
            }
            return userInfo;
           
        }
        public void LoginHistory(string username)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            String query = "insert into mydb.login_history (user_name,login,ip_address,hostName)VALUES(@userName,@dateTime,@Ip,@hostName) ;";
            MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
            SelectCommand.Parameters.Add(new MySqlParameter("@userName", username));
            SelectCommand.Parameters.Add(new MySqlParameter("@dateTime", "2016-05-02 01:05:31" ));
            SelectCommand.Parameters.Add(new MySqlParameter("@Ip", myIP));
            SelectCommand.Parameters.Add(new MySqlParameter("@hostName", hostName));
            MySqlDataReader myReader;
            myReader = SelectCommand.ExecuteReader();
            cons.closeConnection();            

        }
        public void logout(string query)
        {
            try
            {
                MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();
                cons.closeConnection();

            }
            catch (Exception)
            {
                MessageBox.Show("not insert login history");
            }

        }

    }
}
