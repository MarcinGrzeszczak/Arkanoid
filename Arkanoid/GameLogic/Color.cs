using System;


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
        private Random rand;

        public Color(){
            rand = new Random();
        }

        public void randomColor() {
            int t = rand.Next(0, consoleColors.Length-1);
            color = consoleColors[t];
            
        }

        public ConsoleColor getColor()
        {
            return color;
        }
    }
}
