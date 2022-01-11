using FileManager.Commander;
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
    public class EachColumn : IPanelStrategy
        

    {

        //public List<FileSystemInfo> input;

        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        /// <summary>
        /// для трех столбцов
        /// </summary>
        Settings MySet = Settings.Instance();
        public void SetColumn(List<Column> targertList, List<FileSystemInfo> input)
        {
            List<FileSystemInfo> temp = input.Take(MySet.MaxElementsColumn).ToList();
            foreach (var t in temp)
            {
                targertList[0].Add(new Cell(StartPoint, FinishPoint, t));
                targertList[1].Add(new Cell(StartPoint, FinishPoint, t));
                targertList[2].Add(new Cell(StartPoint, FinishPoint, t));

            }
        }
        

    }
}
