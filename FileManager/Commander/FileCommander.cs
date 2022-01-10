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
    class FileCommander<U,T> 
        where U: IStructure
        where T : class
    {
        public List<U> Panels { get; set; }
        public List<Button> Buttons { get; set; }


        public FileCommander(List<U> panels /*Buttons<T> buttons*/)
        {
            throw new NotImplementedException();
        }


        public void GetConfig()
        {
            throw new NotImplementedException();
        }



    }
}
