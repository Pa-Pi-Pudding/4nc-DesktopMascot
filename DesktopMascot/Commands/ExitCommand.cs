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
    class ExitCommand : Command
    {
        private Controller controller;
        public ExitCommand(int id, String executeName, Controller controller) : base(id, executeName)
        {
            this.controller = controller;
            this.description = "アプリケーションを終了します";

            // コンテキストメニューに存在するときだけコピペ
            this.existForContextMenu = true;
        }

        public override Reaction execute(String[] args, CharacterSet characterSet)
        {
            Reaction bufReact;
            bufReact = new Reaction();
            bufReact.message = "no message";

            this.controller.endApplication();
            return bufReact;
        }

        public override ToolStripMenuItem getToolStripMenuItem()
        {
            ToolStripMenuItem bufTsi = new ToolStripMenuItem();

            bufTsi.Text = "終了";
            bufTsi.ToolTipText = this.description;
            bufTsi.Click += this.contextMenuEvent;

            return bufTsi;
        }

        public void contextMenuEvent(object sender, EventArgs e)
        {
            if (existForContextMenu)
            {
                execute(null, null);
            }
            return;
        }
    }
}
