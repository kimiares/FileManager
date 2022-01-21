using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Exceptions
{
    public class CollectionNullException : NullReferenceException
    {
        public CollectionNullException(string message) 
            : base(message)
        {

        }
    }
}
