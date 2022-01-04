﻿using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    class Button<T> : Cell<T>
    {
        public new Point StartPoint { get; set; }
        public new Point FinishPoint { get; set; }
        public new bool IsActive { get; set; }
        public string Text { get; set; }

        public IDrawing drawing;
        public Button(Point startPoint, Point finishPoint, T content, IDrawing drawing): base(startPoint, finishPoint, content)
        {
            
            
        }

        public bool CheckArea(Point point)
        {
            return base.CheckArea(point);
        }
        
    }
}
