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

        public TestListsMaker(Controller controller, CharacterInitializer characterInitializer) : base(controller, characterInitializer)
        {
            // メンバ変数の初期化
            mainScreenMgrList = new List<MainScreenMgr>();
            subScreenMgrList = new List<SubScreenMgr>();
            characterSetList = new List<CharacterSet>();
            mainScreenMgrIdAndNameList = new List<IDAndName>();
            characterSetIdAndNameList = new List<IDAndName>();
            commandList = new List<Command>();

            // 一時的に確保しておく変数
            MainScreenMgr bufMainScrMgr;
            SubScreenMgr bufSubScrMgr;
            CharacterSet bufCharaSet;
            IDAndName bufIDAndName;
            Command bufCommand;
            
            // 全てのSubScreenMgrを生成し、Listに入れる
            // コンストラクタのID番号は取りあえず0で設定している
            bufSubScrMgr = new TestSubScreen(0);
            subScreenMgrList.Add(bufSubScrMgr);
            bufSubScrMgr = new TestSubScreen2(1);
            subScreenMgrList.Add(bufSubScrMgr);
            bufSubScrMgr = new WeatherScreen(2);
            subScreenMgrList.Add(bufSubScrMgr);
            bufSubScrMgr = new Newsviewer(3);
            subScreenMgrList.Add(bufSubScrMgr);
            bufSubScrMgr = new TwitterViewer(4);
            subScreenMgrList.Add(bufSubScrMgr);
            bufSubScrMgr = new OpenAccess(4);
            subScreenMgrList.Add(bufSubScrMgr);

            // 全てのCommandを生成し、Listに入れる
            bufCommand = new HelpCommand(0, "help", subScreenMgrList);
            commandList.Add(bufCommand);
            bufCommand = new ExitCommand(1, "exit", controller);
            commandList.Add(bufCommand);
            bufCommand = new CharacterChangeCommand(2, "characterchange", characterSetList, controller);
            commandList.Add(bufCommand);
            bufCommand = new OpenMScrCommand(3, "openmainscreen", mainScreenMgrList, controller);
            commandList.Add(bufCommand);
            bufCommand = new CloseMScrCommand(4, "closemainscreen", controller);
            commandList.Add(bufCommand);
            bufCommand = new OpenCommand(5, "open");
            commandList.Add(bufCommand);


            characterInitializer.setCommandList(commandList);

            // 全てのCharacterSetを生成し、Listに入れる
            // IDと名前も同時に記録しておく
            // 1個目 コンストラクタ
            bufCharaSet = new TestCharacterSet(0, controller, characterInitializer);
            characterSetList.Add(bufCharaSet);
            // 2個目 IDと名前
            bufIDAndName.id = bufCharaSet.getId();
            bufIDAndName.name = bufCharaSet.getName();
            characterSetIdAndNameList.Add(bufIDAndName);

            // IDと名前も同時に記録しておく
            // 1個目 コンストラクタ
            bufCharaSet = new Character1Set(1, controller, characterInitializer);
            characterSetList.Add(bufCharaSet);
            // 2個目 IDと名前
            bufIDAndName.id = bufCharaSet.getId();
            bufIDAndName.name = bufCharaSet.getName();
            characterSetIdAndNameList.Add(bufIDAndName);


            // 全てのMainScreenMgrを生成し、Listに入れる
            // コンストラクタのID番号は取りあえず0で設定している
            // IDと名前も同時に記録しておく
            // 1個目 コンストラクタ
            bufMainScrMgr = new TestMainScreen(0, subScreenMgrList, controller, commandList);
            mainScreenMgrList.Add(bufMainScrMgr);
            // 1個目 IDと名前
            bufIDAndName.id = bufMainScrMgr.getId();
            bufIDAndName.name = bufMainScrMgr.getName();
            mainScreenMgrIdAndNameList.Add(bufIDAndName);

            // 2個目 コンストラクタ
            bufMainScrMgr = new ConsoleScreen(1, subScreenMgrList, controller, commandList);
            mainScreenMgrList.Add(bufMainScrMgr);
            // 2個目 IDと名前
            bufIDAndName.id = bufMainScrMgr.getId();
            bufIDAndName.name = bufMainScrMgr.getName();
            mainScreenMgrIdAndNameList.Add(bufIDAndName);


            //独り言ウィンドウ
            // 3個目 コンストラクタ
            bufMainScrMgr = new HitorigotoScreen(2, subScreenMgrList, controller, commandList);
            mainScreenMgrList.Add(bufMainScrMgr);
            // 3個目 IDと名前
            bufIDAndName.id = bufMainScrMgr.getId();
            bufIDAndName.name = bufMainScrMgr.getName();
            mainScreenMgrIdAndNameList.Add(bufIDAndName);


            // MainScreenMgrとSubScreenMgrが利用するデフォルトキャラクターを設定する
            // 使用されるスクリーン全てにキャラクターが設定されるようにする

            // MainScreenMgrのデフォルトキャラクター設定
            foreach (MainScreenMgr item in mainScreenMgrList)
            {
                item.setCharacterSet(characterSetList[1]);
            }

            // SubScreenMgrのデフォルトキャラクター設定
            foreach (SubScreenMgr item in subScreenMgrList)
            {
                item.setCharacterSet(characterSetList[1]);
            }
        }

    }
}
