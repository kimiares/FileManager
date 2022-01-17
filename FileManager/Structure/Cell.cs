﻿using FileManager.Commander;
using FileManager.Drawing;
using FileManager.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Cell: ICheckArea, IStructure
        
        
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
        public FileSystemInfo? Content { get; set; }

        Settings mySet = Settings.Instance();


        public Cell(Point startPoint, Point finishPoint)
        {
            this.StartPoint = startPoint;
            this.FinishPoint = finishPoint;
            
        }
        public Cell(Point startPoint, Point finishPoint, FileSystemInfo content) : this(startPoint, finishPoint)
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
