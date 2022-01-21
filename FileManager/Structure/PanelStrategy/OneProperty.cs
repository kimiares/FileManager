using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileManager.Commander;

namespace FileManager.Structure.PanelStrategy
{
    /// <summary>
    /// fill all columns by same data(only names)
    /// </summary>

    public class OneProperty : IPanelStrategy

    {
        public void PrintContent(Panel panel, List<FileSystemInfo> input)
        {
            var cells = panel.SetContent(input);

            Console.ResetColor();

            foreach (Cell cell in cells)
            {
                if (cell.IsActive) cell.ChangeColor();
                if (cell.IsSelected) cell.SetSelectedColor();

                cell.StartPoint.SetCursor();

                cell.Content?.Name
                    .Write();

                Console.ResetColor();
            }
        }
    }
}
