﻿using System;
using System.Collections;
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
using System.Windows.Shapes;
using CoreTweet;

namespace DesktopMascot.SubScreens.twitter
{
    /// <summary>
    /// RegistAccountWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class RegistAccountWindow : UserControl
    {
        OAuth.OAuthSession session;
        public RegistAccountWindow()
        {
            InitializeComponent();
            initAuthrize();
        }

        // OAuthセッションを作る
        private void initAuthrize()
        {
            try
            {
                TwitterMainWindows twitterMainWindows = new TwitterMainWindows();
                string Apikey = twitterMainWindows.ReadAccountcsvdata(1);
                string ApiSecretKey = twitterMainWindows.ReadAccountcsvdata(2);
                session = OAuth.Authorize(Apikey, ApiSecretKey);
                pinURITextBox.Text = session.AuthorizeUri.ToString();
                pinTextBox.Clear();
                // System.Diagnostics.Process.Start(session.AuthorizeUri.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void cancelButton_Click(object sender, RoutedEventArgs e)
        //{
        //}

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            // http://msdn.microsoft.com/ja-jp/library/system.text.regularexpressions.regex.aspx
            // http://msdn.microsoft.com/ja-jp/library/az24scfc.aspx 正規表現言語 - クイック リファレンス
            // PINに数字以外を含む場合，認証に移行しない
            if (string.IsNullOrEmpty(pinTextBox.Text)
                || System.Text.RegularExpressions.Regex.IsMatch(pinTextBox.Text, @"\D"))
            {
                MessageBox.Show("Type numeric characters");
                pinTextBox.Clear();
                return;
            }

            try
            {
                // PIN認証
                TwitterMainWindows owner = new TwitterMainWindows();
                owner.tokens = session.GetTokens(pinTextBox.Text);
                // トークン保存

                //Properties.Settings.Default.AccessToken = owner.tokens.AccessToken;
                //Properties.Settings.Default.AccessTokenSecret = owner.tokens.AccessTokenSecret;
                //Properties.Settings.Default.ScreenName = owner.tokens.ScreenName;
                //Properties.Settings.Default.Save();
                saveOAuthSession("AccessToken",owner.tokens.AccessToken);
                saveOAuthSession("AccessTokenSecret",owner.tokens.AccessTokenSecret);
                saveOAuthSession("ScreenName",owner.tokens.ScreenName);
                // 表示調整
                owner.updatescreennameLabel(owner.tokens.ScreenName);

                MessageBox.Show("verified: " + owner.tokens.ScreenName + "\r\n" + "twitter画面をリロードしてね");

            }
            catch (Exception ex)
            {
                // やり直し
                MessageBox.Show(ex.Message);
                initAuthrize();
            }

        }

        private void pinURITextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void saveOAuthSession(string key , string value)
        {
            string CurrentDir = System.IO.Directory.GetCurrentDirectory();
            String csvfilepath = CurrentDir + @"\twitterAccountdata.csv";
            if (System.IO.File.Exists(csvfilepath))
            {

                //CSVファイル書き込み
                System.IO.StreamWriter csvwrite = new System.IO.StreamWriter(
                    csvfilepath, true,
                    System.Text.Encoding.GetEncoding("shift_jis"));

                //起動コマンドが既に登録されているかどうか判定
                Hashtable ht = new Hashtable();
                if (ht.ContainsKey(key))
                {
                    //Hitする時
                    //起動コマンドは重複してはいけないので(仕様)、エラー表示
                     csvwrite.Close();
                }
                else
                {
                    //Hitしない時
                    //CSVに追記
                    csvwrite.WriteLine("{0},{1}", key, value);

                }

                csvwrite.Close();
            }
        }
    }
}
