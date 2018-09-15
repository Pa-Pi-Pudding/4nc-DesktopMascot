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

        public NewsViewerForm()
        {
            InitializeComponent();
            _NewsviewerformInstance = this;
           
        }
        
        public string ReceiveData { get; set; }

        private void NewsViewerForm_Load(object sender, EventArgs e)
        {

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

       
        private void Anime_Click(object sender, EventArgs e)
        {
            string sendUrl = @"https://www.4gamer.net/rss/news_topics.xml";
            ReceiveData = sendUrl;
            Newsview viewer = new Newsview(sendUrl);
            viewer.Show();

        }

        private void Game_Click(object sender, EventArgs e)
        {
            string url = @"https://www.4gamer.net/rss/news_topics.xml";
            //GetRssXml(url);
        }
    }
}