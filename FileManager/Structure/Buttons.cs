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
    class Buttons<T>: List<T>
    {
        public Point StartPoint { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public int SpaceBetweenButtons { get; set; }
        public Buttons()
        {

        }
        public void CreateButtons()
        {
            throw new NotImplementedException();
        }
    }
}
