using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameObjects
{
    class Ball : MovingGameObject {

        private static double DEFAULT_SPEED = 10;
        private MoveDir movement;

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

        private void changeSpeed(double newSpeed) {
            speed = newSpeed;
        }
        private void init()
        {
            speed = DEFAULT_SPEED;
            isSticked = true;

            movement.down = false;
            movement.up = false;
            movement.left = false;
            movement.right = false;
        }

        public override void draw(DrawingContext dc)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.White;

            dc.DrawEllipse(brush, null, position, size.X, size.Y);
        }

        public override void update(double delta, MoveDir moveFlags)
        {
            movement = moveFlags;

            if (isSticked)
                changeSpeed(Player.DEFAULT_SPEED);
            else {
                changeSpeed(DEFAULT_SPEED);
                movement.up = true;
            }

            base.update(delta, movement);
        }

        public void update(double delta) {
          
            if (position.X <= 0) {
                movement.right = true;
                movement.left = false;
            }

            if (position.Y <= 0)
            {
                movement.up = false;
                movement.down = true;
            }

            base.update(delta, movement);
        }
    }
}
