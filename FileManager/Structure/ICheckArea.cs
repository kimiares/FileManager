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
        /// проверка на принадлежность к указанной области
        /// </summary>
        bool CheckArea(Point point, Point start, Point finish)
        {
            bool result = false;

            if ((point.X >= start.X && point.X <= start.X + finish.X) 
                && (point.Y >= start.Y && point.Y <= start.Y + finish.Y))
                result = true;
            return result;


        }
    }
}
