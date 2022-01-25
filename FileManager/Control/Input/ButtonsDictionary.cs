using FileManager.Models;
using FileManager.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.Input
{
    public class ButtonsDictionary
    {
        Dictionary<ConsoleKey, Action<OperationModel>> fKeysDictionary = new Dictionary<ConsoleKey, Action<OperationModel>>()
        {
                { ConsoleKey.F5, Files.Copy},
                { ConsoleKey.F6, Files.Rename},
                { ConsoleKey.F7, Folder.Create},
                { ConsoleKey.F8, Files.Delete}
                
        };


        public void RunOperation(ConsoleKey key, OperationModel model)
        {
            fKeysDictionary[key].Invoke(model);
        }


    }
    
}
