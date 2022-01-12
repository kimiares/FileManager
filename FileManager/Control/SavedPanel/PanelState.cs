using FileManager.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.SavedPanel
{
    /// <summary>
    /// сохранение состояния панели для перехода по директориям. As is variant
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class PanelState 
        
    {
        public List<FileSystemInfo> ItemsInColumns { get; set; }
        public Panel ActivePanel { get; set; }
        public FileSystemInfo SelectedItem { get; set; }


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
