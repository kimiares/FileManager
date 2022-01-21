using FileManager.Commander;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure.PanelStrategy
{
    public static class SupportMethods
    {
        
        /// <summary>
        /// Cut operation depends on ColumnWidth param
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CutString(this string str)
        {
            Settings mySet = Settings.Instance();
            if (str.Length > mySet.ColumnWidthLeft - 2)
                str = str.Substring(0, mySet.ColumnWidthLeft - 2);
            return str;
        }
        /// <summary>
        /// Get parent directory
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static FileSystemInfo GetRoot(FileSystemInfo file)
        {
            return new DirectoryInfo(Directory.GetDirectoryRoot(file.FullName));

        }     


    }
}
