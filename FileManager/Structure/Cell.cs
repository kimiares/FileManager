﻿using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Cell<T> where T: class, IStructure, ICheckArea
    {
        
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        
        /// <summary>
        /// активность
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// выбор
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// содержимое ячейки (FileSystemInfo/String/Disk?)
        /// </summary>
        public T Content { get; set; }
        

        public Cell(Point startPoint, Point finishPoint, T content)
        {
            this.StartPoint = startPoint;
            this.FinishPoint = finishPoint;
            this.Content = content;
        }

        public void MakeActive()

        {
            this.IsActive = !this.IsActive;
        }
        public void MakeSelected()

        {
            this.IsSelected = !this.IsSelected;
        }
        

       
    }
}
