using Arkanoid.GameLogic;
using Arkanoid.GameObjects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using static Arkanoid.GameObjects.GameObject;

namespace Arkanoid
{
    class GameState
    {
        private const int DEFAULT_LIVES = 3;

        private GameBorder border;
        private List<Brick> bricks;
        private List<GameObject> removedObjects;

        private Player player;
        private Ball ball;
        public int currentLives;
        public bool endgame;
        public bool isWin;
        public int score;
        public GameState(GameBorder border) {
            this.border = border;
            init();
        }

        public void restartState() {
            init();
        }

        private void addScore(int points) {
            score += points;
        }

        private void loseLive(){
            ball.isSticked = true;
            ball.restartPosition();
            player.restartPosition();

            if (currentLives > 1)
                --currentLives;
            else
                gotEndgame();
        }

        private void gotEndgame() {
            removedObjects = getObjects();
            getObjects().Clear();
            endgame = true;
        }

        public void update(double delta, GameController.KeyFlags controllerKeyFlags) {

           player.updateXaxisMovement(
                controllerKeyFlags.isPressedLeft, 
                controllerKeyFlags.isPressedRight);

            player.reactToCollision(border.isCollided(player));

            if (ball.isSticked) 
                ball.movement = player.movement;

            else {
                ball.reactToCollision(ball.isCollided(player));

                Collision isCollidedWithBorder = border.isCollided(ball);
                if (isCollidedWithBorder == Collision.DOWN) {
                    loseLive();
                }
                else
                    ball.reactToCollision(isCollidedWithBorder);

                for (int brickIndex = 0; brickIndex < bricks.Count; ++brickIndex) {
                    Collision isCollidedWithBrick = ball.isCollided(bricks[brickIndex]);
                    ball.reactToCollision(isCollidedWithBrick);

                    if(isCollidedWithBrick != Collision.NONE) {
                        addScore(Brick.POINTS);

                        removedObjects.Add(bricks[brickIndex]);
                        bricks.RemoveAt(brickIndex);
                    }
                }

                if(bricks.Count <= 0) {
                    gotEndgame();
                    isWin = true;
                }
            }

            if (controllerKeyFlags.isPressedSpace && ball.isSticked)
                ball.throwBall();

           
            ball.update(delta);
            player.update(delta);

        }

        public void load(GameLevel level)
        {
            restartState();

            this.bricks = level.getBricks();
            player = level.getPlayer();
            ball = level.getBall();
        }


        public List<GameObject> getRemovedObjects() {
            return removedObjects;
        }

        public List<GameObject> getObjects()
        {
            List<GameObject> allObjects = bricks.Cast<GameObject>().ToList();
            if(player != null)
                allObjects.Add(player);

            if(ball != null)
                allObjects.Add(ball);

            return allObjects;
        }

        private void init()
        {
            endgame = false;
            isWin = false;
            bricks = new List<Brick>();
            removedObjects = new List<GameObject>();
            score = 0;
            currentLives = DEFAULT_LIVES;
           
        }
    }
}
