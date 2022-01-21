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

            List<FileSystemInfo> testFSI = Folder.GetFolder(@"C:\Windows").ToList();

            PanelModel firstPanelModel = new PanelModel();
            { firstPanelModel.StartPoint = new Drawing.Point(1, 1);
                firstPanelModel.FinishPoint = new Point(59, 27);
                firstPanelModel.Path = MySet.Sets.PathLeft;
                firstPanelModel.Index = 0;
                firstPanelModel.Drawing = new Table(MySet.Sets.PathLeft, new Drawing.Point(0, 0), new Drawing.Point(59, 28), 3);
                firstPanelModel.Algorithm = new OneProperty();
             
            }

            PanelModel secondPanelModel = new PanelModel();
            {
                secondPanelModel.StartPoint = new Drawing.Point(61, 1);
                secondPanelModel.FinishPoint = new Drawing.Point(119, 27);
                secondPanelModel.Path = MySet.Sets.PathRight;
                secondPanelModel.Index = 1;
                secondPanelModel.Drawing = new Table(MySet.Sets.PathLeft, new Drawing.Point(61, 0), new Drawing.Point(119, 28), 3);
                secondPanelModel.Algorithm = new ThreeProperties();

            }

            Panel panel = new Panel(firstPanelModel,testFSI);
       

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            Panel panel1 = new Panel(secondPanelModel,testFSI);
        

            List<string> items = new List<string>();

            foreach (var d in Enum.GetValues(typeof(ButtonEnum)))
            {
                items.Add(d.ToString().PadRight(10));
            }

            Buttons F_Buttons = new Buttons(new Drawing.Point(1, 29), 10, 1, 2, items);
            Panel ddd = panel;
            ConsoleKeyInfo MyKey;
            do
            {
                MyKey = Console.ReadKey();

                switch (MyKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        ddd.MoveUp();
                        ddd.FillPanel();
                        break;
                    case ConsoleKey.DownArrow:
                        ddd.MoveDown();
                        ddd.FillPanel();
                        break;
                    case ConsoleKey.OemPlus:
                        ddd.AddSelectedObjects();
                        ddd.MoveDown();
                        ddd.FillPanel();
                        break;
                }

            }
            while (MyKey.Key != ConsoleKey.Escape);
            Console.ReadLine();
        }
    }
}

