using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Domain.Models.detailSale;
using System.Sales.Domain.Models.sale;
using System.Sales.Domain.ValueObjects;
using System.Text;
using System.Threading.Tasks;
using System.Sales.Infrastructure.EF.ReadModel;

namespace System.Sales.Infrastructure.EF.Config.ReadConfig
{
    public class SaleReadConfig : IEntityTypeConfiguration<SaleReadModel>, 
        IEntityTypeConfiguration<DetailSaleReadModel>
    {
        public void Configure(EntityTypeBuilder<SaleReadModel> builder)
        {
            builder.ToTable("Sale");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.date)
           .HasColumnName("date")
           .HasColumnType("DateTime");

            builder.Property(x => x.note)
             .HasColumnName("note")
              .HasMaxLength(200);

            builder.Property(x => x.clienteId)
             .HasColumnName("clienteId");

            builder.Property(x => x.userId)
          .HasColumnName("userId");


            builder.Property(x => x.amountTotal)
            .HasColumnName("amountTotal")
             .HasPrecision(12, 2);



            builder.Property(x => x.status)
            .HasColumnName("status");


            builder.Property(x => x.amountNominal)
            .HasColumnName("amountNominal")
             .HasPrecision(12, 2);


            builder.Property(x => x.discount)
           .HasColumnName("discount")
           .HasColumnType("decimal")
           .HasPrecision(12, 2);

            builder.Property(x => x.iva)
           .HasColumnName("iva")
           .HasColumnType("decimal")
           .HasPrecision(12, 2);

            builder.Property(x => x.active)
         .HasColumnName("active");


            builder.HasMany(x => x.detailSale)
                       .WithOne(x => x.Sale);


        }

        public void Configure(EntityTypeBuilder<DetailSaleReadModel> builder)
        {
            builder.ToTable("DetailSale");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.date)
            .HasColumnName("date")
            .HasColumnType("DateTime");


            builder.Property(x => x.quantity)
                .HasColumnName("quantity");


            builder.Property(x => x.price)
           .HasColumnName("price")
            .HasPrecision(12, 2);

            builder.Property(x => x.productId)
           .HasColumnName("productId");

         
        }

    }
}
