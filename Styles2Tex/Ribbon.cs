using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Tools.Ribbon;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Text;
using Styles2Tex.View;

namespace Styles2Tex
{
    public partial class Ribbon
    {
        Microsoft.Office.Interop.Word.Application word;
        StylesParser sp;
        Dictionary<string, string> config;
        static string config_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Styles2Tex\\settings.xml");
        // TODO: implement more config elements - encoding, labels, filenames, abstract
        readonly Dictionary<string, string> default_config = new Dictionary<string, string>() {
            { "overwrite", "False" },
            { "save_directory", "" },
            { "encoding", "" }
        };

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            // instantiate word app and parser
            word = Globals.ThisAddIn.Application;
            sp = new StylesParser();
            // load config (if there is no config or an error occurs while loading, default_config will be returned
            config = Load_Config();
            // save config (e.g. because the config file was missing before and is instantiated now)
            Save_Config();
            // load overwrite button settings and encoding dropdown entries
            Load_Btn_Overwrite();
            Load_Dd_Encoding();
        }

        private void Btn_New_Simple_Click(object sender, RibbonControlEventArgs e)
        {
            sp.Convert(word, config);
        }

        private void Btn_New_Multiple_Click(object sender, RibbonControlEventArgs e)
        {
            return;
        }

        private void Btn_About_Click(object sender, RibbonControlEventArgs e)
        {
            About about = new View.About();
            about.Show();
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
            return;
        }

        private Dictionary<string, string> Load_Config()
        {
            if (!File.Exists(config_path))
            {
                return Get_Dictionary_Copy(default_config);
            }
            else
            {
                string xml = File.ReadAllText(config_path);
                XElement rootElement = XElement.Parse(xml);
                Dictionary<string, string> config_from_file = Get_Dictionary_Copy(default_config);
                try
                {
                    foreach (var el in rootElement.Elements())
                    {
                        Validate_Settings(el);
                        config_from_file[el.Name.LocalName] = el.Value;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format("The settings of the Styles2Tex addin could not be loaded. Reason: {0}\n\nThe addin starts with default settings now.", e.Message), "Styles2Tex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return Get_Dictionary_Copy(default_config);
                }
                return config_from_file;
            }
        }

        private Dictionary<string, string> Get_Dictionary_Copy(Dictionary<string, string> dict)
        {
            return dict.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        private void Validate_Settings(XElement el)
        {
            switch (el.Name.LocalName)
            {
                case "overwrite":
                    string test_convert = Convert.ToBoolean(el.Value).ToString();
                    break;
                case "save_directory":
                    if (el.Value.Length != 0 && !Directory.Exists(el.Value))
                    {
                        Directory.CreateDirectory(el.Value);
                        Directory.Delete(el.Value);
                    }
                    break;
                case "encoding":
                    if (el.Value.Length != 0)
                    {
                        string test_encoding = Get_Encodings()[el.Value];
                    }
                    break;
            }
        }
        
        private void Btn_Save_Directory_Click(object sender, RibbonControlEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = config["save_directory"];
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK &&
                    !string.IsNullOrWhiteSpace(fbd.SelectedPath) &&
                    fbd.SelectedPath != config["save_directory"])
                {
                    config["save_directory"] = fbd.SelectedPath;
                    Save_Config();
                }
            }
        }

        private void Save_Config()
        {
            Directory.CreateDirectory(new FileInfo(config_path).Directory.FullName);
            XElement el = new XElement("root", config.Select(kv => new XElement(kv.Key, kv.Value)));
            try
            {
                el.Save(config_path);
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(string.Format("Error while saving the config: {0}", e));
#endif
            }
        }

        private void Dd_Encoding_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            config["encoding"] = Dd_Encoding.SelectedItem.Label == "" ? "" : Dd_Encoding.SelectedItem.Tag.ToString();
            Save_Config();
        }

        private void Load_Dd_Encoding()
        {
            Dd_Encoding.Items.Clear();
            Dictionary<string, string> encodings = Get_Encodings();
            foreach (KeyValuePair<string, string> encoding in encodings)
            {
                RibbonDropDownItem ddi = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
                ddi.Label = encoding.Value;
                ddi.Tag = encoding.Key;
                Dd_Encoding.Items.Add(ddi);
            }
            RibbonDropDownItem selected_encoding = Dd_Encoding.Items.FirstOrDefault(x => x.Tag.ToString() == config["encoding"]);
            if (config["encoding"] != "" && selected_encoding != null)
            {
                Dd_Encoding.SelectedItem = selected_encoding;
            }
            else
            {
                // select empty item from dropdown if encoding is not set yet
                Dd_Encoding.SelectedItem = Dd_Encoding.Items.First(x => x.Tag.ToString() == "null");
            }
        }

        private Dictionary<string, string> Get_Encodings()
        {
            Dictionary<string, string> encodings = new Dictionary<string, string>();
            EncodingInfo[] eis = Encoding.GetEncodings();
            encodings.Add("null", "");
            foreach (EncodingInfo ei in eis)
            {
                if (!encodings.ContainsKey(ei.Name))
                {
                    encodings.Add(ei.Name, ei.DisplayName);
                }                    
            }
            encodings = encodings.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return encodings;
        }

        private void Btn_Supported_Styles_Click(object sender, RibbonControlEventArgs e)
        {
            List<string> supported_styles = sp.Get_Local_Names(word.ActiveDocument).Values.ToList();
            StringBuilder message = new StringBuilder();
            message.AppendLine("Currently the following built-in styles are supported already:\r");
            foreach (string supported_style in supported_styles)
            {
                message.Append("  - ").AppendLine(supported_style);
            }
            MessageBox.Show(message.ToString(), "Styles2Tex", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
