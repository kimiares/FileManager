using FileManager.Operations;
using FileManager.Structure.PanelStrategy;
using FileManager.Web.Data;
using FileManager.Web.ExtentionsForFSI;
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
                context.Files.AddRange(@"C:\".FileSystemModelInit());
                context.SaveChanges();
            }
        }


        #region REST
        [HttpGet]
        public IActionResult Get() =>
            Ok(context.Files.ToArray());
        
           



        [HttpPost("Open")]
        public IActionResult Open(FileSystemModel fileSystem)
        {
            ClearDbSet();
            context.Files.AddRange(

                (fileSystem.Name == "..") ?
                fileSystem.GoOutFolder()
                .FileSystemInfoConvert() :
                    fileSystem.GoIntoFolder()
                    .FileSystemInfoConvert()
                );

            context.SaveChanges();
            return RedirectToAction("Get","Panel");


        }
       
        



        [HttpPost("Delete")]
        public IActionResult Delete(string[] checkedFiles)
        {
            foreach(var c in checkedFiles)
            {
                var fileToDelete = context.Files.FirstOrDefault(f => f.Name == c);
                context.Files.Remove(fileToDelete);
            }

            context.SaveChanges();
            return RedirectToAction();

        }
        #endregion


        public void ClearDbSet()
        {
            foreach (var file in context.Files) context.Files.Remove(file);
            context.SaveChanges();
        }

       



    }
}
