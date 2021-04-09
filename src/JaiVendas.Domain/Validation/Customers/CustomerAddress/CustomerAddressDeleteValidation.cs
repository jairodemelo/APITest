using JaiVendas.Domain.Commands.Customers.CustomerAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Validation.Customers.CustomerAddress
{
    public class CustomerAddressDeleteValidation: CustomerAddressValidation<CustomerAddressDeleteCommand>
    {
        public CustomerAddressDeleteValidation()
        {
            ValidateId();
        }
    }
}
