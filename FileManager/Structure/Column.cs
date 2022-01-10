using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Column<T> : List<Cell<T>>, ICheckArea
        where T : class
        //where U: IStructure
    {
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public bool IsActive { get; set; }
        public int MaxElementsNumber { get; set; }
       
        public Column(Point start, Point finish)
        {
            this.StartPoint = start;
            this.FinishPoint = finish;
            
            this.IsActive = false;
        }
        /// <summary>
        /// add cell into column
        /// </summary>
        /// <param name="cell"></param>
        public void Add(Cell<T> cell)
        {
            this.Add(cell);
        }
        /// <summary>
        /// remove cell from column
        /// </summary>
        /// <param name="cell"></param>
        public void Remove(Cell<T> cell)
        {
            this.Remove(cell);
        }

        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
        }

        
    }
}
