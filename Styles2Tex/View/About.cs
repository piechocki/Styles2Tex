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

namespace Styles2Tex.View
{
    public partial class About : Form
    {
        string latest_release = "1.0.0.1";
        public About()
        {
            InitializeComponent();
            L_Version.Text = string.Format(L_Version.Text, Get_Version_Number(), DateTime.Now.Year);
            Ll_Github.Text = string.Format(Ll_Github.Text, latest_release);
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

        private async void Get_Latest_ReleaseAsync()
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;            

            string query = File.OpenText("C:\\Users\\MartinPiechocki\\Documents\\GitHub\\Styles2Tex\\Styles2Tex\\Resources\\Get_Latest_Release.json").ReadToEnd();
            string token = Get_Token();

            // Create the HttpContent for the form to be posted.
            FormUrlEncodedContent requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("-H", "\"Authorization: bearer " + token + "\""),
                new KeyValuePair<string, string>("-X", "POST"),
                new KeyValuePair<string, string>("-d", "\"{\"query\": \"" + query + "\"}")
            });

            // Get the response.
            HttpResponseMessage response = await client.PostAsync("https://api.github.com/graphql", requestContent);

            // Get the response content.
            HttpContent responseContent = response.Content;

            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                latest_release = await reader.ReadToEndAsync();
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
