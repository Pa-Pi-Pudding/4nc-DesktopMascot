using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    public abstract class Command
    {
        protected int id;
        protected String executeName;

        public Command(int id, String executeName)
        {
            this.id = id;
            this.executeName = executeName;
        }

        public int getId() { return this.id; }
        public String getExecuteName() { return this.executeName; }
        public abstract Reaction execute(String[] args, CharacterSet characterSet);
    }
}
