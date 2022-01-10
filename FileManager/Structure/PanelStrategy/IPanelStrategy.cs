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
    public interface IPanelStrategy<T> 
        where T: class, IStructure, ICheckArea

    {
        /// <summary>
        /// Column filling. Params: column for filling, count of columns
        /// </summary>
        /// <param name="targertList"></param>
        /// <param name="columnCount"></param>
        void SetColumn(List<Column<T>> targertList, List<T> input, int columnCount);
    }
}
