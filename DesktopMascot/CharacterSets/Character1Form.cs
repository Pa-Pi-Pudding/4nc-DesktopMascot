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
    }
}
