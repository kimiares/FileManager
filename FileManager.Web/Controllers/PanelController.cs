using FileManager.Web.ExtentionsForFSI;
using FileManager.Web.Model;
using Microsoft.AspNetCore.Mvc;

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
            this.repository.FilesInit(
                @"C:\".FileSystemModelInit()
                );
        }

        #region REST
        
        [HttpGet]
        public IActionResult Get() =>
            Ok(this.repository.GetFiles());
        

        [HttpPost("Open")]
        public IActionResult Open(FileSystemModel fileSystem)
        {
            this.repository.AddFilesFromFolder(
                (fileSystem.Name == "..") ?
                fileSystem.GoOutFolder()
                    .FileSystemInfoConvert() :
                    fileSystem.GoIntoFolder()
                        .FileSystemInfoConvert()
                );

            return RedirectToAction("Get", "Panel");
        }
       
        [HttpPost("Delete")]
        public IActionResult Delete(string[] checkedFiles)
        {
            this.repository.RemoveFiles(checkedFiles);
            return Ok();
        }
        #endregion


    }
}
