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
        private Game game;
        public MainWindow()
        {
            InitializeComponent();

            GameController controller = new GameController();
            mainWindow.KeyDown += controller.keyDownEvent;
            mainWindow.KeyUp += controller.keyUpEvent;
        
            game = new Game(
                mainGrid.ColumnDefinitions[1].Width.Value, 
                761,
                controller,
                endGameHandler);

            game.setScoreLabel(Score_Content_Label);
            game.setLiveLabel(Live_Content_Label);

            GameCanvas gameCanvas = game.getGameCanvas();
            Grid.SetColumn(gameCanvas, 1);
            mainGrid.Children.Add(gameCanvas);

            NewGameButton.Click += StartNewGame;
            TryAgainButton.Click += StartNewGame;
        }

        private void StartNewGame(object sender, RoutedEventArgs e)
        {
            game.start();
            NewGame_Splash_Screen.Visibility = Visibility.Collapsed;
            EndGame_Splash_Screen.Visibility = Visibility.Collapsed;
        }

        private void endGameHandler(int score) {
            Dispatcher.Invoke(() =>
            {
                EndGame_Splash_Screen.Visibility = Visibility.Visible;
                FinalScoreLabel.Content = score;
            });
         
        }
    }
}
