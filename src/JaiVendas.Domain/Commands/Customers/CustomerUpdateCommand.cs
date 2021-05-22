using JaiVendas.Domain.Validation.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers
{
    public class CustomerUpdateCommand : CustomerCommand
    {
        public CustomerUpdateCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
