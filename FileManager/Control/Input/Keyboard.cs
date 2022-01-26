using FileManager.Structure;
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
    public class Keyboard:IInput
    {


        public void MenuKeyboardHandler(Menu menu)
        {
            ConsoleKeyInfo MyKey;
            do
            {
                MyKey = Console.ReadKey();
                switch (MyKey.Key)
                {
                    case ConsoleKey.Tab:
                        menu.ChangeActiveButton();
                        break;
                    case ConsoleKey.Escape:
                        menu.DeleteMenu();
                        break;
                    case ConsoleKey.Enter:
                        menu.CheckActiveButton();
                        break;

                }
            }
            while (MyKey != ConsoleKey.Enter);
        }
}
