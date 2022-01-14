using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Column : List<Cell>, ICheckArea
        
        
    {
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public bool IsActive { get; set; }
        public int selectedIndex = 0;
        
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
        //public void Add(Cell cell)
        //{
        //    this.Add(cell);
        //}
        /// <summary>
        /// remove cell from column
        /// </summary>
        /// <param name="cell"></param>
        //public new void Remove(Cell cell)
        //{
        //    this.Remove(cell);
        //}

        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
        }


        public void Move(bool direction)
        {
            this.selectedIndex = (direction==true) ? this.selectedIndex++ : this.selectedIndex--;
        }
        public void MakeSelected(int selectedIndex)
        {
            this[selectedIndex].IsSelected = !this[selectedIndex].IsSelected;
        }


    }
}
