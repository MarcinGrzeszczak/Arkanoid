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
        private GameCanvas gameCanvas;
        private GameState gameState;
        private GameController controller;
        private Label scoreLabel, liveLabel;
        public Game(double width, double height, GameController controller)
        {
            liveLabel = null;
            scoreLabel = null;
            this.controller = controller;

            //TODO: Usunac tworzenie levelu z konstruktora
            GameBorder border = new GameBorder(new Point(width, height), new Point(0, 0));
          
            GameLevel level = new GameLevel();
            
            level.randomLevel();

            gameState = new GameState(border);
            gameState.load(level);

            gameCanvas = new GameCanvas(draw);
            gameCanvas.setSize(width, height);
            gameCanvas.setBackground(level.getBackgourndColor());

            Task.Factory.StartNew(()=>loop(60));
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
            bool isRunning = true;

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
                    updateControls();
                    gameCanvas.refreshDraw();
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

        private void draw(DrawingContext dc)
        {
            gameState.getObjects().ForEach((GameObject obj) => obj.draw(dc));
        }

        public GameCanvas getGameCanvas() => this.gameCanvas;
    }
}
