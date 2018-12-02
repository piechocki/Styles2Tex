using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Styles2Tex.View
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            L_Version.Text = string.Format(L_Version.Text, Get_Version_Number(), DateTime.Now.Year);
        }

        private string Get_Version_Number()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        private void Ll_Github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/piechocki/Styles2Tex");
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Ll_License_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://opensource.org/licenses/MIT");        
        }

        private void Ll_Copyright_Logo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.com/authors/freepik");
        }

        private void Ll_Copyright_Buttons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://icons8.com/");
        }
    }
}
