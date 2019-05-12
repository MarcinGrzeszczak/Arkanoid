using Arkanoid.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
