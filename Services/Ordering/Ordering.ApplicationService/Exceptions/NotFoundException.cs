using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.ApplicationService.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            :base($"Entity {name} by key {key} was not found")
        {         
        }
    }
}
