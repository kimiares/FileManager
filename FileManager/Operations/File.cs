using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Operations
{
    interface File: IOperation
    {
        public void Get()
        {
            throw new NotImplementedException();
        }
        public void Copy()
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public void Rename()
        {
            throw new NotImplementedException();
        }
        public void Create()
        {
            throw new NotImplementedException();
        }
        public void Info()
        {
            throw new NotImplementedException();
        }
    }
}
