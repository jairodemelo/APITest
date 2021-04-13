using FluentValidation;
using JaiVendas.Domain.Commands.Customers.CustomerPhones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Validation.Customers.CustomerPhones
{
    public abstract class CustomerPhoneValidation<TCommand> : AbstractValidator<TCommand>
        where TCommand : CustomerPhoneCommand
    {
        protected void ValidateId()
            => RuleFor(e => e.Id)
                .NotEqual(Guid.Empty);
        protected void ValidateCustomerId()
            => RuleFor(e => e.CustomerId)
                .NotEqual(Guid.Empty);

        protected void ValidateArea()
            => RuleFor(e => e.Area)
                .NotEmpty();

        protected void ValidateNumber()
            => RuleFor(e => e.Number)
                .NotEmpty();

    }
}
