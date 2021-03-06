﻿using System;
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
        private CharacterInitializer characterInitializer;
        private int defaultMainScrIndex;
        private int defaultCharacterIndex;
        private MainScreenMgr runningMainScr;
        private CharacterSet runningCharacterSet;

        // メソッド
        public List<IDAndName> getCharacterSetIdAndNameList() { return this.characterSetIdAndNameList;  }
        public List<IDAndName> getMainScreenMgrIdAndNameList() { return this.mainScreenMgrIdAndNameList; }
        public void changeCharacter(int characterId)
        {
            if(runningCharacterSet == null)
            {
                return;
            }
            foreach(CharacterSet charaItem in characterSetList)
            {
                if(charaItem.getId() == characterId)
                {
                    runningCharacterSet.stop();
                    foreach(MainScreenMgr mainScrItem in mainScreenMgrList)
                    {
                        mainScrItem.setCharacterSet(charaItem);
                    }
                    foreach (SubScreenMgr subScrItem in subScreenMgrList)
                    {
                        subScrItem.setCharacterSet(charaItem);
                    }
                    runningCharacterSet = charaItem;
                    runningCharacterSet.start();
                    break;
                }
            }
            return;
        }
        public void startCharacter(int characterId)
        {
            foreach (CharacterSet charaItem in characterSetList)
            {
                if (charaItem.getId() == characterId)
                {
                    foreach (MainScreenMgr mainScrItem in mainScreenMgrList)
                    {
                        mainScrItem.setCharacterSet(charaItem);
                    }
                    foreach (SubScreenMgr subScrItem in subScreenMgrList)
                    {
                        subScrItem.setCharacterSet(charaItem);
                    }
                    runningCharacterSet = charaItem;
                    runningCharacterSet.start();
                    break;
                }
            }

            return;
        }
        public void startMainScreen(int mainScreenId)
        {
            foreach(MainScreenMgr item in mainScreenMgrList)
            {
                if(item.getId() == mainScreenId)
                {
                    runningMainScr = item;
                    break;
                }
            }

            runningMainScr.start();
            return;
        }
        public void endMainScreen()
        {
            if(runningMainScr == null)
            {
                return;
            }

            runningMainScr.stop();
            runningMainScr = null;

            return;
        }
        public Controller()
        {
            defaultCharacterIndex = 1;
            defaultMainScrIndex = 0;
            runningMainScr = null;
            runningCharacterSet = null;
            // キャラクター初期化に使うInitializerを生成
            characterInitializer = new CharacterInitializer(new MouseEventHandler(pictureBox1_MouseDown), new MouseEventHandler(pictureBox1_MouseUp), new MouseEventHandler(pictureBox1_MouseMove), new EventHandler(pictureBox1_MouseCaptureChanged));
            // 必要なもの生成器を生成する
            listsMaker = new ProductListsMaker(this, characterInitializer);

            // メンバ変数の初期化
            mainScreenMgrList = listsMaker.getMainScreenMgrList();
            subScreenMgrList = listsMaker.getSubScreenMgrList();
            characterSetList = listsMaker.getCharacterSetList();
            mainScreenMgrIdAndNameList = listsMaker.getMainScreenMgrIDAndNameList();
            characterSetIdAndNameList = listsMaker.getCharacterSetIDAndNameList();

            changeCharacter(defaultCharacterIndex);

            InitializeComponent();
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            // 最初に表示するMainScreenをStartする
            startMainScreen(defaultMainScrIndex);
            // 最初に表示するキャラクターをスタートする
            startCharacter(defaultCharacterIndex);
        }

        public void endApplication()
        {
            this.Close();
        }

        //↓↓↓↓マウスによるウィンドウ移動操作Start↓↓↓↓

        //移動前のマウスの位置
        private Point lastMousePosition;
        //マウス操作を行うかどうかのboolian判定
        private bool mouseCapture;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //押されたマウスのボタンが、左以外だった時
            if (e.Button != MouseButtons.Left)
            {
                //何もしない
                return;
            }

            //マウスの位置を所得
            this.lastMousePosition = Control.MousePosition;
            //mouseCaptureにtrueを設定して、移動処理を行なうことを示す。
            this.mouseCapture = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //mouseCaptureがfalse：左クリックされてないので何も処理はしない。
            if (this.mouseCapture == false)
            {
                return;
            }

            // 最新のマウスの位置を取得
            Point mp = Control.MousePosition;

            // 差分を取得
            int offsetX = mp.X - this.lastMousePosition.X;
            int offsetY = mp.Y - this.lastMousePosition.Y;

            // コントロールを移動
            //マウスの位置差分(offsetX,Y)を、現在の位置(Left,Top)に足し合わせて、移動している様に見せている。
            this.Location = new Point(this.Left + offsetX, this.Top + offsetY);
            //ここに他のフォームのLocationを指定できたら完成。

            //マウスの位置をmp(最新のマウスの位置)にする
            this.lastMousePosition = mp;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //離れるボタンが左以外なら何もしない
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            //左ならmouseCaptureにfalseを入れてこれ以上移動を行わないことを示す。
            this.mouseCapture = false;
        }

        private void pictureBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (this.mouseCapture == true && this.Capture == false)
            {
                this.mouseCapture = false;
            }
        }

        //↑↑↑↑マウスによるウィンドウ移動操作END↑↑↑↑

    }
}
