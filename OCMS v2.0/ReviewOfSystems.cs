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

namespace OCMS_v2._0
{
    public partial class ReviewOfSystems : MetroForm
    {
        public ReviewOfSystems()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton3, "Update");
            metroToolTip1.SetToolTip(metroButton4, "Save");
            metroToolTip1.SetToolTip(metroButton6, "Next Form");
            metroToolTip1.SetToolTip(metroButton1, "Previous Form");
        }
    }
}