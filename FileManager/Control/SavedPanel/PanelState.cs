using FileManager.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.SavedPanel
{
    class PanelState<T>
    {
        public List<T> ItemsInColumns { get; set; }
        public Panel<T> ActivePanel { get; set; }
        public T SelectedItem { get; set; }


        public void SaveState()
        {
            throw new NotImplementedException();
        }
        public void SetSavedState()
        {
            throw new NotImplementedException();
        }


    }
}
