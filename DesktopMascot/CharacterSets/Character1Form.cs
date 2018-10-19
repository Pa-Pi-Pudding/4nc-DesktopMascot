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

        //瞬き用カウント変数
        int blinktime = 100;
        

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

        private void blink_timer_Tick(object sender, EventArgs e)
        {
            blinktime--;

            if(blinktime == 50)
            {
                //MessageBox.Show("50だよ");
            }



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


            if (blinktime == -10)
            {
                //初期値(宣言時の値)に戻す。
                blinktime = 100;
                
            }
        }
    }
}
