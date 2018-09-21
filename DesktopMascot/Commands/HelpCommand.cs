using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class HelpCommand : Command
    {
        private List<SubScreenMgr> subScreenMgrs;
        public HelpCommand(int id, String executeName, List<SubScreenMgr> subScreenMgrs) : base(id, executeName)
        {
            this.subScreenMgrs = subScreenMgrs;
        }

        public override Reaction execute(List<String> args, CharacterSet characterSet)
        {
            Reaction bufReact;
            bufReact = new Reaction();
            return bufReact;
        }
    }
}
