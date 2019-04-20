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

        public virtual Collision isCollided(GameObject obj) {
             if(position.X >= obj.position.X && position.X <= obj.position.X + obj.size.X){

                if (position.Y >= obj.position.Y && position.Y <= obj.position.Y + obj.size.Y / 2)
                    return Collision.DOWN;

                if (position.Y <= obj.position.Y + obj.size.Y && position.Y >= obj.position.Y + obj.size.Y / 2)
                    return Collision.UP;
            }

            if(position.Y >= obj.position.Y && position.Y <= obj.position.Y + obj.size.Y) {

                if (position.X >= obj.position.X && position.X <= obj.position.X + obj.size.X / 2)
                    return Collision.RIGHT;

                if (position.X <= obj.position.X + obj.size.X && position.X >= obj.position.X + obj.size.X / 2)
                    return Collision.LEFT;
            }
        
            return Collision.NONE;
        }


        public virtual void draw(DrawingContext dc) { }

    }
}
