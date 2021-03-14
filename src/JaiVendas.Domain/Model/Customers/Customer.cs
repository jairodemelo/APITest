using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Model.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public ICollection<CustomerPhone> Phones { get; set; }

        public ICollection<CustomerAddress> Addresses { get; set; }
    }
}
