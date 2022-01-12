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
        
        public int maxNumbers;
        

        Settings mySet = Settings.Instance();

        //public void SetColumn(List<Column> targertList, List<FileSystemInfo> input)
        //{
            
        //        foreach (Column column in targertList)
        //        {
        //            List<FileSystemInfo> temp = input.Take(MySet.MaxElementsColumn).ToList();
        //            foreach (FileSystemInfo t in temp)
        //            {
        //                for (int i = 0; i < MySet.Sets.ColumnCount; i++)
        //                {
        //                    column.Add(new Cell(
        //                        new Point(
        //                            MySet.Sets.ALX+1+i, MySet.Sets.ALY+1+i), 
        //                        new Point(
        //                            MySet.Sets.ALX + 1 + i + MySet.ColumnWidth, MySet.Sets.ALY + 1 + i + MySet.MaxElementsColumn), 
        //                            t));
        //                }
                        
        //            }
        //                input = input.Skip(MySet.MaxElementsColumn).ToList();
        //        }
            
        //}


        public void PrintContent(List<Column> targertList)
        {

            foreach (Column column in targertList)
            {
                for (int i = 0; i < column.Count; i++)
                {
                    //Console.SetCursorPosition(mySet.Sets.ALX + 1 + i*mySet, mySet.Sets.ALY + 1 + i);
                    Console.WriteLine(column[i].Content.Name);
                    column.Remove(column[i]);
                }
            }
        }

       
    }
}
