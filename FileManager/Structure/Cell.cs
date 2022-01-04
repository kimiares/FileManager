using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    class Cell<T> : IStructure, ICheckArea
    {
        
        public Point StartPoint { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }
        public T Content { get; set; }
        IDrawing drawing;

        public Cell()
        {

        }

        public void MakeActive()

        {
            throw new NotImplementedException();
        }
        public void MakeSelected()

        {
            throw new NotImplementedException();
        }

        public void CheckArea()
        {
            throw new NotImplementedException();
        }
    }
}
