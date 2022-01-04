using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Panel<T> : IStructure, ICheckArea
    {
        
        
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
       
        public bool IsActive { get; set; }
        public string Path { get; set; }
        public List<T> Columns { get; set; }

        public IDrawing drawing;
        public IPanelStrategy algorithm;

        public Panel()
        {
            drawing = new Table();
        }
        public PanelBuilder<T> CreateBuilder()
        {
            return new PanelBuilder<T>();
        }
        

        public void CreatePanel()
        {
            throw new NotImplementedException();
        }
        public void SetContent()
        {
            this.algorithm.SetColumn();
        }
        public bool CheckArea(Point point)
        {
            bool result = false;
            //or get a List<Point> of this area and check list.Contains(point)
            if ((point.X >= StartPoint.X && point.X <= StartPoint.X + FinishPoint.X) && (point.Y >= StartPoint.Y && point.Y <= StartPoint.Y + FinishPoint.Y)) result = true;
            return result;
        }

        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
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
