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
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            // initialise word app and active document
            word = Globals.ThisAddIn.Application;
            doc = word.ActiveDocument;

            // load config
            sp = new StylesParser();
            sp.load_config();
        }

        private void btn_new_simple_Click(object sender, RibbonControlEventArgs e)
        {
            sp.convert(doc);
        }

        private void btn_new_multiple_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void btn_settings_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void btn_about_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/piechocki/Styles2Tex");
        }
    }
}
