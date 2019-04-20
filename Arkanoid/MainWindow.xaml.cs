using Arkanoid.GameLogic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arkanoid
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GameController controller = new GameController();
            mainWindow.KeyDown += controller.keyDownEvent;
            mainWindow.KeyUp += controller.keyUpEvent;

            Game game = new Game(
                mainGrid.ColumnDefinitions[1].Width.Value, 
                761,
                controller);

            game.setScoreLabel(Score_Content_Label);
            game.setLiveLabel(Live_Content_Label);

            GameCanvas gameCanvas = game.getGameCanvas();
            Grid.SetColumn(gameCanvas, 1);
            mainGrid.Children.Add(gameCanvas);
        }           
    }
}
