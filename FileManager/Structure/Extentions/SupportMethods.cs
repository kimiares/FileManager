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
    public static  class SupportMethods
    {

        /// <summary>
        /// Cut operation depends on ColumnWidth param
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        
        public static string CutString(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return String.Empty;

            Settings mySet = Settings.Instance();

            if (name.Length > mySet.ColumnWidthLeft - 2)
                name = name.Substring(0, mySet.ColumnWidthLeft - 2);

            return name;
        }
        /// <summary>
        /// Get parent directory
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetRoot(this FileSystemInfo file) => 
            Directory.GetDirectoryRoot(file.FullName);
        
        public static void Write(this string data) => 
            Console.WriteLine(data.CutString());
        
        public static void SetCursor(this Point point) => 
            Console.SetCursorPosition(point.X, point.Y);
        

        public static void ChangeColor(this IStructure cell)
        {
            var tmp = Console.BackgroundColor;
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = tmp;
        }

        public static void SetSelectedColor(this IStructure cell)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void SetColour()
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
        }

    }
}
