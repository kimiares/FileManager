using FileManager.Commander;
using FileManager.Drawing;
using FileManager.Structure;
using System;
using System.Collections.Generic;

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
            Table m1 = new Table(MySet.Sets.PathLeft, new Drawing.Point( MySet.Sets.ALX, MySet.Sets.ALY), new Drawing.Point(MySet.Sets.BLX, MySet.Sets.BLY),4);
            Table m2 = new Table(MySet.Sets.PathRight, new Drawing.Point(MySet.Sets.ARX, MySet.Sets.ARY), new Drawing.Point(MySet.Sets.BRX, MySet.Sets.BRY),4);

            List <string> items = new List<string> ();
            foreach (var d in Enum.GetValues(typeof(ButtonEnum)))
            {
                items.Add(d.ToString().PadRight(10));
            
            }
               
            
            Buttons MB  = new Buttons  (new Point(1, 29), 1, 2, 11, items);
      

          //  Buttons MB2 = new Buttons (new Point(1, 2), 3, 1, 20,2);

        
        //   MB2.DrawButtons();
       
            Console.ReadKey();
          

        }
    }
}
