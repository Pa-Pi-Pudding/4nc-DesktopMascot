using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    public class ProductListsMaker : ListsMaker
    {
        // 本番用ListsMaker

        public ProductListsMaker(Controller controller, CharacterInitializer characterInitializer) : base(controller, characterInitializer)
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
            bufSubScrMgr = new WeatherScreen(0);
            subScreenMgrList.Add(bufSubScrMgr);
            bufSubScrMgr = new Newsviewer(1);
            subScreenMgrList.Add(bufSubScrMgr);
            bufSubScrMgr = new TwitterViewer(2);
            subScreenMgrList.Add(bufSubScrMgr);
            bufSubScrMgr = new OpenAccess(3);
            subScreenMgrList.Add(bufSubScrMgr);

            // 全てのCommandを生成し、Listに入れる
            bufCommand = new HelpCommand(0, "help", subScreenMgrList);
            commandList.Add(bufCommand);
            bufCommand = new CharacterChangeCommand(1, "characterchange", characterSetList, controller);
            commandList.Add(bufCommand);
            bufCommand = new OpenMScrCommand(2, "openmainscreen", mainScreenMgrList, controller);
            commandList.Add(bufCommand);
            bufCommand = new CloseMScrCommand(3, "closemainscreen", controller);
            commandList.Add(bufCommand);
            bufCommand = new OpenCommand(4, "open");
            commandList.Add(bufCommand);
            bufCommand = new ExitCommand(5, "exit", controller);
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
            // IDと名前も同時に記録しておく

            // 1個目 コンストラクタ
            bufMainScrMgr = new ConsoleScreen(0, subScreenMgrList, controller, commandList);
            mainScreenMgrList.Add(bufMainScrMgr);
            // 1個目 IDと名前
            bufIDAndName.id = bufMainScrMgr.getId();
            bufIDAndName.name = bufMainScrMgr.getName();
            mainScreenMgrIdAndNameList.Add(bufIDAndName);
        }

    }
}
