using Arkanoid.GameLogic;
using System.Windows;

namespace Arkanoid.GameObjects
{
    class MovingGameObject : GameObject
    {
        public struct MoveDir
        {
            public bool up;
            public bool down;
            public bool left;
            public bool right;
        }

        protected double speed;
        protected double[] acceleration = { 0, 0 };
        public MovingGameObject(Point size, Point position) : base(size, position) { }

        private void updatePosition()
        {
            position.X += acceleration[0];
            position.Y += acceleration[1];
        }

        public virtual void update(double delta, MoveDir moveFlags)
        {
            double currentSpeed = speed / delta;
            double speedX = 0;
            double speedY = 0;

            if (moveFlags.left)
                speedX = -currentSpeed;
            else if (moveFlags.right)
                speedX = currentSpeed;

            if (moveFlags.up)
                speedY = -currentSpeed;
            else if (moveFlags.down)
                speedY = currentSpeed;

            acceleration[0] = speedX;
            acceleration[1] = speedY;
            updatePosition();
        }
    }
}