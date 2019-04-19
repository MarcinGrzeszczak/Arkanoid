using Arkanoid.GameObjects;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Arkanoid.GameLogic
{
    class GameLevel
    {
        private List<Brick> bricks;
        private Player player;
        private Ball ball;
        private Random rand;
        private Color backgorundColor;
        struct RGB
        {
            private Random rand;
            public byte R, G, B;

            public RGB(Random rand) : this()
            {
                this.rand = rand;
            }

            public void nextColor()
            {
                R = (byte)rand.Next(255);
                G = (byte)rand.Next(255);
                B = (byte)rand.Next(255);
            }
        }

        public GameLevel()
        {
            rand = new Random();
        }

        public List<Brick> getBricks() => bricks;
        public Player getPlayer() => player;
        public Ball getBall() => ball;
        public Color getBackgourndColor() => backgorundColor;

        public void randomLevel()
        {
            player = new Player(new Point(200,700));
            
            // TODO: Udostepnic publicznie size obiektow
            ball = new Ball(new Point(200 + Player.DEFAULT_SIZE.X / 2, 700 - Ball.DEFAULT_SIZE.Y- 1));
            bricks = new List<Brick>();
            backgorundColor = Colors.DarkCyan;

            Point position = new Point(0, 0);
            RGB randRGB = new RGB(rand);

            for (int row = 0; row < 4; ++row)
            {
                for (int column = 0; column < 10; ++column)
                {
                    randRGB.nextColor();

                    bricks.Add(new Brick(
                        position, 
                        Color.FromRgb(randRGB.R, randRGB.G, randRGB.B)
                        )
                    );

                    position.X += Brick.DEFAULT_SIZE.X;
                }

                position.Y += Brick.DEFAULT_SIZE.Y;
                position.X = 0;
            }
            
        }
    }
}
