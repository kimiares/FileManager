using FileManager.Operations;
using FileManager.Structure.PanelStrategy;
using FileManager.Web.Data;
using FileManager.Web.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileManager.Web.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PanelController : ControllerBase
    {
        
        public IRepository repository;
        public PanelController(IRepository repository)
        {
            
            this.repository = repository;
            this.repository.FilesInit(FileSystemModelInit(@"C:\"));
            
        }


        #region REST
        [HttpGet]
        public IEnumerable<FileSystemModel> Get() =>
        this.repository.GetFiles();
        
        [HttpPost("Open")]
        public IActionResult Open(FileSystemModel fileSystem)
        {

            this.repository.AddFilesFromFolder(
                (fileSystem.Name == "..") ?
                FileSystemInfoConvert(GoOutFolder(fileSystem)) :
                FileSystemInfoConvert(GoIntoFolder(fileSystem))
                );

            return RedirectToAction("Get", "Panel");


        }
        public List<FileSystemInfo> GoIntoFolder(FileSystemModel fileSystem)
        {

            List<FileSystemInfo> temp = new();

            temp.AddRange(Folder.GetFolders(fileSystem.FullName)
                .Union(Files.GetFiles(fileSystem.FullName)));

            return temp;                        
            
        }
        public List<FileSystemInfo> GoOutFolder(FileSystemModel fileSystem)
        {

            FileInfo file = new FileInfo(fileSystem.FullName);
            DirectoryInfo directory = file.Directory;

            List<FileSystemInfo> temp = new();
            if (directory == null) throw new Exception();

            temp.AddRange(Folder.GetFolders(directory.FullName)
                .Union(Files.GetFiles(directory.FullName)));

            return temp;
        }



        
        [HttpPost("Delete")]
        public IActionResult Delete(string[] checkedFiles)
        {
            this.repository.RemoveFiles(checkedFiles);
            return Ok();

        }
        #endregion


        #region supported methods
        public List<FileSystemModel> FileSystemModelInit(string path)
        {
            List<FileSystemInfo> input = Files.GetFiles(path)
               .Union(Folder.GetFolders(path))
               .ToList();

            return FileSystemInfoConvert(input);

        }

        public List<FileSystemModel> FileSystemInfoConvert(List<FileSystemInfo> input)
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


        #endregion



    }
}
