using JaiVendas.Domain.Validation.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers
{
    public class CustomerDeleteCommand : CustomerCommand
    {
        public CustomerDeleteCommand(Guid id)
            => Id = id;
        
        public override bool IsValid()
        {
            ValidationResult = new CustomerDeleteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
