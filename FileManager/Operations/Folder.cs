using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Operations
{
    public class Folder: IOperation
    {
        public static List<FileSystemInfo> Get(string path)
        {
            List<FileSystemInfo> result = new List<FileSystemInfo>();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                DirectoryInfo[] folders = dir.GetDirectories();
                foreach (DirectoryInfo fol in folders)
                {
                    result.Add(fol);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        public void Copy(FileSystemInfo directory, string pathToCopy)
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
                Copy(folder, dest);
            }
        }
        public static void Delete(params FileSystemInfo[] directory)
        {
            if (directory.Length != 0)
            {
                foreach (var d in directory)
                {
                    if (Directory.Exists(d.FullName))
                    {
                        Directory.Delete(d.FullName, true);
                    }
                }
            }
        }
        public static void Rename(FileSystemInfo directory, string newName)
        {
            if (Directory.Exists(directory.Name))
            {
                Directory.Move(directory.Name, newName);
            }
        }
        public static void Create(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.Create();
        }
       
    }
}
