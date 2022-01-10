using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Drawing;
using FileManager.Structure;

namespace FileManager.Structure.PanelStrategy
{
    /// <summary>
    /// fill all columns by same data(only names)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AllColumn<U,T> : IPanelStrategy<U, T>
        where T : class
        where U: IStructure

    {
        //public List<FileSystemInfo> input;
        public int maxNumbers;
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }

       
        
        public void SetColumn(List<Column<U,T>> targertList, List<T> input, int columnCount)
        {
            
                foreach (Column<U,T> column in targertList)
                {
                    List<T> temp = input.Take(column.MaxElementsNumber).ToList();
                    foreach (T t in temp)
                    {
                    column.Add(new Cell<T>(column.StartPoint, column.FinishPoint, (T)(object)t));
                    }
                    input = input.Skip(column.MaxElementsNumber).ToList();
                }
            
        }


        
    }
}
