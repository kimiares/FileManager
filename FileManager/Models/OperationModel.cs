using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Models
{
    public class OperationModel
    {
        public List<FileSystemInfo> Files { get; set; }
        public string Path { get; set; }

    }
}
