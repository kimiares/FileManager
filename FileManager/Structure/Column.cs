using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    class Column<T> : List<T> where T: Cell<T>, IStructure, ICheckArea
    {
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public bool IsActive { get; set; }
       
        public Column(Point start, Point finish)
        {
            this.StartPoint = start;
            this.FinishPoint = finish;
            
            this.IsActive = false;
        }
        public void Add(Cell<T> cell)
        {
            this.Add(cell);
        }
        public void Remove(Cell<T> cell)
        {
            this.Remove(cell);
        }

        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
        }

        public void CheckArea(Point point)
        {
            throw new NotImplementedException();
        }
    }
}
