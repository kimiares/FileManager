using FileManager.Commander;
using FileManager.Drawing;
using System;
using FileManager.Structure;
using FileManager.Structure.PanelStrategy;
using FileManager.Operations;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileManager.Structure.Models;
using FileManager.Models;
using FileManager.Control.Input;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            Settings MySet = Settings.Instance();


            OperationModel operationModel = new OperationModel()
            { Path = @"C:\Windows",
                
            };
            
            List<FileSystemInfo> testFSI = Folder.GetFolder(operationModel).ToList();

            PanelModel firstPanelModel = new PanelModel()
            {
                StartPoint = MySet.FirstPanelStart,
                FinishPoint = MySet.FirstPanelFinish,
                Path = MySet.Sets.PathLeft,
                Index = 0,
                Drawing = new Table(MySet.Sets.PathLeft, MySet.FirstTabelStart, MySet.FirstTabelFinish, MySet.ColumnCountLeft),
                Algorithm = new OneProperty()
            };



            PanelModel secondPanelModel = new PanelModel() 
            {
                StartPoint = MySet.SecondPanelStart,
                FinishPoint = MySet.SecondPanelFinish,
                Path = MySet.Sets.PathRight,
                Index = 1,
                Drawing = new Table(MySet.Sets.PathRight, MySet.SecondTabelStart, MySet.SecondTabelFinish, MySet.ColumnCountRight),
                Algorithm = new ThreeProperties()
            };


            


        Panel firstPanel = new Panel(firstPanelModel,testFSI);
           

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            Panel secondPanel = new Panel(secondPanelModel,testFSI);


            List<Panel> panels = new List<Panel>() { firstPanel, secondPanel };

            bool panelIndex = false;
            
            
            //Menu menu = new Menu("test",
            //    new Table(
            //        "test",
            //        new Point(MySet.MenuStartX, MySet.MenuStartY),
            //        new Point(MySet.MenuStartX + MySet.MenuWidth, MySet.MenuStartY + MySet.MenuHeight),
            //        0));
            
            List<string> items = new List<string>();

            foreach (var d in Enum.GetValues(typeof(ButtonEnum)))
            {
                items.Add(d.ToString().PadRight(10));
            }

            Buttons F_Buttons = new Buttons(new Drawing.Point(1, 29), 10, 1, 2, items);
            
            //лечит переход на новую строку после таба
            Console.SetCursorPosition(0, 0);

            ButtonsDictionary dictionary = new ButtonsDictionary();
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
                        //меню тут
                        dictionary.RunOperation(MyKey.Key, operationModel);
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
                        //menu.ChangeActiveButton();
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

