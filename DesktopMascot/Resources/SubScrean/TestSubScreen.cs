using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    class TestSubScreen : SubScreenMgr
    {
        public TestSubScreen(int id) : base(id)
        {
            // コンストラクタでスクリーンの名前を設定する
            screenName = "TestSubScreen1";
            // コンストラクタでスクリーンの機能について軽い説明を入れる。
            screenDescription = "これはテスト用の画面です。";
        }

        public override void start()
        {
            Form bufForm = new TestSubScreenForm1();
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
