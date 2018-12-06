using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Text;
using System.Resources;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Styles2Tex.View
{
    public partial class About : Form
    {
        Version last_release;
        Version this_version;

        public About()
        {
            InitializeComponent();
            this_version = new Version(Get_Version_Number());
            L_Version.Text = string.Format(L_Version.Text, this_version, DateTime.Now.Year);
            Show();
            Update();
            Task<string> lr_task = Task.Run(() => Get_Last_Release_Async());            
            lr_task.Wait();
            string lr = lr_task.Result;
            if (lr != "")
            {
                last_release = new Version(lr);
                if (last_release.CompareTo(this_version) > 0)
                {
                    L_Update.Text = "An update is available. Last release is " + last_release + ".";
                }
                else
                {
                    L_Update.Text = "You are using the latest version already.";
                }
                Update();
            }  
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

        private async Task<string> Get_Last_Release_Async()
        {
            string query = Encoding.Default.GetString(Properties.Resources.Get_Latest_Release);
            string token = Get_Token();

            Dictionary<string, string> requestContent = new Dictionary<string, string>(){
                { "Authorization", "bearer " + token }
            };

            try
            {
                Utility.SimpleGraphQLClient client = new Utility.SimpleGraphQLClient("https://api.github.com/graphql");
                Task<JObject> result = client.ExecuteAsync(query, additionalHeaders: requestContent);
                JObject json = await result;
                return ((string)json["data"]["repository"]["tags"]["edges"][0]["node"]["name"]).Replace("v", "");
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string Get_Token()
        {
            ResourceManager rm = new ResourceManager("Styles2Tex.Properties.Token", Assembly.GetExecutingAssembly());
            byte[] b = new byte[80];
            for (int i = 0; i < 80; i++)
            {
                string key = "t" + i;
                b[i] = (byte)Int32.Parse(rm.GetString(key));
            }
            return Encoding.Unicode.GetString(b);
        }
    }
}
