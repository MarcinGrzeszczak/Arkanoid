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
      
        public MovingGameObject(Point3D size, Point position) : base(size, position) {
            restartPosition();
        }

        public virtual void restartPosition(){
            translatedPosition = new Point(0, 0);
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

        public override void refreshShape()
        {
            shape.Transform = new TranslateTransform3D(translatedPosition.Y, 0, translatedPosition.X);
        }

        public virtual void reactToCollision(Collision collision) {}

        public virtual void update(double delta)
        {
            double currentSpeed = speed / delta;

            if (movement.left)
                translatedPosition.X += currentSpeed;
            if (movement.right)
                translatedPosition.X -= currentSpeed;

            if (movement.up)
                translatedPosition.Y -= currentSpeed;
            if (movement.down)
                translatedPosition.Y += currentSpeed;

           
            
        }
    }
}