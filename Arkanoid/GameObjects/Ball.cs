using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameObjects
{
    class Ball : MovingGameObject {

        private static double DEFAULT_SPEED = 20;
        public static Point DEFAULT_SIZE = new Point(7, 7);
        public bool isSticked;
        public Ball(Point size, Point position) : base(size, position)
        {
            init();
        }

        public Ball(Point position) : base(DEFAULT_SIZE, position)
        {
            init();
        }

        private void init()
        {
            speed = DEFAULT_SPEED;
            isSticked = true;
        }

        public override void draw(DrawingContext dc)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.White;

            dc.DrawEllipse(brush, null, position, size.X, size.Y);
        }
    }
}
