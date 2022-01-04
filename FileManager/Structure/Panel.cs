using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    class Panel<T> : List<T>, IStructure,ICheckArea
    {
        
        
        public Point StartPoint { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public bool IsActive { get; set; }
        public string Path { get; set; }
        public 

        IDrawing drawing;
        IPanelStrategy strategy;
        public Panel()
        {

        }

        public void CreatePanel()
        {
            throw new NotImplementedException();
        }
        public void SetContent()
        {
            throw new NotImplementedException();
        }
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
