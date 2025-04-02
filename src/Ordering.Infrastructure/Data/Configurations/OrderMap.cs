using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(
            orderId => orderId.Value,
            dbId => OrderId.Of(dbId));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x=>x.CustomerId)
            .IsRequired();

        builder.HasMany(x => x.OrderItems)
                .WithOne()
                .HasForeignKey(x => x.OrderId);

        builder.ComplexProperty(
                x => x.OrderName, nameBuilder =>
                {
                    nameBuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
                }
            );

        builder.ComplexProperty(
                x=>x.ShippingAddress, addressBuilder =>
                {
                    addressBuilder.Property(a=>a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                    addressBuilder.Property(a=>a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                    addressBuilder.Property(a=>a.EmailAddress)
                    .HasMaxLength(100)
                }
            )
    }
}
