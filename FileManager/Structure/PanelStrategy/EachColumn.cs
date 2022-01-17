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
    public class EachColumn : IPanelStrategy
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
        /// Fill columns with names/creation time/last acces time
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
                foreach(Column col in columns)
                {
                    col[i].Content = temp[i];
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
            return SupportMethods.CutName(file.Name);
        }

        
    }
}
