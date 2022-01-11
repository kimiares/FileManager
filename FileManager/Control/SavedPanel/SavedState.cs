using FileManager.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.SavedPanel
{
    class SavedState 
        
    {
        public List<FileSystemInfo> ItemsInColumns { get; set; }
        public Panel ActivePanel { get; set; }
        public FileSystemInfo SelectedItem { get; set; }
    }
}
