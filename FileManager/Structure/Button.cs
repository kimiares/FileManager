using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Button <T>: Cell<T>
    {
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        //public bool IsActive { get; set; }
        public string Text { get; set; }

        public IDrawing drawing;
        public Button(Point startPoint, Point finishPoint, string text) : base(startPoint, finishPoint, (T)(object)text )
        {
            StartPoint = startPoint;
            FinishPoint = finishPoint;
           // Text = text.to;
        }
      
        public bool CheckArea(Point point)
        {
            //  return base.CheckArea(point);
            return true;
        }
        
    }
}
