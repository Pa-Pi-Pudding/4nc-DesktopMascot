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
            //this.form = new 
        }

        public override void start()
        {
            return;
        }

        public override void stop()
        {
            return;
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
