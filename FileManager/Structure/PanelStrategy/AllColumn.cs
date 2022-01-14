using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Commander;
using FileManager.Drawing;
using FileManager.Structure;

namespace FileManager.Structure.PanelStrategy
{
    /// <summary>
    /// fill all columns by same data(only names)
    /// </summary>

    public class AllColumn : IPanelStrategy

    {
        Settings mySet = Settings.Instance();

        
        public void PrintContent(List<Column> columns)
        {
            foreach (Column column in columns)
            {
                for (int i = 0; i < column.Count; i++)
                {
                    Console.ResetColor();
                    Console.SetCursorPosition(column.StartPoint.X, column.StartPoint.Y + i);
                    Console.WriteLine(CutName(column[i].Content.Name));
                }
            }

        }

        public void SetContent(List<Column> columns, List<FileSystemInfo> input)
        {

            List<FileSystemInfo> temp = new List<FileSystemInfo>();
            for (int i = 0; i < columns.Count; i++)
            {

                temp = input.Skip(i * mySet.MaxElementsColumn).Take(mySet.MaxElementsColumn).ToList();

                for (int j = 0; j < temp.Count; j++)
                {
                    columns[i].Add(
                    new Cell(
                        new Point(columns[i].StartPoint.X, columns[i].StartPoint.Y + i),
                        new Point(columns[i].StartPoint.X + mySet.ColumnWidthLeft, columns[i].StartPoint.Y + i),
                        temp[j]
                        ));
                }
            }
        }
        public string CutName(string name)
        {
            if (name.Length > mySet.ColumnWidthLeft-2)
                name = name.Substring(0, mySet.ColumnWidthLeft - 2);
            return name;
        }
    }
}
