using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml;
using System.Windows.Shapes;

namespace DesktopMascot.SubScreens.Newsviewer
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        SubScreens.Newsviewer.NewsShow newsShow = new SubScreens.Newsviewer.NewsShow();
        public UserControl1()
        {
            string url = newsShow.ReceiveData;

            TableClass tableObject = new TableClass();

            tableObject.colomn1 = GetRssXml(url, 1);
            tableObject.colomn2 = GetRssXml(url, 1);
            tableObject.colomn3 = GetRssXml(url, 1);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public class TableClass
        {
            public string colomn1 { get; set; }
            public string colomn2 { get; set; }
            public string colomn3 { get; set; }
        }

        private string GetRssXml(string url, int counter)
        {
            {
                string hoge;
                var xml = new XmlDocument();
                // xml.Load("http://feed.rssad.jp/rss/gigazine/rss_1.0");
                xml.Load(url);
                var nsmgr = new XmlNamespaceManager(xml.NameTable);
                nsmgr.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
                nsmgr.AddNamespace("rss", "http://purl.org/rss/1.0/");
                nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
                int count = 0;
                foreach (XmlElement node in xml.SelectNodes("/rdf:RDF/rss:item", nsmgr))
                {
                    var title = node.SelectNodes("rss:title", nsmgr)[0].InnerText;
                    var link = node.SelectNodes("rss:link", nsmgr)[0].InnerText;
                    var description = node.SelectNodes("rss:description", nsmgr)[0].InnerText;
                    var date = DateTime.Parse(node.SelectNodes("dc:date", nsmgr)[0].InnerText);

                    if (counter == count)
                    {
                          return  hoge = title + "\n" + link + "\n" + description ;
                    }
                }
                return "";
            }
        }
    }
}