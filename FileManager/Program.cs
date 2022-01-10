<<<<<<< HEAD
﻿using FileManager.Commander;
using FileManager.Drawing;
using System;

=======
﻿using FileManager.Drawing;
using FileManager.Structure;
using FileManager.Structure.PanelStrategy;
using FileManager.Operations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
>>>>>>> 94ecb01d8d3343a8e185d4ed9f10ff275c78b171

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            Console.ResetColor();
           
            Settings MySet = Settings.Instance();
            Table m1 = new Table(MySet.Sets.PathLeft, new Drawing.Point( MySet.Sets.ALX, MySet.Sets.ALY), new Drawing.Point(MySet.Sets.BLX, MySet.Sets.BLY),4);
            Table m2 = new Table(MySet.Sets.PathRight, new Drawing.Point(MySet.Sets.ARX, MySet.Sets.ARY), new Drawing.Point(MySet.Sets.BRX, MySet.Sets.BRY), 4);
            Console.ReadKey();
          
=======
            // Console.ResetColor();
            ////  Line a = new Line(new Drawing.Point(0, 0, ' '), new Drawing.Point(0, 20, ' '));
            //// a.Draw();
            // Table m = new Table("sewfesdfsf", new Drawing.Point(0, 0), new Drawing.Point(60, 28),3);

            // List<FileSystemInfo> input = Files.GetFiles(@"C:\");


            // IStructure PANEL = new Panel<T>(new Drawing.Point(1, 1), new Drawing.Point(59, 27), "C:\\", m, new AllColumn<T>());

            Test test = new Test();
            test.TestMethod();


            Console.ReadKey();
           

        }

        public class Test
        {
            
            public void TestMethod()
            {


                //T cont = (T)Convert.ChangeType("content", typeof(T));
                List<string> input = new List<string>() { "A", "B", "C", "D", "E", "F" };
                List<FileSystemInfo> testFSI = Operations.Files.GetFiles(@"C:\");

                Table m = new Table("sewfesdfsf", new Drawing.Point(0, 0), new Drawing.Point(60, 28), 3);
                
                Panel<IStructure, FileSystemInfo> panel = new Panel<IStructure, FileSystemInfo>(new Drawing.Point(1, 1), 
                    new Drawing.Point(59, 27), 
                    "C", 
                    m, 
                    new AllColumn<IStructure, FileSystemInfo>(),
                    testFSI);


                

                //Button<string> b = new Button<string>(
                //new Drawing.Point(1, 1),
                //new Drawing.Point(59, 27),
                //"content",
                //new Table(
                //    "BUTTON",
                //    new Drawing.Point(1, 1),
                //    new Drawing.Point(59, 27),
                //    1));



            }
           
            
>>>>>>> 94ecb01d8d3343a8e185d4ed9f10ff275c78b171

        }
    }
}
