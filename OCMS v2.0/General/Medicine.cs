﻿using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2_0.General
{
    public partial class Medicine : MetroForm
    {
        public Medicine()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton4, "Save");
        }
    }
}
