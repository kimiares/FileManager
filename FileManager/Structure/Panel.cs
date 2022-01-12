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
            SetColumn();
            SetContent(this, this.Input);
            algorithm.PrintContent(this);
            


        }
        Settings mySet= Settings.Instance();



        /// <summary>
        /// fill panel by content
        /// </summary>
        //public void SetContent()
        //{

        //    this.algorithm.SetColumn(this, this.Input);
        //}
        public void SetContent(List<Column> targertList, List<FileSystemInfo> input)
        {

            foreach (Column column in targertList)
            {
                List<FileSystemInfo> temp = input.Take(mySet.MaxElementsColumn).ToList();
                foreach (FileSystemInfo t in temp)
                {
                    for (int i = 0; i < mySet.Sets.ColumnCount; i++)
                    {
                        column.Add(new Cell(
                            new Point(
                                mySet.Sets.ALX + 1 + i, mySet.Sets.ALY + 1 + i),
                            new Point(
                                mySet.Sets.ALX + 1 + i + mySet.ColumnWidth, mySet.Sets.ALY + 1 + i + mySet.MaxElementsColumn),
                                t));
                    }

                }
                input = input.Skip(mySet.MaxElementsColumn).ToList();
            }

        }
        public void SetColumn()
        {
            for(int i = 0; i< 3;i++)
            {
                this.Add(
                    new Column(
                        new Point(mySet.Sets.ALX + 1 + i*mySet.ColumnWidth, mySet.Sets.ALY + 1),
                            new Point(mySet.Sets.ALX+1+(i+1)*mySet.ColumnWidth, mySet.Sets.ALY+1+mySet.MaxElementsColumn)
                        
                        
                        ));
            }
            
            
        }



        /// <summary>
        /// print content in panel
        /// </summary>
        


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
        


    }
}
