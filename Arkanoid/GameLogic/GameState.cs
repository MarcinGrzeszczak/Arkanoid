﻿using Arkanoid.GameLogic;
using Arkanoid.GameObjects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Arkanoid
{
    class GameState
    {
        private const int DEFAULT_LIVES = 3;

        private GameBorder border;
        private List<Brick> bricks;
        private Player player;
        private Ball ball;
        private int currentLives;
        public GameState(GameBorder border) {
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

            player.reactToCollision(border.isCollided(player));

            if (ball.isSticked) 
                ball.movement = player.movement;

            else {
                ball.reactToCollision(ball.isCollided(player));
                ball.reactToCollision(border.isCollided(ball));   
            }

            if (controllerKeyFlags.isPressedSpace && ball.isSticked)
                ball.throwBall();

           
            ball.update(delta);
            player.update(delta);

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
