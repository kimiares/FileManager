using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure.PanelStrategy
{
    public class Tree<T> : IPanelStrategy<T>
        where T : IStructure
        
    {
        IDrawing drawing;
        

        public void SetColumn(List<Column<T>> targertList, int columnCount)
        {
            throw new NotImplementedException();
        }
    }
}
