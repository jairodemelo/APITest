using JaiVendas.CrossCutting.Infra.Data.Context;
using JaiVendas.Domain.Interfaces;
using JaiVendas.Domain.Interfaces.Repository;
using JaiVendas.Domain.Model.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JaiVendas.CrossCutting.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly JaiVendasDataContext Db;

        public IUnitOfWork UnitOfWork 
            => Db;

        public CustomerRepository(JaiVendasDataContext context)
            => Db = context;
        

        public void Add(Customer customer)
        {
            Db.Customers
                .Add(customer);
        }

        public async void CustomerAddressDelete(Guid id)
        {
            var address = await CustomerAddressGetById(id);
            Db.CustomerAddresses.Remove(address);
        }

        public async Task<CustomerAddress> CustomerAddressGetById(Guid id)
            => await Db.CustomerAddresses
                .FirstOrDefaultAsync(e => e.Id == id);

        public async void CustomerPhoneDelete(Guid id)
        {
            var customerPhone = await CustomerPhoneGetById(id);
            Db.CustomerPhones.Remove(customerPhone);
        }

        public async Task<CustomerPhone> CustomerPhoneGetById(Guid id)
            => await Db.CustomerPhones
                .FirstOrDefaultAsync(e => e.Id == id);

        public async void Delete(Guid id)
        {
            var customer = await GetById(id);
            Db.Customers
                .Remove(customer);
        }

        public async Task<bool> Exists<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
            => await Db.Set<TEntity>().AnyAsync(predicate);

        public async Task<IEnumerable<Customer>> GetAll(string searchText = null)
            =>  string.IsNullOrWhiteSpace(searchText)
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
        
        public async Task<Customer> GetById(Guid id)
            => await Db.Customers
                .Include(e=> e.Addresses)
                .Include(e=> e.Phones)
                .FirstOrDefaultAsync(e => e.Id == id);
        
        public void Update(Customer customer)
            => Db.Customers.Update(customer);
        

    }
}
