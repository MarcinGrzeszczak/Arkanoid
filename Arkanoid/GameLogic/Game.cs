﻿using Arkanoid.GameLogic;
using Arkanoid.GameObjects;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Arkanoid
{
    class Game
    {
        private GameState gameState;
        private GameController controller;
        private GameLevel level;
        private Action<int,bool> endGameCallback;
        private bool isRunning;
        public Game(double width, double height, GameController controller, Action<int,bool> endGameCallback)
        {
            isRunning = false;

            this.controller = controller;
            this.endGameCallback = endGameCallback;

            GameBorder border = new GameBorder(new Point(Console.WindowWidth, Console.WindowHeight), new Point(0, 0));
            
            level = new GameLevel();
            gameState = new GameState(border);
        }

        private void loop(double fps)
        {
            double delay = 1000 / fps;
            refreshConsole(true);
            while (isRunning)
            {
                
                controller.update();
                gameState.update(delay, controller.getKeyFlags());
                refreshConsole();

                Thread.Sleep(60);
            }
        }

        private void refreshConsole(bool firstRun = false){
            gameState.getObjects().ForEach((GameObject obj) => {
                if (obj.isRemoved)
                    GameDrawing.clear(obj);
                else
                    GameDrawing.refresh(obj, firstRun);
                });
        }

        public void start() {

            level.randomLevel();
            gameState.load(level);

            isRunning = true;
            loop(30);
        }

        public void stop()
        {
            isRunning = false;

            endGameCallback(gameState.score, gameState.isWin);
        }
    }
}
