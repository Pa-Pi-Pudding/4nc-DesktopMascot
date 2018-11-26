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
using System.Windows.Shapes;
using CoreTweet;

namespace DesktopMascot.SubScreens.twitter
{
    /// <summary>
    /// TwitterMainWindows.xaml の相互作用ロジック
    /// </summary>
    public partial class TwitterMainWindows : UserControl
    {
        public CoreTweet.Tokens tokens;


        public TwitterMainWindows()
        {
            InitializeComponent();


            // トークン組立
            if (!string.IsNullOrEmpty(ReadAccountcsvdata(1))
                && !string.IsNullOrEmpty(ReadAccountcsvdata(2)))
            {

                string ApiKey = ReadAccountcsvdata(1);
                string ApiSecretKey = ReadAccountcsvdata(2);
                string AccessToken = ReadAccountcsvdata(3);
                string AccessTokenSecret = ReadAccountcsvdata(4);

                tokens = Tokens.Create(
                    ApiKey
                    , ApiSecretKey
                    , AccessToken
                    , AccessTokenSecret);
                updatescreennameLabel();

                /*
                 * http://01647.hateblo.jp/entry/2014/10/12/132505
                 * CoreTweet.Tokens.Account.VerifyCredentials()とTwitter OAuth2それぞれの調査記録 2014-10-12
                 * 
                 * 動的にScreenNameを得る場合のテストコード
                 */
                ///トークン有効性確認
                //try
                //{
                //    var userResponse = tokens.Account.VerifyCredentials();
                //    updatescreennameLabel(userResponse.ScreenName);
                //    Properties.Settings.Default.ScreenName = userResponse.ScreenName;
                //    Properties.Settings.Default.Save();
                //}
                //catch (Exception ex)
                //{
                //    // MessageBox.Show(ex.Message);
                //    tokens = null;
                //}
            }
        }
        /// <param name="screenName">Twitter Screen Name</param>
        /// パラメータ省略時は設定ファイルを読み出す
        internal void updatescreennameLabel(string screenName = null)
        {
            string _screenName;
            if (string.IsNullOrEmpty(screenName))
            {
                _screenName = ReadAccountcsvdata(5);
                // 未認証時
                if (string.IsNullOrEmpty(_screenName))
                {
                    screennameLabel.Content = "unregister";
                    return;
                }
            }
            else
            {
                _screenName = screenName;
            }
            // http://msdn.microsoft.com/ja-jp/library/system.windows.controls.label(v=vs.110).aspx
            // WPF Labelにおける文字 _ の仕様について対策する
            screennameLabel.Content = _screenName.Replace("_", "__");
        }

        // Twitter アカウント認証
        private void registButton_Click(object sender, RoutedEventArgs e)
        {
            RegistAccountWindowForm dialog = new RegistAccountWindowForm();
            // http://msdn.microsoft.com/ja-jp/library/system.windows.window.showdialog(v=vs.110).aspx
            dialog.ShowDialog();
        }

        private void getTl_Click(object sender, RoutedEventArgs e)
        {
            if (tokens != null)
            {
                viewTextBox.Clear();
                try
                {
                    foreach (var status in tokens.Statuses.HomeTimeline())
                    {
                        // http://qiita.com/lambdalice/items/55b1a3d8403ecc603b47#2-4 例1: REST API 
                        //＠{スクリーンネーム(id)}{改行}{名前} : {投稿内容}{改行}
                        //うえから順配列みたいにi{0}みたいにならべるとそれの通りに表示されるらしい
                        viewTextBox.AppendText(string.Format("@{0}{3} {1}: {2}{3}"
                            , status.User.ScreenName
                            , status.User.Name
                            , status.Text
                            , Environment.NewLine));
                    }
                }
                catch (Exception ex)
                {
                    viewTextBox.AppendText(ex.Message);
                }
            }
        }



        // OpenAccessForm_Load __ END __

        //空のCSVファイルを作成する。
        private void CreateNewCSV()
        {
            //実行ファイルのあるディレクトリを取得
            string CurrentDir = System.IO.Directory.GetCurrentDirectory();
            string csvfilepath = CurrentDir + @"\twitterAccountdata.csv";

            //CSVファイル読み込み
            System.IO.StreamWriter csvwrite = new System.IO.StreamWriter(
                csvfilepath, false,
                System.Text.Encoding.GetEncoding("shift_jis"));

            //CSVに追記
            csvwrite.WriteLine("");
            //CSV閉じる
            csvwrite.Close();
            //読み込み直す。
            //CSVRead();

        }//CreateNewCSV() __END_
        internal string ReadAccountcsvdata(int linenum)
        {
            string CurrentDir = System.IO.Directory.GetCurrentDirectory();
            String csvfilepath = CurrentDir + @"\twitterAccountdata.csv";

            //CSVファイルが有るかどうか調べる
            if (System.IO.File.Exists(csvfilepath))
            {
                //存在する場合CSVファイルを読み込む
                System.IO.StreamReader csvread = new System.IO.StreamReader(
                csvfilepath,
                System.Text.Encoding.GetEncoding("shift_jis"));

                String filedata;
                //1行ずつ読み込む
                int count = 0;
                string returndata = "";
                while ((filedata = csvread.ReadLine()) != null)
                {
                    //カンマまで文字列分割
                    string[] csvdata = filedata.Split(',');
                    count++;
                    //CSVが空(つまりvaluesが空)の場合は、ハッシュテーブルには空値を入れておく
                    if (csvdata[0] == "")
                    {
                        //何もしない。
                        //ここは、新しくCSVを開いた時に(CSVの中身は空なので)実行される。

                        csvread.Close();
                    }
                    else
                    {
                        //リストビューに追加
                        if (count == linenum)
                        {
                            returndata = csvdata[1];
                            csvread.Close();
                            return returndata; 
                        }
                    }
                }
               csvread.Close();
            }
            else
            {
                //存在しない場合


            }
            return "";
        }
    }
}
