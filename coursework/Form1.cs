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

namespace coursework
{
    public partial class Form1 : Form
    {
        private const string URLPattern = @"((https ?:\/\/)?w{3}\.(\w+[.-]*)+\.(com|co\.uk))";
        private const string HTTPPattern = @"(https?)";

        public Form1()
        {
            InitializeComponent();
        }

        private void Searchbar_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchbarButton_Click(object sender, EventArgs e)
        {
            handleSearch();
            handleBookmarks(searchbar.Text);
        }

        private void handleSearch()
        {
            string url = searchbar.Text;

            HttpWebResponse res = null;

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

        private void bookmarks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void bookmarks_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (bookmarks.SelectedNode.Text.Substring(0, 4).Equals("http"))
            {
                searchbar.Text = bookmarks.SelectedNode.Text;
                handleSearch();
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
    }
}
