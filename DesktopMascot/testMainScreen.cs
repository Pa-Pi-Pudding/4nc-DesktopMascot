using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class TestMainScreen : MainScreenMgr
    {
        public TestMainScreen(int id, Controller controller) : base(controller)
        {
            this.screenId = id;
            this.screenName = "TestName1";
            this.form = new TestMainScreenForm1();
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
