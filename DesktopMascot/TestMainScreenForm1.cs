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
    public partial class TestMainScreenForm1 : Form
    {
        List<SubScreenMgr> subScreenMgrList;
        public TestMainScreenForm1(List<SubScreenMgr> subScreenMgrList)
        {
            this.subScreenMgrList = subScreenMgrList;
            InitializeComponent();
        }

        private void TestMainScreenForm1_Load(object sender, EventArgs e)
        {
            Button bufButton;

            for (int i = 0; i < subScreenMgrList.Count(); i++)
            {
                //Buttonクラスのインスタンスを作成する
                bufButton = new System.Windows.Forms.Button();

                //Buttonコントロールのプロパティを設定する
                bufButton.Name = subScreenMgrList[i].getName();
                bufButton.Text = subScreenMgrList[i].getName();
                //サイズと位置を設定する
                bufButton.Location = new Point(10, 50 * (i + 1));
                bufButton.Size = new System.Drawing.Size(200, 50);

                bufButton.Click += new System.EventHandler(create_button_Click);

                //フォームに追加する
                this.Controls.Add(bufButton);


                //Buttonクラスのインスタンスを作成する
                bufButton = new System.Windows.Forms.Button();

                //Buttonコントロールのプロパティを設定する
                bufButton.Name = subScreenMgrList[i].getName();
                bufButton.Text = "delete";
                //サイズと位置を設定する
                bufButton.Location = new Point(210, 50 * (i + 1));
                bufButton.Size = new System.Drawing.Size(50, 50);

                bufButton.Click += new System.EventHandler(delete_button_Click);

                //フォームに追加する
                this.Controls.Add(bufButton);
            }
        }

        private void create_button_Click(object sender, EventArgs e)
        {
            Button bufButton = (Button)sender;
            int i = bufButton.Location.Y / 50 - 1;
            if (0 <= i && i < subScreenMgrList.Count())
            {
                subScreenMgrList[i].start();
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            Button bufButton = (Button)sender;
            int i = bufButton.Location.Y / 50 - 1;
            if (0 <= i && i < subScreenMgrList.Count())
            {
                subScreenMgrList[i].allEnd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subScreenMgrList[1].start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            subScreenMgrList[1].allEnd();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
