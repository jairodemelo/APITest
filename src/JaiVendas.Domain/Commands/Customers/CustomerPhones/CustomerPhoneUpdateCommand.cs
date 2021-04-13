using JaiVendas.Domain.Validation.Customers.CustomerPhones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers.CustomerPhones
{
    public class CustomerPhoneUpdateCommand : CustomerPhoneCommand
    {
        public CustomerPhoneUpdateCommand(Guid id, string area, string number)
        {
            Id = id;
            Area = area;
            Number = number;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerPhoneUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
