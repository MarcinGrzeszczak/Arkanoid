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
        protected MoveDir movement;
        protected double[] acceleration = { 0, 0 };

        public void updateXaxisMovement(bool left, bool right) {
            movement.left = left;
            movement.right = right;
        }

        public void updateYaxisMovement(bool up, bool down)
        {
            movement.up = up;
            movement.down = down;
        }

        public MovingGameObject(Point size, Point position) : base(size, position) { }

        private void updatePosition()
        {
            position.X += acceleration[0];
            position.Y += acceleration[1];
        }

        public virtual void update(double delta)
        {
            double currentSpeed = speed / delta;
            double speedX = 0;
            double speedY = 0;

            if (movement.left)
                speedX = -currentSpeed;
            if (movement.right)
                speedX = currentSpeed;

            if (movement.up)
                speedY = -currentSpeed;
            if (movement.down)
                speedY = currentSpeed;

            acceleration[0] = speedX;
            acceleration[1] = speedY;
            updatePosition();
        }
    }
}