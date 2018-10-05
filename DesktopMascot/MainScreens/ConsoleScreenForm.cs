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
    public partial class ConsoleScreenForm : Form
    {
        private String newLineCode = "\n\r";
        private String userName = "testName";
        private CharacterSet characterSet;
        private List<SubScreenMgr> subScreenMgrList;
        private List<Command> commandList;

        public ConsoleScreenForm(List<SubScreenMgr> subScreenMgrList, CharacterSet characterSet, List<Command> commandList)
        {
            this.subScreenMgrList = subScreenMgrList;
            this.characterSet = characterSet;
            this.commandList = commandList;
            InitializeComponent();
        }

        private void ConsoleScreenForm_Load(object sender, EventArgs e)
        {
            //背景透過
            //FromのBackColorコントロールの値を透過色としている。
            this.TransparencyKey = BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isFinish = false;
            String serif = "";
            Reaction bufReact = new Reaction();
            bufReact.message = "message is not found";

            String bufText = this.textBox1.Text;
            label1.Text += userName + ">" + bufText + newLineCode;

            // コマンドの引数を分離
            String[] bufCommandArgs = bufText.Split(' ');

            // 機能一覧を表示
            if (!isFinish)
            {
                foreach(Command item in commandList)
                {
                    if(bufCommandArgs[0] == item.getExecuteName())
                    {
                        bufReact = item.execute(bufCommandArgs, this.characterSet);
                        isFinish = true;
                    }
                }
            }

            // 機能を検索
            if (!isFinish)
            {
                foreach (SubScreenMgr item in subScreenMgrList)
                {
                    if (bufCommandArgs[0] == item.getName())
                    {
                        isFinish = true;
                        item.start();
                        bufReact = this.characterSet.getFuncStartReaction(item.getName());
                    }
                }
            }

            // 会話を検索
            if (!isFinish)
            {
                bufReact = this.characterSet.getCommunicationReaction(bufCommandArgs[0]);
            }

            serif += bufReact.message + newLineCode;
            label1.Text += this.characterSet.getName() + ">" + serif + newLineCode;

            // テキストボックスのクリア
            textBox1.ResetText();

            // panelの自動スクロール
            panel1.AutoScrollPosition = new Point(panel1.AutoScrollPosition.X, panel1.Height + panel1.VerticalScroll.Value);
        }

        public void setCharacterSet(CharacterSet characterSet)
        {
            this.characterSet = characterSet;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Enterキーがおされたら
            if((e.KeyCode == Keys.Enter))
            {
                button1_Click(sender, e);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
