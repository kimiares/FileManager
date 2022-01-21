using FileManager.Commander;
using FileManager.Drawing;
using FileManager.Structure.Models;
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
        public int Index { get; set; }

        public bool IsActive { get; set; }
        /// <summary>
        /// Root path
        /// </summary>
        public string Path { get; set; }
        public List<FileSystemInfo> Input { get; set; }
        public IDrawing drawing;
        public IPanelStrategy algorithm;


        public Panel(PanelModel panelModel, List<FileSystemInfo> input)
        {

            this.StartPoint = panelModel.StartPoint;
            this.FinishPoint = panelModel.FinishPoint;
            this.Path = panelModel.Path;
            this.IsActive = false;
            this.drawing = panelModel.Drawing;
            this.algorithm = panelModel.Algorithm;
            this.Input = input;
            this.Index = panelModel.Index;
            Set();
           

        }
        Settings mySet = Settings.Instance();
        
        public void Set()
        {
            AddTableName();
            SetColumn();
            this.algorithm.SetContent(this, this.Input);
            this.algorithm.PrintContent(this);
        }
        
        
        
        /// <summary>
        /// Create columns with coordinates
        /// </summary>
        public void SetColumn()
        {
            for (int i = 0; i < mySet.ColumnCountLeft; i++)
            {
                this.Add(
                    new Column(
                        new Point(mySet.Sets.ALX + 1 - i + i * mySet.ColumnWidthLeft + this.Index*(mySet.Sets.PanelWidth+1), mySet.Sets.ALY + 1),
                            new Point(mySet.Sets.ALX + 1 - i + (i+1) * mySet.ColumnWidthLeft +  this.Index * (mySet.Sets.PanelWidth+1), mySet.Sets.ALY + 1 + mySet.MaxElementsColumn)
                       ));
            }

        }


        /// <summary>
        /// Adding path into top of the panel
        /// </summary>
        public void AddTableName()
        {
            Console.SetCursorPosition(
                StartPoint.X + (FinishPoint.X - StartPoint.X) / 2 - Path.Length / 2,
                StartPoint.Y - 1);
            Console.Write(Path);
        }

        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
        }


        



    }
}
