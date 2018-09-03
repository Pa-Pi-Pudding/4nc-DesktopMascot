using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.ServiceModel.Syndication;

namespace DesktopMascot
{
    public partial class NewsViewerForm: Form
    {
        private static NewsViewerForm _NewsviewerformInstance;
       
        private string sendData="";
        public NewsViewerForm()
        {
            InitializeComponent();
            _NewsviewerformInstance = this;
           
        }
        
        private void NewsViewerForm_Load(object sender, EventArgs e)
        {

        }
    public string SendData
    {
      set
      {
        sendData = value;
      }
      get
      {
        return sendData;
      }
    }

        private void GetRssFeed(string url)
        {
　　　　　　using (XmlReader rdr = XmlReader.Create(url))

　　　　　　{
                int fontsize = 9;
                Graphics formGraphics = this.CreateGraphics();
                formGraphics.Clear(Color.WhiteSmoke);
                Font drawFont = new System.Drawing.Font("Arial", fontsize);
                SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                float x = 0F;
                float y = 0F;
                
                StringFormat drawFormat = new System.Drawing.StringFormat();
            
                RectangleF rect = new RectangleF(x, y, Width, Height);
　　　　　　　　SyndicationFeed feed = SyndicationFeed.Load(rdr);

                formGraphics.DrawRectangle(Pens.Black, Rectangle.Round(rect));
　　　　　　　　foreach (SyndicationItem item in feed.Items)
　　　　　　　　{
　　　　　　　　　　Console.WriteLine("description:" + item.Summary.Text);
//                    Console.WriteLine("link:" + item.Links[0].Uri);
                    formGraphics.DrawString( item.Title.Text + "\r\n"
                        //+ item.Summary.Text + "\r\n"
                        + item.Links[0].Uri +"\r\n"
                        + item.PublishDate + "\r\n"
                        , drawFont, drawBrush, rect, drawFormat);
                    rect.Y += (fontsize*11+3);
                    formGraphics.DrawRectangle(Pens.Black, Rectangle.Round(rect));
                }
                drawFont.Dispose();
                drawBrush.Dispose();
                formGraphics.Dispose();
　　　　　　}
        }

        private void GetRssXml(string url){
            {
                int fontsize = 9;
                Graphics formGraphics = this.CreateGraphics();
                formGraphics.Clear(Color.WhiteSmoke);
                Font drawFont = new System.Drawing.Font("Arial", fontsize);
                SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                float x = 0F;
                float y = 0F;
               
                StringFormat drawFormat = new System.Drawing.StringFormat();
            
                RectangleF rect = new RectangleF(x, y, Width, Height);

                var xml = new XmlDocument();

            // xml.Load("http://feed.rssad.jp/rss/gigazine/rss_1.0");
                xml.Load(url);
                var nsmgr = new XmlNamespaceManager(xml.NameTable);
                nsmgr.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
                nsmgr.AddNamespace("rss", "http://purl.org/rss/1.0/");
                nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
                formGraphics.DrawRectangle(Pens.Black, Rectangle.Round(rect));

                  foreach (XmlElement node in xml.SelectNodes("/rdf:RDF/rss:item", nsmgr))
                  {
                    var title = node.SelectNodes("rss:title", nsmgr)[0].InnerText;
                    var link = node.SelectNodes("rss:link", nsmgr)[0].InnerText;
                    var description = node.SelectNodes("rss:description", nsmgr)[0].InnerText;
                    var date = DateTime.Parse(node.SelectNodes("dc:date", nsmgr)[0].InnerText);

                    //formGraphics.DrawString( title+"\r\n"
                    //    + link+"\r\n"
                    //    //+ description+"\r\n"
                    //    + date
                    //    , drawFont, drawBrush, rect, drawFormat);
                    
                    //rect.Y += (fontsize*9+3);
                    //formGraphics.DrawRectangle(Pens.Black, Rectangle.Round(rect));
                  }
                //drawFont.Dispose();
                //drawBrush.Dispose();
                //formGraphics.Dispose();
            }
        }
        public string ReceiveData { get; set; }
        private void Anime_Click(object sender, EventArgs e)
        {
            string sendUrl = "http://www.saiani.net/feed";
            ReceiveData = sendUrl;
            Newsview viewer = new Newsview();
            viewer.Show();

        }

        private void Game_Click(object sender, EventArgs e)
        {
            string url = @"https://www.4gamer.net/rss/news_topics.xml";
            GetRssXml(url);
        }
    }
}