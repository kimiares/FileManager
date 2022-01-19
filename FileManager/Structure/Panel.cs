using FileManager.Commander;
using FileManager.Drawing;
using FileManager.Structure.PanelStrategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class Panel : List<Column>, ICheckArea
    {
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public int CountPanelElements { get; set; }
        public int Index { get; set; }
        public int Selected { get; set; }
        public bool IsActive { get; set; }
        /// <summary>
        /// Root path
        /// </summary>
        public string Path { get; set; }
        public List<FileSystemInfo> Input { get; set; }
        public IDrawing drawing;
        public IPanelStrategy algorithm;

        public Panel(Point start, Point finish, string path, int index, IDrawing drawing, IPanelStrategy algorithm, List<FileSystemInfo> input)
        {

            this.StartPoint = start;
            this.FinishPoint = finish;
            this.Path = path;
            this.IsActive = false;
            this.drawing = drawing;
            this.algorithm = algorithm;
            this.Input = input;
            this.Index = index;
            this.Selected = 0;
            SetColumn();
            SetCells();
            AddTableName();
            FillPanel();
        

        }
        Settings mySet = Settings.Instance();
        
        public void FillPanel()
        {
            
            ClearPanel();
            SetCountPanelElements();
            this.algorithm.PrintContent(this, this.Input);
        }

        public void SetCountPanelElements()
        {
            this.CountPanelElements = mySet.MaxElementsColumn;
            if (this.algorithm is AllColumn) this.CountPanelElements = 3*mySet.MaxElementsColumn;


        }
         
        /// <summary>
        /// Create columns with coordinates
        /// </summary>
        public void SetColumn()
        {
            for (int i = 0; i < mySet.ColumnCountLeft; i++)
            {
                this.Add(
                    new Column(
                        new Point(mySet.Sets.ALX + 1 - i + i * mySet.ColumnWidthLeft + this.Index*(mySet.Sets.PanelWidth+1), mySet.Sets.ALY + 1),
                            new Point(mySet.Sets.ALX + 1 - i + (i+1) * mySet.ColumnWidthLeft +  this.Index * (mySet.Sets.PanelWidth+1), mySet.Sets.ALY + 1 + mySet.MaxElementsColumn)
                       ));
            }

        }
        
        /// <summary>
        /// create cells in each columns
        /// </summary>
        public void SetCells()
        {
            for(int i = 0; i < this.Count; i++)
            {
                for(int j = 0; j < mySet.MaxElementsColumn; j++)
                {
                    this[i].Add(new Cell(
                        new Point(this[i].StartPoint.X, this[i].StartPoint.Y + j),
                        new Point(this[i].StartPoint.X + mySet.ColumnWidthLeft, this[i].StartPoint.Y + j)
                        ));
                }
            }
        }

        public IEnumerable<Cell> GetAllCells()
        {
            foreach (Column column in this)
                foreach (Cell cell in column)
                    yield return cell;
        }


        /// <summary>
        /// Adding path into top of the panel
        /// </summary>
        public void AddTableName()
        {
            Console.SetCursorPosition(
                StartPoint.X + (FinishPoint.X - StartPoint.X) / 2 - Path.Length / 2,
                StartPoint.Y - 1);
            Console.Write(Path);
        }

        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
        }

        public void MoveUp()
        {
         
            if (this.Selected<= 0)
            {
                this.Selected = GetAllCells().Count() - 1;
                SetSelected(0, CountPanelElements - 1);
            }
            else
            {
                SetSelected(this.Selected, this.Selected- 1);
                this.Selected--;
            }
        }


        public void MoveDown()
        {
            if (this.Selected == GetAllCells().Count() - 1)
            {
                this.Selected = 0;
                SetSelected(CountPanelElements - 1, this.Selected);
            }
            else
            {

                SetSelected(this.Selected, this.Selected+ 1);
                this.Selected++;
            }
        }

        public void ClearPanel()
        {
            Console.ResetColor();
            string h = new String(' ', mySet.ColumnWidthLeft - 2);

                foreach (Cell cell in GetAllCells())
            {
                cell.StartPoint.SetCursor();
                Console.WriteLine(h);
            }
        }

        public void SetSelected(int oldIndex, int newIndex)
        {
            if ((newIndex < CountPanelElements) & (oldIndex < CountPanelElements))
            {
                GetAllCells().ElementAt(oldIndex).IsActive = false;
                GetAllCells().ElementAt(newIndex).IsActive = true;
            }


        }
    }
}
