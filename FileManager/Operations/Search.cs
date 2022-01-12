using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileManager.Operations
{
    class Search:IOperation
    {
        
        public List<FileSystemInfo> SearchFileFolders(string mask, string disk)
        {
            Regex regMask = RegexMethod.TransformMaskToRegex(mask);
            List<FileSystemInfo> resultFiles = new List<FileSystemInfo>();

            DirectoryInfo directory = new DirectoryInfo(disk);

            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo di in directories)
            {
                if (regMask.IsMatch(di.Name))
                {
                    resultFiles.Add(di);
                }
            }

            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo f in files)
            {
                if (regMask.IsMatch(f.Name))
                {
                    resultFiles.Add(f);
                }
            }
            return resultFiles;


        }

    }
}
