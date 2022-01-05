using FileManager.Drawing;
using System;
using System.Drawing;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
           //  Line a = new Line(new Drawing.Point(0, 0, ' '), new Drawing.Point(0, 20, ' '));
           // a.Draw();
            Table m = new Table("sewfesdfsf", new Drawing.Point(10, 14), new Drawing.Point(60, 28),8);

            Console.ReadKey();
            // Cells?

        }
    }
}
