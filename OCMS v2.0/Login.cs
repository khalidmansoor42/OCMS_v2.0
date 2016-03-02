using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2._0
{
    public partial class Login : MetroForm
    {
        Class.LoginDetail login = new Class.LoginDetail();

        public Login()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(usernameTxt, "Enter credentials here");
            metroToolTip1.SetToolTip(passwordTxt, "Enter credentials here");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            login.loginsdetail(this.usernameTxt.Text,this.passwordTxt.Text);
        }
        
    }
}
