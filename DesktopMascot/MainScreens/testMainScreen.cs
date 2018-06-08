using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class TestMainScreen : MainScreenMgr
    {
        public TestMainScreen(int id, List<SubScreenMgr> subScreenMgrList, Controller controller) : base(id, subScreenMgrList, controller)
        {
            // コンストラクタでスクリーンの名前を設定する
            this.screenName = "TestName1";

            // 作ったフォームを生成する
            this.form = new TestMainScreenForm1(subScreenMgrList);

            // このタイミングで呼び出し
            // コンストラクタ以外でこのinitializeを呼び出しても無駄になる
            initialize();
        }

        public override void start()
        {
            form.Visible = true;
        }

        public override void stop()
        {
            form.Visible = false;
        }
    }
}
