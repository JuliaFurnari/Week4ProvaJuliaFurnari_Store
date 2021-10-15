using Microsoft.EntityFrameworkCore;
using Week4Prova_Store.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Week4Prova_Store.EF
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(ord => ord.Id);

            builder.Property(ord => ord.OrderDate)
                       .IsRequired();

            builder.Property(ord => ord.OrderCode)
                      .IsRequired();

            builder.Property(ord => ord.ProductCode)
                      .IsRequired();

            builder.Property(ord => ord.Amount)
                      .IsRequired();

            builder.HasOne(ord => ord.Customer)
               .WithMany(c => c.Orders);


        }
    }
}