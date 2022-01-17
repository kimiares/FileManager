﻿using FileManager.Drawing;
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

        public void PrintContent(Panel targertList, List<FileSystemInfo> input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cell> SetContent(Panel targertList, List<FileSystemInfo> input)
        {
            throw new NotImplementedException();
        }
    }
}
