using System;
using System.Collections.Generic;
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
        void SetColumn(int columnCount);
    }
}
