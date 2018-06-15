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
        protected String screenDescription;
        protected List<Form> formList;
        protected CharacterSet characterSet;

        // メソッド
        public SubScreenMgr(int id)
        {
            screenId = id;
            screenName = null;
            screenDescription = null;
            formList = new List<Form>();
            characterSet = null;
        }
        public int getId() { return this.screenId; }
        public String getName() { return this.screenName; }
        public String getDescription() { return this.screenDescription; }
        public void setCharacterSet(CharacterSet characterSet) { this.characterSet = characterSet; }
        abstract public void start();
        abstract public void allEnd();
    }
}
