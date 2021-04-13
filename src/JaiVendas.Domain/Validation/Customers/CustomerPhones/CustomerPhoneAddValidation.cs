using JaiVendas.Domain.Commands.Customers.CustomerPhones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Validation.Customers.CustomerPhones
{
    public class CustomerPhoneAddValidation : CustomerPhoneValidation<CustomerPhoneAddCommand>
    {
        public CustomerPhoneAddValidation()
        {
            ValidateCustomerId();
            ValidateArea();
            ValidateNumber();
        }
    }
}
