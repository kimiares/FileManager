﻿using FileManager.Commander;
using FileManager.Drawing;
using FileManager.Structure.PanelStrategy;
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
        public int Selected { get; set; }
        public bool IsActive { get; set; }
        /// <summary>
        /// Root path
        /// </summary>
        public string Path { get; set; }
        public List<FileSystemInfo> Input { get; set; }
        public IDrawing drawing;
        public IPanelStrategy algorithm;

        public Panel(Point start, Point finish, string path, int index, IDrawing drawing, IPanelStrategy algorithm, List<FileSystemInfo> input)
        {

            this.StartPoint = start;
            this.FinishPoint = finish;
            this.Path = path;
            this.IsActive = false;
            this.drawing = drawing;
            this.algorithm = algorithm;
            this.Input = input;
            this.Index = index;
            this.Selected = 0;
            SetColumn();
            SetCells();
            AddTableName();
            Set();
        

        }
        Settings mySet = Settings.Instance();
        
        public void Set()
        {
            RefreshContent();
            this.algorithm.PrintContent(this, this.Input);
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
        /// create cells in each columns
        /// </summary>
        public void SetCells()
        {
            for(int i = 0; i < this.Count; i++)
            {
                for(int j = 0; j < mySet.MaxElementsColumn; j++)
                {
                    this[i].Add(new Cell(
                        new Point(this[i].StartPoint.X, this[i].StartPoint.Y + j),
                        new Point(this[i].StartPoint.X + mySet.ColumnWidthLeft, this[i].StartPoint.Y + j)
                        ));
                }
            }
        }

        public IEnumerable<Cell> GetAllCells()
        {
            foreach (Column column in this)
                foreach (Cell cell in column)
                    yield return cell;
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


        public void Move(bool direction)
        {
             if (direction)
            {

                if (this[0].selectedIndex == GetAllCells().Count() - 1)
                {
                    this[0].selectedIndex = 0;
                    SetSelected(mySet.MaxElementsColumn-1, this[0].selectedIndex);
                }
                else
                {
                    SetSelected(this[0].selectedIndex, this[0].selectedIndex + 1);
                    this[0].selectedIndex++;
                }
            }

            else
            {
                if (this[0].selectedIndex <= 0)
                {
                    this[0].selectedIndex = GetAllCells().Count() - 1;
                    SetSelected(0, mySet.MaxElementsColumn - 1);
                }
                else
                {
                    SetSelected(this[0].selectedIndex, this[0].selectedIndex - 1);
                    this[0].selectedIndex--;
                }
            }
        }

        public void RefreshContent()
        {
            Console.ResetColor();
            string h = new String(' ', mySet.ColumnWidthLeft - 2);
            foreach (Column column in this)
                foreach (Cell cell in column)
            {
                cell.StartPoint.SetCursor();
                Console.WriteLine(h);
            }
        }

        public void SetSelected(int oldIndex, int newIndex)
        {
            if ((newIndex < 27)&(oldIndex<27))
            {
                this[0][oldIndex].IsActive = false;
                this[0][newIndex].IsActive = true;
            }

           
        }
    }
}
