using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Structure;

namespace FileManager.Structure.PanelStrategy
{
    public class AllColumn: IPanelStrategy
    {
        public void SetColumn()
        {
            try
            {
                foreach(Column column in Panel.Columns)
                {
                    //fill column
                }
            }
            catch
            {
                throw new NotImplementedException();
            }

            
            
            
        }
    }
}
