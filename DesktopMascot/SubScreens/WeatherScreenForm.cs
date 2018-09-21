using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace DesktopMascot
{
    public partial class WeatherScreenForm : Form
    {
        ////////////////////////////////変数宣言
        string prefecture;
        string prefectures_id = "";




        public WeatherScreenForm()
        {
            InitializeComponent();
        }

        private void WeatherScreenForm_Load(object sender, EventArgs e)
        {
            string[] regions = { "北海道", "東北", "関東", "中部", "近畿", "中国", "四国", "九州/沖縄" };
            this.comboBox1.Items.AddRange(regions);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string region = comboBox1.Text;
            string[] prefectures = { };

            switch (region)
            {
                case "北海道":
                    prefectures = new string[] { "北海道" };
                    break;
                case "東北":
                    prefectures = new string[] { "青森", "岩手", "秋田", "宮城", "山形", "福島" };
                    break;
                case "関東":
                    prefectures = new string[] { "茨城", "栃木", "群馬", "埼玉", "千葉", "東京", "神奈川" };
                    break;
                case "中部":
                    prefectures = new string[] { "山梨", "長野", "新潟", "富山", "石川", "福井", "静岡", "愛知", "岐阜" };
                    break;
                case "近畿":
                    prefectures = new string[] { "三重", "滋賀", "京都", "大阪", "兵庫", "奈良", "和歌山" };
                    break;
                case "中国":
                    prefectures = new string[] { "鳥取", "島根", "岡山", "広島", "山口" };
                    break;
                case "四国":
                    prefectures = new string[] { "香川", "愛媛", "徳島", "高知" };
                    break;
                case "九州/沖縄":
                    prefectures = new string[] { "福岡", "佐賀", "長崎", "熊本", "大分", "宮崎", "鹿児島", "沖縄" };
                    break;
                default:
                    break;

            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(prefectures);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            prefecture = listBox1.Text;

            switch (prefecture)
            {
                case "北海道":
                    prefectures_id = "016010";
                    break;
                case "青森":
                    prefectures_id = "020010";
                    break;

                case "岩手":
                    prefectures_id = "030010";
                    break;

                case "秋田":
                    prefectures_id = "050010";
                    break;


                case "宮城":
                    prefectures_id = "040010";
                    break;

                case "山形":
                    prefectures_id = "060010";
                    break;

                case "福島":
                    prefectures_id = "070010";
                    break;

                case "茨城":
                    prefectures_id = "080010";
                    break;

                case "栃木":
                    prefectures_id = "090010";
                    break;

                case "群馬":
                    prefectures_id = "100010";
                    break;

                case "埼玉":
                    prefectures_id = "110010";
                    break;

                case "千葉":
                    prefectures_id = "120010";
                    break;


                case "東京":
                    prefectures_id = "130010";
                    break;

                case "神奈川":
                    prefectures_id = "140010";
                    break;

                case "山梨":
                    prefectures_id = "190010";
                    break;

                case "長野":
                    prefectures_id = "200010";
                    break;

                case "新潟":
                    prefectures_id = "150010";
                    break;

                case "富山":
                    prefectures_id = "160010";
                    break;

                case "石川":
                    prefectures_id = "170010";
                    break;

                case "福井":
                    prefectures_id = "180010";
                    break;

                case "静岡":
                    prefectures_id = "220010";
                    break;

                case "愛知":
                    prefectures_id = "230010";
                    break;

                case "岐阜":
                    prefectures_id = "210010";
                    break;

                case "三重":
                    prefectures_id = "240010";
                    break;

                case "滋賀":
                    prefectures_id = "250010";
                    break;

                case "京都":
                    prefectures_id = "260010";
                    break;

                case "大阪":
                    prefectures_id = "270000";
                    break;

                case "兵庫":
                    prefectures_id = "280010";
                    break;

                case "奈良":
                    prefectures_id = "290010";
                    break;

                case "和歌山":
                    prefectures_id = "300010";
                    break;

                case "鳥取":
                    prefectures_id = "310010";
                    break;

                case "島根":
                    prefectures_id = "320010";
                    break;

                case "岡山":
                    prefectures_id = "330010";
                    break;

                case "広島":
                    prefectures_id = "340010";
                    break;

                case "山口":
                    prefectures_id = "350010";
                    break;

                case "香川":
                    prefectures_id = "370010";
                    break;

                case "愛媛":
                    prefectures_id = "380010";
                    break;

                case "徳島":
                    prefectures_id = "360010";
                    break;

                case "高知":
                    prefectures_id = "390010";
                    break;

                case "福岡":
                    prefectures_id = "400010";
                    break;

                case "佐賀":
                    prefectures_id = "410010";
                    break;

                case "長崎":
                    prefectures_id = "420010";
                    break;

                case "熊本":
                    prefectures_id = "430010";
                    break;

                case "大分":
                    prefectures_id = "440010";
                    break;

                case "宮崎":
                    prefectures_id = "450010";
                    break;

                case "鹿児島":
                    prefectures_id = "460010";
                    break;

                case "沖縄":
                    prefectures_id = "471010";
                    break;

                default:
                    //this.button1.Enabled = true;
                    break;



            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("地域を選択してください", "エラー", MessageBoxButtons.OK);
            }
            else if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("都道府県を選択してください", "エラー", MessageBoxButtons.OK);
            }
            else
            {

                try
                {
                    string todayweather = "";
                    //MessageBox.Show(prefectures_id);
                    ////今日の天気予報の取得   
                    string baseUrl = "http://weather.livedoor.com/forecast/webservice/json/v1";
                    //東京都のID
                    //string cityname = "130010";
                    string url = $"{baseUrl}?city={prefectures_id}";
                    string json = new HttpClient().GetStringAsync(url).Result;
                    JObject jobj = JObject.Parse(json);

                    todayweather = (string)((jobj["forecasts"][0]["telop"] as JValue).Value);//今日の天気の取得
                                                                                             //label2.Text = todayweather;

                    MessageBox.Show(todayweather);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("接続エラーが発生しました。", "エラー", MessageBoxButtons.OK);
                }


            }
        }
    
    }
}
