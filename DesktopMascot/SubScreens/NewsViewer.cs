using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesktopMascot
{
    class NewsViewer : SubScreenMgr
    {
        public NewsViewer(int id) : base(id)
        {
            // コンストラクタでスクリーンの名前を設定する
            screenName = "Newsviewer";
            // コンストラクタでスクリーンの機能について軽い説明を入れる。
            screenDescription = "hoge";
        }

        public override void start()
        {
            Form bufForm = new NewsViewerForm();
            // 起動させるフォームを保持しておく
            formList.Add(bufForm);
            // フォームを表示する
            bufForm.Show();
        }
        public override void allEnd()
        {
            // 保持されたフォームをすべて閉じる
            foreach(Form form in formList)
            {
                form.Close();
            }
            // フォームを空にする
            formList.Clear();
        }

    }

}