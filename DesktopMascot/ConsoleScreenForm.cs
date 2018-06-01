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

        List<SubScreenMgr> subScreenMgrList;
        public ConsoleScreenForm(List<SubScreenMgr> subScreenMgrList, CharacterSet characterSet)
        {
            this.subScreenMgrList = subScreenMgrList;
            this.characterSet = characterSet;
            InitializeComponent();
        }

        private void ConsoleScreenForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String bufText = this.textBox1.Text;
            label1.Text += userName + ">" + bufText + newLineCode;
            Reaction bufReact = this.characterSet.getEchoReaction(bufText);
            String serif = bufReact.message + newLineCode;
            label1.Text += this.characterSet.getName() + ">" + serif + newLineCode;
        }

        public void setCharacterSet(CharacterSet characterSet)
        {
            this.characterSet = characterSet;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
