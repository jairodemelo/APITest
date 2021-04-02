using JaiVendas.CrossCutting.Infra.Data.Context;
using JaiVendas.Domain.Interfaces.Repository;
using JaiVendas.Domain.Model.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Add(Customer customer)
        {
            Db.Customers
                .Add(customer);
        }

        public void Delete(Guid id)
        {
            var customer = GetById(id);
            Db.Customers
                .Remove(customer);
        }

        public IEnumerable<Customer> GetAll(string searchText = null)
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

        public Customer GetById(Guid id)
        {
            return Db.Customers
                .FirstOrDefault(e => e.Id == id);
        }

        public void Update(Customer customer)
        {
            Db.Customers.Update(customer);
        }
    }
}
