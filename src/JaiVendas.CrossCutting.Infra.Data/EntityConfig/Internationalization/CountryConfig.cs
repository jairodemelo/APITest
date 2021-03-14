using JaiVendas.Domain.Model.Internationalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.CrossCutting.Infra.Data.EntityConfig.Internationalization
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("CountryId")
                .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasData(Seed);

        }

        private IEnumerable<Country> Seed
        {
            get
            {
                yield return new Country { Id = new Guid("0cf96f71-605e-4cca-b2b7-df4ed8bc35f9"), Name = "Brazil" };
                yield return new Country { Id = new Guid("bea6856e-f59a-4505-9f8b-dc96b374a2c5"), Name = "Germany" };
            }
        }
    }
}
