using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Domain.Models.sale;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Domain.Interfaces
{
  
        public interface ISaleRepository : InterfaceGeneric<Sale, Guid>
        {
            Task UpdateAsync(Sale obj);
        }
    
}
