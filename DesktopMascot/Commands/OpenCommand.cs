using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace DesktopMascot
{
    // ヘルプコマンド
    class OpenCommand : Command
    {

        public OpenCommand(int id, String executeName): base(id, executeName)
        {
            this.description = "コマンドに従ってアクセスします。";

        }

        public override Reaction execute(String[] args, CharacterSet characterSet)
        {
            //MessageBox.Show(args[1]);//[0]は"open"。[1]がアクセスコマンド部分

            Reaction mainReact = new Reaction();//キャラクタの返答メッセージを格納する変数
            mainReact.message = "";



            if (args.Length == 1 ||args[1] == "")
            {
                //MessageBox.Show("検索したい起動コマンドを入力して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mainReact.message = "検索したい起動コマンドを入力して下さい。";
            }
            else
            {

                //実行ファイルのあるディレクトリを取得
                string CurrentDir = System.IO.Directory.GetCurrentDirectory();
                String csvfilepath = CurrentDir + @"\openlistfile.csv";

                System.IO.StreamReader csvread = new System.IO.StreamReader(
                        csvfilepath,
                        System.Text.Encoding.GetEncoding("shift_jis"));

                Hashtable ht = new Hashtable();
                Hashtable ht2 = new Hashtable();

                //1行ずつ読み込む

                while (!csvread.EndOfStream)
                {
                    //ファイルから1行読み込む
                    var line = csvread.ReadLine();
                    //読み込んだ一行をカンマごとに分けて配列に格納する
                    var values = line.Split(',');
                    

                    //CSVが空(つまりvaluesが空)の場合は、ハッシュテーブルには空値を入れておく
                    if (values[0] == "")
                    {
                        ht.Add("", "");
                        ht2.Add("", "");
                    }
                    else
                    {
                        ht.Add(values[1], values[2]);
                        ht2.Add(values[1], values[0]);
                    }

                }//while end

                csvread.Close();

                //起動コマンドの存在を調べる。
                if (ht.ContainsKey(args[1]))
                {
                    //存在する時
                    //MessageBox.Show("アクセスパスは\"" + ht[args[1]].ToString() + "\"です");

                    /*
                    if (ht2[args[1]].ToString() == "Webサイト")
                    {
                        //Webサイトにアクセス
                        System.Diagnostics.Process.Start(ht[args[1]].ToString());

                    }
                    else if(ht2[args[1]].ToString() == "ディレクトリ")
                    {

                    }
                    */
                    System.Diagnostics.Process.Start(ht[args[1]].ToString());
                    mainReact.message = "\"" + args[1] + "\"にアクセスします。";

                }
                else
                {
                    //存在しない時
                    //MessageBox.Show("\"" + args[1] + "\"は登録されていません。");
                    mainReact.message = "\"" + args[1] + "\"は登録されていません。";
                }

                
            }




            


            /*
            Reaction mainReact = new Reaction();
            Reaction bufReact = new Reaction();

            bufReact = characterSet.getFuncAllDisplayReaction();
            mainReact.message += bufReact.subMessage + "\n\r" + "\n\r";
            foreach (SubScreenMgr item in subScreenMgrList)
            {
                mainReact.message += item.getName() + "\t" + "..." + item.getDescription() + "\n\r";
            }
            mainReact.message += "\n\r";

            mainReact.message += bufReact.message;

            return mainReact;
            */

            return mainReact;
        }
    }
}
