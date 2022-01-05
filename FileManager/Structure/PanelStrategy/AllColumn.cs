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
    public class AllColumn<T> : IPanelStrategy<T>
        where T : IStructure

    {
        public List<FileSystemInfo> input;
        public int maxNumbers;
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public void SetColumn(List<Column<T>> targertList, int columnCount)
        {
            
                foreach (Column<T> col in targertList)
                {
                    List<FileSystemInfo> temp = this.input.Take(col.MaxElementsNumber).ToList();
                    foreach (FileSystemInfo t in temp)
                    {
                        col.Add(new Cell<T>(StartPoint, FinishPoint, (T)(object)t));
                    }
                    input = input.Skip(col.MaxElementsNumber).ToList();
                }
            
        }
    }
}
