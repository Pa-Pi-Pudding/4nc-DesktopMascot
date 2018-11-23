using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.ServiceModel.Syndication;

namespace DesktopMascot
{
    public partial class Newsview : Form
    {

        private String URL;
        private int MethodFlag;
        private System.Windows.Forms.RichTextBox[] richTextBoxes;
        public Newsview(String URL, int MethodFlag)
        {
            InitializeComponent();
            this.URL = URL;
            this.MethodFlag = MethodFlag;

        }

        private void Newsview_Load(object sender, EventArgs e)
        {
            this.richTextBoxes = new RichTextBox[6];
            this.richTextBoxes[0] = this.richTextBox1;
            this.richTextBoxes[1] = this.richTextBox2;
            this.richTextBoxes[2] = this.richTextBox3;
            this.richTextBoxes[3] = this.richTextBox4;
            this.richTextBoxes[4] = this.richTextBox5;
            this.richTextBoxes[5] = this.richTextBox6;

            if (MethodFlag == 0)
            {
                GetRssXml(URL, 0);
                GetRssXml(URL, 1);
                GetRssXml(URL, 2);
                GetRssXml(URL, 3);
                GetRssXml(URL, 4);
                GetRssXml(URL, 5);
            }
            else if  (MethodFlag == 1)
            {

                GetRssFeed(URL, 0);
                GetRssFeed(URL, 1);
                GetRssFeed(URL, 2);
                GetRssFeed(URL, 3);
                GetRssFeed(URL, 4);
                GetRssFeed(URL, 5);
            }
        }

        // クリックされたリンクをブラウザで開きます
        private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            
            try
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
            catch
            {
            }
        }

        protected internal void GetRssXml(string url, int colomn)
        {
            {

                var xml = new XmlDocument();
                int count = 0;
                xml.Load(url);

                var nsmgr = new XmlNamespaceManager(xml.NameTable);
                nsmgr.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
                nsmgr.AddNamespace("rss", "http://purl.org/rss/1.0/");
                nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");

                foreach (XmlElement node in xml.SelectNodes("/rdf:RDF/rss:item", nsmgr))
                {

                    var title = node.SelectNodes("rss:title", nsmgr)[0].InnerText;
                    var link = node.SelectNodes("rss:link", nsmgr)[0].InnerText;
                    var description = node.SelectNodes("rss:description", nsmgr)[0].InnerText;

                    var date = DateTime.Parse(node.SelectNodes("dc:date", nsmgr)[0].InnerText);

                    if (count == colomn)
                    {
                        richTextBoxes[colomn].Text = title + "\n" + link + description;
                        this.Controls.Add(this.richTextBoxes[colomn]);
                    }
                    count++;
                }

            }
        }

        protected internal void GetRssFeed(string url, int colomn)
        {
            using (XmlReader rdr = XmlReader.Create(url))

            {
                SyndicationFeed feed = SyndicationFeed.Load(rdr);

                int count = 0;
                foreach (SyndicationItem item in feed.Items)
                {

                    var title = item.Title.Text;
                    var link = item.Links[0].Uri;
                    var description = item.Summary.Text;
                    if (count == colomn)
                    {
                        richTextBoxes[colomn].Text = title + "\n" + link + description; 
                        this.Controls.Add(this.richTextBoxes[colomn]);
                    }
                    count++;
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
