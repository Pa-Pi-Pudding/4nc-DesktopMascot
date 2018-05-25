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
        public List<IDAndName> getCharacterSetIdAndNameList() { return this.characterSetIdAndNameList;  }
        public List<IDAndName> getMainScreenMgrIdAndNameList() { return this.mainScreenMgrIdAndNameList; }
        public void chengeCharacter(int characterId) { ; }
        public void startMainScreen(int mainScreenId) { ; }
        public void endMainScreen() { ; }
        
        public Controller()
        {
            // メンバ変数の初期化
            mainScreenMgrList = new List<MainScreenMgr>();
            subScreenMgrList = new List<SubScreenMgr>();
            characterSetList = new List<CharacterSet>();
            mainScreenMgrIdAndNameList = new List<IDAndName>();
            characterSetIdAndNameList = new List<IDAndName>();

            // 一時的に確保しておく変数
            MainScreenMgr bufMainScrMgr;
            SubScreenMgr bufSubScrMgr;
            CharacterSet bufCharaSet;
            IDAndName bufIDAndName;

            // 全てのCharacterSetを生成し、Listに入れる
            bufCharaSet = new TestCharacterSet(0);
            characterSetList.Add(bufCharaSet);
            // IDと名前も同時に記録しておく
            bufIDAndName.id = bufCharaSet.getId();
            bufIDAndName.name = bufCharaSet.getName();
            characterSetIdAndNameList.Add(bufIDAndName);


            // 全てのSubScreenMgrを生成し、Listに入れる
            // コンストラクタのID番号は取りあえず0で設定している
            bufSubScrMgr = new TestSubScreen(0);
            subScreenMgrList.Add(bufSubScrMgr);
            bufSubScrMgr = new TestSubScreen2(1);
            subScreenMgrList.Add(bufSubScrMgr);


            // 全てのMainScreenMgrを生成し、Listに入れる
            // コンストラクタのID番号は取りあえず0で設定している
            bufMainScrMgr = new TestMainScreen(0, subScreenMgrList, this);
            mainScreenMgrList.Add(bufMainScrMgr);
            // IDと名前も同時に記録しておく
            bufIDAndName.id = bufMainScrMgr.getId();
            bufIDAndName.name = bufMainScrMgr.getName();
            mainScreenMgrIdAndNameList.Add(bufIDAndName);



            // MainScreenMgrとSubScreenMgrが利用するデフォルトキャラクターを設定する
            // 使用されるスクリーン全てにキャラクターが設定されるようにする

            // MainScreenMgrのデフォルトキャラクター設定
            foreach (MainScreenMgr item in mainScreenMgrList)
            {
                item.setCharacterSet(characterSetList[0]);
            }

            // SubScreenMgrのデフォルトキャラクター設定
            foreach(SubScreenMgr item in subScreenMgrList)
            {
                item.setCharacterSet(characterSetList[0]);
            }


            InitializeComponent();
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            // 最初に表示するMainScreenをStartする
            mainScreenMgrList[0].start();
        }

    }
}
