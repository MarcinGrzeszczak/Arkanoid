using Arkanoid.GameObjects;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Arkanoid.GameLogic
{
    class GameBorder : GameObject
    {
        public GameBorder(Point size, Point position) : base(new Point3D(size.X,size.Y,0), position) { }

        public override Collision isCollided(GameObject obj)
        {
            obj.updateBorder();

            if (position.X >= obj.border.left)
                return Collision.LEFT;

            if (position.X + size.X <= obj.border.right)
                return Collision.RIGHT;

            if (position.Y >= obj.border.top)
                return Collision.UP;

            if (position.Y + size.Y <= obj.border.bottom)
                return Collision.DOWN;

            return Collision.NONE;
        }
    }
}
