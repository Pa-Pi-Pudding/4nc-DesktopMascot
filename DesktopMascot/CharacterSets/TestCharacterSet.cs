using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class TestCharacterSet : CharacterSet
    {
        // ここの変数はテスト用　コピペしないで
        TestCharacter1Form bufForm;
        int counter;
        Random rnd;

        public TestCharacterSet(int id, Controller controller, CharacterInitializer characterInitializer) : base(id, controller, characterInitializer)
        {
            // 必須
            characterName = "TestCharacter1";

            // テスト用　コピペしないで
            counter = 0;
            rnd = new Random();
        }

        public override void start()
        {
            // ここでフォームを生成する
            // フォームのコンストラクタにCharacterInitializerを渡せるようにしないとキャラクターを掴んで移動できない
            // 本来は以下のような感じになる
            // this.form = new TestCharacter1Form(characterInitializer);
            this.form = this.bufForm = new TestCharacter1Form(characterInitializer);

            // ここはそのままでOK
            this.form.TopLevel = false;
            this.controller.Controls.Add(form);
            this.form.Show();
            this.form.Visible = true;
            this.form.BringToFront();

            // 画像のサイズによって適宜変更する必要あり
            this.form.Location = new System.Drawing.Point(290, 90);


            // テスト用　コピペしないで
            //this.bufForm = new TestCharacter1Form(characterInitializer);

            return;
        }

        public override void stop()
        {
            // コピペでOK
            this.form.Close();
            this.form = null;

            // テスト用　コピペしないで
            this.bufForm = null;
            return;
        }


        // 以下はキャラクターごとの処理
        // メソッド名はそのままで、処理は適宜変えてください
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

        public override Reaction getChangeMainScreenReaction(String screenName)
        {
            Reaction bufReact = new Reaction();
            bufReact.message = screenName + "に変更します！";
            bufForm.setHelloAnimation();

            return bufReact;
        }

        public override Reaction getErrorReaction()
        {
            Reaction bufReact = new Reaction();
            bufReact.message = "エラーみたいです。";
            bufForm.setWhatAnimation();

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
