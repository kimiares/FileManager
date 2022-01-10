using FileManager.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.SavedPanel
{
    class Buffer<U,T> where U : IStructure
        where T: class
    {
        public SavedState<U,T> SavedState { get; set; }
    }
}
