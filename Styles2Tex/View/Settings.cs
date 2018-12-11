using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Styles2Tex.View
{
    public partial class Settings : Form
    {
        public Dictionary<string, string> new_config {get;set;}

        public Settings(Dictionary<string, string> current_config)
        {
            new_config = current_config.ToDictionary(pair => pair.Key, pair => pair.Value);

            InitializeComponent();

            Cb_Italic.Checked = Convert.ToBoolean(current_config["emphasize"]);
            Cb_Labels.Checked = Convert.ToBoolean(current_config["labels"]);
            Cb_Abstract.Checked = Convert.ToBoolean(current_config["abstract"]);
            Tb_Naming.Text = current_config["naming"];

            Tt_Abstract.SetToolTip(Cb_Abstract, "First section is formatted like an abstract (numbering of section files will begin after first section)");
            Tt_Italic.SetToolTip(Cb_Italic, "Will be applied always for the whole word whether parts of it are italic");
            Tt_Labels.SetToolTip(Cb_Labels, "For every section and subsection, create a label with the same name (all in lowercases, spaces will be replaced by hyphens)");
            Tt_Naming.SetToolTip(L_Naming, "Naming pattern for output file names (always set exactly one dollar sign '$' that stands for the section number)");
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (Tb_Naming.Text.Count(c => c == '$') != 1)
            {
                MessageBox.Show("Please input exactly one dollar sign ($) in the naming pattern.", "Styles2Tex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Tb_Naming.SelectAll();
                Tb_Naming.Focus();
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }            
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cb_Abstract_CheckedChanged(object sender, EventArgs e)
        {
            new_config["abstract"] = Convert.ToBoolean(Cb_Abstract.Checked).ToString();
        }

        private void Cb_Labels_CheckedChanged(object sender, EventArgs e)
        {
            new_config["labels"] = Convert.ToBoolean(Cb_Labels.Checked).ToString();
        }

        private void Cb_Italic_CheckedChanged(object sender, EventArgs e)
        {
            new_config["emphasize"] = Convert.ToBoolean(Cb_Italic.Checked).ToString();
        }

        private void Tb_Naming_TextChanged(object sender, EventArgs e)
        {
            new_config["naming"] = Tb_Naming.Text;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
