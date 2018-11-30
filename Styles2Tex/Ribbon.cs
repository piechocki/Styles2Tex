using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Tools.Ribbon;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;

namespace Styles2Tex
{
    public partial class Ribbon
    {
        Microsoft.Office.Interop.Word.Application word;
        StylesParser sp;
        Dictionary<string, string> config;
        static string config_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Styles2Tex\\settings.xml");
        // TODO: implement more config elements - encoding, labels, filenames, abstract
        static Dictionary<string, string> default_config = new Dictionary<string, string>() {
            { "overwrite", "true" },
            { "save_directory", "" }
        };

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            // initialise word app and parser
            word = Globals.ThisAddIn.Application;
            sp = new StylesParser();
            // load config
            config = Load_Config();
            // load button
            Load_Btn_Overwrite();
        }

        private void Btn_New_Simple_Click(object sender, RibbonControlEventArgs e)
        {
            sp.Convert(word, config);
        }

        private void Btn_New_Multiple_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void Btn_About_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/piechocki/Styles2Tex");
        }

        private void Load_Btn_Overwrite()
        {
            if (Convert.ToBoolean(config["overwrite"]))
            {
                Btn_Overwrite.Image = Properties.Resources.overwrite_on;
            }
            else
            {
                Btn_Overwrite.Image = Properties.Resources.overwrite_off;
            }
        }

        private void Btn_Overwrite_Click(object sender, RibbonControlEventArgs e)
        {
            config["overwrite"] = (!Convert.ToBoolean(config["overwrite"])).ToString();
            Load_Btn_Overwrite();
            Save_Config();
        }

        private void Btn_More_Settings_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private Dictionary<string, string> Load_Config()
        {
            if (!File.Exists(config_path))
            {
                config = default_config;
                Save_Config();
            }
            else
            {
                string xml = File.ReadAllText(config_path);
                XElement rootElement = XElement.Parse(xml);
                config = default_config;
                try
                {
                    foreach (var el in rootElement.Elements())
                    {
                        config[el.Name.LocalName] = el.Value;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format("The settings of the Styles2Tex addin could not be loaded. Reason: {0} \n\nThe addin starts with default settings now.", e.Message), "Error");
                    Save_Config();
                }
            }
            return config;
        }

        private void Btn_Encoding_Click(object sender, RibbonControlEventArgs e)
        {
            return;
        }
        
        private void Btn_Save_Directory_Click(object sender, RibbonControlEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = config["save_directory"];
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (fbd.SelectedPath != config["save_directory"])
                    {
                        config["save_directory"] = fbd.SelectedPath;
                        Save_Config();
                    }
                }
            }
        }

        private void Btn_Styles_Click(object sender, RibbonControlEventArgs e)
        {
            return;
        }

        private void Save_Config()
        {
            Directory.CreateDirectory(new FileInfo(config_path).Directory.FullName);
            XElement el = new XElement("root", config.Select(kv => new XElement(kv.Key, kv.Value)));
            try
            {
                el.Save(config_path);
            }
            catch (Exception)
            {

            }
        }       
    }
}
