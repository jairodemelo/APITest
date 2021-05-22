using JaiVendas.Application.ViewModel.Customers.CustomerAddresses;
using JaiVendas.Application.ViewModel.Customers.CustomerPhones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.ViewModel.Customers
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public IEnumerable<CustomerPhoneViewModel> Phones { get; set; }

        public IEnumerable<CustomerAddressViewModel> Addresses { get; set; }
    }
}
