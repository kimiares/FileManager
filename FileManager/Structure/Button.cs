using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    class Button<T> : Cell<T>, ICheckArea
    {
        public new Point StartPoint { get; set; }
        public new int Width { get; set; }
        public new int Heigth { get; set; }
        public new bool IsActive { get; set; }
        public string Text { get; set; }

        IDrawing drawing;
        public Button()
        {

        }
        public new void CheckArea()
        {
            throw new NotImplementedException();
        }
    }
}
