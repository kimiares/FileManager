using FileManager.Drawing;
using FileManager.Structure;
using System;
using System.Drawing;

namespace FileManager
{
    class Program<T>
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
           //  Line a = new Line(new Drawing.Point(0, 0, ' '), new Drawing.Point(0, 20, ' '));
           // a.Draw();
            Table m = new Table("sewfesdfsf", new Drawing.Point(0, 0), new Drawing.Point(60, 28),3);
            Menu<T> menu = new Structure.Menu<T>(new Drawing.Point(1,1), new Drawing.Point(59,27), "first", m);
            ICheckArea ce = new Cell<string>(new Drawing.Point(0, 0), new Drawing.Point(60, 28), "content");
            ce.CheckArea(new Drawing.Point(5, 11), new Drawing.Point(0, 0), new Drawing.Point(60, 28));
            




            Console.ReadKey();
            // Cells?

        }
    }
}
