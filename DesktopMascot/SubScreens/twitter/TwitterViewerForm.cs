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
    public partial class TwitterViewerForm : Form
    {
        public TwitterViewerForm()
        {
            InitializeComponent();
        }

        private void TwitterViewerForm_Load(object sender, EventArgs e)
        {

        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
    　　　　// 再起動後のForm2を生成
    　　　　TwitterViewerForm frm2 = new TwitterViewerForm();
    　　　　// 自身を閉じる
    　　　　this.Close();
    　　　　// 再起動のForm2を起動する
    　　　　frm2.Show();
        }
    }
}
