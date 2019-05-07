

using Arkanoid.GameLogic;

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

        public override void draw() {
          
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
