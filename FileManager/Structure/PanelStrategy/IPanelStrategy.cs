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
        /// Column filling. Params: column for filling, count of columns
        /// </summary>
        /// <param name="targertList"></param>
        /// <param name="columnCount"></param>
        //void SetContent(List<Column> targertList, List<FileSystemInfo> input);
        void PrintContent(List<Column> targertList);
    }
}
