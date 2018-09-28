using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    // ヘルプコマンド
    class HelpCommand : Command
    {
        private List<SubScreenMgr> subScreenMgrList;
        public HelpCommand(int id, String executeName, List<SubScreenMgr> subScreenMgrList) : base(id, executeName)
        {
            this.subScreenMgrList = subScreenMgrList;
            this.description = "ヘルプを表示します";
        }

        public override Reaction execute(String[] args, CharacterSet characterSet)
        {
            Reaction mainReact = new Reaction();
            Reaction bufReact = new Reaction();

            bufReact = characterSet.getFuncAllDisplayReaction();
            mainReact.message += bufReact.subMessage + "\n\r" + "\n\r";
            foreach (SubScreenMgr item in subScreenMgrList)
            {
                mainReact.message += item.getName() + "\t" + "..." + item.getDescription() + "\n\r";
            }
            mainReact.message += "\n\r";

            mainReact.message += bufReact.message;

            return mainReact;
        }
    }
}
