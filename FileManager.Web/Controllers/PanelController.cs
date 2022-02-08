using FileManager.Operations;
using FileManager.Structure.PanelStrategy;
using FileManager.Web.Data;
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
        FSIContext context;
        public PanelController(FSIContext context)
        {
            this.context = context;
            
            if (!context.Files.Any())
            {
                context.Files.AddRange(FileSystemModelInit(@"C:\"));
                context.SaveChanges();
            }
        }


        #region REST
        [HttpGet]
        public IEnumerable<FileSystemModel> Get() =>
           context.Files.ToArray();



        [HttpPost("Open")]
        public IActionResult Open(FileSystemModel fileSystem)
        {
            ClearDbSet();
            context.Files.AddRange(

                (fileSystem.Name == "..") ?
                FileSystemInfoConvert(GoOutFolder(fileSystem)) :
                FileSystemInfoConvert(GoIntoFolder(fileSystem))
                );

            context.SaveChanges();
            return Ok();


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

            temp.AddRange(Folder.GetFolders(directory.FullName)
                .Union(Files.GetFiles(directory.FullName)));

            return temp;
        }



        [HttpDelete]
        public IActionResult Delete(int[] checkedFiles)
        {
            foreach(var c in checkedFiles)
            {
                var fileToDelete = context.Files.FirstOrDefault(f => f.Id == c);
                context.Files.Remove(fileToDelete);
            }

            context.SaveChanges();
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


        public void ClearDbSet()
        {
            foreach (var file in context.Files) context.Files.Remove(file);
            context.SaveChanges();
        }

        #endregion



    }
}
