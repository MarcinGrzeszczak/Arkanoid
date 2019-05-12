

using Arkanoid.GameLogic;

namespace Arkanoid.GameObjects
{
    class Player : MovingGameObject
    {
        public static double DEFAULT_SPEED = 4;
        public static Point DEFAULT_SIZE = new Point(5, 1);
        public Player(Point size, Point position) : base(size, position) {
            init();
        }

        public Player(Point position) : base(DEFAULT_SIZE, position) { 
            init();
        }

        private void init() {
            color = System.ConsoleColor.White;
            centerPosition();
            speed = DEFAULT_SPEED;
        }

        public override string draw() {
            return "▀▀▀▀▀";
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
