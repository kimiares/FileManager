using FileManager.Commander;
using FileManager.Drawing;
using FileManager.Structure.Models;
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

        public List<FileSystemInfo> SelectedFiles { get; set; }

        public IDrawing drawing;
        
        public IPanelStrategy algorithm;

        public Panel(PanelModel panelModel, List<FileSystemInfo> input)
        {
            this.StartPoint = panelModel.StartPoint;
            this.FinishPoint = panelModel.FinishPoint;
            this.Path = panelModel.Path;
            this.drawing = panelModel.Drawing;
            this.algorithm = panelModel.Algorithm;
            this.Input = input;
            this.Index = panelModel.Index;
           
            this.Selected = 0;
            SelectedFiles = new List<FileSystemInfo>();
            CreateColumnsWithCells();
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
            if (this.algorithm is OneProperty) this.CountPanelElements = 3*mySet.MaxElementsColumn;
        }
         
        /// <summary>
        /// create cells in each columns
        /// </summary>
        
        public void CreateColumnsWithCells() 
        {
            this.SetColumn();
            this.SetCells();
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
            this.FillPanel();
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
            this.FillPanel();
          

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
        public IEnumerable<Cell> SetContent(List<FileSystemInfo> input)
        {
            int cellsCount = this.Count * mySet.MaxElementsColumn;

            var tempList = new List<FileSystemInfo>
            {
                new ParentDirectory(input[0])
            }
            .Union(input.Take(cellsCount));

            if (this.algorithm is ThreeProperties)
            {
                if (this.Selected > mySet.MaxElementsColumn - 1)
                    tempList = tempList.Skip(this.Selected - (mySet.MaxElementsColumn - 1));
            }
            return this.GetAllCells()
                .ZipAll(tempList, (cellsForFilling, temp) => new { cellsForFilling, temp })
                .Where(r => r.cellsForFilling != null)
                .Each(r => r.cellsForFilling.Content = r.temp)
                .Select(r => r.cellsForFilling);
        }

        public void AddSelectedObjects()
        {
            //var rr = (GetAllCells().ElementAt(this.Selected));
            //var t = Input;
            if (SelectedFiles.Contains(Input[this.Selected - 1]))
                SelectedFiles.Remove(Input[this.Selected - 1]);
            else
            SelectedFiles.Add(Input[this.Selected-1]);

        }
    }
}
