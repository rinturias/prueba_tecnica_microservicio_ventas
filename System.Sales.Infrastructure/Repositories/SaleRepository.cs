using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Domain.Interfaces;
using System.Sales.Domain.Models.sale;
using System.Sales.Infrastructure.EF.Context;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public readonly DbSet<Sale> _sales;

        public SaleRepository(WriteDbContext context)
        {
            _sales = context._Sale;
        }
        public async Task CreateAsync(Sale obj)
        {
            await _sales.AddAsync(obj);
        }

        public async Task<Sale> FindByIdAsync(Guid id)
        {
            return await _sales
                .AsNoTracking()
              .SingleOrDefaultAsync(x => x.Id == id && x.active == 0);
        }

        public  Task UpdateAsync(Sale obj)
        {
            _sales.Update(obj);
            return Task.CompletedTask;
        }
    }
}
