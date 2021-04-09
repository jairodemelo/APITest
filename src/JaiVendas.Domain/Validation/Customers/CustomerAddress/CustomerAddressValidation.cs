using FluentValidation;
using JaiVendas.Domain.Commands.Customers.CustomerAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Validation.Customers.CustomerAddress
{
    public abstract class CustomerAddressValidation<TCommand> : AbstractValidator<TCommand>
        where TCommand : CustomerAddressCommand
    {
        protected void ValidateId()
            => RuleFor(e => e.Id)
                .NotEqual(Guid.Empty);
        protected void ValidateCustomerId()
            => RuleFor(e => e.CustomerId)
                .NotEqual(Guid.Empty);

        protected void ValidateCountryId()
            => RuleFor(e => e.CountryId)
                .NotEqual(Guid.Empty);

        protected void ValidateRegionId()
            => RuleFor(e => e.CountryId)
                .NotEqual(Guid.Empty);

        protected void ValidateStreet()
            => RuleFor(e => e.Street)
                .NotNull()
                .NotEmpty()
                .MaximumLength(300);

        protected void ValidateNumber()
            => RuleFor(e => e.Number)
                .NotNull()
                .NotEmpty()
                .MaximumLength(10);

        protected void ValidateNeighborhood()
            => RuleFor(e => e.Neighborhood)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

        protected void ValidateCity()
            => RuleFor(e => e.City)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

        protected void ValidateZipCode()
            => RuleFor(e => e.ZipCode)
                .NotNull()
                .NotEmpty()
                .MaximumLength(15);


    }
}
