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

        private ListsMaker listsMaker;

        // メソッド
        public List<IDAndName> getCharacterSetIdAndNameList() { return this.characterSetIdAndNameList;  }
        public List<IDAndName> getMainScreenMgrIdAndNameList() { return this.mainScreenMgrIdAndNameList; }
        public void chengeCharacter(int characterId) { ; }
        public void startMainScreen(int mainScreenId) { ; }
        public void endMainScreen() { ; }
        
        public Controller()
        {
            // 必要なもの生成器を生成する
            listsMaker = new TestListsMaker(this);

            // メンバ変数の初期化
            mainScreenMgrList = listsMaker.getMainScreenMgrList();
            subScreenMgrList = listsMaker.getSubScreenMgrList();
            characterSetList = listsMaker.getCharacterSetList();
            mainScreenMgrIdAndNameList = listsMaker.getMainScreenMgrIDAndNameList();
            characterSetIdAndNameList = listsMaker.getCharacterSetIDAndNameList();

            InitializeComponent();
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            // 最初に表示するMainScreenをStartする
            mainScreenMgrList[0].start();
        }

    }
}
