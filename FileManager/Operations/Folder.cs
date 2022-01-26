using FileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Operations
{
    public class Folder : IOperation
    {

        public static Action<OperationModel> Get = (model) => GetFolder(model);
        public static Action<OperationModel> Rename = (model) => RenameFolder(model);
        public static Action<OperationModel> Create = (model) => CreateFolder(model);
        public static Action<OperationModel> Copy = (model) => CopyFolders(model);



        public static IEnumerable<FileSystemInfo> GetFolder(OperationModel model)
        {
            try
            {
                DirectoryInfo dir = new(model.Path);
                return dir.GetDirectories();
            }
            catch
            {
                throw new DirectoryNotFoundException();
            }            
        }
        public static IEnumerable<FileSystemInfo> GetFolders(string path)
        {
            try
            {
                DirectoryInfo dir = new(path);
                return dir.GetDirectories();
            }
            catch
            {
                throw new DirectoryNotFoundException();
            }
        }
        public static void CopyFolders(OperationModel model) => 
            model.Files.ForEach(folder => CopyFolder(folder, model.Path));     
        

        public static void CopyFolder(FileSystemInfo directory, string pathToCopy)
        {
            if (!Directory.Exists(pathToCopy))
            {
                Directory.CreateDirectory(pathToCopy);

            }

            string[] files = Directory.GetFiles(directory.FullName);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(pathToCopy, name);
                File.Copy(file, dest);
            }


            DirectoryInfo di = new DirectoryInfo(directory.FullName);
            DirectoryInfo[] folders = di.GetDirectories();
            foreach (DirectoryInfo folder in folders)
            {
                string name = Path.GetFileName(folder.Name);
                string dest = Path.Combine(pathToCopy, name);
                CopyFolder(folder, dest);
            }
        }


        public static void RenameFolder(OperationModel model)
        {
            foreach(var folder in model.Files)
                if (folder.Exists) Directory.Move(folder.Name, model.Path);
            
        }
        public static void CreateFolder(OperationModel model)
        {
            DirectoryInfo directory = new DirectoryInfo(model.Path);
            directory.Create();
        }

    }
}
