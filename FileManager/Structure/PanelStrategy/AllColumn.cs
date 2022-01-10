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
        where T : class, IStructure, ICheckArea
        

    {
        //public List<FileSystemInfo> input;
        public int maxNumbers;
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }

       
        
        public void SetColumn(List<Column<T>> targertList, List<T> input, int columnCount)
        {
            
                foreach (Column<T> column in targertList)
                {
                    List<T> temp = input.Take(column.MaxElementsNumber).ToList();
                    foreach (T t in temp)
                    {
                        for (int i = 0; i < column.Count; i++)
                        {
                            column.Add(new Cell<T>(
                                new Point(
                                    column.StartPoint.X, column.StartPoint.Y+i), 
                                new Point(
                                    column.FinishPoint.X, column.FinishPoint.Y-column.MaxElementsNumber+i), 
                                    (T)(object)t));
                        }
                        
                        }
                        input = input.Skip(column.MaxElementsNumber).ToList();
                    }
            
        }
    }
}
