using JaiVendas.Domain.Commands.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Validation.Customers
{
    public class CustomerDeleteValidation: CustomerValidation<CustomerDeleteCommand>
    {
        public CustomerDeleteValidation()
        {
            ValidateId();
        }
    }
}
