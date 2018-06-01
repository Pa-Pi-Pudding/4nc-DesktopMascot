using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class TestCharacterSet : CharacterSet
    {
        public TestCharacterSet(int id) : base(id)
        {
            characterName = "TestCharacter1";
        }

        public override Reaction getTestReaction()
        {
            Reaction bufReact = new Reaction();
            bufReact.message = "これはテストメッセージ1です";

            return bufReact;
        }

        public override Reaction getEchoReaction(String inputMessage)
        {
            Reaction bufReact = new Reaction();
            bufReact.message = "あなたが入力したメッセージは、" + inputMessage + "ですね！";

            return bufReact;
        }
    }
}
