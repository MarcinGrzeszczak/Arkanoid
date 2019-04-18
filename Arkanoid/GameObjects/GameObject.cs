
using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameObjects
{
    class GameObject
    {
        public Point size;
        public Point position;

        public GameObject(Point size, Point position)
        {
            this.size = size;
            this.position = position;
        }

        public virtual void draw(DrawingContext dc) { }
    }
}
