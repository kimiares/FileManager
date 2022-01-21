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
    public class Buttons: List<Button>
    {
        /// <summary>
        /// Start point of first button
        /// </summary>
        public Point StartPoint { get; set; }
        /// <summary>
        /// Width of buttons
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Heigth of buttons
        /// </summary>
        public int Heigth { get; set; }
        /// <summary>
        /// Space between buttons
        /// </summary>
        public int SpaceBetweenButtons { get; set; }
        /// <summary>
        /// Count of buttons
        /// </summary>
        public int ButtonsCount { get; set; }
        ///



        public Buttons(Point start, int width, int height, int space, List<string> items)
        {
            this.StartPoint = start;
            this.Width = width;
            this.Heigth = height;
            this.SpaceBetweenButtons = space;
            this.ButtonsCount = items.Count;
            ButtonsInitializer(items);
          
        }

        private Point GetButtonStartPoint(int i)
        {

            return new Point((i) * (Width + SpaceBetweenButtons) + StartPoint.X, StartPoint.Y);
        }
        private Point GetButtonFinishtPoint(int i)
        {

            return new Point((i) * (Width + SpaceBetweenButtons) + StartPoint.X+Width, StartPoint.Y+Heigth);
        }

        public void ButtonsInitializer(List<string> items)
        {
            for (int i = 0; i < ButtonsCount; i++)
                this.Add(new Button(GetButtonStartPoint(i), GetButtonFinishtPoint(i), items[i]));
        }

       
    }
}
