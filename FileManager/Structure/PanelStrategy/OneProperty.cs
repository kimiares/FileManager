using FileManager.Commander;
using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace FileManager.Structure.PanelStrategy
{
    /// <summary>
    /// fill each column by diff data(name,date,etc)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OneProperty : IPanelStrategy
    {

        Settings mySet = Settings.Instance();

        /// <summary>
        /// print different property in each column
        /// </summary>
        /// <param name="columns"></param>
        public void PrintContent(Panel columns)
        {
            foreach (Column column in columns)
            {
                for (int i = 0; i < column.Count; i++)
                {
                    Console.ResetColor();
                    Console.SetCursorPosition(column.StartPoint.X, column.StartPoint.Y + i);
                    Console.WriteLine((i == 0) ? ".." : CheckColumn(columns.IndexOf(column), column[i].Content));
                }
            }

        }
        /// <summary>
        /// Fill column with files/folder
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="input"></param>
        public void SetContent(Panel columns, List<FileSystemInfo> input)
        {

            List<FileSystemInfo> temp = new List<FileSystemInfo>();
            temp.Add(SupportMethods.GetRoot(input[0]));
            temp.AddRange(input.Take(mySet.MaxElementsColumn - 1).ToList());
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < columns.Count; j++)
                {
                    columns[j].Add(
                    new Cell(
                        new Point(columns[j].StartPoint.X + j * mySet.ColumnWidthLeft, columns[j].StartPoint.Y + i),
                        new Point(columns[j].StartPoint.X + mySet.ColumnWidthLeft + j * mySet.ColumnWidthLeft, columns[j].StartPoint.Y + i),
                        temp[i]
                        ));
                }
            }
        }




        /// <summary>
        /// check column's index to choose strategy
        /// </summary>
        /// <param name="index"></param>
        /// <param name="file"></param>
        
        public static string CheckColumn(int index, FileSystemInfo file)
        {
            if (index == 1)
            {
                return file.CreationTime.ToShortDateString();
            }
            if (index == 2)
            {
                return file.LastAccessTime.ToShortDateString();
            }
            return file.Name.CutString();
        }


      

        

    }
}
