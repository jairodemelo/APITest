using JaiVendas.Domain.Validation.Customers.CustomerPhones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers.CustomerPhones
{
    public class CustomerPhoneAddCommand : CustomerPhoneCommand
    {
        public CustomerPhoneAddCommand(Guid customerId, string area, string number)
        {
            CustomerId = customerId;
            Area = area;
            Number = number;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerPhoneAddValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
