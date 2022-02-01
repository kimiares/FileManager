using FileManager.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet]
        //public IEnumerable<TestClass> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new TestClass
        //    {
        //        Name = "test",
        //        Number = rng.Next(0, 12)
        //    })
        //    .ToArray();
        //}
        [HttpGet]
        public IEnumerable<FileSystemModel> Get()
        {
            List<FileSystemInfo> test = Files.GetFiles(@"C:\Windows").ToList();
            List<FileSystemModel> result = new();
            
            foreach(var file in test)
            {
                result.Add(
                    new FileSystemModel()
                    {
                        Name = file.Name,
                        FullName = file.FullName,
                        Count = file.Name.Length,
                        CreationTime = file.CreationTime
                    });
            }
            
            
            return result.ToArray();
        }
    }
}
