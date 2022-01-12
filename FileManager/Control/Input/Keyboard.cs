using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.Input
{
    /// <summary>
    /// обработчик клавиатуры
    /// </summary>
    class Keyboard:IInput
    {
       
        public static ConsoleKeyInfo GetKey()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            }
            while (key.Key == 0);
            return key;
        }
        ConsoleKey MyKey;
            do
            {
                switch (MyKey)
                {
                    case ConsoleKey.F1:
                        break;
                    case ConsoleKey.F2:
                        break;
                    case ConsoleKey.F3:
                        break;
                    case ConsoleKey.Escape:
                        break;
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Tab:
                        break;
                }
}
while (MyKey != ConsoleKey.Escape) ;
    }
}
