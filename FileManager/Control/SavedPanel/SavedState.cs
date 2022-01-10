using FileManager.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.SavedPanel
{
    class SavedState<T> 
        //where U : IStructure
        where T : class
    {
        public List<T> ItemsInColumns { get; set; }
        public Panel<T> ActivePanel { get; set; }
        public T SelectedItem { get; set; }
    }
}
