using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
                            
        public NotFoundException(string name , object key) // Entity, Pk
            :base($"The {name} With Id:{key} Is Not Found!") 
        {
            
        }
    }
}
