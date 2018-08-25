using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot.SubScreens.Newsviewer
{
    public partial class NewsShow: Form
    {

        private string receiveData = "";

        public NewsShow()
        {
            InitializeComponent();
        }

        private void NewsShow_Load(object sender, EventArgs e)
        {
           UserControl1 us = new UserControl1();
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        public string ReceiveData
        {
          set
          {
            receiveData = value;
          }
          get
          {
            return receiveData;
          }
        }
    }
}
