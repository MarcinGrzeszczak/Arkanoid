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
        public MoveDir movement;
        protected double[] acceleration = { 0, 0 };

        public MovingGameObject(Point size, Point position) : base(size, position) { }

        public virtual void restartPosition(){
            position = startPosition;
            
        }

        public void updateXaxisMovement(bool left, bool right) {
            movement.left = left;
            movement.right = right;
        }

        public void updateYaxisMovement(bool up, bool down)
        {
            movement.up = up;
            movement.down = down;
        }

        private void updatePosition()
        {
            prevPosition = position;
            position.X += acceleration[0];
            position.Y += acceleration[1];
        }

        public virtual void reactToCollision(Collision collision) {}

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