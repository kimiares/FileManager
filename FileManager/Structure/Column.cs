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
        

        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
        }


    }
}
