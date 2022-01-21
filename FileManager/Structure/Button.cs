using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Button:ICheckArea
    {
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        ////public bool IsActive { get; set; }
        public string Text { get; set; }

        //public IDrawing drawing;
        public Button(Point startPoint, Point finishPoint, string text)
        {
            StartPoint = startPoint;
            FinishPoint = finishPoint;
            Text = text;
            DrawButton();
        }
        public void DrawButton()
        {
                Console.SetCursorPosition(StartPoint.X, StartPoint.Y);
                Console.Write(Text);
        }
        //public bool CheckArea(Point point)
        //{
        //    //  return base.CheckArea(point);
        //    return true;
        //}

        public void MakeActive()
        {
            throw new NotImplementedException();
        }
    }
}
