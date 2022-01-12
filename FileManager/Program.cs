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

            List<string> input = new List<string>() { "A", "B", "C", "D", "E", "F" };
            List<Stream> input2 = new List<Stream>()
                { new MemoryStream(new byte[56],false),
                        new MemoryStream(new byte[56],false),
                       new MemoryStream(new byte[56],false)};

            List<FileSystemInfo> testFSI = Folder.GetFolder(@"C:\").ToList();

            //Table tableForPanel = new Table(MySet.Sets.PathLeft, new Drawing.Point(0, 0), new Drawing.Point(60, 28), 3);

            ICheckArea panel = new Panel(
                new Drawing.Point(1, 1),
                new Drawing.Point(59, 27),
                MySet.Sets.PathLeft,
                new Table(MySet.Sets.PathLeft, new Drawing.Point(0, 0), new Drawing.Point(60, 28), 3),
                new AllColumn(),
                testFSI);








        }
    }
}

