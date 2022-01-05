using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    /// <summary>
    /// class for checking position of selected point
    /// </summary>
    public static class CheckArea
    {
         public static bool CheckPoint(Point start, Point finish, Point check)
         {
            
                bool result = false;
                
                if ((check.X >= start.X && check.X <= start.X + finish.X) && (check.Y >= start.Y && check.Y <= start.Y + finish.Y)) result = true;
                return result;
            
         }
    }
}
