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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            subScreenMgrList[0].start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            subScreenMgrList[0].allEnd();
        }
    }
}
