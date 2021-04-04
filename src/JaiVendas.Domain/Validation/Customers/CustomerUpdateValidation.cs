using JaiVendas.Domain.Commands.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Validation.Customers
{
    public class CustomerUpdateValidation: CustomerValidation<CustomerUpdateCommand>
    {
        public CustomerUpdateValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
