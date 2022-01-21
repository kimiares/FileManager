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

    public class ThreeProperties : IPanelStrategy

    {
        Settings mySet = Settings.Instance();


        public IEnumerable<Cell> SetContent(Panel panel, List<FileSystemInfo> input)
        {

            int cellsCount = panel.Count * mySet.MaxElementsColumn;
            var tempList = new List<FileSystemInfo>
            {
                new ParentDirectory(input[0])
            }
            .Union(input.Take(cellsCount));


            return panel.GetAllCells()
                .ZipAll(tempList, (cellsForFilling, temp) => new { cellsForFilling, temp })
                .Where(r => r.cellsForFilling != null)
                .Each(r => r.cellsForFilling.Content = r.temp)
                .Select(r => r.cellsForFilling);


        }



        public void PrintContent(Panel panel, List<FileSystemInfo> input)
        {

            var cells = SetContent(panel, input);
            Console.ResetColor();
            foreach (Cell cell in cells)
            {
                cell.StartPoint.SetCursor();
                cell.Content?.Name.Write();
               
            }
        }


    }
}
