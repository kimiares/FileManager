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
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public bool IsActive { get; set; }
        public string Text { get; set; }
        public ConsoleColor BackColor { get; set; }


        public Button(Point startPoint, Point finishPoint, string text, bool activity) : this(startPoint, finishPoint, text)
        {
            this.BackColor = activity ? ConsoleColor.Red : ConsoleColor.Black;
            this.IsActive = activity;
            DrawButton();
        }
        public Button(Point startPoint, Point finishPoint, string text)
        {
            StartPoint = startPoint;
            FinishPoint = finishPoint;
            Text = text;
            
            
        }
        public void DrawButton()
        {
            Console.SetCursorPosition(StartPoint.X, StartPoint.Y);
            Console.BackgroundColor = this.BackColor;
            Console.Write(Text);
        }
        
        public void MakeActive()
        {
            throw new NotImplementedException();
        }
    }
}
