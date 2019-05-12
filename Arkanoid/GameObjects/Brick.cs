using Arkanoid.GameLogic;
using System;

namespace Arkanoid.GameObjects
{
    class Brick : GameObject
    {
        public enum STRENGTH_LEVEL{ LOW, MEDIUM, HEIGHT };
        public static int POINTS = 10;
        public static Point DEFAULT_SIZE = new Point(4, 1);
        private static string block = "█";
        public Brick(Point size, Point position, ConsoleColor brickColor): base(size, position)
        {
            init(brickColor);
        }

        public Brick(Point position, ConsoleColor brickColor) :base(DEFAULT_SIZE, position)
        {
            init(brickColor);    
        }
        

        private void init(ConsoleColor brickColor){
            //centerPosition();
            color = brickColor;
        }

        public override string draw()
        {
            string result = "";
            for (int i = 0; i < DEFAULT_SIZE.X; ++i)
                result += block;
            return result;
        }

        public override string clear()
        {
            string result = "";
            for (int i = 0; i < DEFAULT_SIZE.X; ++i)
                result += " ";
            return result;
        }
    }
}
