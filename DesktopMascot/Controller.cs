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
    public partial class Controller : Form
    {
        // メンバ変数
        private List<CharacterSet> characterSetList;
        private List<MainScreenMgr> mainScreenMgrList;
        private List<SubScreenMgr> subScreenMgrList;
        private List<IDAndName> mainScreenMgrIdAndNameList;
        private List<IDAndName> characterSetIdAndNameList;

        // メソッド
        public List<IDAndName> getCharacterSetList() { return this.mainScreenMgrIdAndNameList; }
        public List<IDAndName> getMainScreenMgrList() { return this.characterSetIdAndNameList; }
        public void chengeCharacter(int characterId) { ; }
        public void startMainScreen(int mainScreenId) { ; }
        public void endMainScreen() { ; }
        
        public Controller()
        {
            

            InitializeComponent();
        }

        private void Controller_Load(object sender, EventArgs e)
        {

        }

    }
}
