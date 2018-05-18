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
        private bool isInit;

        // メソッド
        public MainScreenMgr(Controller controller)
        {
            this.screenId = -1;
            this.screenName = null;
            this.form = null;
            this.controller = controller;
            this.isInit = false;
        }
        public int getMainScreenMgrID() { return screenId; }
        public String getMainScreenMgrName() { return screenName; }

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
            this.form.Visible = false;
            this.form.Show();
            this.form.BringToFront();
            this.isInit = true;
        }
    }
}
