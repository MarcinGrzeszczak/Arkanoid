using Arkanoid.GameObjects;
using System;
using System.Collections.Generic;


namespace Arkanoid.GameLogic
{
    class GameLevel
    {
        private List<Brick> bricks;
        private Player player;
        private Ball ball;
        private Color color;
       
        public GameLevel()
        {
        }

        public List<Brick> getBricks() => bricks;
        public Player getPlayer() => player;
        public Ball getBall() => ball;
    
        public void randomLevel()
        {
            player = new Player(new Point(10,15));
            
            // TODO: Udostepnic publicznie size obiektow
            ball = new Ball(new Point(10,14));
            bricks = new List<Brick>();
          

            Point position = new Point(1, 1);
            color = new Color();
            for (int row = 0; row < 4; ++row)
            {
                for (int column = 0; column < 10; ++column)
                {
                   
                    color.randomColor();
                    bricks.Add(new Brick(
                        position,
                        color.getColor()
                        )
                    );
                    

                    position.X += Brick.DEFAULT_SIZE.X;
                }

                position.Y += Brick.DEFAULT_SIZE.Y;
                position.X = 1;
            }
            
        }
    }
}
