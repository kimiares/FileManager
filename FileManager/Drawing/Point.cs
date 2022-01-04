using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Drawing
{
    public class Point : IDrawing
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public Point(int x, int y, char symb)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symb;
        }
        
        public void Draw()
        {
            throw new NotImplementedException();
        }

       
        
    }
}
