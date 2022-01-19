using FileManager.Commander;
using FileManager.Drawing;
using System;
using FileManager.Structure;
using FileManager.Structure.PanelStrategy;
using FileManager.Operations;
using System.Collections.Generic;
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

            ConsoleKeyInfo MyKey;
            do
            {
                MyKey = Console.ReadKey();

                switch (MyKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        panel1.MoveUp();
                        panel1.FillPanel();
                        break;
                    case ConsoleKey.DownArrow:
                        panel1.MoveDown();
                        panel1.FillPanel();
                        break;
                }

            }
            while (MyKey.Key != ConsoleKey.Escape);
            Console.ReadLine();
        }
    }
}

