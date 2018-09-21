using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class ExitCommand : Command
    {
        private Controller controller;
        public ExitCommand(int id, String executeName, Controller controller) : base(id, executeName)
        {
            this.controller = controller;
        }

        public override Reaction execute(List<String> args, CharacterSet characterSet)
        {
            Reaction bufReact;
            bufReact = new Reaction();
            return bufReact;
        }
    }
}
