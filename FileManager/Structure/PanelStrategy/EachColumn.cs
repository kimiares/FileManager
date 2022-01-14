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

        /// <summary>
        /// print different property in each column
        /// </summary>
        /// <param name="columns"></param>
        public void PrintContent(List<Column> columns)
        {
            foreach (Column column in columns)

            {
                
                for (int i = 0; i < column.Count; i++)
                {
                    Console.ResetColor();
                    Console.SetCursorPosition(column.StartPoint.X, column.StartPoint.Y + i);
                    CheckColumn(columns.IndexOf(column), column[i].Content);
                }
            }

        }
        /// <summary>
        /// Fill column with files/folder
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="input"></param>
        public void SetContent(List<Column> columns, List<FileSystemInfo> input)
        {
            List<FileSystemInfo> temp = input.Take(mySet.MaxElementsColumn-1).ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                
                for(int c = 0; c < columns.Count; c++)
                {
                    columns[c].Add(
                        new Cell(
                            new Point(columns[c].StartPoint.X + c * mySet.ColumnWidthLeft, columns[c].StartPoint.Y + i),
                            new Point(columns[c].StartPoint.X + mySet.ColumnWidthLeft + c * mySet.ColumnWidthLeft, columns[c].StartPoint.Y + i),
                            
                            ));
                }
                
                
                for (int j = 1; j < columns.Count-1; j++)
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
        public void CheckColumn(int index, FileSystemInfo file)
        {
            if (index == 0)
            {
                Console.WriteLine(CutName(file.Name));
            }
            if (index == 1)
            {
                Console.WriteLine(file.CreationTime.ToShortDateString());
            }
            if (index == 2)
            {
                Console.WriteLine(file.LastAccessTime.ToShortDateString());
            }
        }
        public string CutName(string name)
        {
            if (name.Length > mySet.ColumnWidthLeft - 2)
                name = name.Substring(0, mySet.ColumnWidthLeft - 2);
            return name;
        }


        public FileSystemInfo GetRoot(FileSystemInfo file)
        {
            string rootPath = Directory.GetDirectoryRoot(file.FullName);

            FileSystemInfo result = FileSystemInfo;
            


            

        }
    }
}
