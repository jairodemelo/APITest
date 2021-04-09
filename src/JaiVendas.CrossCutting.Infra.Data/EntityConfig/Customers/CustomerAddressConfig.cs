using JaiVendas.Domain.Model.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.CrossCutting.Infra.Data.EntityConfig.Customers
{
    public class CustomerAddressConfig : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("CustomerAddressId")
                .IsRequired();

            builder.Property(e => e.Neighborhood)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.ZipCode)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
