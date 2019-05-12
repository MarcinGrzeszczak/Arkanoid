using System;

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

        public void update()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    flags.isPressedRight = true;
                    flags.isPressedLeft = false;
                    flags.isPressedSpace = false;
                }
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    flags.isPressedRight = false;
                    flags.isPressedLeft = true;
                    flags.isPressedSpace = false;
                }
                if(keyInfo.Key == ConsoleKey.Spacebar) {
                    flags.isPressedRight = false;
                    flags.isPressedLeft = false;
                    flags.isPressedSpace = true;
                }
            }
            else {
                flags.isPressedLeft = false;
                flags.isPressedSpace = false;
                flags.isPressedRight = false;
            }
        }
    }
}
