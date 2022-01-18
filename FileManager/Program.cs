using FileManager.Commander;
using FileManager.Drawing;
using System;

using FileManager.Structure;
using FileManager.Structure.PanelStrategy;
using FileManager.Operations;

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            Settings MySet = Settings.Instance();

            
           
            List<FileSystemInfo> testFSI = Folder.GetFolder(@"C:\Windows").ToList();




            Panel panel = new Panel(
                new Drawing.Point(1, 1),
                new Drawing.Point(59, 27),
                MySet.Sets.PathLeft,
                0,
                new Table(MySet.Sets.PathLeft, new Drawing.Point(0, 0), new Drawing.Point(59, 28), 3),
                new AllColumn(),
                testFSI);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Panel panel1 = new Panel(
                new Drawing.Point(61, 1),
                new Drawing.Point(119, 27),
                MySet.Sets.PathLeft,
                1,
                new Table(MySet.Sets.PathLeft, new Drawing.Point(61, 0), new Drawing.Point(119, 28), 3),
                new EachColumn(),
                testFSI);

            List<string> items = new List<string>();
            foreach (var d in Enum.GetValues(typeof(ButtonEnum)))
            {
                items.Add(d.ToString().PadRight(10));
            }

            Buttons F_Buttons = new Buttons(new Drawing.Point(1, 29), 10, 1, 2, items);


            ConsoleKeyInfo MyKey = Console.ReadKey();
           

                if (MyKey.Key == ConsoleKey.UpArrow)
                {
                    panel1.Move(false);
                    panel1.Set();
                }
                else if(MyKey.Key == ConsoleKey.DownArrow)
                {
                    panel1.Move(true);
                    panel1.Set();
            }

           



            Console.ReadLine();






        }
    }
}

