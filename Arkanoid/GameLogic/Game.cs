using Arkanoid.GameLogic;
using Arkanoid.GameObjects;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Arkanoid
{
    class Game
    {
        private GameCanvas gameCanvas;
        private GameState gameState;
        private GameController controller;
        
        public Game(double width, double height, GameController controller)
        {
            this.controller = controller;

            //TODO: Usunac tworzenie levelu z konstruktora
            GameObject border = new GameObject(new Point(width, height), new Point(0, 0));

            GameLevel level = new GameLevel();
            
            level.randomLevel();

            gameState = new GameState(border);
            gameState.load(level);

            gameCanvas = new GameCanvas(draw);
            gameCanvas.setSize(width, height);
            gameCanvas.setBackground(level.getBackgourndColor());

            Task.Factory.StartNew(()=>loop(60));
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
                    gameCanvas.refreshDraw();
                    delta--;
                }
            }
        }

        private void draw(DrawingContext dc)
        {
            gameState.getObjects().ForEach((GameObject obj) => obj.draw(dc));
        }

        public GameCanvas getGameCanvas() => this.gameCanvas;
    }
}
