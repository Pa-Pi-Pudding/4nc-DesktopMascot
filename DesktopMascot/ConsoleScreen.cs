using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class ConsoleScreen : MainScreenMgr
    {
        public ConsoleScreen(int id, List<SubScreenMgr> subScreenMgrList, Controller controller) : base(id, subScreenMgrList, controller)
        {
            // コンストラクタでスクリーンの名前を設定する
            this.screenName = "ConsoleScreen";

            // 作ったフォームを生成する
            this.form = new ConsoleScreenForm(subScreenMgrList, this.characterSet);

            // このタイミングで呼び出し
            // コンストラクタ以外でこのinitializeを呼び出しても無駄になる
            initialize();
        }

        public override void setCharacterSet(CharacterSet characterSet)
        {
            this.characterSet = characterSet;
            ConsoleScreenForm bufForm = (ConsoleScreenForm)this.form;
            bufForm.setCharacterSet(characterSet);
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
