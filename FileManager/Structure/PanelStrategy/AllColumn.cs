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
    public class AllColumn<T> : IPanelStrategy<T>
        where T : IStructure

    {
        public List<FileSystemInfo> input;
        public int maxNumbers;
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public void SetColumn(List<Column<T>> targertList, int columnCount)
        {
            
                foreach (Column<T> column in targertList)
                {
                    List<FileSystemInfo> temp = this.input.Take(column.MaxElementsNumber).ToList();
                    foreach (FileSystemInfo t in temp)
                    {
                    column.Add(new Cell<T>(StartPoint, FinishPoint, (T)(object)t.Name));
                    }
                    input = input.Skip(column.MaxElementsNumber).ToList();
                }
            
        }
    }
}
