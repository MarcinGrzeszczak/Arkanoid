using Arkanoid.GameLogic;
using System;

namespace Arkanoid.GameObjects
{
    class GameObject
    {
        public struct Border {
            public double left, right, top, bottom;
        }
        public enum Collision { LEFT, RIGHT, UP, DOWN, NONE }

        public Border border;
        public Point size;
        protected Point startPosition;
        public Point position;
        public Point prevPosition;
        public ConsoleColor color;
        public bool isRemoved = false;

        public void updateBorder()
        {
            border.left = position.X - size.X / 2;
            border.right = position.X + size.X / 2;

            border.top = position.Y - size.Y / 2;
            border.bottom = position.Y + size.Y / 2;
        }

        public GameObject(Point size, Point position)
        {
            this.size = size;
            this.position = position;
            this.prevPosition = position;
            this.startPosition = position;
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


        public virtual string draw() { return ""; }

        public virtual string clear() { return ""; }
        protected void centerPosition (){
            position.X = position.X + size.X / 2;
            position.Y = position.Y + size.Y / 2;
            this.prevPosition = position;
        }
    }
}
