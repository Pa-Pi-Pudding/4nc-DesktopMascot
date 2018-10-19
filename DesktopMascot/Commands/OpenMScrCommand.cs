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
    class OpenMScrCommand : Command
    {
        private List<MainScreenMgr> mainScreenMgrList;
        public OpenMScrCommand(int id, String executeName, List<MainScreenMgr> mainScreenMgrList) : base(id, executeName)
        {
            this.mainScreenMgrList = mainScreenMgrList;
            this.description = "メインスクリーンを変更します。";

            // コンテキストメニューに存在するときだけコピペ
            this.existForContextMenu = true;
        }

        public override Reaction execute(String[] args, CharacterSet characterSet)
        {
            Reaction bufReact;
            bufReact = new Reaction();

            bufReact = characterSet.getErrorReaction();

            foreach(MainScreenMgr item in mainScreenMgrList)
            {
                if(args[1] == item.getName())
                {
                    bufReact = characterSet.getChangeMainScreenReaction(item.getName());
                }
            }

            return bufReact;
        }

        public override ToolStripMenuItem getToolStripMenuItem()
        {
            ToolStripMenuItem bufTsi = new ToolStripMenuItem();

            bufTsi.Text = this.executeName;
            bufTsi.ToolTipText = this.description;

            foreach (MainScreenMgr item in mainScreenMgrList)
            {
                ToolStripMenuItem dropDownTsi = new ToolStripMenuItem();

                dropDownTsi.Text = item.getName();
                dropDownTsi.ToolTipText = "キャラクターを" + item.getName() + "に変更します";
                dropDownTsi.Click += this.contextMenuEvent;

                bufTsi.DropDownItems.Add(dropDownTsi);
            }

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
