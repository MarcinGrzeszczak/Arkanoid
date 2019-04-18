
using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameObjects
{
    class GameObject
    {
        protected Point size;
        protected Point position;

        public GameObject(Point size, Point position)
        {
            this.size = size;
            this.position = position;
        }

        public bool collision(GameObject obj)
        {
            return obj.position.X + obj.size.X / 2 >= this.position.X + this.size.X / 2 && 
                obj.position.Y + obj.size.Y / 2 >= this.position.Y + this.size.Y / 2;
        }

        public virtual void draw(DrawingContext dc) { }
    }
}
