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
    public partial class add_pic : MetroForm
    {
        public add_pic()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton5, "Previous History");
            metroToolTip1.SetToolTip(metroButton2, "Browse Pictures");
            metroToolTip1.SetToolTip(metroButton4, "Save");
            metroToolTip1.SetToolTip(metroButton7, "Delete");
            metroToolTip1.SetToolTip(metroButton1, "Previous Form");
            metroToolTip1.SetToolTip(metroButton6, "Next Form");
            metroToolTip1.SetToolTip(panel1, "Double Click On A Picture To Delete");
        }
    }
}
