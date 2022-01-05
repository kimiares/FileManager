using FileManager.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commander
{
    /// <summary>
    /// инициализация коммандера
    /// </summary>
    class FileCommander<T>
    {
        public List<T> Panels { get; set; }
        //public Buttons<T> Buttons { get; set; }


        public FileCommander(List<T> panels /*Buttons<T> buttons*/)
        {
            throw new NotImplementedException();
        }


        public void GetConfig()
        {
            throw new NotImplementedException();
        }



    }
}
