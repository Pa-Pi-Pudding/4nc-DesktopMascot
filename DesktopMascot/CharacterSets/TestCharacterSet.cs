using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class TestCharacterSet : CharacterSet
    {
        TestCharacter1Form bufForm;
        int counter;
        Random rnd;

        public TestCharacterSet(int id, Controller controller, CharacterInitializer characterInitializer) : base(id, controller, characterInitializer)
        {
            counter = 0;
            characterName = "TestCharacter1";
            rnd = new Random();
        }

        public override void start()
        {
            // ここでフォームを生成する
            this.form = this.bufForm = new TestCharacter1Form(characterInitializer);

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
            this.form = this.bufForm = null;
            return;
        }

        public override Reaction getTestReaction()
        {
            // ここの中の処理はマネしないように
            Reaction bufReact = new Reaction();
            bufReact.message = "これはテストメッセージ1です";

            return bufReact;
        }

        public override Reaction getEchoReaction(String inputMessage)
        {
            // ここの中の処理はマネしないように
            Reaction bufReact = new Reaction();
            bufReact.message = "あなたが入力したメッセージは、" + inputMessage + "ですね！";
            bufForm.setHelloAnimation();


            return bufReact;
        }

        public override Reaction getFuncStartReaction(String funcName) {

            Reaction bufReact = new Reaction();
            bufReact.message = funcName + "を起動します！";
            bufForm.setHelloAnimation();

            return bufReact;
        }

        public override Reaction getCommunicationReaction(String message)
        {
            Reaction bufReact = new Reaction();
            
            switch (message)
            {
                case "こんにちは":
                    bufReact.message = "こんにちは！";
                    bufForm.setHelloAnimation();
                    break;
                case "お前誰だよ":
                    bufReact.message = "失礼ですね！？私はテスト君です！！";
                    bufForm.setAngryAnimation();
                    break;
                case "hoge":
                    bufReact.message = "適当にhogeを入れているんですね！わかりますよ！";
                    bufForm.setHelloAnimation();
                    break;
                case "くぁｗせｄｒｆｔｇｙふじこｌｐ；":
                    bufReact.message = "大丈夫ですか？お気を確かに！";
                    bufForm.setSurprisedAnimation();
                    break;
                default:
                    counter++;
                    if (counter < 50)
                    {
                        bufReact.message = "メッセージがわかりません…";
                        bufForm.setWhatAnimation();
                    }
                    else
                    {
                        bufReact.message = "結構間違えてますよ！";
                        bufForm.setWhatAnimation();
                        counter = 0;
                    }
                    break;
            }


            return bufReact;
        }

        public override Reaction getFuncAllDisplayReaction()
        {
            Reaction bufReact = new Reaction();
            bufReact.message = "機能は以上です！";
            bufReact.subMessage = "機能を一覧表示します！";
            bufForm.setHelloAnimation();
            return bufReact;
        }
    }
}
