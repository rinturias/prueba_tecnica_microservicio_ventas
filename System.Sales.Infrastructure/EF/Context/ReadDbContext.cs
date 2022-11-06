using Microsoft.EntityFrameworkCore;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Domain.Event;
using System.Sales.Domain.Models.detailSale;
using System.Sales.Domain.Models.sale;
using System.Sales.Infrastructure.EF.Config.ReadConfig;
using System.Sales.Infrastructure.EF.ReadModel;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Infrastructure.EF.Context
{
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<SaleReadModel> Sale { get; set; }
    
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var saleConfig = new SaleReadConfig();
            modelBuilder.ApplyConfiguration<SaleReadModel>(saleConfig);
            modelBuilder.ApplyConfiguration<DetailSaleReadModel>(saleConfig);


            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<SaleMade>();
            modelBuilder.Ignore<SaleDelivered>();
        }
    }
}