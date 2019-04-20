using Arkanoid.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arkanoid.GameLogic
{
    class GameBorder : GameObject
    {
        public GameBorder(Point size, Point position) : base(size, position) { }

        public override Collision isCollided(GameObject obj)
        {
            if (position.X >= obj.position.X)
                return Collision.LEFT;

            if (position.X + size.X <= obj.position.X)
                return Collision.RIGHT;

            if (position.Y >= obj.position.Y)
                return Collision.UP;

            if (position.Y + size.Y <= obj.position.Y)
                return Collision.DOWN;

            return Collision.NONE;
        }
    }
}
