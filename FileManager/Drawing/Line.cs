using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Drawing
{
    public class Line : List<Point>, IDrawing
    {
        /// <summary>
        /// Start point of line
        /// </summary>
        public Point FirstPoint { get; set; }
        /// <summary>
        /// End point of line
        /// </summary>
        public Point LastPoint { get; set; }
        public Line(Point a, Point b)
        {
            this.FirstPoint = a;
            this.LastPoint = b;
            CalculatePoints();
        }
        /// <summary>
        /// Is Line Gorisontal ?
        /// </summary>
        /// <returns>gorisontal: true else: false</returns>
        public bool isVertical() => FirstPoint.X == LastPoint.X ? true:false;
        /// <summary>
        /// Is Line Vertical ?
        /// </summary>
        /// <returns>vertical: true else: false</returns>
        public bool isGorisontal() => FirstPoint.Y == LastPoint.Y ? true:false;
        /// <summary>
        /// Drawing line with calculating of each point
        /// </summary>

        public void CalculatePoints()
        {
            if (isGorisontal())
            {
                for (int x = Math.Min(FirstPoint.X, LastPoint.X); x <= Math.Max(FirstPoint.X, LastPoint.X); x++)
                    this.Add(new Point(x, FirstPoint.Y, '═'));
            }
            else
            {
                for (int y = Math.Min(FirstPoint.Y, LastPoint.Y); y <= Math.Max(FirstPoint.Y, LastPoint.Y); y++)
                    this.Add(new Point(FirstPoint.X, y, '║'));
           }
        }
        public void Draw()
        {
            foreach (Point point in this)
            {
                point.Draw();
            }

        }


      
       
    }
}
