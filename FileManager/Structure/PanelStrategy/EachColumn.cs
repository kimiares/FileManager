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
        where T : class
        //where U: IStructure

    {

        //public List<FileSystemInfo> input;
       
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        /// <summary>
        /// для трех столбцов
        /// </summary>
        public void SetColumn(List<Column<T>> targertList, List<T> input, int columnCount)
        {
             List<T> temp = input.Take(targertList[0].MaxElementsNumber).ToList();
               foreach (var t in temp)
               {
                   targertList[0].Add(new Cell<T>(StartPoint, FinishPoint, t));
                   targertList[1].Add(new Cell<T>(StartPoint, FinishPoint, t));
                   targertList[2].Add(new Cell<T>(StartPoint, FinishPoint, t));
                        
               }               
        }
    }
}
