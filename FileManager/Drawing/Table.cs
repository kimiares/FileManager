using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Drawing
{
    class Table : IDrawing
    {
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public List<Line> Lines { get; set; }

        public Table()
        {

        }
        public void Draw()
        {
            throw new NotImplementedException();
        }
        public void BuildTable()
        {
            throw new NotImplementedException();
        }
        public void Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
