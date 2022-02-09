using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Web.Model
{
    public interface IRepository
    {
        IEnumerable<FileSystemModel> GetFiles();
        void SaveFiles();
        void RemoveFiles(string[] fileSystems);
        void AddFilesFromFolder(List<FileSystemModel> fileSystems);
        void ClearDbSet();
        void FilesInit(List<FileSystemModel> fileSystems);
    }
}
