using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class Character1Set : CharacterSet
    {
        // ここの変数はテスト用　コピペしないで
        Character1Form bufForm;
        //int counter;
        //Random rnd;

        public Character1Set(int id, Controller controller, CharacterInitializer characterInitializer) : base(id, controller, characterInitializer)
        {
            // 必須
            characterName = "Character1";

            // テスト用　コピペしないで
            //counter = 0;
            //rnd = new Random();
        }

        public override void start()
        {
            // ここでフォームを生成する
            // フォームのコンストラクタにCharacterInitializerを渡せるようにしないとキャラクターを掴んで移動できない
            // 本来は以下のような感じになる
            // this.form = new TestCharacter1Form(characterInitializer);
            this.form = this.bufForm = new Character1Form(characterInitializer);

            // ここはそのままでOK
            this.form.TopLevel = false;
            this.controller.Controls.Add(form);
            this.form.Show();
            this.form.Visible = true;
            this.form.BringToFront();


            // 画像のサイズによって適宜変更する必要あり
            this.form.Location = new System.Drawing.Point(300, 40);


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
            //bufForm.setHelloAnimation();


            return bufReact;
        }

        public override Reaction getFuncStartReaction(String funcName)
        {

            Reaction bufReact = new Reaction();
            bufReact.message = funcName + "を起動します！";
            //bufForm.setHelloAnimation();

            return bufReact;
        }

        public override Reaction getCommunicationReaction(String message)
        {
            Reaction bufReact = new Reaction();

            switch (message)
            {
                case "こんにちは":
                    bufReact.message = "こんにちは！";
                    //bufForm.setHelloAnimation();
                    break;
                case "お前誰だよ":
                    bufReact.message = "失礼ですね！？私はテスト君です！！";
                    //bufForm.setAngryAnimation();
                    break;
                case "hoge":
                    bufReact.message = "適当にhogeを入れているんですね！わかりますよ！";
                    //bufForm.setHelloAnimation();
                    break;
                case "くぁｗせｄｒｆｔｇｙふじこｌｐ；":
                    bufReact.message = "大丈夫ですか？お気を確かに！";
                    //bufForm.setSurprisedAnimation();
                    break;
                default:
                    bufReact.message = "すみません...メッセージの意図が分かりません(汗";
                    break;

            }


            return bufReact;
        }




        public override Reaction getFuncAllDisplayReaction()
        {
            Reaction bufReact = new Reaction();
            bufReact.message = "以上になります。";
            bufReact.subMessage = "機能一覧を表示しますね。\r\n";
            bufReact.subMessage += "あああ\r\n";
            //bufForm.setHelloAnimation();
            return bufReact;
        }
    }
}
