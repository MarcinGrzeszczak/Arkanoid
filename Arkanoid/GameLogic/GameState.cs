using Arkanoid.GameLogic;
using Arkanoid.GameObjects;
using System.Collections.Generic;
using System.Linq;

namespace Arkanoid
{
    class GameState
    {
        private const int DEFAULT_LIVES = 3;

        private List<Brick> bricks;
        private Player player;
        private Ball ball;

        private int currentLives;
        public GameState() {
            init();
        }

        public void restartState() {
            init();
        }


        public void update(double delta, GameController.KeyFlags controllerKeyFlags) {
            player.update(
                delta,
                controllerKeyFlags.isPressedLeft, 
                controllerKeyFlags.isPressedRight);   
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
