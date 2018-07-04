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
        public NewsViewerForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NewsViewerForm_Load(object sender, EventArgs e)
        {

        }

        private string GetHtml(string url)
        {
            // 指定されたURLに対してのRequestを作成します。
            var req = (HttpWebRequest)WebRequest.Create(url);
 
            // html取得文字列
            string html = "";
 
            // 指定したURLに対してReqestを投げてResponseを取得します。
            using (var res = (HttpWebResponse)req.GetResponse())
            using (var resSt = res.GetResponseStream())
            // 取得した文字列をUTF8でエンコードします。
            using (var sr = new StreamReader(resSt, Encoding.UTF8))
            {
                // HTMLを取得する。
                html = sr.ReadToEnd();
            }
 
            return html;
        }

        private string GetTitle(string html)
        {
         
            // 正規化表現
            // 大文字小文字区別なし       : RegexOptions.IgnoreCase
            // 「.」を改行にも適応する設定: RegexOptions.Singleline
            var reg = new Regex(@"<title>(?<title>.*?)</title>",
                         RegexOptions.IgnoreCase | RegexOptions.Singleline);
         
            // html文字列内から条件にマッチしたデータを抜き取ります。
            var m = reg.Match(html);
         
            // 条件にマッチした文字列内からKey("title部分")にマッチした値を抜き取ります。
            return m.Groups["title"].Value;
        }


        public string GetKeyword(string html, string Keyword)
        {
            string header = "<p";
            string footer = "</p";

            // html文字列内からKeywordをさがしその位置を返す
            int keywordStart = html.IndexOf(Keyword);

            string buf_buf_mae = html.Substring(0, keywordStart);
            string buf_mae = "";
            for (int n = 1; n <= buf_buf_mae.Length; n++)
            {
                buf_mae = buf_buf_mae.Substring((buf_buf_mae.Length) - n, n);
                if (buf_mae.IndexOf(header) > 0)
                {  //後ろからさがして見つかったら
                    break;
                }
                if (n > 50000)
                {
                    MessageBox.Show("Header get Error.");
                    break;
                }
            }

            string buf_ushiro = html.Substring(keywordStart); //indexOfから後ろを取得第2引数省略
            int nagasa_u = buf_ushiro.IndexOf(footer);
            buf_ushiro = html.Substring(keywordStart, nagasa_u + 4); //start位置,対象文字列長さ

            string getWord = buf_mae + buf_ushiro;
            return getWord;

        }
        
        public string deleteTag(string getWord)
        {
            int buf_int = -1;
            int buf_int2;
            string tukau1, tukau2;
            string buf_1;
            string deleteTag_getword;

            for (int n = 1; n < 80; n++)
            {
                buf_int = getWord.IndexOf("<");
                if (buf_int < 0)
                {
                    break;
                }

                tukau1 = getWord.Substring(0, buf_int);
                buf_1 = getWord.Substring(buf_int + 1);
                buf_int2 = buf_1.IndexOf(">");
                tukau2 = buf_1.Substring(buf_int2 + 1);

                getWord = tukau1 + tukau2;
              
            }
            deleteTag_getword = getWord;
                 return deleteTag_getword;
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

                    formGraphics.DrawString( title+"\r\n"
                        + link+"\r\n"
                        //+ description+"\r\n"
                        + date
                        , drawFont, drawBrush, rect, drawFormat);
                    
                    rect.Y += (fontsize*9+3);
                    formGraphics.DrawRectangle(Pens.Black, Rectangle.Round(rect));
                  }
                drawFont.Dispose();
                drawBrush.Dispose();
                formGraphics.Dispose();
            }
        }

        private void Anime_Click(object sender, EventArgs e)
        {
            // string html = GetHtml("https://animeanime.jp/category/news/");
           
            string url = "http://www.saiani.net/feed";
            //  Console.WriteLine(html);
            //  Console.WriteLine(GetTitle(html));
            GetRssFeed(url);
            // string getkeyword = GetKeyword(html, "銀魂");
            // Console.WriteLine(getkeyword);
            // Console.WriteLine("===================================================================");
            // Console.WriteLine(deleteTag(getkeyword));

        }

        private void Game_Click(object sender, EventArgs e)
        {
            string url = @"https://www.4gamer.net/rss/news_topics.xml";
            GetRssXml(url);
        }
    }
}