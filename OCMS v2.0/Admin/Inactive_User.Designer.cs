namespace OCMS_v2_0.Admin
{
    partial class Inactive_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inactive_User));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.text_user_type = new System.Windows.Forms.TextBox();
            this.saveBtn = new MetroFramework.Controls.MetroButton();
            this.searchBtn = new MetroFramework.Controls.MetroButton();
            this.active = new MetroFramework.Controls.MetroRadioButton();
            this.inactive = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.text_user_name = new System.Windows.Forms.TextBox();
            this.text_Eid = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.SystemColors.Menu;
            this.metroPanel1.Controls.Add(this.text_user_type);
            this.metroPanel1.Controls.Add(this.saveBtn);
            this.metroPanel1.Controls.Add(this.searchBtn);
            this.metroPanel1.Controls.Add(this.active);
            this.metroPanel1.Controls.Add(this.inactive);
            this.metroPanel1.Controls.Add(this.metroLabel4);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.text_user_name);
            this.metroPanel1.Controls.Add(this.text_Eid);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.pictureBox4);
            this.metroPanel1.Controls.Add(this.pictureBox5);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(760, 400);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // text_user_type
            // 
            this.text_user_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.text_user_type.Location = new System.Drawing.Point(262, 160);
            this.text_user_type.Multiline = true;
            this.text_user_type.Name = "text_user_type";
            this.text_user_type.Size = new System.Drawing.Size(233, 29);
            this.text_user_type.TabIndex = 2;
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.saveBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveBtn.BackgroundImage")));
            this.saveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Location = new System.Drawing.Point(342, 310);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(64, 36);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.UseSelectable = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.Teal;
            this.searchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBtn.BackgroundImage")));
            this.searchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.Location = new System.Drawing.Point(458, 116);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(37, 29);
            this.searchBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchBtn.TabIndex = 1;
            this.searchBtn.UseCustomBackColor = true;
            this.searchBtn.UseSelectable = true;
            this.searchBtn.UseStyleColors = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // active
            // 
            this.active.AutoSize = true;
            this.active.Cursor = System.Windows.Forms.Cursors.Hand;
            this.active.Location = new System.Drawing.Point(332, 250);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(56, 15);
            this.active.TabIndex = 5;
            this.active.Text = "Active";
            this.active.UseCustomBackColor = true;
            this.active.UseSelectable = true;
            // 
            // inactive
            // 
            this.inactive.AutoSize = true;
            this.inactive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inactive.Location = new System.Drawing.Point(262, 250);
            this.inactive.Name = "inactive";
            this.inactive.Size = new System.Drawing.Size(64, 15);
            this.inactive.TabIndex = 4;
            this.inactive.Text = "Inactive";
            this.inactive.UseCustomBackColor = true;
            this.inactive.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(181, 204);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(75, 19);
            this.metroLabel4.TabIndex = 181;
            this.metroLabel4.Text = "User Name";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(190, 160);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(66, 19);
            this.metroLabel3.TabIndex = 180;
            this.metroLabel3.Text = "User Type";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // text_user_name
            // 
            this.text_user_name.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.text_user_name.Location = new System.Drawing.Point(262, 204);
            this.text_user_name.Multiline = true;
            this.text_user_name.Name = "text_user_name";
            this.text_user_name.Size = new System.Drawing.Size(233, 29);
            this.text_user_name.TabIndex = 3;
            // 
            // text_Eid
            // 
            this.text_Eid.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.text_Eid.Location = new System.Drawing.Point(262, 116);
            this.text_Eid.Multiline = true;
            this.text_Eid.Name = "text_Eid";
            this.text_Eid.Size = new System.Drawing.Size(200, 29);
            this.text_Eid.TabIndex = 0;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(173, 116);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(83, 19);
            this.metroLabel2.TabIndex = 176;
            this.metroLabel2.Text = "Employee ID";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(304, 16);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(114, 25);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Login Details";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox4.Location = new System.Drawing.Point(9, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(751, 52);
            this.pictureBox4.TabIndex = 174;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 52);
            this.pictureBox5.TabIndex = 175;
            this.pictureBox5.TabStop = false;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // Inactive_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.Name = "Inactive_User";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Manage Users";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private MetroFramework.Controls.MetroRadioButton active;
        private MetroFramework.Controls.MetroRadioButton inactive;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.TextBox text_user_name;
        private System.Windows.Forms.TextBox text_Eid;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton searchBtn;
        private MetroFramework.Controls.MetroButton saveBtn;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.TextBox text_user_type;
    }
}