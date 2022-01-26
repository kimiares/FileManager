using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Models;

namespace FileManager.Operations
{
    public class Files: IOperation
    {

        //public static Action<OperationModel> Get = (model) => GetFiles(model);
        public static Action<OperationModel> Copy = (model) => CopyFile(model);
        public static Action<OperationModel> Delete = (model) => DeleteFilesFolders(model);
        public static Action<OperationModel> Rename = (model) => RenameFile(model);




        public static IEnumerable<FileSystemInfo> GetFiles(OperationModel model)
        {
            try
            {
                DirectoryInfo dir = new(model.Path);
                return dir.GetFiles();                
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }
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

        public static void CopyFile(OperationModel model)
        {

            foreach(var file in model.Files)
            {
                if (!file.Exists)
                    throw new FileNotFoundException();
                File.Copy(file.Name, Path.Combine(model.Path, file.Name));
            }
            
        }
        public static void DeleteFilesFolders(OperationModel model)
        {
            if (model.Files == null) 
                throw new FileNotFoundException(); 
            
            foreach(FileSystemInfo file in model.Files)
                if (file.Exists) file.Delete();
            
        }
        public static void RenameFile(OperationModel model)
        {
            
            foreach(var file in model.Files)
            {
                if (string.IsNullOrWhiteSpace(model.Path))
                    throw new ArgumentNullException("New name cannot be null or blank", model.Path);
                if (!file.Exists)
                    throw new FileNotFoundException();
                File.Move(file.Name, model.Path);
            }

        }
        public void Create()
        {
            throw new NotImplementedException();
        }
        
    }
}
