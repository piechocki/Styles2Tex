using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Word;

namespace Styles2Tex
{
    public partial class Ribbon
    {
        Application word;
        Document doc;
        StylesParser sp;
        bool overwrite = true;
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            // initialise word app and active document
            word = Globals.ThisAddIn.Application;

            // load config
            sp = new StylesParser();
            sp.load_config();
        }

        private void btn_new_simple_Click(object sender, RibbonControlEventArgs e)
        {
            doc = word.ActiveDocument;
            sp.convert(doc);
        }

        private void btn_new_multiple_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void btn_about_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/piechocki/Styles2Tex");
        }

        private void btn_overwrite_Click(object sender, RibbonControlEventArgs e)
        {
            if (overwrite)
            {
                btn_overwrite.Image = Properties.Resources.icons8_schalter_aus_100;
            }
            else
            {
                btn_overwrite.Image = Properties.Resources.icons8_schalter_an_100;
            }
            overwrite = !overwrite;
        }
         
        private void btn_more_settings_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
