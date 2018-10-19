using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    // コンテキストメニューに存在するコマンド用のソース
    // そうでない場合はコピペ厳禁
    class CloseMScrCommand : Command
    {
        private Controller controller;
        public CloseMScrCommand(int id, String executeName, Controller controller) : base(id, executeName)
        {
            this.controller = controller;
            this.description = "メインスクリーンを閉じます。";

            // コンテキストメニューに存在するときだけコピペ
            this.existForContextMenu = true;
        }

        public override Reaction execute(String[] args, CharacterSet characterSet)
        {
            Reaction bufReact;
            bufReact = new Reaction();

            bufReact = characterSet.getErrorReaction();

            if (args.Length < 2)
            {
                return bufReact;
            }


            controller.endMainScreen();

            return bufReact;
        }

        public override ToolStripMenuItem getToolStripMenuItem()
        {
            ToolStripMenuItem bufTsi = new ToolStripMenuItem();

            bufTsi.Text = this.executeName;
            bufTsi.ToolTipText = this.description;
            bufTsi.Click += this.contextMenuEvent;

            return bufTsi;
        }

        public void contextMenuEvent(object sender, EventArgs e)
        {
            controller.endMainScreen();

            return;
        }
    }
}
