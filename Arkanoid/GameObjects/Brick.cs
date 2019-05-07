
using System.Drawing;
using Arkanoid.GameLogic;

namespace Arkanoid.GameObjects
{
    class Brick : GameObject
    {
        public enum STRENGTH_LEVEL{ LOW, MEDIUM, HEIGHT };
        public static int POINTS = 10;
        public static Point DEFAULT_SIZE = new Point(50, 25);

        private Color brickColor;

        public Brick(Point size, Point position, Color brickColor): base(size, position)
        {
            init(brickColor);
        }

        public Brick(Point position, Color brickColor) :base(DEFAULT_SIZE, position)
        {
            init(brickColor);
           
           
        }
        

        private void init(Color brickColor){
            centerPosition();
            this.brickColor = brickColor;
        }
        public override void draw()
        {
          
        }
    }
}
