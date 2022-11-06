using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Application.Dto.Sales
{
    public class RequestSaleDelivered
    {
        public Guid saleId { get; set; }
        //public Guid clienteId { get; set; }
        public Guid userId { get; set; }
        public string status { get; set; }
        public string note { get; set; }

    }
}
