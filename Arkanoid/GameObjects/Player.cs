using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameObjects
{
    class Player : MovingGameObject
    {
        private static double DEFAULT_SPEED = 4;
        public static Point DEFAULT_SIZE = new Point(100, 20);
        public Player(Point size, Point position) : base(size, position) {
            init();
        }

        public Player(Point position) : base(DEFAULT_SIZE, position) {
            init();
        }

        private void init() {
            speed = DEFAULT_SPEED;
        }

        public override void draw(DrawingContext dc) {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Black;

            dc.DrawRoundedRectangle(brush, null, new Rect(position.X, position.Y, size.X, size.Y), 10, 10);
        }

        public override void update(double delta, MoveDir moveFlags)
        {
            base.update(delta, moveFlags);
        }
    }
}
