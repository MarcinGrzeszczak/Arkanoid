using Arkanoid.GameLogic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

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

            GameDrawing gameViewport = new GameDrawing(GameViewport);
            GameController controller = new GameController();
            mainWindow.KeyDown += controller.keyDownEvent;
            mainWindow.KeyUp += controller.keyUpEvent;
        
            game = new Game(
                gameViewport,
                controller,
                endGameHandler);

            game.setScoreLabel(Score_Content_Label);
            game.setLiveLabel(Live_Content_Label);

            NewGameButton.Click += StartNewGame;
            TryAgainButton.Click += StartNewGame;
         
        }

        
        private void StartNewGame(object sender, RoutedEventArgs e)
        {
            game.start();
            NewGame_Splash_Screen.Visibility = Visibility.Collapsed;
            EndGame_Splash_Screen.Visibility = Visibility.Collapsed;
        }

        private void endGameHandler(int score, bool winner) {
            Dispatcher.Invoke(() =>
            {
                if (winner)
                {
                    EndGameLabel.Content = "Epic Win!";
                }
                else
                    EndGameLabel.Content = "Game Over!";
                EndGame_Splash_Screen.Visibility = Visibility.Visible;
                FinalScoreLabel.Content = score;
            });
         
        }
        
    }
}
