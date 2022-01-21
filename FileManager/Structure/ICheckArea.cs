using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    
    public interface ICheckArea
    {
        /// <summary>
        /// C#8.0: inteface default realization
        /// </summary>
        bool CheckArea(Point point, Point start, Point finish)
        {
            bool result = false;
            if (CheckX(point, start, finish) 
                &&
                CheckY(point, start, finish)) 
            result = true;
            return result;
        }

        /// <summary>
        /// check x-coordinate list
        /// </summary>
        /// <returns></returns>
        private static bool CheckX(Point point, Point start, Point finish)
        {
            bool result =false;
            if (point.X >= start.X && point.X <= start.X + finish.X) result = true;

            return result;

        }
        /// <summary>
        /// check Y-coordinate list
        /// </summary>
        /// <returns></returns>
        private static bool CheckY(Point point, Point start, Point finish)
        {
            bool result = false;
            if (point.Y >= start.X && point.Y <= start.Y + finish.Y) result = true;

            return result;
        }




    }
}
