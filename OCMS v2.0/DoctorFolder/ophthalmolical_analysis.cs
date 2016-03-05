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

namespace OCMS_v2_0.DoctorFolder
{
    public partial class ophthalmolical_analysis : MetroForm
    {
        public ophthalmolical_analysis()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton4, "Save");
            metroToolTip1.SetToolTip(metroButton7, "History");
            metroToolTip1.SetToolTip(metroButton1, "Previous Form");
            metroToolTip1.SetToolTip(metroButton6, "Next Form");
            metroToolTip1.SetToolTip(metroButton8, "Update");
        }
    }
}
