﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class HitorigotoScreen : MainScreenMgr
    {
        public HitorigotoScreen(int id, List<SubScreenMgr> subScreenMgrList, Controller controller, List<Command> commandList) : base(id, subScreenMgrList, controller, commandList)
        {
            // コンストラクタでスクリーンの名前を設定する
            this.screenName = "Hitorigoto";

            // 作ったフォームを生成する
            this.form = new HitorigotoScreenForm(subScreenMgrList);

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
