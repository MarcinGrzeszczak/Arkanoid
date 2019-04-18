using Arkanoid.GameLogic;
using Arkanoid.GameObjects;
using System.Collections.Generic;
using System.Linq;

namespace Arkanoid
{
    class GameState
    {
     

        private const int DEFAULT_LIVES = 3;

        private Collisions collisions;
        private List<Brick> bricks;
        private Player player;
        private Ball ball;
        private int currentLives;
        public GameState(Collisions collisions) {
            init();
            this.collisions = collisions;
        }

        public void restartState() {
            init();
        }

        private bool isBorder(GameObject obj)
        {


            return false;
        }

        public void update(double delta, GameController.KeyFlags controllerKeyFlags) {
            Player.MoveDir movement = Player.movementWrapper(
                controllerKeyFlags.isPressedLeft, 
                controllerKeyFlags.isPressedRight);

            if (collisions.isBorder(player) == Collisions.Border.LEFT)
                movement.left = false;

            if (collisions.isBorder(player) == Collisions.Border.RIGHT)
                movement.right = false;

            player.update(delta,movement);

            if (ball.isSticked) {
                if (controllerKeyFlags.isPressedSpace)
                    ball.isSticked = false;
                ball.update(delta, movement);
            }
            else
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
