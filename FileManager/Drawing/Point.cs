using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Drawing
{
    public class Point : IDrawing
    {
        /// <summary>
        /// X
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        public int Y { get; set; }

        public char Symbol { get; set; }
        public Point(int x, int y) : this(x, y, ' ') { }
        public Point(int x, int y, char symb)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symb;
        }
        
        public void Draw()
        {

            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
          
        }

       
        
    }
}
