using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    public class CharacterInitializer
    {
        private MouseEventHandler MouseDown;
        private MouseEventHandler MouseUp;
        private MouseEventHandler MouseMove;
        private EventHandler MouseCaptureChanged;
        private List<Command> commandList;
        private List<Command> commandListForContextMenu;

        public CharacterInitializer(MouseEventHandler MouseDown, MouseEventHandler MouseUp, MouseEventHandler MouseMove, EventHandler MouseCaptureChanged)
        {
            this.MouseDown = MouseDown;
            this.MouseUp = MouseUp;
            this.MouseMove = MouseMove;
            this.MouseCaptureChanged = MouseCaptureChanged;
            this.commandList = null;
            this.commandListForContextMenu = null;
        }

        public void setCommandList(List<Command> commandList)
        {
            this.commandList = commandList;
            this.commandListForContextMenu = new List<Command>();
            foreach(Command item in commandList)
            {
                if (item.getExistForContextMenu())
                {
                    commandListForContextMenu.Add(item);
                }
            }
        }

        public void initCharaPictureBox(PictureBox pictureBox)
        {
            pictureBox.MouseDown += this.MouseDown;
            pictureBox.MouseUp += this.MouseUp;
            pictureBox.MouseMove += this.MouseMove;
            pictureBox.MouseCaptureChanged += this.MouseCaptureChanged;
            return;
        }

        public void addContextMenu(ContextMenuStrip targetContextMenuStrip)
        {
            if(commandList == null)
            {
                return;
            }

            // コンテキストメニューをクリア
            targetContextMenuStrip.Items.Clear();

            foreach(Command item in commandListForContextMenu)
            {
                ToolStripMenuItem bufTsi = item.getToolStripMenuItem();

                if(bufTsi == null)
                {
                    continue;
                }

                targetContextMenuStrip.Items.Add(bufTsi);
            }

            //// 第1階層のメニュー
            //ToolStripMenuItem tsi1 = new ToolStripMenuItem();
            //tsi1.Text = "グループ";
            //tsi1.ToolTipText = "グループのツールチップ";

            //// 第2階層のメニュー
            //ToolStripMenuItem tsi2 = new ToolStripMenuItem();
            //tsi2.Text = "メニュー項目1";
            //tsi2.ToolTipText = "メニュー項目1のツールチップ";
            //// クリックイベントを追加する
            //// フォームで設定した ItemClicked イベントは第1階層の項目のみ発生する
            //tsi2.Click += contextMenuStrip_SubMenuClick;

            //// 第1階層のメニューの最後尾に追加
            //tsi1.DropDownItems.Add(tsi2);

            //ToolStripMenuItem tsi3 = new ToolStripMenuItem();
            //tsi3.Text = "メニュー項目2";
            //tsi3.ToolTipText = "メニュー項目2のツールチップ";
            //tsi3.Click += contextMenuStrip_SubMenuClick;

            //// 第1階層のメニューの最後尾に追加する
            //tsi1.DropDownItems.Add(tsi3);

            //// コンテキストメニューに第1階層のメニューを追加する
            //targetContextMenuStrip.Items.Add(tsi1);
        }
    }
}
