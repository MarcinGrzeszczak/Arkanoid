using Arkanoid.GameLogic;
using Arkanoid.GameObjects;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arkanoid
{
    class Game
    {
        private GameDrawing gameViewport;
        private GameState gameState;
        private GameController controller;
        private GameLevel level;
        private Label scoreLabel, liveLabel;
        private Action<int,bool> endGameCallback;
        private bool isRunning;
        public Game(GameDrawing gameViewport, GameController controller, Action<int,bool> endGameCallback)
        {
            isRunning = false;
            liveLabel = null;
            scoreLabel = null;

            this.gameViewport = gameViewport;
            this.controller = controller;
            this.endGameCallback = endGameCallback;

            GameBorder border = new GameBorder(gameViewport.getsSize(), new Point(0, 0));
          
            level = new GameLevel();
            gameState = new GameState(border);
        }

        public void setScoreLabel(Label scoreLabel){
            this.scoreLabel = scoreLabel;
        }

        public void setLiveLabel(Label liveLabel){
            this.liveLabel = liveLabel;
        }
        private void loop(double fps)
        {
            double delay = 1000 / fps;
           
            long last = Environment.TickCount;
            int timer = Environment.TickCount;
            double delta = 0;

            while (isRunning)
            {
                long now = Environment.TickCount;
                delta += (now - last) / delay;  
                last = now;

                while (delta >= 1)
                {
                    gameState.update(delta, controller.getKeyFlags());
                    if (gameState.endgame)
                        stop();

                    updateControls();
                    draw();

                    delta--;
                }
            }
        }

        private void updateControls(){
            if(scoreLabel != null)
                scoreLabel.Dispatcher.Invoke(() => scoreLabel.Content = gameState.score);

            if (liveLabel != null)
                liveLabel.Dispatcher.Invoke(() => liveLabel.Content = gameState.currentLives);

        }

        private void draw()
        {
           gameViewport.draw(gameState.getObjects()[0].draw);
            isRunning = false;
        }

        public void start() {

            level.randomLevel();
            gameState.load(level);
           

            isRunning = true;
            Task.Factory.StartNew(() => loop(60));
        }

        public void stop() {
            isRunning = false;
            
            endGameCallback(gameState.score,gameState.isWin);
        }
    }
}
