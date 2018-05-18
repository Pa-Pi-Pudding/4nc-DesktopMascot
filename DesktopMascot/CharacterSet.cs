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
        protected List<Reaction> reactionList;

        // メソッド
        // ↓例
        abstract public Reaction getReactionSet1();
    }
}
