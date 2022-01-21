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

            PanelModel firstPanelModel = new PanelModel()
            { StartPoint = new Drawing.Point(1, 1),
              FinishPoint = new Point(59, 27),
              Path = MySet.Sets.PathLeft,
              Index = 0,
              Drawing = new Table(MySet.Sets.PathLeft, new Drawing.Point(0, 0), new Drawing.Point(59, 28), 3),
              Algorithm = new OneProperty()
            };

            PanelModel secondPanelModel = new PanelModel()
            {
                StartPoint = new Drawing.Point(61, 1),
                FinishPoint = new Drawing.Point(119, 27),
                Path = MySet.Sets.PathRight,
                Index = 1,
                Drawing = new Table(MySet.Sets.PathLeft, new Drawing.Point(61, 0), new Drawing.Point(119, 28), 3),
                Algorithm = new ThreeProperties()

            };

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
                        
                        break;
                    case ConsoleKey.DownArrow:
                        ddd.MoveDown();
                       
                        break;
                    case ConsoleKey.OemPlus:
                        ddd.AddSelectedObjects();
                        ddd.MoveDown();
                       
                        break;
                }

            }
            while (MyKey.Key != ConsoleKey.Escape);
            Console.ReadLine();
        }
    }
}

