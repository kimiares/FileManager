using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Operations
{
    public class Files: IOperation
    {
        public static List<FileSystemInfo> GetFiles(string path)
        {
            List<FileSystemInfo> result = new List<FileSystemInfo>();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles();

                result.AddRange(files);
                return result;
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }


        }
        public void Copy(FileSystemInfo file, string pathToCopy)
        {
            
                if (File.Exists(file.Name))
                {
                    File.Copy(file.Name, Path.Combine(pathToCopy, file.Name));
                }
                else
                {
                    throw new FileNotFoundException();
                }
            
        }
        public void DeleteFilesFolders(params FileSystemInfo[] filesToDelete)
        {
            if (filesToDelete.Length != 0)
            {
                foreach (FileSystemInfo file in filesToDelete)
                {
                    if (file.Exists) file.Delete();
                }
            }
        }
        public void Rename(FileSystemInfo file, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentNullException("New name cannot be null or blank", newName);
            }
            else
            {
                if (file.Exists) File.Move(file.Name, newName);
                else
                {
                    throw new FileNotFoundException("file not found");
                }

            }
        }
        public void Create()
        {
            throw new NotImplementedException();
        }
        
    }
}
