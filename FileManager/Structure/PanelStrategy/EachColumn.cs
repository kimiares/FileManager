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
        Settings mySet = Settings.Instance();
        //public void SetColumn(List<Column> targertList, List<FileSystemInfo> input)
        //{
        //    List<FileSystemInfo> temp = input.Take(MySet.MaxElementsColumn).ToList();
        //    foreach (var t in temp)
        //    {
        //        targertList[0].Add(new Cell(StartPoint, FinishPoint, t));
        //        targertList[1].Add(new Cell(StartPoint, FinishPoint, t));
        //        targertList[2].Add(new Cell(StartPoint, FinishPoint, t));

        //    }
        //}

        public void PrintContent(List<Column> targertList)
        {
            FillFirstColumn(targertList);
            FillSecondColumn(targertList);
            FillThirdColumn(targertList);
        }


        

        private void FillFirstColumn(List<Column> targertList)
        {
            foreach (Column column in targertList)
            {
                for (int i = 0; i < targertList.Count; i++)
                {
                    Console.SetCursorPosition(mySet.Sets.ALX + 1, mySet.Sets.ALY + 1+i);
                    Console.WriteLine(column[i].Content.Name);
                }
            }
        }
        private void FillSecondColumn(List<Column> targertList)
        {
            foreach (Column column in targertList)
            {
                for (int i = 0; i < targertList.Count; i++)
                {
                    Console.SetCursorPosition(mySet.Sets.ALX + 1 + mySet.ColumnWidth, mySet.Sets.ALY + 1 + i);
                    Console.WriteLine(column[i].Content.Name);
                }
            }

        }
        private void FillThirdColumn(List<Column> targertList)
        {
            foreach (Column column in targertList)
            {
                for (int i = 0; i < targertList.Count; i++)
                {
                    Console.SetCursorPosition(mySet.Sets.ALX + 1 + 2*mySet.ColumnWidth, mySet.Sets.ALY + 1 + i);
                    Console.WriteLine(column[i].Content.Name);
                }
            }

        }



    }
}
