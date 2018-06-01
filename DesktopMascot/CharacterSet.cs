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

        // メソッド

        public CharacterSet(int id)
        {
            characterId = id;
            form = null;
        }

        public int getId() { return this.characterId; }
        public String getName() { return this.characterName; }

        abstract public void start();
        abstract public void stop();

        // ↓例
        abstract public Reaction getTestReaction();
        abstract public Reaction getEchoReaction(String inputMessage);


    }
}
