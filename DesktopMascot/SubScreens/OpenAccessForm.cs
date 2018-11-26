using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace DesktopMascot
{
    public partial class OpenAccessForm : Form
    {
        public OpenAccessForm()
        {
            InitializeComponent();
        }

        private void OpenAccessForm_Load(object sender, EventArgs e)
        {
            //ListViewの表示形式をDetails(詳細表示に設定)
            listView1.View = View.Details;

            //実行ファイルのあるディレクトリを取得
            string CurrentDir = System.IO.Directory.GetCurrentDirectory();
            String csvfilepath = CurrentDir + @"\openlistfile.csv";

            //CSVファイルが有るかどうか調べる
            if (System.IO.File.Exists(csvfilepath))
            {
                //存在する場合
                CSVRead_ListviewAdd();

            }
            else
            {
                //存在しない場合
                MessageBox.Show("保存ファイルが存在しないので新しく作成します。");
                CreateNewCSV();

            }

        }// OpenAccessForm_Load __ END __



        //CSVを読み込んで、ListViewに表示する。
        public void CSVRead_ListviewAdd()
        {
            //最初にリストビューをクリアな状態にする。
            listView1.Items.Clear();

            //実行ファイルのあるディレクトリを取得
            string CurrentDir = System.IO.Directory.GetCurrentDirectory();
            string csvfilepath = CurrentDir + @"\openlistfile.csv";

            //CSVファイルを読み込む
            System.IO.StreamReader csvread = new System.IO.StreamReader(
                    csvfilepath,
                    System.Text.Encoding.GetEncoding("shift_jis"));



            String filedata;
            //1行ずつ読み込む
            while ((filedata = csvread.ReadLine()) != null)
            {
                //カンマまで文字列分割
                string[] csvdata = filedata.Split(',');

                //CSVが空(つまりvaluesが空)の場合は、ハッシュテーブルには空値を入れておく
                if (csvdata[0] == "")
                {
                    //何もしない。
                    //ここは、新しくCSVを開いた時に(CSVの中身は空なので)実行される。
                }
                else
                {
                    //リストビューに追加
                    ListViewItem listdata = new ListViewItem();
                    listdata.Text = csvdata[0];
                    listdata.SubItems.Add(csvdata[1]);
                    listdata.SubItems.Add(csvdata[2]);
                    listView1.Items.Add(listdata);
                }
            }

            csvread.Close();


        }//CSVRead_ListviewAdd() __END__


        //空のCSVファイルを作成する。
        private void CreateNewCSV()
        {
            //実行ファイルのあるディレクトリを取得
            string CurrentDir = System.IO.Directory.GetCurrentDirectory();
            string csvfilepath = CurrentDir + @"\openlistfile.csv";

            //CSVファイル読み込み
            System.IO.StreamWriter csvwrite = new System.IO.StreamWriter(
                csvfilepath, false,
                System.Text.Encoding.GetEncoding("shift_jis"));

            //CSVに追記
            csvwrite.WriteLine("");
            //CSV閉じる
            csvwrite.Close();

        }//CreateNewCSV() __END__

        private void button2_Click(object sender, EventArgs e)
        {
            using (SubScreens.OpenAccess.AddWindow addwindow = new SubScreens.OpenAccess.AddWindow())
            {
                addwindow.ShowDialog();

                //Form2で設定されたプロパティから値を反映させる。
                //this.listView1.Items.Add(f2.InputText);
                addwindow.Dispose();
            }

            //読み込み直す。
            CSVRead_ListviewAdd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("検索したい起動コマンドを入力して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    }
                    else
                    {
                        ht.Add(values[1], values[2]);
                    }

                }//while end

                csvread.Close();

                //起動コマンドの存在を調べる。
                if (ht.ContainsKey(textBox1.Text))
                {
                    //存在する時
                    MessageBox.Show("アクセスパスは\"" + ht[textBox1.Text].ToString() + "\"です");
                }
                else
                {
                    //存在しない時
                    MessageBox.Show("\"" + textBox1.Text.ToString() + "\"は登録されていません。");
                }

                textBox1.Clear();
            }
        }

        private void 削除DToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //どれかしらの項目が選択されているかどうか
            if (listView1.SelectedItems.Count == 0)
            {
                //何も選択されていない時
                MessageBox.Show("削除したい行を選択して下さい。");

            }
            else
            {
                // 選択されているリストを取得しリストビューから削除する
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                }

                //CSVに書き込む
                //実行ファイルのあるディレクトリを取得
                string CurrentDir = System.IO.Directory.GetCurrentDirectory();
                String csvfilepath = CurrentDir + @"\openlistfile.csv";

                //CSVファイル書き込み
                System.IO.StreamWriter csvwrite = new System.IO.StreamWriter(
                    csvfilepath, false,
                    System.Text.Encoding.GetEncoding("shift_jis"));

                string items = "";      //種類
                string subitem = "";    //起動コマンド
                string subitem2 = "";   //パス
                foreach (ListViewItem item in listView1.Items)
                {

                    //種類
                    items = item.Text.ToString();
                    //起動コマンド
                    subitem = item.SubItems[1].Text.ToString();
                    //パス
                    subitem2 = item.SubItems[2].Text.ToString();

                    //CSVに追記
                    csvwrite.WriteLine("{0},{1},{2}", items, subitem, subitem2);

                }

                csvwrite.Close();

                //読み込みし直し
                CSVRead_ListviewAdd();

            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            access();
        }

        private void access()
        {
            //どれかしらの項目が選択されているかどうか
            //int idx = 0;
            if (listView1.SelectedItems.Count == 0)
            {
                //何も選択されていない時
                //何もしない

            }
            else
            {

                //選択されている項目数を取得
                int selectnum = listView1.SelectedItems.Count;
                int i = 0;

                //選択された項目数だけ繰り返しアクセス。
                for (i = 0; i < selectnum; i++)
                {
                    try
                    {
                        //MessageBox.Show(listView1.SelectedItems[0].Text.ToString());//行名取得
                        if (listView1.SelectedItems[i].Text.ToString() == "Webサイト")
                        {
                            //Webサイトにアクセス
                            System.Diagnostics.Process.Start(listView1.SelectedItems[i].SubItems[2].Text.ToString());

                        }
                        else
                        {
                            //ディレクトリを展開
                            System.Diagnostics.Process.Start(listView1.SelectedItems[i].SubItems[2].Text.ToString());

                        }
                    }
                    catch (Win32Exception)
                    {
                        MessageBox.Show("指定されたアクセス先が存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //押されたキーがエンターの場合
                access();

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //押されたボタンがエンターの場合
                //検索ボタンと同じ処理をする。
                button2_Click(sender, e);

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
