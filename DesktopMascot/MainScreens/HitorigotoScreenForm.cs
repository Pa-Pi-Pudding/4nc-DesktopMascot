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
    public partial class HitorigotoScreenForm : Form
    {
        private List<SubScreenMgr> subScreenMgrList;

        public HitorigotoScreenForm(List<SubScreenMgr> subScreenMgrList)
        {
            this.subScreenMgrList = subScreenMgrList;
            InitializeComponent();
        }
    }
}
