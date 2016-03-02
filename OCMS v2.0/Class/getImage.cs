using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2._0.Class
{
    class getImage:connectionDb
    {
        Image img=null;
        public Image get_pic(string query)
        {
            try
            {
                MySqlCommand SelectCommand = new MySqlCommand(query, openConnection());

                MySqlDataReader myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    byte[] imgg = (byte[])(myReader["image"]);
                    if (imgg == null)
                    {
                        img = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        img = Image.FromStream(mstream);
                    }
                }
                closeConnection() ;
            }
            catch (Exception)
            {
                MessageBox.Show("do not Find Form picture");
            }
            return img;
        }
    }
}
