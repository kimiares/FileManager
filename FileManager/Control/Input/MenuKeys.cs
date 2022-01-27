using FileManager.Control.Input;
using FileManager.Models;
using FileManager.Structure;
using FileManager.Structure.PanelStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control
{
    public class MenuKeys
    {

        public static void MenuKeyboardHandler(Menu menu, ButtonsDictionary dictionary, OperationModel model)
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
                        if (menu.ActiveButton)
                        {
                            dictionary.RunOperation(MyKey.Key, model);
                        }
                        else
                        {
                            menu.DeleteMenu();
                        }
                        SupportMethods.SetColour();
                        break;
                }
            }
            while (MyKey.Key != ConsoleKey.Enter);

            if (menu.ActiveButton)
            {
                dictionary.RunOperation(MyKey.Key, model);
            }
            else
            {
                menu.DeleteMenu();
            }
            SupportMethods.SetColour();

        }
    }
}
