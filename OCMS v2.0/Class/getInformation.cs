using COS_ECMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCMS_v2._0.Class
{
    class getInformation
    {
        connectionDb cons = new connectionDb();
        public string[] getinfo(string query)
        {
            string[] listInfo = new string[2];
            try
            {
                MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();
                string list1 = "";
                string list = "";
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
                    list1 = "Tk: " + myReader.GetString("token_no") + "              Reg: " + myReader.GetString("patient_reg") + "              Name: " + myReader.GetString("full_name");
                    listInfo[0] = list;
                    listInfo[1] = list1;
                }
                cons.closeConnection();                                
            }
            catch (Exception)
            {
            }
            return listInfo;

        }

        public string [] information(string query)
        {
                Findage obj = new Findage();
                string[] patientInfo = new string[4];

                MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                patientInfo[0] = myReader.GetString("full_name");
                patientInfo[1] = myReader.GetString("father_name");
                patientInfo[2] = myReader.GetString("visit_no");
                patientInfo[3] = obj.calculateAge(myReader.GetDateTime("DOB"));
                }
                cons.closeConnection();
            return patientInfo;

        }
    }
}
