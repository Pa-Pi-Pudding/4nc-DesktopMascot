using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    public abstract class MainScreenMgr
    {
        // メンバ
        protected int screenId;
        protected String screenName;
        protected Form form;
        protected Controller controller;
        protected CharacterSet characterSet;
        protected List<SubScreenMgr> subScreenMgrList;
        protected List<Command> commandList;
        private bool isInit;

        // メソッド
        public MainScreenMgr(int id, List<SubScreenMgr> subScreenMgrList, Controller controller, List<Command> commandList)
        {
            this.screenId = id;
            this.screenName = null;
            this.form = null;
            this.subScreenMgrList = subScreenMgrList;
            this.commandList = commandList;
            this.controller = controller;
            this.isInit = false;
        }
        public int getId() { return screenId; }
        public String getName() { return screenName; }
        virtual public void setCharacterSet(CharacterSet characterSet) { this.characterSet = characterSet; }

        abstract public void start();
        abstract public void stop();

        // 内部だけで使用

        // initialize関数はコンストラクタ内だけで使用する
        // それ以外の場面で使用してはいけない
        protected void initialize()
        {
            // すでに初期化済み（この関数が一度呼ばれている）なら何もしない
            if (isInit)
            {
                return;
            }

            // formが初期化されていない場合何もしない
            if(form == null)
            {
                return;
            }

            this.form.TopLevel = false;
            this.controller.Controls.Add(form);
            this.form.Show();
            this.form.Visible = false;
            this.form.BringToFront();
            this.isInit = true;
        }
    }
}
