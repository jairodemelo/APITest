using JaiVendas.Domain.Model.Customers;
using JaiVendas.Domain.Validation.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers
{
    public class CustomerAddCommand : CustomerCommand
    {
        public CustomerAddCommand(string cpf, string name)
        {
            CPF = cpf;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerAddValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
