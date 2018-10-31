using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    public abstract class CharacterSet
    {
        // メンバ変数
        protected int characterId;
        protected String characterName;
        protected Form form;
        protected Controller controller;
        protected CharacterInitializer characterInitializer;

        // メソッド

        public CharacterSet(int id, Controller controller, CharacterInitializer characterInitializer)
        {
            characterId = id;
            form = null;
            this.controller = controller;
            this.characterInitializer = characterInitializer;
        }

        public int getId() { return this.characterId; }
        public String getName() { return this.characterName; }


        abstract public void start();
        abstract public void stop();

        // ↓例
        virtual public Reaction getTestReaction() { return getNullReaction(); }
        virtual public Reaction getEchoReaction(String inputMessage) { return getNullReaction(); }
        virtual public Reaction getFuncStartReaction(String funcName) { return getNullReaction(); }
        virtual public Reaction getCommunicationReaction(String message) { return getNullReaction(); }
        virtual public Reaction getFuncAllDisplayReaction() { return getNullReaction(); }
        virtual public Reaction getChangeMainScreenReaction(String screenName) { return getNullReaction(); }
        virtual public Reaction getErrorReaction() { return getNullReaction(); }

        // 何の反応もしない関数 内部でだけ使用
        private Reaction getNullReaction()
        {
            Reaction buf = new Reaction();
            buf.message = null;
            return buf;
        }

    }
}
