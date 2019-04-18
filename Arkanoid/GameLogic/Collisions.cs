
using Arkanoid.GameObjects;
using System.Windows;

namespace Arkanoid.GameLogic
{
    class Collisions
    {
        public enum Border { LEFT,RIGHT,UP,DOWN,NONE}
        Rect borders;

        public Collisions(Rect borders)
        {
            this.borders = borders;
        } 

        public Border isBorder(GameObject obj)
        {
            if (obj.position.X <= borders.X)
                return Border.LEFT;

            if (obj.position.X + obj.size.X >= borders.Width)
                return Border.RIGHT;

            if (obj.position.Y <= borders.Y)
                return Border.UP;

            if (obj.position.Y + obj.size.Y >= borders.Height)
                return Border.DOWN;

            return Border.NONE;
        }
    }
}
