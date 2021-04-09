using JaiVendas.Domain.Validation.Customers.CustomerAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers.CustomerAddresses
{
    public class CustomerAddressDeleteCommand : CustomerAddressCommand
    {
        public CustomerAddressDeleteCommand(Guid id)
            => Id = id;
        
        public override bool IsValid()
        {
            ValidationResult = new CustomerAddressDeleteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
