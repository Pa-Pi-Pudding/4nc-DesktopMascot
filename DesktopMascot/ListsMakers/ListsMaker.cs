using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    public abstract class ListsMaker
    {
        protected List<MainScreenMgr> mainScreenMgrList;
        protected List<SubScreenMgr> subScreenMgrList;
        protected List<CharacterSet> characterSetList;
        protected List<IDAndName> mainScreenMgrIdAndNameList;
        protected List<IDAndName> characterSetIdAndNameList;
        protected CharacterInitializer characterInitializer;
        protected List<Command> commandList;
        protected Form controller;

        public ListsMaker(Controller controller, CharacterInitializer characterInitializer)
        {
            this.mainScreenMgrList = null;
            this.subScreenMgrList = null;
            this.characterSetList = null;
            this.mainScreenMgrIdAndNameList = null;
            this.characterSetIdAndNameList = null;
            this.characterInitializer = characterInitializer;
            this.commandList = null;
            this.controller = controller;
        }

        public List<MainScreenMgr> getMainScreenMgrList()
        {
            if(mainScreenMgrList != null)
            {
                return mainScreenMgrList;
            }
            return null;
        }
        public List<SubScreenMgr> getSubScreenMgrList()
        {
            if (subScreenMgrList != null)
            {
                return subScreenMgrList;
            }
            return null;
        }
        public List<CharacterSet> getCharacterSetList()
        {
            if (characterSetList != null)
            {
                return characterSetList;
            }
            return null;
        }
        public List<IDAndName> getMainScreenMgrIDAndNameList()
        {
            if (mainScreenMgrIdAndNameList != null)
            {
                return mainScreenMgrIdAndNameList;
            }
            return null;
        }
        public List<IDAndName> getCharacterSetIDAndNameList()
        {
            if (characterSetIdAndNameList != null)
            {
                return characterSetIdAndNameList;
            }
            return null;
        }
        public List<Command> getCommandList()
        {
            if(commandList != null)
            {
                return commandList;
            }
            return null;
        }
    }
}
