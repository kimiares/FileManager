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

            //Table m1 = new Table(MySet.Sets.PathLeft, new Drawing.Point( MySet.Sets.ALX, MySet.Sets.ALY), new Drawing.Point(MySet.Sets.BLX, MySet.Sets.BLY),3);
            //Table m2 = new Table(MySet.Sets.PathRight, new Drawing.Point(MySet.Sets.ARX, MySet.Sets.ARY), new Drawing.Point(MySet.Sets.BRX, MySet.Sets.BRY),4);

            //List <string> items = new List<string> ();
            //foreach (var d in Enum.GetValues(typeof(ButtonEnum)))
            //{
            //    items.Add(d.ToString().PadRight(10));
            //}
            //Buttons MB  = new Buttons  (new Point(1, 29), 1, 2, 11, items);
            //  Buttons MB2 = new Buttons (new Point(1, 2), 3, 1, 20,2);
            //   MB2.DrawButtons();
            //Console.ReadKey();







            //List<string> input = new List<string>() { "A", "B", "C", "D", "E", "F" };
            //    List<Stream> input2 = new List<Stream>()
            //    { new MemoryStream(new byte[56],false),
            //            new MemoryStream(new byte[56],false),
            //           new MemoryStream(new byte[56],false)};

            List<FileSystemInfo> testFSI = Folder.GetFolder(@"C:\Windows").ToList();
            

            //Table tableForPanel = new Table(MySet.Sets.PathLeft, new Drawing.Point(0, 0), new Drawing.Point(60, 28), 3);

            ICheckArea panel = new Panel(
                new Drawing.Point(1, 1),
                new Drawing.Point(59, 27),
                MySet.Sets.PathLeft,
                0,
                new Table(MySet.Sets.PathLeft, new Drawing.Point(0, 0), new Drawing.Point(59, 28), 3),
                new EachColumn(),
                testFSI);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            ICheckArea panel1 = new Panel(
                new Drawing.Point(61, 1),
                new Drawing.Point(119, 27),
                MySet.Sets.PathLeft,
                1,
                new Table(MySet.Sets.PathLeft, new Drawing.Point(61, 0), new Drawing.Point(119, 28), 3),
                new EachColumn(),
                testFSI);

            Console.ReadLine();






        }
    }
}

