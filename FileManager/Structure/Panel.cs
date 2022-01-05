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
        /// <summary>
        /// Root path
        /// </summary>
        public string Path { get; set; }
        public List<T> Columns { get; set; }

        public IDrawing drawing;
        public IPanelStrategy algorithm;

        public Panel(Point start, Point finish, string path, IDrawing drawing, IPanelStrategy algorithm)
        {
            this.StartPoint = start;
            this.FinishPoint = finish;
            this.Path = path;
            this.IsActive = false;
            this.drawing = drawing;
            this.algorithm = algorithm;
            SetContent();
            DrawPanel();
        }
        //public PanelBuilder<T> CreateBuilder()
        //{
        //    return new PanelBuilder<T>();
        //}
        

        /// <summary>
        /// Drawing panel border
        /// </summary>
        public void DrawPanel()
        {
            this.drawing.Draw();
        }
        public void SetContent()
        {
            this.algorithm.SetColumn();
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

        public bool CheckArea()
        {
            throw new NotImplementedException();
        }
    }
}
