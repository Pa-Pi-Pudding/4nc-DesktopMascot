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

        public override Reaction execute(String[] args, CharacterSet characterSet)
        {
            Reaction bufReact;
            bufReact = new Reaction();
            bufReact.message = "no message";

            this.controller.endApplication();
            return bufReact;
        }
    }
}
