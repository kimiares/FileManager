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
        where T: IStructure
        
        
    {
        void SetColumn(List<Column<T>> targertList, int columnCount);
    }
}
