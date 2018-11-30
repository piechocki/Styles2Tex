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
            this.btn_new_simple = this.Factory.CreateRibbonButton();
            this.btn_new_multiple = this.Factory.CreateRibbonButton();
            this.btn_styles = this.Factory.CreateRibbonButton();
            this.btn_save_directory = this.Factory.CreateRibbonButton();
            this.btn_overwrite = this.Factory.CreateRibbonButton();
            this.btn_encoding = this.Factory.CreateRibbonButton();
            this.btn_more_settings = this.Factory.CreateRibbonButton();
            this.btn_about = this.Factory.CreateRibbonButton();
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
            this.grp_styles2tex.Items.Add(this.btn_new_simple);
            this.grp_styles2tex.Items.Add(this.btn_new_multiple);
            this.grp_styles2tex.Items.Add(this.btn_styles);
            this.grp_styles2tex.Items.Add(this.btn_save_directory);
            this.grp_styles2tex.Items.Add(this.btn_overwrite);
            this.grp_styles2tex.Items.Add(this.btn_encoding);
            this.grp_styles2tex.Items.Add(this.btn_more_settings);
            this.grp_styles2tex.Items.Add(this.btn_about);
            this.grp_styles2tex.Label = "Styles2Tex";
            this.grp_styles2tex.Name = "grp_styles2tex";
            // 
            // btn_new_simple
            // 
            this.btn_new_simple.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_new_simple.Image = global::Styles2Tex.Properties.Resources.icons8_dokument_100;
            this.btn_new_simple.Label = "New tex file";
            this.btn_new_simple.Name = "btn_new_simple";
            this.btn_new_simple.ShowImage = true;
            this.btn_new_simple.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_new_simple_Click);
            // 
            // btn_new_multiple
            // 
            this.btn_new_multiple.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_new_multiple.Image = global::Styles2Tex.Properties.Resources.icons8_dokumente_100;
            this.btn_new_multiple.Label = "New tex files";
            this.btn_new_multiple.Name = "btn_new_multiple";
            this.btn_new_multiple.ShowImage = true;
            this.btn_new_multiple.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_new_multiple_Click);
            // 
            // btn_styles
            // 
            this.btn_styles.Image = global::Styles2Tex.Properties.Resources.icons8_kopfzeile_1_80;
            this.btn_styles.Label = "Styles";
            this.btn_styles.Name = "btn_styles";
            this.btn_styles.ShowImage = true;
            // 
            // btn_save_directory
            // 
            this.btn_save_directory.Image = global::Styles2Tex.Properties.Resources.icons8_live_ordner_80;
            this.btn_save_directory.Label = "Save directory";
            this.btn_save_directory.Name = "btn_save_directory";
            this.btn_save_directory.ShowImage = true;
            // 
            // btn_overwrite
            // 
            this.btn_overwrite.Image = global::Styles2Tex.Properties.Resources.icons8_schalter_an_100;
            this.btn_overwrite.Label = "Overwrite";
            this.btn_overwrite.Name = "btn_overwrite";
            this.btn_overwrite.ShowImage = true;
            this.btn_overwrite.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_overwrite_Click);
            // 
            // btn_encoding
            // 
            this.btn_encoding.Image = global::Styles2Tex.Properties.Resources.icons8_übersetzung_80;
            this.btn_encoding.Label = "Encoding";
            this.btn_encoding.Name = "btn_encoding";
            this.btn_encoding.ShowImage = true;
            // 
            // btn_more_settings
            // 
            this.btn_more_settings.Image = global::Styles2Tex.Properties.Resources.icons8_sortier_optionen_100;
            this.btn_more_settings.Label = "More settings";
            this.btn_more_settings.Name = "btn_more_settings";
            this.btn_more_settings.ShowImage = true;
            this.btn_more_settings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_more_settings_Click);
            // 
            // btn_about
            // 
            this.btn_about.Image = global::Styles2Tex.Properties.Resources.icons8_informationen_80;
            this.btn_about.Label = "About";
            this.btn_about.Name = "btn_about";
            this.btn_about.ShowImage = true;
            this.btn_about.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_about_Click);
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
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_new_simple;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_new_multiple;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_more_settings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_about;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_encoding;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_styles;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_save_directory;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_overwrite;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
