using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    /// <summary>
    /// всплывающее меню
    /// </summary>
    class Menu<T> : IStructure, ICheckArea
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Point StartPoint { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public List<T> Buttons { get; set; }
        public List<T> Cells { get; set; }
        IDrawing drawing;
        public void CheckArea()
        {
            throw new NotImplementedException();
        }

        public void MakeActive()
        {
            throw new NotImplementedException();
        }
        public void Add()
        {
            throw new NotImplementedException();
        }
        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
