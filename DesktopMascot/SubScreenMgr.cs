using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    public abstract class SubScreenMgr
    {
        // メンバ変数
        protected int screenId;
        protected String screenName;
        protected List<Form> formList;
        protected CharacterSet characterSet;

        // メソッド
        public SubScreenMgr()
        {
            screenId = -1;
            screenName = null;
            formList = null;
            characterSet = null;
        }
        public int getSubScreenMgrID() { return this.screenId; }
        public String getSubScreenMgrName() { return this.screenName; }
        public void setCharacter(CharacterSet characterSet) { this.characterSet = characterSet; }
        abstract public void start();
        abstract public void allEnd();
    }
}
