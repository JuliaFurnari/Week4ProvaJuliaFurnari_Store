using Microsoft.EntityFrameworkCore;
using Week4Prova_Store.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Week4Prova_Store.EF
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
         .HasKey(c => c.Id);

            builder
                .Property(c => c.CustomerCode)
                .IsRequired();

            builder
                .Property(c => c.FirstName)
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .IsRequired();

        }
    }
}