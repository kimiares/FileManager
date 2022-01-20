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
        public IDrawing drawing;
        public IPanelStrategy algorithm;

        public PanelModel(Point start, Point finish, string path, int index, IDrawing drawing, IPanelStrategy algorithm)
        {
            this.StartPoint = start;
            this.FinishPoint = finish;
            this.Path = path;
            this.drawing = drawing;
            this.algorithm = algorithm;
            this.Index = index;
        }

    }
}
