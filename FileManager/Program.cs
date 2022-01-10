
﻿using FileManager.Commander;
using FileManager.Drawing;
using System;
﻿using FileManager.Drawing;
using FileManager.Structure;
using FileManager.Structure.PanelStrategy;
using FileManager.Operations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ResetColor();
           
            Settings MySet = Settings.Instance();
            Table m1 = new Table(MySet.Sets.PathLeft, new Drawing.Point( MySet.Sets.ALX, MySet.Sets.ALY), new Drawing.Point(MySet.Sets.BLX, MySet.Sets.BLY),4);
            Table m2 = new Table(MySet.Sets.PathRight, new Drawing.Point(MySet.Sets.ARX, MySet.Sets.ARY), new Drawing.Point(MySet.Sets.BRX, MySet.Sets.BRY), 4);
            Console.ReadKey();



            Test test = new Test();
            test.TestMethod();


            Console.ReadKey();
           

        }

        public class Test
        {
            
            public void TestMethod()
            {


                
                List<string> input = new List<string>() { "A", "B", "C", "D", "E", "F" };
                List<FileSystemInfo> testFSI = Operations.Files.GetFiles(@"C:\");

                Table m = new Table("sewfesdfsf", new Drawing.Point(0, 0), new Drawing.Point(60, 28), 3);
                
                Panel<IStructure, FileSystemInfo> panel = new Panel<IStructure, FileSystemInfo>(new Drawing.Point(1, 1), 
                    new Drawing.Point(59, 27), 
                    "C", 
                    m, 
                    new AllColumn<IStructure, FileSystemInfo>(),
                    testFSI);



            }
           
            


        }
    }
}
