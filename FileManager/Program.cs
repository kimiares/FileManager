
﻿using FileManager.Commander;
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
           
            //Settings MySet = Settings.Instance();
            //Table m1 = new Table(MySet.Sets.PathLeft, new Drawing.Point( MySet.Sets.ALX, MySet.Sets.ALY), new Drawing.Point(MySet.Sets.BLX, MySet.Sets.BLY),4);
            //Table m2 = new Table(MySet.Sets.PathRight, new Drawing.Point(MySet.Sets.ARX, MySet.Sets.ARY), new Drawing.Point(MySet.Sets.BRX, MySet.Sets.BRY), 4);
            //Console.ReadKey();



            Test test = new Test();
            test.TestMethod();


            Console.ReadKey();
           

        }

        public class Test
        {
            
            public void TestMethod()
            {


                Settings MySet = Settings.Instance();
                List<string> input = new List<string>() { "A", "B", "C", "D", "E", "F" };
                List<Stream> input2 = new List<Stream>()
                { new MemoryStream(new byte[56],false),
                        new MemoryStream(new byte[56],false),
                       new MemoryStream(new byte[56],false)};

                List<FileSystemInfo> testFSI = Folder.GetFolder(@"C:\bob\").ToList();

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
}
