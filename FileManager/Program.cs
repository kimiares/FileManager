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
using FileManager.Structure.Models;

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



            PanelModel pm1 = new PanelModel()
            {

                StartPoint= new Drawing.Point(1, 1),
                FinishPoint= new Drawing.Point(59, 27),
                Path= MySet.Sets.PathLeft,
                Index=0,
                Drawing = new Table(MySet.Sets.PathLeft, new Drawing.Point(0, 0), new Drawing.Point(59, 28), 3),
                Algorithm= new EachColumn()

            };
            ICheckArea panel = new Panel(pm1, testFSI);

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            PanelModel pm2 = new PanelModel()
            {
                StartPoint = new Drawing.Point(61, 1),
                FinishPoint = new Drawing.Point(119, 27),
                Path = MySet.Sets.PathRight,
                Index = 1,
                Drawing = new Table(MySet.Sets.PathLeft, new Drawing.Point(61, 0), new Drawing.Point(119, 28), 3),
                Algorithm = new EachColumn()
            };



            ICheckArea panel1 = new Panel(pm2, testFSI);

            Console.ReadLine();






        }
    }
}

