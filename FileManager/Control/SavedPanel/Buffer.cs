using FileManager.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.SavedPanel
{
    class Buffer<T> 
        //where U : IStructure
        where T: class
    {
        public SavedState<T> SavedState { get; set; }
    }
}
