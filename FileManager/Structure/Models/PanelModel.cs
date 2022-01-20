using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure.Models
{
    public class PanelModel
    {
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public string Path { get; set; }
        public int Index { get; set; }
        public IDrawing Drawing { get; set; }
        public IPanelStrategy Algorithm { get; set; }

      

    }
}
