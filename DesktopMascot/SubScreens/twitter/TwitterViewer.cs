using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreTweet;
namespace DesktopMascot
{
    class TwitterViewer : SubScreenMgr
    {
        public TwitterViewer(int id) : base(id)
        {
            // コンストラクタでスクリーンの名前を設定する
            screenName = "twitter";
            // コンストラクタでスクリーンの機能について軽い説明を入れる。
            screenDescription = "twitterのTLを読むことができます";
        }

        public override void start()
        {
            Form bufForm = new TwitterViewerForm();
            // 起動させるフォームを保持しておく
            formList.Add(bufForm);
            // フォームを表示する
            bufForm.Show();
        }
        public override void allEnd()
        {
            // 保持されたフォームをすべて閉じる
            foreach (Form form in formList)
            {
                form.Close();
            }
            // フォームを空にする
            formList.Clear();
        }
    }
}
