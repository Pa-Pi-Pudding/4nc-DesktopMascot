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
    public partial class TestCharacter1Form : Form
    {
        enum AnimationMode { DEFAULT, HELLO, WHAT, ANGRY, SURPRISED };
        private AnimationMode mode;
        private int animeCounter;

        // コンストラクタ内のCharacterInitializerの記述のみ必要になる
        // それ以外は自由にどうぞ
        public TestCharacter1Form(CharacterInitializer characterInitializer)
        {
            mode = AnimationMode.DEFAULT;
            animeCounter = 0;
            InitializeComponent();

            // 以下は最後に呼び出すこと（正確にはInitializeComponentの後に呼び出す）

            // 掴んで移動が出来るようになる
            characterInitializer.initCharaPictureBox(pictureBox1);
            // 右クリックでコンテキストメニューを表示できるようになる
            characterInitializer.addContextMenu(this.contextMenuStrip1);

        }

        public void setHelloAnimation()
        {
            mode = AnimationMode.HELLO;
            animeCounter = 0;
            return;
        }

        public void setAngryAnimation()
        {
            mode = AnimationMode.ANGRY;
            animeCounter = 0;
            return;
        }

        public void setSurprisedAnimation()
        {
            mode = AnimationMode.SURPRISED;
            animeCounter = 0;
            return;
        }

        public void setWhatAnimation()
        {
            mode = AnimationMode.WHAT;
            animeCounter = 0;
            return;
        }

        private void TestCharacter1Form_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            setWhatAnimation();
        }

        private void timerLoop(object sender, EventArgs e)
        {
            if(mode != AnimationMode.DEFAULT)
            {
                animeCounter++;

                if(animeCounter > 10)
                {
                    animeCounter = 0;
                    mode = AnimationMode.DEFAULT;
                }
            }

            switch (mode)
            {
                case AnimationMode.DEFAULT:
                    this.pictureBox1.Image = Properties.Resources.TestCharacter1_default;
                    break;
                case AnimationMode.HELLO:
                    this.pictureBox1.Image = Properties.Resources.TestCharacter1_hello;
                    break;
                case AnimationMode.WHAT:
                    this.pictureBox1.Image = Properties.Resources.TestCharacter1_what;
                    break;
                case AnimationMode.ANGRY:
                    this.pictureBox1.Image = Properties.Resources.TestCharacter1_angry;
                    break;
                case AnimationMode.SURPRISED:
                    this.pictureBox1.Image = Properties.Resources.TestCharacter1_surprised;
                    break;
                default:
                    break;
            }

            return;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
