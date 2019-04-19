using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameObjects
{
    class GameObject
    {
        public enum Collision { LEFT, RIGHT, UP, DOWN, NONE }
        
        public Point size;
        public Point position;

        public GameObject(Point size, Point position)
        {
            this.size = size;
            this.position = position;
        }

        public Collision isCollided(GameObject obj) {
                if (position.X <= obj.position.X)
                    return Collision.LEFT;

                if (position.X + size.X >= obj.position.X + obj.size.X)
                    return Collision.RIGHT;

                if (position.Y <= obj.position.Y)
                    return Collision.UP;

                if (position.Y + size.Y >= obj.position.Y + obj.size.Y)
                    return Collision.DOWN;
        
            return Collision.NONE;
        }


        public virtual void draw(DrawingContext dc) { }

    }
}
