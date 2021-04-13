using JaiVendas.Domain.Validation.Customers.CustomerPhones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers.CustomerPhones
{
    public class CustomerPhoneDeleteCommand : CustomerPhoneCommand
    {

        public CustomerPhoneDeleteCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerPhoneDeleteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
