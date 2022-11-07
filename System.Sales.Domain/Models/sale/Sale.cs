using Sharedkernel.Core;
using System.Collections.ObjectModel;
using System.Sales.Domain.Event;
using System.Sales.Domain.Models.detailSale;
using System.Sales.Domain.ValueObjects;

namespace System.Sales.Domain.Models.sale
{
    public class Sale : AggregateRoot<Guid>
    {



        public DateTime date { get; private set; }
        public string note { get; private set; }

        public Guid clienteId { get; private set; }
        public Guid userId { get; private set; }

        public PrecioValue amountTotal { get; private set; }

        public StatusValue status { get; private set; }

        public PrecioValue amountNominal { get; private set; }

        public decimal discount { get; private set; }

        public decimal iva { get; private set; }

        public int active { get; private set; }

        private readonly ICollection<DetailSale> _detalleSale;

        public IReadOnlyCollection<DetailSale> DetalleSale
        {
            get
            {
                return new ReadOnlyCollection<DetailSale>(_detalleSale.ToList());
            }
        }
        internal Sale() { }
        internal Sale( int active, string note , Guid clienteId, Guid userId, decimal discount, decimal VALUE_IVA)
        {
            Id = Guid.NewGuid();
            status = new StatusValue("P");
            amountTotal = new PrecioValue(0m);
            amountNominal = new PrecioValue(0m);
            _detalleSale = new List<DetailSale>();
            date = DateTime.UtcNow;
            this.active = active;
            this.note = note;
            this.clienteId = clienteId;
            this.userId = userId;
            this.discount = discount;
            this.iva = VALUE_IVA;
        }




        public void agregarItem(Guid p_productId, Guid p_saleId, PrecioValue p_price, CantidadValue p_quantity)
        {

            var detaelProduct = _detalleSale.FirstOrDefault(x => x.productId == p_productId);
            if (detaelProduct is null)
            {
                 
                detaelProduct = new DetailSale(p_productId, p_saleId, p_price, p_quantity);
                _detalleSale.Add(detaelProduct);
            }
            else
            {
                detaelProduct.modifyDetailsSale(p_price, p_quantity);
            }


            this.amountNominal += (detaelProduct.price *detaelProduct.quantity);

            var cobroConDescuento = ((this.amountNominal.Value * discount) / 100);

            var cobroIva= ((amountNominal.Value * this.iva) /100);

            var Totaldescuento = cobroConDescuento; 

            this.amountTotal = (amountNominal +cobroIva)-Totaldescuento;
        }

        public void consolidateSale()
        {
            var evento = new SaleMade(this, DateTime.Now);
            AddDomainEvent(evento);
        }


        public void consolidateSaleDelivered(Guid pidSale, string pEstatus)
        {
            var evento = new SaleDelivered(this, DateTime.Now);
            Id = pidSale;
            status = pEstatus;
            AddDomainEvent(evento);
        }

    }
}
