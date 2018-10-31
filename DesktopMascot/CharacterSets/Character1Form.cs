using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    public partial class Character1Form : Form
    {
        //瞬き用差分画像
        Bitmap pic1 = Properties.Resources.character1;//初期
        Bitmap pic2 = Properties.Resources.character1_hanme;//半目
        Bitmap pic3 = Properties.Resources.character1_toji;//閉じ
        Bitmap pic4 = Properties.Resources.character1_smile;//笑顔

        //瞬き用カウント変数
        int blinktime = 100;

        //アニメーション用
        enum AnimationMode { DEFAULT, HELLO, WHAT, ANGRY, SURPRISED };
        private AnimationMode mode;
        //private int animeCounter;
        private int reaction_hold_time = 0;//インターバル50なので、1秒は20。


        public Character1Form(CharacterInitializer characterInitializer)
        {
            InitializeComponent();
            
            // 最後に呼び出すこと（正確にはInitializeComponentの後に呼び出す）
            // これを呼び出さないと掴んで移動が出来ない
            characterInitializer.initCharaPictureBox(pictureBox2);
            
            
        }

        private void Character1Form_Load(object sender, EventArgs e)
        {
            //透過をバックカラーに指定
            //this.BackColor = Color.FromArgb(0xFF, 0xFF, 0xFF);
            this.TransparencyKey = BackColor;

        }

        public void setWhatAnimation()
        {
            //mode = AnimationMode.WHAT;
            //animeCounter = 0;
            return;
        }


        private void blink_timer_Tick(object sender, EventArgs e)
        {
            blinktime--;

            if (this.pictureBox2.Image != @pic4)
            {
                if (blinktime == 16)
                {
                    //背景画像を指定する;
                    this.pictureBox2.Image = @pic2;
                }
                else if (blinktime == 14)
                {
                    this.pictureBox2.Image = @pic3;

                }
                else if (blinktime == 12)
                {
                    this.pictureBox2.Image = @pic2;

                }
                else if (blinktime == 10)
                {
                    this.pictureBox2.Image = @pic1;

                }
                else if (blinktime == -2)
                {
                    this.pictureBox2.Image = @pic2;

                }
                else if (blinktime == -3)
                {
                    this.pictureBox2.Image = @pic3;

                }
                else if (blinktime == -4)
                {
                    this.pictureBox2.Image = @pic2;

                }
                else if (blinktime == -5)
                {
                    this.pictureBox2.Image = @pic1;

                }
                else if (blinktime == -6)
                {
                    this.pictureBox2.Image = @pic2;

                }
                else if (blinktime == -7)
                {
                    this.pictureBox2.Image = @pic3;

                }
                else if (blinktime == -8)
                {
                    this.pictureBox2.Image = @pic2;

                }
                else if (blinktime == -9)
                {
                    this.pictureBox2.Image = @pic1;

                }
            }//if (this.pictureBox2.Image != @pic4)
            else
            {
                reaction_hold_time++;
                if (reaction_hold_time >= 100)
                {
                    this.pictureBox2.Image = @pic1;
                    reaction_hold_time = 0;
                }
            }


            if (blinktime == -10)
            {
                //初期値(宣言時の値)に戻す。
                blinktime = 100;
                
            }


        }//blink_timer_Tick　END

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Image = @pic4;
            //setWhatAnimation();
        }
    }
}
