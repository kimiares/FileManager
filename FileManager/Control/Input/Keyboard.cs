using FileManager.Commander;
using FileManager.Drawing;
using FileManager.Models;
using FileManager.Structure;
using FileManager.Structure.PanelStrategy;
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
    public class Keyboard : IInput
    {

        Settings MySet = Settings.Instance();
        bool panelIndex = false;
        public void KeyboardHandler(Panel[] panels, ButtonsDictionary dictionary, OperationModel model)
        {
            ConsoleKeyInfo MyKey;
            do
            {
                MyKey = Console.ReadKey();
                Panel activePanel = panels[panelIndex ? 1 : 0];

                switch (MyKey.Key)
                {
                    case ConsoleKey.F5:
                    case ConsoleKey.F6:
                    case ConsoleKey.F7:
                    case ConsoleKey.F8:
                        Menu menu = new Menu(dictionary.GetDecription(MyKey.Key),
                            new Table(
                                dictionary.GetDecription(MyKey.Key),
                                new Point(MySet.MenuStartX, MySet.MenuStartY),
                                new Point(MySet.MenuStartX + MySet.MenuWidth, MySet.MenuStartY + MySet.MenuHeight),
                                0));
                        model.Files = activePanel.SelectedFiles;
                        MenuKeys.MenuKeyboardHandler(menu, dictionary, model);
                        activePanel.ReDraw();
                        break;

                    case ConsoleKey.UpArrow:
                        activePanel.MoveUp();
                        activePanel.FillPanel();
                        break;
                    case ConsoleKey.DownArrow:
                        activePanel.MoveDown();
                        activePanel.FillPanel();
                        break;
                    case ConsoleKey.Tab:
                        panelIndex = !panelIndex;

                        break;
                    case ConsoleKey.D:
                        //menu.DeleteMenu();
                        SupportMethods.SetColour();
                        activePanel.ReDraw();
                        break;
                    case ConsoleKey.Enter:
                        SupportMethods.SetColour();
                        activePanel.OpenFolder();
                        SupportMethods.SetColour();

                        break;

                }

            }
            while (MyKey.Key != ConsoleKey.Escape);
            Console.ReadLine();

        }
    }
}
