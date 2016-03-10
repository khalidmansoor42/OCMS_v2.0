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
    public partial class Clinic_Name : MetroForm
    {
        public Clinic_Name()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton4, "Save");
            metroToolTip1.SetToolTip(metroButton8, "Update");
            metroToolTip1.SetToolTip(metroButton2, "Upload Picture");
        }
    }
}
