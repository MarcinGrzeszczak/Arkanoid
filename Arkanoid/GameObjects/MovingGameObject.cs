using System.Windows;
using System.Windows.Media.Media3D;

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
        private Point originalPosition;
      
        public MovingGameObject(Point3D size, Point position) : base(size, position) {
            originalPosition = position;
        }

        public virtual void restartPosition(){
            position = originalPosition;
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

        public virtual void reactToCollision(Collision collision) {}

        public virtual void update(double delta)
        {
            double currentSpeed = speed / delta;

            if (movement.left)
                position.X += currentSpeed;
            if (movement.right)
                position.X -= currentSpeed;

            if (movement.up)
                position.Y -= currentSpeed;
            if (movement.down)
                position.Y += currentSpeed;

           
            
        }
    }
}