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
using System.Threading; // multi-threading

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

        private string stringToUri(string s)
        {
            // TODO : improve if statement, cannot garuantee that "http(s)://" is at the beginning
            const string HTTP = "http://";
            const string HTTPS = "https://";
            string uri = s;

            if (!(s.Contains(HTTP) || s.Contains(HTTPS)))
            {
                uri = HTTPS + s;
            }

            return uri;
        }

        private void handleSearch(string s)
        {
            string url = stringToUri(s);

            HttpWebResponse res;

            try
            {
                WebRequest req = WebRequest.Create(url);
                req.Method = "GET";
                res = (HttpWebResponse)req.GetResponse();
                StreamReader data = new StreamReader(res.GetResponseStream());
                setssStatus("(200) OK", Color.Green);

                OutputDataBox.Text = data.ReadToEnd();
            }
            catch (WebException e)
            {
                Regex r = new Regex(@"(\(\d+\).+)");
                //OutputDataLabel.Text = e.Message;

                MatchCollection errStatusCode = r.Matches(e.Message);

                if (errStatusCode.Count > 0)
                {
                    ssStatus.Text = errStatusCode[0].Value;
                    ssStatus.ForeColor = Color.Red;
                } else
                {
                    ssStatus.Text = e.Message;
                    ssStatus.ForeColor = Color.Red;
                }

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
            // remove
        }

        private void bookmarks_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.Right:
                    if (!(bookmarks.SelectedNode.Equals(bookmarks.Nodes[0]) || bookmarks.SelectedNode.Equals(bookmarks.Nodes[1])))
                    {
                        nodeMenu.Show(bookmarks, bookmarks.PointToClient(MousePosition));
                    }
                    break;
            }
        }

        private void nodeMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // remove
        }

        private void setHomeNode_Click(object sender, EventArgs e)
        {
            homePage.Uri = bookmarks.SelectedNode.Text;
        }

        private void addFavouriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleBookmarks(bookmarks.SelectedNode.Text, 0);
        }

        private void deleteNode_Click(object sender, EventArgs e)
        {
            bookmarks.Nodes.Remove(bookmarks.SelectedNode);
        }

        private void handleSearchThread(string s)
        {
            Console.WriteLine(s);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine(openBatch.FileName);
            FileStream fs = File.OpenRead(openBatch.FileName);
            
            // read into mem
            byte[] raw = new byte[fs.Length];
            fs.Read(raw, 0, raw.Length);
            string s = Encoding.Default.GetString(raw);
            string[] vs = s.Split(new char[] { ',', ' ', '\n' });

            UrlRequest[] us = new UrlRequest[vs.Length];
            ThreadStart tDelagate;
            Thread[] ts = new Thread[vs.Length];

            int i = 0;
            OutputDataBox.Text = "";
            foreach (string v in vs)
            {
                us[i] = new UrlRequest(v, OutputDataBox);
                tDelagate = new ThreadStart(us[i].request);
                ts[i] = new Thread(tDelagate);
                ts[i].Start();
                i++;
            }
        }

        private void btnBatchDownload_Click(object sender, EventArgs e)
        {
            openBatch.ShowDialog();
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

        // deconstructor will be used to save/update settings file
        ~HomePage()
        {
            XmlSerializer t_xs = new XmlSerializer(typeof(HomePage));
            StreamWriter sw = new StreamWriter(HomePage.HOME_SETTINGS_XML);
            t_xs.Serialize(sw, this);
            sw.Close();
        }
    };

    public class UrlRequest
    {
        public UrlRequest(string url, TextBox t)
        {
            uri = url;
            tb = t;
        }

        public string uri { get; set; }

        //[ThreadStatic]
        public string code;
        public void request()
        {
            HttpWebResponse res;

            try
            {
                WebRequest req = WebRequest.Create(uri);
                req.Method = "GET";
                res = (HttpWebResponse)req.GetResponse();
                StreamReader data = new StreamReader(res.GetResponseStream());

                code = "(200) OK";
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                Regex r = new Regex(@"(\(\d+\).+)");
                MatchCollection errStatusCode = r.Matches(e.Message);

                if (errStatusCode.Count > 0)
                {
                    code = errStatusCode[0].Value;
                }
            }

            tb.BeginInvoke((Action)(() => tb.Text += Environment.NewLine + "[-" + uri + ": " + code + "-]"));
        }

        public string Code() { return code; }
        private TextBox tb;
    }
}
