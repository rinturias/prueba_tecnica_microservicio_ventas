using Sharedkernel.Core;
using System.Sales.Domain.Models.sale;

namespace System.Sales.Domain.Event
{
    public class SaleDelivered : DomainEvent
    {
        public Sale saleDelivered { get;  set; }
        public SaleDelivered(Sale sale, DateTime occuredOn) : base(occuredOn)
        {

            saleDelivered = sale;

        }

    }
}