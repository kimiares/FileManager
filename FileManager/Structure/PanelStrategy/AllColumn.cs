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
    /// <typeparam name="T"></typeparam>
    public class AllColumn : IPanelStrategy
        


    {
        //public List<FileSystemInfo> input;
        public int maxNumbers;
        //public Point StartPoint { get; set; }
        //public Point FinishPoint { get; set; }

        Settings MySet = Settings.Instance();

        public void SetColumn(List<Column> targertList, List<FileSystemInfo> input)
        {
            
                foreach (Column column in targertList)
                {
                    List<FileSystemInfo> temp = input.Take(MySet.MaxElementsColumn).ToList();
                    foreach (FileSystemInfo t in temp)
                    {
                        for (int i = 0; i < MySet.Sets.ColumnCount; i++)
                        {
                            column.Add(new Cell(
                                new Point(
                                    column.StartPoint.X, column.StartPoint.Y+i), 
                                new Point(
                                    column.FinishPoint.X, column.FinishPoint.Y- MySet.MaxElementsColumn + i), 
                                    t));
                        }
                        
                        }
                        input = input.Skip(column.MaxElementsNumber).ToList();
                    }
            
        }
    }
}
