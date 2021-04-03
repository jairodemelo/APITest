using JaiVendas.CrossCutting.Infra.Data.Context;
using JaiVendas.Domain.Interfaces.Repository;
using JaiVendas.Domain.Model.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaiVendas.CrossCutting.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly JaiVendasDataContext Db;

        public CustomerRepository(JaiVendasDataContext context)
        {
            Db = context;
        }

        public async Task Add(Customer customer)
        {
            await Db.Customers
                .AddAsync(customer);
        }

        public async void Delete(Guid id)
        {
            var customer = await GetById(id);
            Db.Customers
                .Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetAll(string searchText = null)
        {
            return string.IsNullOrWhiteSpace(searchText)
                ? Db.Customers.ToList()
                : Db.Customers
                    .Include(i => i.Phones)
                    .Where
                    (e=>
                        e.Name.Contains(searchText) 
                        || e.CPF.Contains(searchText) 
                        || e.Phones.Any(p=> p.Number.Contains(searchText))
                    )
                    .ToList();
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await Db.Customers
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Update(Customer customer)
        {
            Db.Customers.Update(customer);
        }
    }
}
