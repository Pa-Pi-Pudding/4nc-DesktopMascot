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
        protected String description;
        protected bool existForContextMenu;

        public Command(int id, String executeName)
        {
            this.id = id;
            this.executeName = executeName;
            existForContextMenu = false;
            description = null;
        }

        public int getId() { return this.id; }
        public String getExecuteName() { return this.executeName; }
        public String getDescription() { return this.description; }
        public bool getExistForContextMenu() { return this.existForContextMenu; }
        public abstract Reaction execute(String[] args, CharacterSet characterSet);
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
