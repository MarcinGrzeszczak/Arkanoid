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

            if (size.X <= obj.position.X + obj.size.Z )
                return Collision.LEFT;

            if (position.X >= obj.position.X - obj.size.Z)
                return Collision.RIGHT;

            if (position.Y >= obj.position.Y - obj.size.X)
                return Collision.UP;

            if (size.Y <= obj.position.Y - obj.size.X)
                return Collision.DOWN;

            return Collision.NONE;
        }
    }
}
