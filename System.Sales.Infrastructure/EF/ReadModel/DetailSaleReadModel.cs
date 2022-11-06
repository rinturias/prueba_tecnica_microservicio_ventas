using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Domain.ValueObjects;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Infrastructure.EF.ReadModel
{
    public class DetailSaleReadModel
    {
        public Guid Id { get; set; }
        public DateTime date { get;  set; }
        public int quantity { get;  set; }

        public decimal price { get;  set; }

        public Guid productId { get;  set; }

        public SaleReadModel Sale { get; set; }

     //   public Guid saleId { get;  set; }

     
    }
}
