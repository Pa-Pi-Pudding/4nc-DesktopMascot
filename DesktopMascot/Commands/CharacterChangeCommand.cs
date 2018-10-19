using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    // コンテキストメニューに存在するコマンド用のソース
    // そうでない場合はコピペ厳禁
    class CharacterChangeCommand : Command
    {
        private Controller controller;
        private List<CharacterSet> characterSetList;
        public CharacterChangeCommand(int id, String executeName, List<CharacterSet> characterSetList, Controller controller) : base(id, executeName)
        {
            this.controller = controller;
            this.characterSetList = characterSetList;
            this.description = "キャラクターを変更します";

            // コンテキストメニューに存在するときだけコピペ
            this.existForContextMenu = true;
        }

        public override Reaction execute(String[] args, CharacterSet characterSet)
        {
            Reaction bufReact;
            bufReact = new Reaction();

            foreach(CharacterSet item in characterSetList)
            {
                if(item.getName() == args[1])
                {
                    controller.changeCharacter(item.getId());
                    break;
                }
            }
            


            return bufReact;
        }

        public override ToolStripMenuItem getToolStripMenuItem()
        {
            ToolStripMenuItem bufTsi = new ToolStripMenuItem();

            bufTsi.Text = this.executeName;
            bufTsi.ToolTipText = this.description;

            foreach(CharacterSet item in characterSetList)
            {
                ToolStripMenuItemWithCharacterInfo dropDownTsi = new ToolStripMenuItemWithCharacterInfo();

                dropDownTsi.Text = item.getName();
                dropDownTsi.ToolTipText = "キャラクターを" + item.getName() + "に変更します";
                dropDownTsi.Click += this.contextMenuEvent;
                dropDownTsi.setCharacterId(item.getId());

                bufTsi.DropDownItems.Add(dropDownTsi);
            }

            return bufTsi;
        }

        public void contextMenuEvent(object sender, EventArgs e)
        {
            ToolStripMenuItemWithCharacterInfo tsmiwci = (ToolStripMenuItemWithCharacterInfo)sender;
            int characterId = tsmiwci.getCharacterId();

            controller.changeCharacter(characterId);

            return;
        }

        private class ToolStripMenuItemWithCharacterInfo : ToolStripMenuItem
        {
            public int characterId;
            public void setCharacterId(int id) { this.characterId = id; }
            public int getCharacterId() { return characterId; }
        }
    }
}
