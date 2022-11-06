using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Domain.Models.detailSale;
using System.Sales.Domain.ValueObjects;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Infrastructure.EF.ReadModel
{
    public class SaleReadModel
    {
        public Guid Id { get; set; }
        public DateTime date { get;  set; }
        public string? note { get;  set; }

        public Guid clienteId { get;  set; }
        public Guid userId { get;  set; }

        public decimal amountTotal { get;  set; }

        public string status { get;  set; }

        public decimal amountNominal { get;  set; }

        public decimal discount { get;  set; }

        public decimal iva { get;  set; }
        public int active  { get; set; }
        public ICollection<DetailSaleReadModel> detailSale { get; set; }

    

    }
}
