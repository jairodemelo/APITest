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
    public class CountryRegionConfig : IEntityTypeConfiguration<CountryRegion>
    {
        public void Configure(EntityTypeBuilder<CountryRegion> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("CountryRegionId")
                .IsRequired();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasData(Seed);
        }

        private IEnumerable<CountryRegion> Seed
        {
            get
            {
                //Brazil
                yield return new CountryRegion 
                { 
                    Id = new Guid("9a227e78-f037-4593-a103-e3626316666f"),
                    CountryId = new Guid("0cf96f71-605e-4cca-b2b7-df4ed8bc35f9"), 
                    Code = "SP",
                    Description = "São Paulo"
                };
                yield return new CountryRegion 
                {
                    Id = new Guid("e9970d15-d7c3-47b4-80b1-3b1d148032f7"),
                    CountryId = new Guid("0cf96f71-605e-4cca-b2b7-df4ed8bc35f9"),
                    Code = "MG",
                    Description = "Minas Gerais"
                };

                //Germany
            }
        }
    }
}
