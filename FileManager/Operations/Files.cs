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
        public static IEnumerable<FileSystemInfo> GetFiles(string path)
        {
            try
            {
                DirectoryInfo dir = new(path);
                return dir.GetFiles();                
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }
       
        public void Copy(FileSystemInfo file, string pathToCopy)
        {

            if (!file.Exists)
                throw new FileNotFoundException();
            File.Copy(file.Name, Path.Combine(pathToCopy, file.Name));

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
                throw new ArgumentNullException("New name cannot be null or blank", newName);
            if (!file.Exists)
                throw new FileNotFoundException();
            File.Move(file.Name, newName);

        }
        public void Create()
        {
            throw new NotImplementedException();
        }
        
    }
}
