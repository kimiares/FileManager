using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Drawing
{
    class Line : IDrawing
    {
        public Point FirstPoint { get; set; }
        public Point LastPoint { get; set; }
        public Line()
        {

        }
        public void Draw()
        {
            throw new NotImplementedException();
        }
        public void BuildLine()
        {
            throw new NotImplementedException();
        }
    }
}
