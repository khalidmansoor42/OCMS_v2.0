﻿namespace OCMS_v2_0.ReportViewers
{
    partial class Patient_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient_Report));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.SystemColors.Menu;
            this.metroPanel1.Controls.Add(this.reportViewer1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 109);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1160, 471);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1160, 471);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.metroToolTip1_Popup);
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.Teal;
            this.metroButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton1.BackgroundImage")));
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.Location = new System.Drawing.Point(861, 63);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(48, 29);
            this.metroButton1.TabIndex = 204;
            this.metroButton1.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(689, 63);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(85, 19);
            this.metroLabel3.TabIndex = 203;
            this.metroLabel3.Text = "Visit Number";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(388, 63);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(88, 19);
            this.metroLabel2.TabIndex = 202;
            this.metroLabel2.Text = "Patient Name";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox2.Location = new System.Drawing.Point(307, 63);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 29);
            this.textBox2.TabIndex = 201;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(780, 63);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(75, 29);
            this.metroComboBox1.TabIndex = 200;
            this.metroComboBox1.UseSelectable = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox1.Location = new System.Drawing.Point(482, 63);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 29);
            this.textBox1.TabIndex = 199;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(237, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(64, 19);
            this.metroLabel1.TabIndex = 198;
            this.metroLabel1.Text = "Patient ID";
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.SystemColors.GrayText;
            this.metroButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton2.BackgroundImage")));
            this.metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton2.Location = new System.Drawing.Point(915, 63);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(48, 29);
            this.metroButton2.TabIndex = 205;
            this.metroButton2.UseSelectable = true;
            // 
            // Patient_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroComboBox1);
            this.MaximizeBox = false;
            this.Name = "Patient_Report";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Patient Report";
            this.Load += new System.EventHandler(this.Patient_Report_Load);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox textBox2;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}