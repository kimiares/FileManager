using FileManager.Operations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanelController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<FileSystemModel> Get()
        {
            List<FileSystemInfo> test = Files.GetFiles(@"C:\Windows")
                .Union(Folder.GetFolders(@"C:\Windows")).ToList();
            List<FileSystemModel> result = new();

            foreach (var file in test)
            {
                result.Add(
                    new FileSystemModel()
                    {
                        Name = file.Name,
                        FullName = file.FullName.ToString(),
                        CreationTime = file.CreationTime
                    });
            }
            return result.ToArray();
        }

        [HttpPost("Open")]
        public void Open(FileSystemModel fileSystem)
        {
            return;

            List<FileSystemModel> result = new();
            List<FileSystemInfo> files = Files.GetFiles(fileSystem.FullName).Union(Folder.GetFolders(fileSystem.FullName)).ToList();

            foreach (var file in files)
            {
                result.Add(
                    new FileSystemModel()
                    {
                        Name = file.Name,
                        FullName = file.FullName,
                        CreationTime = file.CreationTime
                    });
            }

        }
    }
}
