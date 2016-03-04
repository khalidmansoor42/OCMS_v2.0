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

namespace OCMS_v2._0
{
    public partial class MyProfile : MetroForm
    {
        public MyProfile()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton1, "Browse Picture");
            metroToolTip1.SetToolTip(metroButton2, "Save");
        }
    }
}
