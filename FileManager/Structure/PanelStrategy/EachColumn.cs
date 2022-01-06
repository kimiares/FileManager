using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure.PanelStrategy
{
    /// <summary>
    /// fill each column by diff data(name,date,etc)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EachColumn<T> : IPanelStrategy<T>
        where T : IStructure

    {

        public List<FileSystemInfo> input;
        public int maxNumbers;
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        /// <summary>
        /// для трех столбцов
        /// </summary>
        public void SetColumn(List<Column<T>> targertList, int columnCount)
        {
            foreach (Column<T> col in targertList)
            {
                if (targertList.IndexOf(col)==0)
                {
                    List<FileSystemInfo> temp = input.Take(col.MaxElementsNumber).ToList();
                    foreach (var t in temp)
                    {
                        col.Add(new Cell<T>(StartPoint, FinishPoint, (T)(object)t.Name));
                    }                    
                }
                if (targertList.IndexOf(col) == 1)
                {
                    List<FileSystemInfo> temp = input.Take(col.MaxElementsNumber).ToList();
                    foreach (var t in temp)
                    {
                        col.Add(new Cell<T>(StartPoint, FinishPoint, (T)(object)t.CreationTime.Year));
                    }
                }
                if (targertList.IndexOf(col) == 2)
                {
                    List<FileSystemInfo> temp = input.Take(col.MaxElementsNumber).ToList();
                    foreach (var t in temp)
                    {
                        col.Add(new Cell<T>(StartPoint, FinishPoint, (T)(object)t.LastWriteTime.Date));
                    }
                }

            }
        }
    }
}
