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

namespace DesktopMascot.SubScreens.OpenAccess
{
    public partial class AddWindow : Form
    {
        public AddWindow()
        {
            InitializeComponent();

            //ComboBoxの初期値の設定
            this.comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //3項目のいずれかが空欄ならエラー
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("起動コマンドおよびアクセスパスを入力して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("起動コマンドを入力して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("アクセスパスを入力して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("種類項目を選択して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //CSVが置いてあるディレクトリを取得
                string CurrentDir = System.IO.Directory.GetCurrentDirectory();
                String csvfilepath = CurrentDir + @"\openlistfile.csv";

                //起動コマンドが既に登録されているかどうか判定
                Hashtable ht = new Hashtable();
                
                //CSVファイル読み込み
                System.IO.StreamReader csvread = new System.IO.StreamReader(
                        csvfilepath,
                        System.Text.Encoding.GetEncoding("shift_jis"));


                //CSVファイルの終端まで読み込み続ける。
                while (!csvread.EndOfStream)
                {
                    //1行読み込む
                    var line = csvread.ReadLine();
                    //読み込んだ一行をカンマごとに分けて配列に格納する
                    string[] values = line.Split(',');

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


                //CSVファイル書き込み
                System.IO.StreamWriter csvwrite = new System.IO.StreamWriter(
                    csvfilepath, true,
                    System.Text.Encoding.GetEncoding("shift_jis"));


                //起動コマンドの存在を調べる。
                if (ht.ContainsKey(textBox1.Text))
                {
                    //Hitする時
                    //起動コマンドは重複してはいけないので(仕様)、エラー表示
                    MessageBox.Show("その起動コマンドは既に登録されています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    //Hitしない時
                    //CSVに追記
                    csvwrite.WriteLine("{0},{1},{2}", comboBox1.Text, textBox1.Text, textBox2.Text);

                    this.Close();

                }


                csvwrite.Close();



            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
