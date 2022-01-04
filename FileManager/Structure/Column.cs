using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    class Column<T> : List<T>, IStructure, ICheckArea
    {
        public Point StartPoint { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public bool IsActive { get; set; }
       
        IDrawing drawing;
        public Column()
        {

        }
        public void Add()
        {
            throw new NotImplementedException();
        }
        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void MakeActive()
        {
            throw new NotImplementedException();
        }

        public void CheckArea()
        {
            throw new NotImplementedException();
        }
    }
}
