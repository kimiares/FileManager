using FileManager.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.SavedPanel
{
    /// <summary>
    /// сохранение состояния панели для перехода по директориям. As is variant
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class PanelState<T> where T : IStructure
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
