using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Drawing
{
    class Table : IDrawing
    {
        /// <summary>
        /// Left upper point
        /// </summary>
        public Point StartPoint { get; set; }
        /// <summary>
        /// Right bottom point
        /// </summary>
        public Point FinishPoint { get; set; }
        /// <summary>
        /// Columns count
        /// </summary>
        public int ColCount { get; set; }
        /// <summary>
        /// Panels name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// All Lines of Table
        /// </summary>
        public List<Line> Lines { get; set; }
        public Table(string name, Point a, Point b, int colcount)
        {
            Name = name;
            StartPoint = a;
            FinishPoint = b;
            ColCount = colcount;
            Lines = Calculate();
            Draw();
            //AddTableName();
        }
        /// <summary>
        /// Draw table with cornerns
        /// </summary>
        public void Draw()
        {
        foreach (IDrawing line in Lines.Cast<IDrawing>()
                                      .Union(GetCornersPoint())
                                      .Union(GetUpTCornersPoint())
                                      .Union(GetBottomTCornersPoint()) )
            {
                line.Draw();
            }
        }
        /// <summary>
        /// Return all corners of table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Point> GetCornersPoint()
        {
            for (int i = 0; i < 4; i++)
                yield return new Point(Lines[i].FirstPoint.X, Lines[i].FirstPoint.Y, Corner.Corners[i]);
        }
        /// <summary>
        /// Return all upper T-corners
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Point> GetUpTCornersPoint()
        {
            if (Lines.Count > 4)
                for (int i = 4; i < Lines.Count; i++)
                    yield return new Point(Lines[i][0].X, Lines[i][0].Y, Corner.TCorners[0]);
        }
        /// <summary>
        /// Return all bottom T-corners
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Point> GetBottomTCornersPoint()
        {
            if (Lines.Count > 4)
                for (int i = 4; i < Lines.Count; i++)
                    yield return new Point(Lines[i][0].X, FinishPoint.Y, Corner.TCorners[1]);
        }
        /// <summary>
        /// Print panels name
        /// </summary>
        public void AddTableName()
        {
            Console.SetCursorPosition(StartPoint.X + (FinishPoint.X - StartPoint.X) / 2 - Name.Length / 2, StartPoint.Y);
            Console.Write(Name);
        }
        /// <summary>
        /// Return all lines of table
        /// </summary>
        /// <returns></returns>
        public List<Line> Calculate()
        {
            List<Line> lines = new List<Line>()
            {
                new Line(StartPoint, new Point(FinishPoint.X, StartPoint.Y)),
                new Line(new Point(FinishPoint.X, StartPoint.Y), FinishPoint),
                new Line(FinishPoint, new Point(StartPoint.X, FinishPoint.Y)),
                new Line(new Point(StartPoint.X, FinishPoint.Y), StartPoint)
            };
            if (ColCount > 1)
            {
                int ColumnWidth = (FinishPoint.X - StartPoint.X) / ColCount;
                for (int i = 1; i < ColCount; i++)
                {
                    lines.Add(
                        new Line(
                            new Point(StartPoint.X + i * ColumnWidth, StartPoint.Y), 
                            new Point((StartPoint.X + (i+1) * ColumnWidth), FinishPoint.Y)
                            ));
                }
            }

            return lines;
        }
    }
}
