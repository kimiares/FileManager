using FileManager.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Web.Model
{
    public class Repository : IRepository
    {

        public FSIContext context;
        public Repository(FSIContext context)
        {
            this.context = context;
        }


        public IEnumerable<FileSystemModel> Files
        {
            get { return context.Files; }
        }

        public void FilesInit(List<FileSystemModel> fileSystems)
        {
            if (!context.Files.Any())
            {
                context.Files.AddRange(fileSystems);
                SaveFiles();
            }
        }

        public IEnumerable<FileSystemModel> GetFiles()
        {
            return context.Files.ToArray();
        }

        public void SaveFiles()
        {
            context.SaveChanges();
        }

        public void RemoveFiles(string[] fileSystems)
        {
            context.Files.RemoveRange(
                context.Files.Where(
                    item => fileSystems.Contains(item.Name)
                    ));
            
            SaveFiles();
        }

        public void AddFilesFromFolder(List<FileSystemModel> fileSystems)
        {
            ClearDbSet();
            context.Files.AddRange(fileSystems);
            SaveFiles();

        }

        public void ClearDbSet()
        {
            context.Files.RemoveRange(context.Files);
            SaveFiles();
        }


    }
}
