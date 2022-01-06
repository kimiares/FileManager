using FileManager.Commander;
using FileManager.Drawing;
using System;


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
          

        }
    }
}
