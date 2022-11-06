using System.Sales.Domain.Models.sale;

namespace System.Sales.Domain.Factories
{
    public interface ISaleFactory
    {
        public Sale Create(int active, string note, Guid clienteId, Guid userId, decimal discount,decimal iva);
    }
}
