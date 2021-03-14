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
    public class CustomerPhoneConfig : IEntityTypeConfiguration<CustomerPhone>
    {
        public void Configure(EntityTypeBuilder<CustomerPhone> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("CustomerPhoneId")
                .IsRequired();

            builder.Property(e => e.Area)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
