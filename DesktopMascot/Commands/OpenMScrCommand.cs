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
        private Controller controller;
        public OpenMScrCommand(int id, String executeName, List<MainScreenMgr> mainScreenMgrList, Controller controller) : base(id, executeName)
        {
            this.mainScreenMgrList = mainScreenMgrList;
            this.controller = controller;
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
                    break;
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
                ToolStripMenuItemWithMainScrInfo dropDownTsi = new ToolStripMenuItemWithMainScrInfo();

                dropDownTsi.Text = item.getName();
                dropDownTsi.ToolTipText = "メインスクリーンを" + item.getName() + "に変更します";
                dropDownTsi.Click += this.contextMenuEvent;
                dropDownTsi.setMainScreenId(item.getId());

                bufTsi.DropDownItems.Add(dropDownTsi);
            }

            return bufTsi;
        }

        public void contextMenuEvent(object sender, EventArgs e)
        {
            ToolStripMenuItemWithMainScrInfo tsmiwmsi = (ToolStripMenuItemWithMainScrInfo)sender;
            int mainScreenId = tsmiwmsi.getMainScreenId();

            controller.endMainScreen();
            controller.startMainScreen(mainScreenId);

            return;
        }

        private class ToolStripMenuItemWithMainScrInfo : ToolStripMenuItem
        {
            public int mainScreenId;
            public void setMainScreenId(int id) { this.mainScreenId = id; }
            public int getMainScreenId() { return mainScreenId; }
        }
    }
}
