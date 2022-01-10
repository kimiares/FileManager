using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure.PanelStrategy
{
    public class Tree<U,T> : IPanelStrategy<U,T>
        where T : class
        where U : IStructure

    {
        IDrawing drawing;
        

        public void SetColumn(List<Column<U, T>> targertList, int columnCount)
        {
            throw new NotImplementedException();
        }

        public void SetColumn(List<Column<U, T>> targertList, List<T> input, int columnCount)
        {
            throw new NotImplementedException();
        }
    }
}
