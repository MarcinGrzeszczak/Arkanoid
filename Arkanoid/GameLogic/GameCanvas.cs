using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arkanoid
{
    class GameCanvas : Canvas
    {
        public double width { set; get; }
        public double height { set; get; }

        private Action<DrawingContext> drawCallback;
        public GameCanvas(Action<DrawingContext> drawCallback) {
            this.drawCallback = drawCallback;

          
        }

        public void setBackground(Color color)
        {
            Background = new SolidColorBrush(color);
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            drawCallback(dc);
        }

        private void reDraw()
        {
            InvalidateVisual();
            UpdateLayout();
        } 

        public void refreshDraw()
        {
            Dispatcher.Invoke(reDraw);
        }

        public void setSize(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public void Start() { }
        public void Stop() { }
    }
}
