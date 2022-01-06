using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Panel<T> : List<Column<T>>, IStructure, ICheckArea
        where T: IStructure
        
    {
        
        
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public int ColCount { get; set; }
       
        public bool IsActive { get; set; }
        /// <summary>
        /// Root path
        /// </summary>
        public string Path { get; set; }
        //public List<T> Columns { get; set; }

        public IDrawing drawing;
        public IPanelStrategy<T> algorithm;

        public Panel(Point start, Point finish, string path, IDrawing drawing, IPanelStrategy<T> algorithm)
        {
            this.StartPoint = start;
            this.FinishPoint = finish;
            this.Path = path;
            this.IsActive = false;
            this.drawing = drawing;
            this.algorithm = algorithm;
            SetContent();
            
        }
        
        

      
        /// <summary>
        /// fill panel by content
        /// </summary>
        public void SetContent()
        {
            this.algorithm.SetColumn(this, ColCount);


        }
        

        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
        }
        /// <summary>
        /// add column
        /// </summary>
        public void Add()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// remove column
        /// </summary>
        public void Remove()
        {
            throw new NotImplementedException();
        }


    }
}
