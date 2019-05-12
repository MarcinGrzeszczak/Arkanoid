using Arkanoid.GameObjects;
using System;
using System.Collections.Generic;

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
    }
}
