using Arkanoid.GameLogic;


namespace Arkanoid
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController controller = new GameController();
            Game game = new Game(200,300,controller,null);
            game.start();
        }
    }
}
