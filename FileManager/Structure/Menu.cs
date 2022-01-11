using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    /// <summary>
    /// всплывающее меню
    /// </summary>
    public class Menu: IStructure
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        
        /// <summary>
        /// кнопки меню (Yes/No)
        /// </summary>
        public List<Cell> MenuButtons { get; set; }
        /// <summary>
        /// ячейки для вывод/ввод 
        /// </summary>
        public List<Cell> MenuCells { get; set; }
        public IDrawing drawing;

        public Menu(Point start, Point finish, string name, IDrawing drawing)
        {
            this.StartPoint = start;
            this.FinishPoint = finish;
            this.Name = name;
            this.drawing = drawing;
            this.IsActive = false;
        }
   
        
        
        
        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
        }
        public void Add()
        {
            throw new NotImplementedException();
        }
        public void Remove()
        {
            throw new NotImplementedException();
        }

     
    }
}
