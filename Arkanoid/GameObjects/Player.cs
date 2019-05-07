using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameObjects
{
    class Player : MovingGameObject
    {
        public static double DEFAULT_SPEED = 4;
        public static Point DEFAULT_SIZE = new Point(100, 20);
        public Player(Point size, Point position) : base(size, position) {
            init();
        }

        public Player(Point position) : base(DEFAULT_SIZE, position) {
            init();
        }

        private void init() {
            centerPosition();
            speed = DEFAULT_SPEED;
        }

        public override void draw(DrawingContext dc) {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Black;

            //TODO: Przeniesc gdzies indziej obliczanie oryginalnej pozycji
            dc.DrawRoundedRectangle(brush, null, new Rect(position.X - size.X /2, position.Y - size.Y / 2, size.X, size.Y), 10, 10);
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
