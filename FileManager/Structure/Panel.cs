using FileManager.Commander;
using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Panel : List<Column>, ICheckArea
        
    {
        
        
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public int ColCount { get; set; }
       
        public bool IsActive { get; set; }
        /// <summary>
        /// Root path
        /// </summary>
        public string Path { get; set; }
        public List<FileSystemInfo> Input { get; set; }
        

        public IDrawing drawing;
        public IPanelStrategy algorithm;

        public Panel(Point start, Point finish, string path, IDrawing drawing, IPanelStrategy algorithm, List<FileSystemInfo> input)
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
        Settings mySet= Settings.Instance();
        


        /// <summary>
        /// fill panel by content
        /// </summary>
        public void SetContent()
        {
           
            this.algorithm.SetColumn(this, this.Input);
        }



        /// <summary>
        /// print content in panel
        /// </summary>
        public void PrintContent()
        {
            
            foreach (Column column in this)
            {
                for(int i = 0; i < column.Count; i++)
                {
                    Console.SetCursorPosition(
                        this.StartPoint.X+i*mySet.Sets.PanelWidth/ mySet.Sets.ColumnCount, 
                        this.StartPoint.Y + i);
                    

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
