using Sharedkernel.Core;
using System.Sales.Domain.ValueObjects;

namespace System.Sales.Domain.Models.detailSale
{
    public class DetailSale : Entity<Guid>
    {
        public DateTime date { get; private set; }
        public CantidadValue quantity { get; private set; }
        public PrecioValue price { get; private set; }

        public Guid productId { get; private set; }

        public Guid saleId { get; private set; }

        internal DetailSale() {
        Id = Guid.NewGuid();
        price =new PrecioValue(0);
        }
        public DetailSale(Guid productoId, Guid saleId, PrecioValue price, CantidadValue quantity)
        {
            Id = Guid.NewGuid();
            date = DateTime.UtcNow;

            productId = productoId;
            this.saleId = saleId;

            this.price = price;
            this.quantity = quantity;
        }


        internal void modifyDetailsSale(PrecioValue price, CantidadValue quantity)
        {
            this.price = price;
            this.quantity = quantity;
          
        }
    }
}
