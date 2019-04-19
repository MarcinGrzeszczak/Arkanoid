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
           player.updateXaxisMovement(
                controllerKeyFlags.isPressedLeft, 
                controllerKeyFlags.isPressedRight);

            if (ball.isSticked) {
                if (controllerKeyFlags.isPressedSpace)
                    ball.isSticked = false;
                ball.updateXaxisMovement(
                    controllerKeyFlags.isPressedLeft,
                    controllerKeyFlags.isPressedRight);
            }

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
