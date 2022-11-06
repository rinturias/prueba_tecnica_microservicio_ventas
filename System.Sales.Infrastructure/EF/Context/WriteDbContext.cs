using Microsoft.EntityFrameworkCore;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Domain.Event;
using System.Sales.Domain.Models.detailSale;
using System.Sales.Domain.Models.sale;
using System.Sales.Infrastructure.EF.Config.WriteConfig;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Infrastructure.EF.Context
{
    public class WriteDbContext : DbContext
    {

        public virtual DbSet<Sale> _Sale { get; set; }


        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var saleConfig = new SaleWhiteConfig();
            modelBuilder.ApplyConfiguration<Sale>(saleConfig);
            modelBuilder.ApplyConfiguration<DetailSale>(saleConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<SaleMade>();
            //modelBuilder.Ignore<SaleDelivered>();
        }
    }
}
