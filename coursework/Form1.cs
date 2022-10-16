using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// added libs
using System.Text.RegularExpressions;
using System.Net;   // WebRequest, WebResponse
using System.IO;    // StreamReader
using System.Xml;   // XmlDocument
using System.Xml.Serialization; // XmlSerializer

namespace coursework
{
    public partial class Form1 : Form
    {
        private const string URLPattern = @"((https ?:\/\/)?w{3}\.(\w+[.-]*)+\.(com|co\.uk))";
        private const string HTTPPattern = @"(https?)";
        private HomePage homePage;

        public Form1()
        {
            InitializeComponent();
            homepageLoader();
        }

        private HomePage loadHP()
        {
            XmlDocument xdoc = new XmlDocument();
            HomePage homePage;

            try
            {
                // check if "settings file"
                xdoc.Load(HomePage.HOME_SETTINGS_XML);
                XmlSerializer xs = new XmlSerializer(typeof(HomePage));
                FileStream fs = new FileStream(HomePage.HOME_SETTINGS_XML, FileMode.Open);
                homePage = (HomePage)xs.Deserialize(fs);
            }
            catch (FileNotFoundException e)
            {
                // if not found, create one
                homePage = new HomePage();
                homePage.Uri = "null";

                XmlSerializer t_xs = new XmlSerializer(typeof(HomePage));
                StreamWriter sw = new StreamWriter(HomePage.HOME_SETTINGS_XML);
                t_xs.Serialize(sw, homePage);
                sw.Close();

                // no need to deserialise it
            }


            return homePage;
        }

        private void homepageLoader()
        {
            homePage = loadHP();
            handleSearch(homePage.useSetURI());
        }

        private void SearchbarButton_Click(object sender, EventArgs e)
        {
            handleSearch();
        }

        private void handleSearch(String s)
        {
            string url = s;

            HttpWebResponse res;

            try
            {
                WebRequest req = WebRequest.Create(url);
                req.Method = "GET";
                res = (HttpWebResponse)req.GetResponse();
                StreamReader data = new StreamReader(res.GetResponseStream());
                setssStatus("200 (OK)", Color.Green);

                OutputDataBox.Text = data.ReadToEnd();
            }
            catch (WebException e)
            {
                Regex r = new Regex(@"(\(\d+\).+)");
                //OutputDataLabel.Text = e.Message;

                MatchCollection errStatusCode = r.Matches(e.Message);

                ssStatus.Text = errStatusCode[0].Value;
                ssStatus.ForeColor = Color.Red;

                OutputDataBox.Text = "ERR";
            }

            handleBookmarks(s);
        }
        private void handleSearch()
        {
            handleSearch(searchbar.Text);
        }

        private void setssStatus(string s, Color c)
        {
            ssStatus.Text = s;
            ssStatus.ForeColor = c;
        }

        private void handleBookmarks(string s, int index = 1)
        {
            bookmarks.Nodes[index].Nodes.Add(s);
        }


        private void bookmarks_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    if (bookmarks.SelectedNode.Text.Substring(0, 4).Equals("http"))
                    {
                        searchbar.Text = bookmarks.SelectedNode.Text;
                        handleSearch();
                    }
                    break;
                case MouseButtons.Right:
                    NodeMenu uc = new NodeMenu();
                    uc.Show();
                    // MenuStrip.Show();
                    break;
            }
        }

        private void btnBookmarsAddFavourite_MouseUp(object sender, MouseEventArgs e)
        {
            if (searchbar.Text.Equals(""))
            {
                return;
            }

            handleBookmarks(searchbar.Text, 0);
        }

        private void btnBookmarksDelete_MouseUp(object sender, MouseEventArgs e)
        {
            if (bookmarks.SelectedNode == null || bookmarks.SelectedNode == bookmarks.Nodes[0] || bookmarks.SelectedNode == bookmarks.Nodes[1])
            {
                return;
            }

            bookmarks.SelectedNode.Remove();
        }

        public void deleteSelectedNode()
        {
            if (bookmarks.SelectedNode == null || bookmarks.SelectedNode == bookmarks.Nodes[0] || bookmarks.SelectedNode == bookmarks.Nodes[1])
            {
                return;
            }

            bookmarks.SelectedNode.Remove();
        }

        private void searchbar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                handleSearch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handleSearch(homePage.useSetURI());
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }

    [Serializable]
    public class HomePage
    {
        public string Uri { get; set; }
        public const string default_uri = "https://www.hw.ac.uk/";
        public const string HOME_SETTINGS_XML = "home.settings.xml";

        public string useSetURI()
        {
            if (Uri == null || Uri.Equals("null"))
            {
                return default_uri;
            }

            return Uri;
        }
    };
}
