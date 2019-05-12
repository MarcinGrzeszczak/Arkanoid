using Arkanoid.GameObjects;
using System;


namespace Arkanoid
{
    class GameDrawing
    {

        public GameDrawing() {
            Console.CursorVisible = false;
        }

        public static void clear(GameObject gameObject) {
            Console.SetCursorPosition((int)gameObject.prevPosition.X, (int)gameObject.prevPosition.Y);
            Console.Write(gameObject.clear());
        }

        public static void refresh(GameObject gameObject, bool firstRun=false){
            if (!gameObject.prevPosition.equalTo(gameObject.position) || firstRun)
            {
                clear(gameObject);
                Console.ForegroundColor = gameObject.color;
                Console.SetCursorPosition((int)gameObject.position.X, (int)gameObject.position.Y);
                Console.Write(gameObject.draw());
                Console.ResetColor();
            }
        }


        public static void endgame(bool isWon, int score) {
            Console.Clear();
            Console.SetCursorPosition(5, 3);
            Console.Write("************************");

            for(int i=0; i <7; ++i){
                Console.SetCursorPosition(5, 3+i);
                Console.Write('*');
                Console.SetCursorPosition(28, 3 + i);
                Console.Write('*');
            }
            Console.SetCursorPosition(12, 5);
            Console.Write("Game Over!");
            Console.SetCursorPosition(10, 8);
            Console.Write("Your score : "+score);
            Console.SetCursorPosition(5, 10);
            Console.Write("************************");
            Console.ReadKey();
        }
    }
}
