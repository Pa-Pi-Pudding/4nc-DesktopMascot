using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    public class TestListsMaker : ListsMaker
    {
        // テスト用ListsMaker

        public TestListsMaker(Controller controller) : base(controller)
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
            // IDと名前も同時に記録しておく
            // 1個目 コンストラクタ
            bufMainScrMgr = new TestMainScreen(0, subScreenMgrList, controller);
            mainScreenMgrList.Add(bufMainScrMgr);
            // 1個目 IDと名前
            bufIDAndName.id = bufMainScrMgr.getId();
            bufIDAndName.name = bufMainScrMgr.getName();
            mainScreenMgrIdAndNameList.Add(bufIDAndName);

            // 2個目 コンストラクタ
            bufMainScrMgr = new ConsoleScreen(1, subScreenMgrList, controller);
            mainScreenMgrList.Add(bufMainScrMgr);
            // 2個目 IDと名前
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
            foreach (SubScreenMgr item in subScreenMgrList)
            {
                item.setCharacterSet(characterSetList[0]);
            }
        }

    }
}
