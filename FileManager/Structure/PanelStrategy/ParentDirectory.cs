using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure.PanelStrategy
{
    public class ParentDirectory : FileSystemInfo
    {
        public override bool Exists => true;

        public override string Name => "..";

        public override void Delete()
        {
            throw new NotImplementedException();
        }
        public ParentDirectory(string fullPath)
        {
            this.FullPath = fullPath;
        }


        
    }
}
