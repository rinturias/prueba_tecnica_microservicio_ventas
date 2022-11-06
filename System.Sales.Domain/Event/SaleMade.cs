using Sharedkernel.Core;
using System.Sales.Domain.Models.sale;

namespace System.Sales.Domain.Event
{
    public class SaleMade : DomainEvent
    {
        public Sale saleMade { get; set; }
        public SaleMade(Sale sale, DateTime occuredOn) : base(occuredOn)
        {
            saleMade = sale;

        }
    }

}