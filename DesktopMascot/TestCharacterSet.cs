using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class TestCharacterSet : CharacterSet
    {
        public TestCharacterSet(int id, Controller controller) : base(id, controller)
        {
            characterName = "TestCharacter1";
        }

        public override void start()
        {
            // ここでフォームを生成する
            this.form = new TestCharacter1Form();

            this.form.TopLevel = false;
            this.controller.Controls.Add(form);
            this.form.Show();
            this.form.Visible = true;
            this.form.Location = new System.Drawing.Point(290, 90);
            this.form.BringToFront();

            return;
        }

        public override void stop()
        {
            this.form.Close();
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
