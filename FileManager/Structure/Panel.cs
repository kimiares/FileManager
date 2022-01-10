using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Panel<T> : List<Column<T>>, ICheckArea
        where T : class
        //where U: IStructure

    {
        
        
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public int ColCount { get; set; }
       
        public bool IsActive { get; set; }
        /// <summary>
        /// Root path
        /// </summary>
        public string Path { get; set; }
        public List<T> Input { get; set; }

        public IDrawing drawing;
        public IPanelStrategy<T> algorithm;

        public Panel(Point start, Point finish, string path, IDrawing drawing, IPanelStrategy<T> algorithm, List<T> input)
        {
            this.StartPoint = start;
            this.FinishPoint = finish;
            this.Path = path;
            this.IsActive = false;
            this.drawing = drawing;
            this.algorithm = algorithm;
            this.Input = input;
            

            AddTableName();
            SetContent();
            PrintContent();


        }




        /// <summary>
        /// fill panel by content
        /// </summary>
        public void SetContent()
        {
            this.algorithm.SetColumn(this, this.Input, this.ColCount);


        }



        public void PrintContent()
        {
            foreach(Column<T> column in this)
            {
                for(int i = 0; i < column.Count; i++)
                {
                    Console.SetCursorPosition(column[i].StartPoint.X, column[i].StartPoint.Y + i);
                    Console.WriteLine(column[i].Content);
                    
                }
            }
            
        }


        public void AddTableName()
        {
            Console.SetCursorPosition(
                StartPoint.X + (FinishPoint.X - StartPoint.X) / 2 - Path.Length / 2, 
                StartPoint.Y-1);
            Console.Write(Path);
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
