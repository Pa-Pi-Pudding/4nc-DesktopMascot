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
            if (!string.IsNullOrEmpty(Properties.Settings.Default.AccessToken)
                && !string.IsNullOrEmpty(Properties.Settings.Default.AccessTokenSecret))
            {
                tokens = Tokens.Create(
                    Properties.Settings.Default.ApiKey
                    , Properties.Settings.Default.ApiSecret
                    , Properties.Settings.Default.AccessToken
                    , Properties.Settings.Default.AccessTokenSecret);
                updatescreennameLabel();

                /*
                 * http://01647.hateblo.jp/entry/2014/10/12/132505
                 * CoreTweet.Tokens.Account.VerifyCredentials()とTwitter OAuth2それぞれの調査記録 2014-10-12
                 * 
                 * 動的にScreenNameを得る場合のテストコード
                 */
                ///トークン有効性確認
                try
                {
                    var userResponse = tokens.Account.VerifyCredentials();
                    updatescreennameLabel(userResponse.ScreenName);
                    Properties.Settings.Default.ScreenName = userResponse.ScreenName;
                    Properties.Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                    tokens = null;
                }
            }
        }
        /// <param name="screenName">Twitter Screen Name</param>
        /// パラメータ省略時は設定ファイルを読み出す
        internal void updatescreennameLabel(string screenName = null)
        {
            string _screenName;
            if (string.IsNullOrEmpty(screenName))
            {
                _screenName = Properties.Settings.Default.ScreenName;
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
    }
}
