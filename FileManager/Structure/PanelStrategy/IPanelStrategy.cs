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
    public interface IPanelStrategy<U, T> 
        where U: IStructure
        where T: class
        
    {
        /// <summary>
        /// Column filling. Params: column for filling, count of columns
        /// </summary>
        /// <param name="targertList"></param>
        /// <param name="columnCount"></param>
        void SetColumn(List<Column<U, T>> targertList, List<T> input, int columnCount);
    }
}
