using MetroFramework.Forms;
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
    public partial class User_Registration : MetroForm
    {
        public User_Registration()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton2, "Search User");
            metroToolTip1.SetToolTip(metroButton7, "Clear");
            metroToolTip1.SetToolTip(metroButton4, "Save");
        }
    }
}
