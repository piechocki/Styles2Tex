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
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            // TODO: Plausiprüfung naming
            Close();
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
    }
}
