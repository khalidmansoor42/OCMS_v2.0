namespace OCMS_v2_0.General
{
    partial class changePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changePassword));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.wrongPic = new System.Windows.Forms.PictureBox();
            this.rightPic = new System.Windows.Forms.PictureBox();
            this.visibelPassBtn = new MetroFramework.Controls.MetroButton();
            this.updateBtn = new MetroFramework.Controls.MetroButton();
            this.Conform_passLabel = new MetroFramework.Controls.MetroLabel();
            this.Conform_pass = new MetroFramework.Controls.MetroTextBox();
            this.new_passLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.new_pass = new MetroFramework.Controls.MetroTextBox();
            this.Previous_pass = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wrongPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.SystemColors.Menu;
            this.metroPanel1.Controls.Add(this.wrongPic);
            this.metroPanel1.Controls.Add(this.rightPic);
            this.metroPanel1.Controls.Add(this.visibelPassBtn);
            this.metroPanel1.Controls.Add(this.updateBtn);
            this.metroPanel1.Controls.Add(this.Conform_passLabel);
            this.metroPanel1.Controls.Add(this.Conform_pass);
            this.metroPanel1.Controls.Add(this.new_passLabel);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.new_pass);
            this.metroPanel1.Controls.Add(this.Previous_pass);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 96);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(754, 361);
            this.metroPanel1.TabIndex = 187;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // wrongPic
            // 
            this.wrongPic.Image = ((System.Drawing.Image)(resources.GetObject("wrongPic.Image")));
            this.wrongPic.Location = new System.Drawing.Point(513, 168);
            this.wrongPic.Name = "wrongPic";
            this.wrongPic.Size = new System.Drawing.Size(24, 24);
            this.wrongPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.wrongPic.TabIndex = 189;
            this.wrongPic.TabStop = false;
            this.wrongPic.Visible = false;
            // 
            // rightPic
            // 
            this.rightPic.Image = ((System.Drawing.Image)(resources.GetObject("rightPic.Image")));
            this.rightPic.Location = new System.Drawing.Point(513, 168);
            this.rightPic.Name = "rightPic";
            this.rightPic.Size = new System.Drawing.Size(24, 24);
            this.rightPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rightPic.TabIndex = 188;
            this.rightPic.TabStop = false;
            this.rightPic.Visible = false;
            // 
            // visibelPassBtn
            // 
            this.visibelPassBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.visibelPassBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("visibelPassBtn.BackgroundImage")));
            this.visibelPassBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.visibelPassBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.visibelPassBtn.Location = new System.Drawing.Point(474, 168);
            this.visibelPassBtn.Name = "visibelPassBtn";
            this.visibelPassBtn.Size = new System.Drawing.Size(33, 23);
            this.visibelPassBtn.TabIndex = 3;
            this.visibelPassBtn.UseSelectable = true;
            this.visibelPassBtn.Click += new System.EventHandler(this.visibelPassBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.updateBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("updateBtn.BackgroundImage")));
            this.updateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateBtn.Location = new System.Drawing.Point(262, 197);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(71, 31);
            this.updateBtn.TabIndex = 4;
            this.updateBtn.UseSelectable = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // Conform_passLabel
            // 
            this.Conform_passLabel.AutoSize = true;
            this.Conform_passLabel.Location = new System.Drawing.Point(111, 168);
            this.Conform_passLabel.Name = "Conform_passLabel";
            this.Conform_passLabel.Size = new System.Drawing.Size(145, 19);
            this.Conform_passLabel.TabIndex = 16;
            this.Conform_passLabel.Text = "Confirm New Password";
            this.Conform_passLabel.UseCustomBackColor = true;
            // 
            // Conform_pass
            // 
            // 
            // 
            // 
            this.Conform_pass.CustomButton.Image = null;
            this.Conform_pass.CustomButton.Location = new System.Drawing.Point(223, 1);
            this.Conform_pass.CustomButton.Name = "";
            this.Conform_pass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.Conform_pass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Conform_pass.CustomButton.TabIndex = 1;
            this.Conform_pass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Conform_pass.CustomButton.UseSelectable = true;
            this.Conform_pass.CustomButton.Visible = false;
            this.Conform_pass.Lines = new string[0];
            this.Conform_pass.Location = new System.Drawing.Point(262, 168);
            this.Conform_pass.MaxLength = 20;
            this.Conform_pass.Name = "Conform_pass";
            this.Conform_pass.PasswordChar = '*';
            this.Conform_pass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Conform_pass.SelectedText = "";
            this.Conform_pass.SelectionLength = 0;
            this.Conform_pass.SelectionStart = 0;
            this.Conform_pass.Size = new System.Drawing.Size(245, 23);
            this.Conform_pass.TabIndex = 2;
            this.Conform_pass.UseSelectable = true;
            this.Conform_pass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Conform_pass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Conform_pass.TextChanged += new System.EventHandler(this.metroTextBox6_TextChanged);
            this.Conform_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.metroTextBox6_KeyPress);
            // 
            // new_passLabel
            // 
            this.new_passLabel.AutoSize = true;
            this.new_passLabel.Location = new System.Drawing.Point(163, 127);
            this.new_passLabel.Name = "new_passLabel";
            this.new_passLabel.Size = new System.Drawing.Size(93, 19);
            this.new_passLabel.TabIndex = 14;
            this.new_passLabel.Text = "New Password";
            this.new_passLabel.UseCustomBackColor = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(145, 87);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(111, 19);
            this.metroLabel5.TabIndex = 13;
            this.metroLabel5.Text = "Current Password";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // new_pass
            // 
            // 
            // 
            // 
            this.new_pass.CustomButton.Image = null;
            this.new_pass.CustomButton.Location = new System.Drawing.Point(223, 1);
            this.new_pass.CustomButton.Name = "";
            this.new_pass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.new_pass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.new_pass.CustomButton.TabIndex = 1;
            this.new_pass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.new_pass.CustomButton.UseSelectable = true;
            this.new_pass.CustomButton.Visible = false;
            this.new_pass.Lines = new string[0];
            this.new_pass.Location = new System.Drawing.Point(262, 127);
            this.new_pass.MaxLength = 20;
            this.new_pass.Name = "new_pass";
            this.new_pass.PasswordChar = '*';
            this.new_pass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.new_pass.SelectedText = "";
            this.new_pass.SelectionLength = 0;
            this.new_pass.SelectionStart = 0;
            this.new_pass.Size = new System.Drawing.Size(245, 23);
            this.new_pass.TabIndex = 1;
            this.new_pass.UseSelectable = true;
            this.new_pass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.new_pass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.new_pass.TextChanged += new System.EventHandler(this.metroTextBox5_TextChanged);
            // 
            // Previous_pass
            // 
            // 
            // 
            // 
            this.Previous_pass.CustomButton.Image = null;
            this.Previous_pass.CustomButton.Location = new System.Drawing.Point(223, 1);
            this.Previous_pass.CustomButton.Name = "";
            this.Previous_pass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.Previous_pass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Previous_pass.CustomButton.TabIndex = 1;
            this.Previous_pass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Previous_pass.CustomButton.UseSelectable = true;
            this.Previous_pass.CustomButton.Visible = false;
            this.Previous_pass.Lines = new string[0];
            this.Previous_pass.Location = new System.Drawing.Point(262, 87);
            this.Previous_pass.MaxLength = 32767;
            this.Previous_pass.Name = "Previous_pass";
            this.Previous_pass.PasswordChar = '\0';
            this.Previous_pass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Previous_pass.SelectedText = "";
            this.Previous_pass.SelectionLength = 0;
            this.Previous_pass.SelectionStart = 0;
            this.Previous_pass.Size = new System.Drawing.Size(245, 23);
            this.Previous_pass.TabIndex = 0;
            this.Previous_pass.UseSelectable = true;
            this.Previous_pass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Previous_pass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox4.Location = new System.Drawing.Point(39, 63);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(738, 39);
            this.pictureBox4.TabIndex = 185;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox5.Location = new System.Drawing.Point(23, 63);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(18, 39);
            this.pictureBox5.TabIndex = 186;
            this.pictureBox5.TabStop = false;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // changePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.MaximizeBox = false;
            this.Name = "changePassword";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Change Password";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wrongPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel Conform_passLabel;
        private MetroFramework.Controls.MetroTextBox Conform_pass;
        private MetroFramework.Controls.MetroLabel new_passLabel;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox new_pass;
        private MetroFramework.Controls.MetroTextBox Previous_pass;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private MetroFramework.Controls.MetroButton updateBtn;
        private MetroFramework.Controls.MetroButton visibelPassBtn;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.PictureBox wrongPic;
        private System.Windows.Forms.PictureBox rightPic;
    }
}