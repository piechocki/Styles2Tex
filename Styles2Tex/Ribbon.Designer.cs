using System;
using Microsoft.Office.Tools.Ribbon;

namespace Styles2Tex
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grp_styles2tex = this.Factory.CreateRibbonGroup();
            this.Btn_New_Simple = this.Factory.CreateRibbonButton();
            this.Btn_New_Multiple = this.Factory.CreateRibbonButton();
            this.Btn_Supported_Styles = this.Factory.CreateRibbonButton();
            this.Btn_Save_Directory = this.Factory.CreateRibbonButton();
            this.Btn_Overwrite = this.Factory.CreateRibbonButton();
            this.Dd_Encoding = this.Factory.CreateRibbonDropDown();
            this.Btn_More_Settings = this.Factory.CreateRibbonButton();
            this.Btn_About = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grp_styles2tex.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grp_styles2tex);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // grp_styles2tex
            // 
            this.grp_styles2tex.Items.Add(this.Btn_New_Simple);
            this.grp_styles2tex.Items.Add(this.Btn_New_Multiple);
            this.grp_styles2tex.Items.Add(this.Btn_Supported_Styles);
            this.grp_styles2tex.Items.Add(this.Btn_Save_Directory);
            this.grp_styles2tex.Items.Add(this.Btn_Overwrite);
            this.grp_styles2tex.Items.Add(this.Dd_Encoding);
            this.grp_styles2tex.Items.Add(this.Btn_More_Settings);
            this.grp_styles2tex.Items.Add(this.Btn_About);
            this.grp_styles2tex.Label = "Styles2Tex";
            this.grp_styles2tex.Name = "grp_styles2tex";
            // 
            // Btn_New_Simple
            // 
            this.Btn_New_Simple.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_New_Simple.Image = global::Styles2Tex.Properties.Resources.new_simple;
            this.Btn_New_Simple.Label = "New tex file";
            this.Btn_New_Simple.Name = "Btn_New_Simple";
            this.Btn_New_Simple.ShowImage = true;
            this.Btn_New_Simple.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_New_Simple_Click);
            // 
            // Btn_New_Multiple
            // 
            this.Btn_New_Multiple.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Btn_New_Multiple.Image = global::Styles2Tex.Properties.Resources.new_multiple;
            this.Btn_New_Multiple.Label = "New tex files";
            this.Btn_New_Multiple.Name = "Btn_New_Multiple";
            this.Btn_New_Multiple.ShowImage = true;
            this.Btn_New_Multiple.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_New_Multiple_Click);
            // 
            // Btn_Supported_Styles
            // 
            this.Btn_Supported_Styles.Image = global::Styles2Tex.Properties.Resources.styles;
            this.Btn_Supported_Styles.Label = "Supported styles";
            this.Btn_Supported_Styles.Name = "Btn_Supported_Styles";
            this.Btn_Supported_Styles.ShowImage = true;
            this.Btn_Supported_Styles.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_Supported_Styles_Click);
            // 
            // Btn_Save_Directory
            // 
            this.Btn_Save_Directory.Image = global::Styles2Tex.Properties.Resources.save_directory;
            this.Btn_Save_Directory.Label = "Save directory";
            this.Btn_Save_Directory.Name = "Btn_Save_Directory";
            this.Btn_Save_Directory.ShowImage = true;
            this.Btn_Save_Directory.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_Save_Directory_Click);
            // 
            // Btn_Overwrite
            // 
            this.Btn_Overwrite.Image = global::Styles2Tex.Properties.Resources.overwrite_on;
            this.Btn_Overwrite.Label = "Overwrite";
            this.Btn_Overwrite.Name = "Btn_Overwrite";
            this.Btn_Overwrite.ShowImage = true;
            this.Btn_Overwrite.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_Overwrite_Click);
            // 
            // Dd_Encoding
            // 
            this.Dd_Encoding.Image = global::Styles2Tex.Properties.Resources.encoding;
            this.Dd_Encoding.Label = "Encoding";
            this.Dd_Encoding.Name = "Dd_Encoding";
            this.Dd_Encoding.ShowImage = true;
            this.Dd_Encoding.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Dd_Encoding_SelectionChanged);
            // 
            // Btn_More_Settings
            // 
            this.Btn_More_Settings.Image = global::Styles2Tex.Properties.Resources.more_settings;
            this.Btn_More_Settings.Label = "More settings";
            this.Btn_More_Settings.Name = "Btn_More_Settings";
            this.Btn_More_Settings.ShowImage = true;
            this.Btn_More_Settings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_More_Settings_Click);
            // 
            // Btn_About
            // 
            this.Btn_About.Image = global::Styles2Tex.Properties.Resources.about;
            this.Btn_About.Label = "About";
            this.Btn_About.Name = "Btn_About";
            this.Btn_About.ShowImage = true;
            this.Btn_About.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Btn_About_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grp_styles2tex.ResumeLayout(false);
            this.grp_styles2tex.PerformLayout();
            this.ResumeLayout(false);

        }

      

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grp_styles2tex;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_New_Simple;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_New_Multiple;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_More_Settings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_About;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Supported_Styles;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Save_Directory;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Btn_Overwrite;
        internal RibbonDropDown Dd_Encoding;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
