using System;
using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameObjects
{
    class Ball : MovingGameObject {

        private static double DEFAULT_SPEED = 10;
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

        public override void reactToCollision(Collision collision) {
            switch (collision){
                case Collision.LEFT: updateXaxisMovement(false, true); break;
                case Collision.RIGHT: updateXaxisMovement(true, false); break;
                case Collision.UP: updateYaxisMovement(false, true); break;
                case Collision.DOWN: updateYaxisMovement(true, false); break;
            }

        }

        public void throwBall() {
            isSticked = false;
            speed = DEFAULT_SPEED;
            updateYaxisMovement(true, false);
        }

        public override void update(double delta)
        {
            if (isSticked)
                speed = Player.DEFAULT_SPEED;
           
            base.update(delta);
        }
    }
}
