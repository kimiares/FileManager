using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileManager.Operations
{
    public class Searching:IOperation
    {
        
        public List<FileSystemInfo> SearchInFolder(string mask, string disk)
        {
            Regex regMask = RegexMethod.MakeRegexMaskForSearch(mask);
            List<FileSystemInfo> resultFilesAndFolder = new List<FileSystemInfo>();

            DirectoryInfo directory = new DirectoryInfo(disk);

            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo di in directories)
            {
                if (regMask.IsMatch(di.Name))
                {
                    resultFilesAndFolder.Add(di);
                }
                SearchInFolder(mask, di.Name);
            }

            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo f in files)
            {
                if (regMask.IsMatch(f.Name))
                {
                    resultFilesAndFolder.Add(f);
                }
            }
            return resultFilesAndFolder;

        }

    }
}
