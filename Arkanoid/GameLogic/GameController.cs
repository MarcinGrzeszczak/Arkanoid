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

     
    }
}
