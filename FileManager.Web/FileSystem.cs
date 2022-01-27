using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Web
{
    public class FileSystemModel
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
