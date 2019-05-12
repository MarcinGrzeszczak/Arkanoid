using Arkanoid.GameObjects;
using System;
using System.Collections.Generic;

namespace Arkanoid
{
    class GameDrawing
    {

        public static void clear() {
            Console.Clear();
        }

        public static void refresh(GameObject gameObject){
            Console.ForegroundColor = gameObject.color;
            Console.SetCursorPosition((int) gameObject.position.X, (int) gameObject.position.Y);
            Console.Write(gameObject.draw());
            Console.ResetColor();
        }
    }
}
