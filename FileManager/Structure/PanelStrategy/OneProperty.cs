﻿using FileManager.Commander;
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

       
        
        public IEnumerable<Cell> SetContent(Panel panel, List<FileSystemInfo> input)
        {

            var tempList = new List<FileSystemInfo>
            {
                new ParentDirectory(input[0])
            }
            .Union(input.Take(mySet.MaxElementsColumn-1));


            return panel.GetAllCells()
                .ZipAll(tempList, (cellsForFilling, temp) => new { cellsForFilling, temp })
                .Where(r => r.cellsForFilling != null)
                .Each(r => r.cellsForFilling.Content = r.temp)
                .Select(r => r.cellsForFilling);

        }

        
        public void PrintContent(Panel panel, List<FileSystemInfo> input)
        {
            var cells = SetContent(panel, input).Take(mySet.MaxElementsColumn);
            Console.ResetColor();
            PrintProperties(cells);
        }
        
        /// <summary>
        /// Print properties of FileSystemInfo file in columns
        /// </summary>
        /// <param name="cells"></param>
        public void PrintProperties(IEnumerable<Cell> cells)
        {
            foreach (Cell cell in cells)
            {

                cell.StartPoint.SetCursor();
                (cell.Content?.Name)
                    .Write();

                Console.SetCursorPosition(cell.StartPoint.X + mySet.ColumnWidthLeft - 1, cell.StartPoint.Y);

                (cell.Content?.CreationTime.ToShortDateString())
                    .Write();

                Console.SetCursorPosition(cell.StartPoint.X + 2 * (mySet.ColumnWidthLeft - 1), cell.StartPoint.Y);
                (cell.Content?.LastAccessTime.ToShortDateString())
                    .Write();

            }
        }

       
    }
}
