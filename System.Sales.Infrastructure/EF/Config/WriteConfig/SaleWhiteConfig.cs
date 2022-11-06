using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Sales.Domain.Models.detailSale;
using System.Sales.Domain.Models.sale;
using System.Sales.Domain.ValueObjects;

namespace System.Sales.Infrastructure.EF.Config.WriteConfig
{
    public class SaleWhiteConfig : IEntityTypeConfiguration<Sale>, IEntityTypeConfiguration<DetailSale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
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

            var amountTotalConverter = new ValueConverter<PrecioValue, decimal>(
             precioValue => precioValue.Value,
             precio => new PrecioValue(precio)
            );
            builder.Property(x => x.amountTotal)
            .HasConversion(amountTotalConverter)
            .HasColumnName("amountTotal")
             .HasPrecision(12, 2);


            var statusConverter = new ValueConverter<StatusValue, string>(
                 objValue => objValue.Value,
                 obj => new StatusValue(obj)
                );

            builder.Property(x => x.status)
            .HasConversion(statusConverter)
            .HasColumnName("status");


            var amountNominalConverter = new ValueConverter<PrecioValue, decimal>(
            precioValue => precioValue.Value,
            precio => new PrecioValue(precio)
           );
            builder.Property(x => x.amountNominal)
            .HasConversion(amountNominalConverter)
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

            builder.HasMany(typeof(DetailSale), "_detalleSale");


            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.DetalleSale);

        }

        public void Configure(EntityTypeBuilder<DetailSale> builder)
        {
            builder.ToTable("DetailSale");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.date)
            .HasColumnName("date")
            .HasColumnType("DateTime");




            var cantidadConverter = new ValueConverter<CantidadValue, int>(
            cantidadValue => cantidadValue.Value,
            cantidad => new CantidadValue(cantidad)
        );

            builder.Property(x => x.quantity)
               .HasConversion(cantidadConverter)
                .HasColumnName("quantity");


            var priceConverter = new ValueConverter<PrecioValue, decimal>(
               objValue => objValue.Value,
               obj => new PrecioValue(obj)
              );
            builder.Property(x => x.price)
           .HasConversion(priceConverter)
           .HasColumnName("price")
            .HasPrecision(12, 2);

            builder.Property(x => x.productId)
           .HasColumnName("productId");

            builder.Property(x => x.saleId)
           .HasColumnName("saleId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }

    }
}
