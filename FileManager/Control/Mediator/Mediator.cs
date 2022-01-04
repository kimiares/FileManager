using FileManager.Operations;
using FileManager.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Control.Mediator
{
    /// <summary>
    /// binding input with operations
    /// /// </summary>
    class Mediator: IMediator
    {
        IStructure structure;
        IOperation operation;
        IInput input;

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
}
