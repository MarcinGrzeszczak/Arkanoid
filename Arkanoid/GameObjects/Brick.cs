
using Arkanoid.GameLogic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Arkanoid.GameObjects
{
    class Brick : GameObject
    {
        public enum STRENGTH_LEVEL{ LOW, MEDIUM, HEIGHT };
        public static int POINTS = 10;
        public static Point3D DEFAULT_SIZE = new Point3D(3, 2, 2);

        private Color brickColor;

        public Brick(Point3D size, Point position, Color brickColor): base(size, position)
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
        public override Model3DGroup draw()
        {
            return GameDrawing.CreateCubeModel(new Point3D(position.X, position.Y, 0), DEFAULT_SIZE);
        }
    }
}
