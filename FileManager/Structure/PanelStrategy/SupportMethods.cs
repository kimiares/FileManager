using FileManager.Commander;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure.PanelStrategy
{
    class SupportMethods
    {
        
        /// <summary>
        /// Cut operation depends on ColumnWidth param
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CutName(string name)
        {
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
        public static FileSystemInfo GetRoot(FileSystemInfo file)
        {
            return new DirectoryInfo(Directory.GetDirectoryRoot(file.FullName));

        }

        /// <summary>
        /// Add parent directory to the top of the column
        /// </summary>
        /// <param name="file"></param>
        /// <param name="list"></param>
        public static void AddRootIntoList(FileSystemInfo file, List<FileSystemInfo> list)
        {
            list.Reverse();
            list.Add(GetRoot(file));
            list.Reverse();
        }


    }
}
