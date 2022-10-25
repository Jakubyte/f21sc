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
        private Settings settings;
        private TreeNode currentNode = null;

        public Form1()
        {
            InitializeComponent();
            settingsLoader();
            bookmarksLoader();
            reload(settings.useSetURI());
            homeStatusLoader(settings.useSetURI());
            currentNode = bookmarks.Nodes[1].LastNode;
        }

        private void homeStatusLoader(string s)
        {
            ssHome.Text = "Home: " + s;
        }

        private void settingsLoader()
        {
            XmlDocument xdoc = new XmlDocument();

            try
            {
                // check if "settings file" exists
                xdoc.Load(Settings.SETTINGS_XML);
                XmlSerializer xs = new XmlSerializer(typeof(Settings));
                FileStream fs = new FileStream(Settings.SETTINGS_XML, FileMode.Open);
                settings = (Settings)xs.Deserialize(fs);
            }
            catch (FileNotFoundException e)
            {
                // if not found, create one
                settings = new Settings();
                settings.Uri = "null";

                XmlSerializer t_xs = new XmlSerializer(typeof(Settings));
                StreamWriter sw = new StreamWriter(Settings.SETTINGS_XML);
                t_xs.Serialize(sw, settings);
                sw.Close();

                settings.Favourites = new List<Settings.KeyVal<string, string>>();
                settings.History = new List<string>();

                // no need to deserialise it
            }
        }

        private void bookmarksLoader()
        {
            if (settings.History != null)
            {
                foreach (string s in settings.History)
                {
                    bookmarks.Nodes[1].Nodes.Add(s);
                }
            }

            if (settings.Favourites != null)
            {
                foreach (Settings.KeyVal<string, string> kv in settings.Favourites)
                {
                    bookmarks.Nodes[0].Nodes.Add(kv.Key);
                }
            }

        }

        private void SearchbarButton_Click(object sender, EventArgs e)
        {
            handleSearch();
            handleBookmarks(searchbar.Text);
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
                using (res = (HttpWebResponse)req.GetResponse())
                {
                    StreamReader data = new StreamReader(res.GetResponseStream());
                    setssStatus("(200) OK", Color.Green);

                    OutputDataBox.Text = data.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                Regex r = new Regex(@"(\(\d+\).+)");
                //OutputDataLabel.Text = e.Message;

                MatchCollection errStatusCode = r.Matches(e.Message);

                if (errStatusCode.Count > 0)
                {
                    setssStatus(errStatusCode[0].Value, Color.Red);
                } else
                {
                    setssStatus(e.Message, Color.Red);
                }

                OutputDataBox.Text = "ERR";
            }
            catch (Exception e)
            {
                setssStatus("Invalid URI", Color.Red);
                OutputDataBox.Text = e.Message;
            }
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

            if (index == 1)
            {
                settings.History.Add(s);
                currentNode = bookmarks.Nodes[1].LastNode;
                return;
            }

            settings.Favourites.Add(new Settings.KeyVal<string, string> { Key = s, Value = s });
        }


        private void bookmarks_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    // navigate history
                    if (bookmarks.SelectedNode.Parent == bookmarks.Nodes[1])
                    {
                        searchbar.Text = bookmarks.SelectedNode.Text;
                        handleSearch();
                    }

                    // navigate favourites - needs extra check and validation since nodes are renamable
                    if (bookmarks.SelectedNode.Parent == bookmarks.Nodes[0])
                    {
                        Settings.KeyVal<string, string> kv = settings.Favourites.Find(x => x.Key == bookmarks.SelectedNode.Text);
                        Console.WriteLine("Key {0}, Val {1}", kv.Key, kv.Value);
                        
                        if (kv == null)
                        {
                            return;
                        }

                        reload(kv.Value);
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

        //private void btnBookmarksDelete_MouseUp(object sender, MouseEventArgs e)
        //{
        //    // remove

        //    if (bookmarks.SelectedNode == null || bookmarks.SelectedNode == bookmarks.Nodes[0] || bookmarks.SelectedNode == bookmarks.Nodes[1])
        //    {
        //        return;
        //    }

        //    bookmarks.SelectedNode.Remove();
        //}

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
            {
                reload();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handleSearch(settings.useSetURI());
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

        private void setHomeNode_Click(object sender, EventArgs e)
        {
            string t = bookmarks.SelectedNode.Text;

            if (bookmarks.SelectedNode.Parent == bookmarks.Nodes[0])
            {
                t = settings.Favourites.Find(x => x.Key.Equals(bookmarks.SelectedNode.Text)).Value;
            }

            settings.Uri = t;
            homeStatusLoader(settings.useSetURI());
        }

        private void addFavouriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleBookmarks(bookmarks.SelectedNode.Text, 0);
        }

        private void deleteNode_Click(object sender, EventArgs e)
        {
            bookmarks.Nodes.Remove(bookmarks.SelectedNode);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine(openBatch.FileName);
            FileStream fs = File.OpenRead(openBatch.FileName);
            
            if (fs == null)
            {
                return;
            }

            // read into mem
            byte[] raw = new byte[fs.Length];
            fs.Read(raw, 0, raw.Length);

            string s = Encoding.Default.GetString(raw);
            string[] vs = s.Split(new char[] { ',', ' ', '\n' });

            Task<string>[] requests = new Task<string>[vs.Length];
            List<string> res = new List<string>();
            int i = 0;
            OutputDataBox.Text = "";

            foreach (string v in vs)
            {
                requests[i] = Task.Run(() =>
                {
                    UrlRequest r = new UrlRequest(v);
                    return r.Request();
                });

                i++;
            }

            Task.WaitAll(requests);

            for (i = 0;  i < requests.Length; ++i)
            {
                appendOutput(requests[i].Result);
            }

            fs.Close();
        }

        private void appendOutput(string s)
        {
            OutputDataBox.Text += s;
        }

        private void btnBatchDownload_Click(object sender, EventArgs e)
        {
            openBatch.ShowDialog();
            openBatch.Dispose();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int i = bookmarks.Nodes[1].Nodes.IndexOf(currentNode) - 1;

            if (i < 0)
            {
                return;
            }

            currentNode = bookmarks.Nodes[1].Nodes[i];

            if (currentNode == null)
            {
                return;
            }

            searchbar.Text = currentNode.Text;
            bookmarks.SelectedNode = currentNode;
            handleSearch();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            int i = bookmarks.Nodes[1].Nodes.IndexOf(currentNode) + 1;

            if (i > bookmarks.Nodes[1].Nodes.Count - 1)
            {
                return;
            }

            currentNode = bookmarks.Nodes[1].Nodes[i];


            if (currentNode == null)
            {
                return;
            }

            searchbar.Text = currentNode.Text;
            bookmarks.SelectedNode = currentNode;
            handleSearch();
        }

        private void reload(string s)
        {
            handleSearch(s);
            handleBookmarks(s);
            this.Text = s;
        }

        private void reload()
        {
            reload(searchbar.Text);
        }

        //private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    // remove
        //}

        //private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        //{
        //    // remove
        //}

        //private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    // remove
        //}

        //private void toolStripTextBox1_Click(object sender, EventArgs e)
        //{
        //    // remove
        //}

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1 == null || 
                toolStripTextBox1.Equals("") || 
                bookmarks.SelectedNode.Parent != bookmarks.Nodes[0])
            {
                return;
            }

            string prev = bookmarks.SelectedNode.Text;
            bookmarks.SelectedNode.Text = toolStripTextBox1.Text;

            settings.rename(prev, toolStripTextBox1.Text);
        }
    }

    [XmlInclude(typeof(List<string>))]
    public class Settings
    {
        public class KeyVal<_K, _V>
        {
            public _K Key { get; set; }
            public _V Value { get; set; }
        }

        public string Uri { get; set; }
        public List<string> History { get; set; }
        public List<KeyVal<string, string>> Favourites { get; set; }

        public const string default_uri = "https://www.hw.ac.uk/";
        public const string SETTINGS_XML = "settings.xml";

        public string useSetURI()
        {
            if (Uri == null || Uri.Equals("null"))
            {
                return default_uri;
            }

            return Uri;
        }

        public void rename(string key, string to)
        {

            KeyVal<string, string> k = Favourites.Find(x => key.Equals(x.Key));
            Favourites.Remove(k);

            // make new key and insert
            string v = k.Value;
            k = new KeyVal<string, string> { Key = to, Value = v };
            Favourites.Add(k);
        }

        // deconstructor will be used to save/update settings file
        ~Settings()
        {
            XmlSerializer t_xs = new XmlSerializer(typeof(Settings));
            StreamWriter sw = new StreamWriter(Settings.SETTINGS_XML);
            t_xs.Serialize(sw, this);
            sw.Close();
        }
    };

    public class UrlRequest
    {
        public UrlRequest(string url)
        {
            uri = url;
        }

        public string uri { get; set; }

        //public async Task<Response> GetAsync()
        //{
        //    string code = "";
        //    long size = 0;

        //    try
        //    {
        //        HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
        //        req.Method = "GET";

        //        HttpWebResponse res = await req.GetResponseAsync() as HttpWebResponse;
        //        StreamReader data = new StreamReader(res.GetResponseStream());
        //        size = res.ContentLength;
        //        code = "(200) OK";
        //    } catch(WebException e)
        //    {
        //        Console.WriteLine(e.Message);
        //        Regex r = new Regex(@"(\(\d+\).+)");
        //        MatchCollection errStatusCode = r.Matches(e.Message);

        //        if (errStatusCode.Count > 0)
        //        {
        //            code = errStatusCode[0].Value;
        //        }
        //    }

        //    return new Response { uri = uri, code = code, size = size };
        //}
        //public async Task<string> RequestAsync()
        //{

        //    Response res = await GetAsync();
        //    return Environment.NewLine + "[- [" + res.code + "] <" + res.size / 8 + "B> " + res.uri + "-]";
        //}

        public string Request()
        {
            string code = "";
            long size = 0;

            try
            {
                HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                req.Method = "GET";

                using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                {
                    StreamReader data = new StreamReader(res.GetResponseStream());
                    size = res.ContentLength;
                    code = "(200) OK";
                }
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
            catch (Exception ex)
            {
                code = ex.Message;
            }

            return Environment.NewLine + "[- [" + code + "] <" + size / 8 + "B> " + uri + "-]";
        }

        //public class Response{
        //    public string uri { get; set;}
        //    public string code { get; set;}
        //    public long size { get; set; }
        //}
    }
}
