using Arkanoid.GameLogic;
using Arkanoid.GameObjects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Arkanoid
{
    class GameState
    {
        private const int DEFAULT_LIVES = 3;

        private GameObject border;
        private List<Brick> bricks;
        private Player player;
        private Ball ball;
        private int currentLives;
        public GameState(GameObject border) {
            this.border = border;
            init();
        }

        public void restartState() {
            init();
        }

        public void update(double delta, GameController.KeyFlags controllerKeyFlags) {
           player.updateXaxisMovement(
                controllerKeyFlags.isPressedLeft, 
                controllerKeyFlags.isPressedRight);

           
            GameObject.Collision playerBorderCollision = border.isCollided(player);

            if (playerBorderCollision == GameObject.Collision.LEFT)
                player.updateXaxisMovement(false, controllerKeyFlags.isPressedRight);
    
            if (playerBorderCollision == GameObject.Collision.RIGHT)
                player.updateXaxisMovement(controllerKeyFlags.isPressedLeft, false);


            if (ball.isSticked) 
                ball.movement = player.movement;
            else {
                ball.bounce(border.isCollided(ball));

                GameObject.Collision playerCollision = ball.isCollided(player);
                if (playerCollision == GameObject.Collision.DOWN)
                    ball.bounce(GameObject.Collision.DOWN);
            }

            if (controllerKeyFlags.isPressedSpace && ball.isSticked)
                ball.throwBall();

            player.update(delta);
            ball.update(delta);

        }

        public void load(GameLevel level)
        {
            this.bricks = level.getBricks();
            player = level.getPlayer();
            ball = level.getBall();
        }

        public List<GameObject> getObjects()
        {
            List<GameObject> allObjects = bricks.Cast<GameObject>().ToList();
            allObjects.Add(player);
            allObjects.Add(ball);
            return allObjects;
        }

        private void init()
        {
            bricks = new List<Brick>();
            currentLives = DEFAULT_LIVES;
           
        }
    }
}
