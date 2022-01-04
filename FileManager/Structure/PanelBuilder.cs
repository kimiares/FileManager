using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public class PanelBuilder<T>
    {
        public Panel<T> panel;
        public PanelBuilder()
        {
            panel = new Panel<T>();
        }

        public PanelBuilder<T> SetPoints(Point start, Point finish)
        {
            panel.StartPoint = start;
            panel.FinishPoint = finish;
            return this;
        }
       
        public PanelBuilder<T> SetPath(string path)
        {
            panel.Path = path;
            return this;
        }
        public PanelBuilder<T> SetActiveState()
        {
            panel.IsActive = false;
            return this;
        }
        

        public PanelBuilder<T> SetList(List<T> Columns)
        {

            panel.Columns = Columns;
            return this;
        }


        public Panel<T> Build()
        {
            return panel;
        }







    }
}
