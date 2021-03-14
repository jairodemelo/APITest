using JaiVendas.CrossCutting.Infra.Data.EntityConfig.Customers;
using JaiVendas.CrossCutting.Infra.Data.EntityConfig.Internationalization;
using JaiVendas.Domain.Model.Customers;
using JaiVendas.Domain.Model.Internationalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.CrossCutting.Infra.Data.Context
{
    public class JaiVendasDataContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public DbSet<CustomerPhone> CustomerPhones { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CountryRegion> CountryRegions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aplicando as configurações das entidades de modelo
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new CustomerAddressConfig());
            modelBuilder.ApplyConfiguration(new CustomerPhoneConfig());
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new CountryRegionConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Obtendo as configurações de conexão com Banco de Dados
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
