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
    public partial class Reports : MetroForm
    {
        public Reports()
        {
            InitializeComponent();
            this.FocusMe();
            textBox2.Select();
        }
    }
}
