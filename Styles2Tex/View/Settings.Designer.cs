namespace Styles2Tex.View
{
    partial class Settings
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
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Cb_Italic = new System.Windows.Forms.CheckBox();
            this.Cb_Abstract = new System.Windows.Forms.CheckBox();
            this.Cb_Labels = new System.Windows.Forms.CheckBox();
            this.Gb_Beta = new System.Windows.Forms.GroupBox();
            this.Tb_Naming = new System.Windows.Forms.TextBox();
            this.L_Naming = new System.Windows.Forms.Label();
            this.Gb_Beta.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Save
            // 
            this.Btn_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_Save.Location = new System.Drawing.Point(377, 443);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(136, 38);
            this.Btn_Save.TabIndex = 0;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(519, 443);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(136, 38);
            this.Btn_Cancel.TabIndex = 1;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Cb_Italic
            // 
            this.Cb_Italic.AutoSize = true;
            this.Cb_Italic.Location = new System.Drawing.Point(26, 44);
            this.Cb_Italic.Name = "Cb_Italic";
            this.Cb_Italic.Size = new System.Drawing.Size(321, 29);
            this.Cb_Italic.TabIndex = 2;
            this.Cb_Italic.Text = "Emphasize italic formatted words";
            this.Cb_Italic.UseVisualStyleBackColor = true;
            this.Cb_Italic.CheckedChanged += new System.EventHandler(this.Cb_Italic_CheckedChanged);
            // 
            // Cb_Abstract
            // 
            this.Cb_Abstract.AutoSize = true;
            this.Cb_Abstract.Location = new System.Drawing.Point(53, 39);
            this.Cb_Abstract.Name = "Cb_Abstract";
            this.Cb_Abstract.Size = new System.Drawing.Size(316, 29);
            this.Cb_Abstract.TabIndex = 3;
            this.Cb_Abstract.Text = "Create abstract from first section";
            this.Cb_Abstract.UseVisualStyleBackColor = true;
            this.Cb_Abstract.CheckedChanged += new System.EventHandler(this.Cb_Abstract_CheckedChanged);
            // 
            // Cb_Labels
            // 
            this.Cb_Labels.AutoSize = true;
            this.Cb_Labels.Location = new System.Drawing.Point(53, 87);
            this.Cb_Labels.Name = "Cb_Labels";
            this.Cb_Labels.Size = new System.Drawing.Size(281, 29);
            this.Cb_Labels.TabIndex = 4;
            this.Cb_Labels.Text = "Create labels from headings";
            this.Cb_Labels.UseVisualStyleBackColor = true;
            this.Cb_Labels.CheckedChanged += new System.EventHandler(this.Cb_Labels_CheckedChanged);
            // 
            // Gb_Beta
            // 
            this.Gb_Beta.Controls.Add(this.Cb_Italic);
            this.Gb_Beta.Location = new System.Drawing.Point(27, 194);
            this.Gb_Beta.Name = "Gb_Beta";
            this.Gb_Beta.Size = new System.Drawing.Size(628, 111);
            this.Gb_Beta.TabIndex = 5;
            this.Gb_Beta.TabStop = false;
            this.Gb_Beta.Text = "Beta functions";
            // 
            // Tb_Naming
            // 
            this.Tb_Naming.Location = new System.Drawing.Point(459, 134);
            this.Tb_Naming.Name = "Tb_Naming";
            this.Tb_Naming.Size = new System.Drawing.Size(186, 29);
            this.Tb_Naming.TabIndex = 6;
            this.Tb_Naming.TextChanged += new System.EventHandler(this.Tb_Naming_TextChanged);
            // 
            // L_Naming
            // 
            this.L_Naming.AutoSize = true;
            this.L_Naming.Location = new System.Drawing.Point(48, 137);
            this.L_Naming.Name = "L_Naming";
            this.L_Naming.Size = new System.Drawing.Size(405, 25);
            this.L_Naming.TabIndex = 7;
            this.L_Naming.Text = "Name tex files ($ represents section number):";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 512);
            this.Controls.Add(this.L_Naming);
            this.Controls.Add(this.Tb_Naming);
            this.Controls.Add(this.Gb_Beta);
            this.Controls.Add(this.Cb_Labels);
            this.Controls.Add(this.Cb_Abstract);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Save);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Gb_Beta.ResumeLayout(false);
            this.Gb_Beta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.CheckBox Cb_Italic;
        private System.Windows.Forms.CheckBox Cb_Abstract;
        private System.Windows.Forms.CheckBox Cb_Labels;
        private System.Windows.Forms.GroupBox Gb_Beta;
        private System.Windows.Forms.TextBox Tb_Naming;
        private System.Windows.Forms.Label L_Naming;
    }
}