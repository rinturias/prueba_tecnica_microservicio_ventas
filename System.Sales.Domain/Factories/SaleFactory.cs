using System.Sales.Domain.Models.sale;

namespace System.Sales.Domain.Factories
{
    public class SaleFactory : ISaleFactory
    {
        public Sale Create(int active, string note, Guid clienteId, Guid userId, decimal discount,decimal iva)
        {
            return new Sale(active,note,clienteId,userId,discount,iva);
        }
    }
}
