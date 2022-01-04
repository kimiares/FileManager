using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    /// <summary>
    /// панель кнопок
    /// </summary>
    class Buttons<T>: List<T> where T: Button<T>
    {
        public Point StartPoint { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        /// <summary>
        /// расстояние между кнопками
        /// </summary>
        public int SpaceBetweenButtons { get; set; }
        public Buttons(Point start, int width, int height, int space)
        {
            this.StartPoint = start;
            this.Width = width;
            this.Heigth = height;
            this.SpaceBetweenButtons = space;
        }
        public void CreateButtons()
        {
            throw new NotImplementedException();
        }
    }
}
