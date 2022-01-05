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
        bool CheckArea(Point point);
    }
}
