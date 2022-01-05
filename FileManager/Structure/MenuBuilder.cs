using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class MenuBuilder<T>
    {
        public Menu<T> menu;
        public IDrawing drawing;

        public MenuBuilder()
        {
            menu = new Menu<T>();
        }
        public MenuBuilder<T> SetDrawing()
        {
            this.drawing = new Table();
            return this;
        }
        public MenuBuilder<T> SetStartPoint(Point point)
        {
            menu.StartPoint = point;
            return this;
        }
        public MenuBuilder<T> SetfinishPoint(Point point)
        {
            menu.FinishPoint = point;
            return this;
        }
        
        
        public MenuBuilder<T> SetButtonList(List<T> menuButtons)
        {

            menu.MenuButtons = menuButtons;
            return this;
        }
        public MenuBuilder<T> SetCellList(List<T> menuCells)
        {

            menu.MenuCells = menuCells;
            return this;
        }
        public Menu<T> Build()
        {
            return menu;
        }

    }
}
