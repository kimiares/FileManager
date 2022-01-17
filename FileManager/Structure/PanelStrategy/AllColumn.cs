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

        
        public void PrintContent(Panel columns)
        {
            foreach (Column column in columns)
            {
                for (int i = 0; i < column.Count; i++)
                {
                    Console.ResetColor();
                    Console.SetCursorPosition(column.StartPoint.X, column.StartPoint.Y + i);
                    Console.WriteLine(((columns.IndexOf(column) == 0)&&i==0) ? ".." : SupportMethods.CutName(column[i].Content.Name));
                }
            }

        }

        

        public void SetContent(Panel targertList, List<FileSystemInfo> input)
        {
            List<FileSystemInfo> temp = new List<FileSystemInfo>();
            temp.Add(SupportMethods.GetRoot(input[0]));
            temp.AddRange(input.Take(mySet.MaxElementsColumn - 1).ToList());

            
            for(int j = 0; j < targertList.Count; j++)
            {
                temp = input.Skip(j * mySet.MaxElementsColumn).Take(mySet.MaxElementsColumn).ToList();
                for (int i=0; i < targertList[j].Count; i++)
                {
                    targertList[j][i].Content = temp[i];
                }              
                
            }
            
        }

    }
}
