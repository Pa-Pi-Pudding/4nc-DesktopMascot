using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    public abstract class CharacterSet
    {
        // メンバ変数
        protected int characterId;
        protected String characterName;

        // メソッド

        public CharacterSet(int id)
        {
            characterId = id;
        }

        public int getId() { return this.characterId; }
        public String getName() { return this.characterName; }

        // ↓例
        abstract public Reaction getTestReaction();
        abstract public Reaction getEchoReaction(String inputMessage);
    }
}
