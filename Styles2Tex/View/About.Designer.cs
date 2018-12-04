namespace Styles2Tex.View
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.L_Version = new System.Windows.Forms.Label();
            this.Ll_Github = new System.Windows.Forms.LinkLabel();
            this.Pb_Logo = new System.Windows.Forms.PictureBox();
            this.L_Title = new System.Windows.Forms.Label();
            this.Rtb_License = new System.Windows.Forms.RichTextBox();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Ll_License = new System.Windows.Forms.LinkLabel();
            this.Ll_Copyright_Logo = new System.Windows.Forms.LinkLabel();
            this.Ll_Copyright_Buttons = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // L_Version
            // 
            this.L_Version.AutoSize = true;
            this.L_Version.Location = new System.Drawing.Point(127, 56);
            this.L_Version.Name = "L_Version";
            this.L_Version.Size = new System.Drawing.Size(209, 13);
            this.L_Version.TabIndex = 1;
            this.L_Version.Text = "Version {0} — Copyright © {1} M. Piechocki";
            // 
            // Ll_Github
            // 
            this.Ll_Github.AutoSize = true;
            this.Ll_Github.LinkArea = new System.Windows.Forms.LinkArea(31, 6);
            this.Ll_Github.Location = new System.Drawing.Point(7, 101);
            this.Ll_Github.Name = "Ll_Github";
            this.Ll_Github.Size = new System.Drawing.Size(310, 17);
            this.Ll_Github.TabIndex = 2;
            this.Ll_Github.TabStop = true;
            this.Ll_Github.Text = "Get updates and report bugs on GitHub. Latest version is {0}.";
            this.Ll_Github.UseCompatibleTextRendering = true;
            this.Ll_Github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Ll_Github_LinkClicked);
            // 
            // Pb_Logo
            // 
            this.Pb_Logo.Image = global::Styles2Tex.Properties.Resources.logo;
            this.Pb_Logo.Location = new System.Drawing.Point(65, 13);
            this.Pb_Logo.Name = "Pb_Logo";
            this.Pb_Logo.Size = new System.Drawing.Size(49, 49);
            this.Pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pb_Logo.TabIndex = 3;
            this.Pb_Logo.TabStop = false;
            // 
            // L_Title
            // 
            this.L_Title.AutoSize = true;
            this.L_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Title.Location = new System.Drawing.Point(125, 23);
            this.L_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_Title.Name = "L_Title";
            this.L_Title.Size = new System.Drawing.Size(142, 29);
            this.L_Title.TabIndex = 5;
            this.L_Title.Text = "Styles2Tex";
            // 
            // Rtb_License
            // 
            this.Rtb_License.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Rtb_License.Font = new System.Drawing.Font("Consolas", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rtb_License.Location = new System.Drawing.Point(7, 171);
            this.Rtb_License.Margin = new System.Windows.Forms.Padding(2);
            this.Rtb_License.Name = "Rtb_License";
            this.Rtb_License.ReadOnly = true;
            this.Rtb_License.Size = new System.Drawing.Size(416, 103);
            this.Rtb_License.TabIndex = 6;
            this.Rtb_License.Text = resources.GetString("Rtb_License.Text");
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(371, 292);
            this.Btn_Ok.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(52, 22);
            this.Btn_Ok.TabIndex = 0;
            this.Btn_Ok.Text = "OK";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // Ll_License
            // 
            this.Ll_License.AutoSize = true;
            this.Ll_License.LinkArea = new System.Windows.Forms.LinkArea(33, 11);
            this.Ll_License.Location = new System.Drawing.Point(7, 152);
            this.Ll_License.Name = "Ll_License";
            this.Ll_License.Size = new System.Drawing.Size(235, 17);
            this.Ll_License.TabIndex = 9;
            this.Ll_License.TabStop = true;
            this.Ll_License.Text = "Styles2Tex is licensed under the MIT License.";
            this.Ll_License.UseCompatibleTextRendering = true;
            this.Ll_License.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Ll_License_LinkClicked);
            // 
            // Ll_Copyright_Logo
            // 
            this.Ll_Copyright_Logo.AutoSize = true;
            this.Ll_Copyright_Logo.LinkArea = new System.Windows.Forms.LinkArea(13, 7);
            this.Ll_Copyright_Logo.Location = new System.Drawing.Point(7, 135);
            this.Ll_Copyright_Logo.Name = "Ll_Copyright_Logo";
            this.Ll_Copyright_Logo.Size = new System.Drawing.Size(209, 17);
            this.Ll_Copyright_Logo.TabIndex = 10;
            this.Ll_Copyright_Logo.TabStop = true;
            this.Ll_Copyright_Logo.Text = "Logo made by Freepik from flaticon.com.";
            this.Ll_Copyright_Logo.UseCompatibleTextRendering = true;
            this.Ll_Copyright_Logo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Ll_Copyright_Logo_LinkClicked);
            // 
            // Ll_Copyright_Buttons
            // 
            this.Ll_Copyright_Buttons.AutoSize = true;
            this.Ll_Copyright_Buttons.LinkArea = new System.Windows.Forms.LinkArea(23, 6);
            this.Ll_Copyright_Buttons.Location = new System.Drawing.Point(7, 118);
            this.Ll_Copyright_Buttons.Name = "Ll_Copyright_Buttons";
            this.Ll_Copyright_Buttons.Size = new System.Drawing.Size(166, 17);
            this.Ll_Copyright_Buttons.TabIndex = 11;
            this.Ll_Copyright_Buttons.TabStop = true;
            this.Ll_Copyright_Buttons.Text = "Ribbon buttons made by Icons8.";
            this.Ll_Copyright_Buttons.UseCompatibleTextRendering = true;
            this.Ll_Copyright_Buttons.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Ll_Copyright_Buttons_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(427, 319);
            this.Controls.Add(this.Ll_Copyright_Buttons);
            this.Controls.Add(this.Ll_Copyright_Logo);
            this.Controls.Add(this.Ll_License);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Rtb_License);
            this.Controls.Add(this.L_Title);
            this.Controls.Add(this.Pb_Logo);
            this.Controls.Add(this.Ll_Github);
            this.Controls.Add(this.L_Version);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Styles2Tex";
            ((System.ComponentModel.ISupportInitialize)(this.Pb_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Version;
        private System.Windows.Forms.LinkLabel Ll_Github;
        private System.Windows.Forms.PictureBox Pb_Logo;
        private System.Windows.Forms.Label L_Title;
        private System.Windows.Forms.RichTextBox Rtb_License;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.LinkLabel Ll_License;
        private System.Windows.Forms.LinkLabel Ll_Copyright_Logo;
        private System.Windows.Forms.LinkLabel Ll_Copyright_Buttons;
    }
}