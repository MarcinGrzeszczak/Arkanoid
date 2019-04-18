﻿
using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameObjects
{
    class Brick : GameObject
    {
        public enum STRENGTH_LEVEL{ LOW, MEDIUM, HEIGHT };

        public static Point DEFAULT_SIZE = new Point(50, 25);

        private Color brickColor;

        public Brick(Point size, Point position, Color brickColor): base(size, position)
        {
            this.brickColor = brickColor;
        }

        public Brick(Point position, Color brickColor) :base(DEFAULT_SIZE, position)
        {
            this.brickColor = brickColor;
        }

        public override void draw(DrawingContext dc)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = brickColor;

            dc.DrawRectangle(brush, null, new Rect(position.X, position.Y, size.X, size.Y));
        }
    }
}
