using System.Windows;
using System.Windows.Media.Media3D;

namespace Arkanoid.GameObjects
{
    class GameObject
    {
        public struct Border {
            public double left, right, top, bottom;
        }
        public enum Collision { LEFT, RIGHT, UP, DOWN, NONE }

        public Border border;
        public Point3D size;
        public Point position;
        protected ModelVisual3D shape;

        public void updateBorder()
        {
            border.left = position.X - size.Z ;
            border.right = position.X + size.Z ;

            border.top = position.Y - size.X;
            border.bottom = position.Y + size.X ;
        }

        public GameObject(Point3D size, Point position)
        {
            shape = new ModelVisual3D();
            this.size = size;
            this.position = position;
        }

        public ModelVisual3D getShape()
        {
            return shape;
        }

        public virtual Collision isCollided(GameObject obj) {
            updateBorder();
            obj.updateBorder();

             if(border.right >= obj.border.left && border.left <= obj.border.right){

                if (border.bottom >= obj.border.top && border.bottom <= obj.position.Y)
                    return Collision.DOWN;

                if (border.top <= obj.border.bottom && border.top >= obj.position.Y)
                    return Collision.UP;
            }

            if(border.bottom >= obj.border.top && border.top <= obj.border.bottom) {

                if (border.right >= obj.border.left && border.right <= obj.position.X)
                    return Collision.RIGHT;

                if (border.left <= obj.border.right && border.left >= obj.position.X)
                    return Collision.LEFT;
            }
            
            return Collision.NONE;
        }

        public void refreshShape()
        {
            shape.Transform = new TranslateTransform3D(position.Y, 0, position.X);
        }

        public virtual ModelVisual3D draw() { return shape; }

        protected void centerPosition (){
            position.X = position.X + size.X / 2;
            position.Y = position.Y + size.Y / 2;
        }
    }
}
