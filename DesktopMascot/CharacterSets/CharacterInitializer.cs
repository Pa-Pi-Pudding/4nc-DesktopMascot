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

        }
    }
}
