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
    public partial class Newsview: Form
    {

        private String URL;
        private System.Windows.Forms.RichTextBox[] richTextBoxes;
        RichTextBox[] textBoxArray;
        public Newsview(String ReceiveURL)
        {
            InitializeComponent();
            URL = ReceiveURL;

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void Newsview_Load(object sender, EventArgs e)
        {
            this.richTextBoxes = new RichTextBox[7];
            this.richTextBoxes[0] = this.richTextBox1;
            this.richTextBoxes[1] = this.richTextBox2;
            this.richTextBoxes[2] = this.richTextBox3;
            this.richTextBoxes[3] = this.richTextBox4;
            this.richTextBoxes[4] = this.richTextBox5;
            this.richTextBoxes[5] = this.richTextBox6;
            GetRssXml(URL, 0);
            GetRssXml(URL, 1);
            GetRssXml(URL, 2);
            GetRssXml(URL, 3);
            GetRssXml(URL, 4);
            GetRssXml(URL, 5);
        }

         private void GetRssXml(string url, int colomnn){
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

                    if (count == colomnn)
                    {
                    richTextBoxes[colomnn].Text = title + "\n" + link +  description ;
                    this.Controls.Add(this.richTextBoxes[colomnn]);
                    }

                    count ++ ;
                  }

            }
        }
    }
}
