using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arkanoid.GameLogic
{
    class GameController {


        public struct KeyFlags
        {
            public bool isPressedLeft;
            public bool isPressedRight;
            public bool isPressedSpace;
        }

        private KeyFlags flags;

        public GameController()
        {
            flags.isPressedLeft = false;
            flags.isPressedRight = false;
            flags.isPressedSpace = false;
        }

        public KeyFlags getKeyFlags() => flags;

        public void keyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.Key) {
                case Key.A: flags.isPressedLeft = true; break;
                case Key.D: flags.isPressedRight = true; break;
                case Key.Space: flags.isPressedSpace = true; break;
            }
        }

        public void keyUpEvent(object sender, KeyEventArgs e)
        {
            switch (e.Key) {
                case Key.A: flags.isPressedLeft = false; break;
                case Key.D: flags.isPressedRight = false; break;
                case Key.Space: flags.isPressedSpace = false; break;
            }
        }
    }
}
