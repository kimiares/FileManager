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
    public class Menu<T> : IStructure, ICheckArea
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Point StartPoint { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        /// <summary>
        /// кнопки меню (Yes/No)
        /// </summary>
        public List<T> MenuButtons { get; set; }
        /// <summary>
        /// ячейки для вывод/ввод 
        /// </summary>
        public List<T> MenuCells { get; set; }
        public IDrawing drawing;
        public Menu()
        {
            drawing = new Table();
        }
        
        public MenuBuilder<T> CreateBuilder()
        {
            return new MenuBuilder<T>();
        }
        

        public void MakeActive()
        {
            throw new NotImplementedException();
        }
        public void Add()
        {
            throw new NotImplementedException();
        }
        public void Remove()
        {
            throw new NotImplementedException();
        }

        public bool CheckArea(Point point)
        {
            throw new NotImplementedException();
        }
    }
}
