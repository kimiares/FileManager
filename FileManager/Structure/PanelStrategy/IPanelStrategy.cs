using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    /// <summary>
    /// выбор способа заполнения столбцов
    /// </summary>
    public interface IPanelStrategy
        

    {
        /// <summary>
        /// Fill collection of all cells by FileSystemInfo files
        /// </summary>
        /// <param name="targertList"></param>
        /// <param name="columnCount"></param>
        //IEnumerable<Cell> SetContent(Panel targertList, List<FileSystemInfo> input);

        /// <summary>
        /// Print FileSystemInfo in console
        /// </summary>
        /// <param name="targertList"></param>
        /// <param name="input"></param>
        void PrintContent(Panel targertList, List<FileSystemInfo> input);
    }
}
