using Arkanoid.GameLogic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Arkanoid.GameObjects
{
    class Player : MovingGameObject
    {
        public static double DEFAULT_SPEED = 4;
        public static Point3D DEFAULT_SIZE = new Point3D(.5, .5, 3);
        public Player(Point3D size, Point position) : base(size, position) {
            init();
        }

        public Player(Point position) : base(DEFAULT_SIZE, position) {
            init();
        }

        private void init() {
            //centerPosition();
            speed = DEFAULT_SPEED;
            shape.Content = GameDrawing.CreateCubeModel(new Point3D(position.Y, 0, position.X), DEFAULT_SIZE, Colors.DarkGray);
        }

        public override void restartPosition()
        {
            base.restartPosition();
            centerPosition();
        }

        public override void reactToCollision(Collision collision) {
            if (collision == Collision.LEFT)
                updateXaxisMovement(false, movement.right);

            if (collision == Collision.RIGHT)
                updateXaxisMovement(movement.left, false);
        }

    }
}
