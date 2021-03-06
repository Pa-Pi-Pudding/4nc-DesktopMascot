﻿using System;
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
        

        private void NewsViewerForm_Load(object sender, EventArgs e)
        {

        }

        private void NewsViewerForm_Load_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        // TODO: HTMLタグの消去ができないので,利用できるRSSが限られている
        //
        // Game tab method
        //
        private void Gamer_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://www.4gamer.net/rss/news_topics.xml";
            int MethodFlag = 0;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }    
        private void Gamedrive_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://gamedrive.jp/feed";
            int MethodFlag = 0;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
            
        }
        private void doope_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://doope.jp/feed/";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
            
        }

        private void famicoroti_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"http://famicoroti.blog81.fc2.com/?xml";
            int MethodFlag = 0;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        //
        // Anime tab method
        //

        private void zaikei_anime_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://www.zaikei.co.jp/rss/topics/449.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();

        }
        private void AkibaBlog_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"http://blog.livedoor.jp/geek/index.rdf";
            int MethodFlag = 0;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void WebNewtype_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://webnewtype.com/xml/";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void Animehack_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"http://feeds.eiga.com/animehack-news";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void moca_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://moca-news.net/index.xml";
            int MethodFlag = 0;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        //
        // IT tab method
        //

        private void codezine_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://codezine.jp/rss/new/20/index.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();

        }

        private void Itmedia_total_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://rss.itmedia.co.jp/rss/2.0/ait.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void gizmodo_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://www.gizmodo.jp/index.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void Itmedia_linux_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://rss.itmedia.co.jp/rss/2.0/ait_linux.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void Itmedia_Html_UX_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://rss.itmedia.co.jp/rss/2.0/ait_ux.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        // 経済
        private void zaikei_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"http://www.zaikei.co.jp/rss/sections/economy.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }
        private void otakuma_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"http://otakei.otakuma.net/feed";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void toyokeizai_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://toyokeizai.net/list/feed/rss";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void JBpress_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"http://jbpress.ismedia.jp/list/feed/rss";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void meti_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"http://www.meti.go.jp/ml_index_release_atom.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        //  芸能

        private void nitisupo_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://www.nikkansports.com/entertainment/atom.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void zakzak_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://www.zakzak.co.jp/rss/news/flash-n.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();           

        }

        private void nifty_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"https://news.nifty.com/rss/topics_entame.xml";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void geinoukininaru_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"http://blog.livedoor.jp/uwasainfo/index.rdf";
            int MethodFlag = 0;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }

        private void geinou_scoop_Click(object sender, EventArgs e)
        {
            string sendRssUrl = @"http://imashun-navi.com/feed";
            int MethodFlag = 1;
            Newsview viewer = new Newsview(sendRssUrl,MethodFlag);
            viewer.Show();
        }
    }
}