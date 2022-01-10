using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Button<T> : Cell<T>, ICheckArea
    {
        public new Point StartPoint { get; set; }
        public new Point FinishPoint { get; set; }
        //public bool IsActive { get; set; }
        public string Text { get; set; }

        public IDrawing drawing;
        public Button(Point startPoint, Point finishPoint, T content, IDrawing drawing): base(startPoint, finishPoint, content)
        {

            Text = (string)Convert.ChangeType(content, typeof(string));

        }

        
    }
}
