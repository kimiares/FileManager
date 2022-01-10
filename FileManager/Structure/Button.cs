using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Button : ICheckArea
    {
        public new Point StartPoint { get; set; }
        public new Point FinishPoint { get; set; }
        
        public string Text { get; set; }

        public Button(Point startPoint, Point finishPoint, string text)
        {

            this.StartPoint = startPoint;
            this.FinishPoint = finishPoint;
            this.Text = text;

        }

        
    }
}
