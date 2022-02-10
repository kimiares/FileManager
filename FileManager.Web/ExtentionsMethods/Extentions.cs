using FileManager.Operations;
using FileManager.Structure.PanelStrategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Web.ExtentionsForFSI
{
    public static class Extentions
    {
        public static List<FileSystemModel> FileSystemInfoConvert(this List<FileSystemInfo> input)
        {
            List<FileSystemModel> result = new();

            if (input == null) throw new Exception();
            var FSIlist = new List<FileSystemInfo>
            {
                new ParentDirectory(input[0])
            }.Union(input);


            foreach (var file in FSIlist)
            {
                result.Add(
                    new FileSystemModel()
                    {
                        Name = file.Name,
                        FullName = file.FullName,
                        CreationTime = file.CreationTime
                    });
            }
            return result;

        }
        public static List<FileSystemModel> FileSystemModelInit(this string path)
        {
            List<FileSystemInfo> input = Files.GetFiles(path)
               .Union(Folder.GetFolders(path))
               .ToList();

            return FileSystemInfoConvert(input);

        }
        public static List<FileSystemInfo> GoIntoFolder(this FileSystemModel fileSystem)
        {

            List<FileSystemInfo> temp = new();

            temp.AddRange(Folder.GetFolders(fileSystem.FullName)
                .Union(Files.GetFiles(fileSystem.FullName)));

            return temp;

        }
        public static List<FileSystemInfo> GoOutFolder(this FileSystemModel fileSystem)
        {

            FileInfo file = new FileInfo(fileSystem.FullName);
            DirectoryInfo directory = file.Directory;

            List<FileSystemInfo> temp = new();
            if (directory == null) throw new Exception();

            temp.AddRange(Folder.GetFolders(directory.FullName)
                .Union(Files.GetFiles(directory.FullName)));

            return temp;
        }
    }
}
