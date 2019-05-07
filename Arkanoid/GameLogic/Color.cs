using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.GameLogic
{
    class Color
    {
        private static ConsoleColor[] consoleColors =
        {
            ConsoleColor.Blue,
            ConsoleColor.DarkGreen,
            ConsoleColor.Green,
            ConsoleColor.Yellow,
            ConsoleColor.Red
        };

        private ConsoleColor color;
        private static Random rand = new Random();

        public void randomColor() {
            color = consoleColors[rand.Next(0, consoleColors.Length)];
        }

        public ConsoleColor getColor()
        {
            return color;
        }
    }
}
