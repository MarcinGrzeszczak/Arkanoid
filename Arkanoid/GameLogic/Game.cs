using Arkanoid.GameLogic;
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

            GameBorder border = new GameBorder(new Point(width, height), new Point(0, 0));
          
            level = new GameLevel();
            gameState = new GameState(border);
        }

        private void loop(double fps)
        {
            double delay = 1000 / fps;
           
            while (isRunning)
            { 
                //gameState.update(delta, controller.getKeyFlags());
                refreshConsole();

                Thread.Sleep((int) delay);
            }
        }

        private void refreshConsole(){
            gameState.getObjects().ForEach((GameObject obj) => GameDrawing.refresh(obj));
        }

        public void start() {

            level.randomLevel();
            gameState.load(level);
            //gameCanvas.setBackground(level.getBackgourndColor());

            isRunning = true;
            loop(1);
        }

        public void stop()
        {
            isRunning = false;

            endGameCallback(gameState.score, gameState.isWin);
        }
    }
}
