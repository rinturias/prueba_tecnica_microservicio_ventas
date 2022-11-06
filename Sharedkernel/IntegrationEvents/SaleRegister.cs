using Sharedkernel.Core;

namespace Sharedkernel.IntegrationEvents
{
    public record SaleRegister : IntegrationEvent
    {
        public DateTime date { get; set; }
        public string note { get; set; }

        public Guid clienteId { get; set; }
        public Guid userId { get; set; }

        public decimal amountTotal { get; set; }

        public decimal amountNominal { get; set; }

        public decimal discount { get; set; }

        public decimal iva { get; set; }
        public string status { get; set; }
        public List<DetailSale> detalleSale { get; set; }
    }

    public class DetailSale
    {
        public DateTime date { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

        public Guid productId { get; set; }

        public Guid saleId { get; set; }
        public Guid categoryId { get; set; }
    }
}
