using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure.PanelStrategy
{
    public class Tree : IPanelStrategy
        
    {
        IDrawing drawing;

        

        public void PrintContent(List<Column> targertList)
        {
            throw new NotImplementedException();
        }

        public void PrintContent(Panel targertList)
        {
            throw new NotImplementedException();
        }

        public void PrintContentTest(Panel targertList)
        {
            throw new NotImplementedException();
        }

        public void SetContent(List<Column> targertList, List<FileSystemInfo> input)
        {
            throw new NotImplementedException();
        }

        public void SetContent(Panel targertList, List<FileSystemInfo> input)
        {
            throw new NotImplementedException();
        }
    }
}
