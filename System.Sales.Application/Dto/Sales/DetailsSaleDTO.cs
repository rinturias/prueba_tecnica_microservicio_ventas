using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Application.Dto.Sales
{
    public class DetailsSaleDTO
    {
        public int quantity { get; set; }
        public decimal price { get; set; }
        public Guid productId { get; set; }
    }
}
