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

        public CharacterInitializer(MouseEventHandler MouseDown, MouseEventHandler MouseUp, MouseEventHandler MouseMove, EventHandler MouseCaptureChanged)
        {
            this.MouseDown = MouseDown;
            this.MouseUp = MouseUp;
            this.MouseMove = MouseMove;
            this.MouseCaptureChanged = MouseCaptureChanged;
        }

        public void initCharaPictureBox(PictureBox pictureBox)
        {
            pictureBox.MouseDown += this.MouseDown;
            pictureBox.MouseUp += this.MouseUp;
            pictureBox.MouseMove += this.MouseMove;
            pictureBox.MouseCaptureChanged += this.MouseCaptureChanged;
            return;
        }
    }
}
