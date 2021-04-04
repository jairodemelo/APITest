using FluentValidation;
using JaiVendas.Domain.Commands.Customers;
using JaiVendas.Domain.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Validation.Customers
{
    public abstract class CustomerValidation<TCommand>: AbstractValidator<TCommand> 
        where TCommand : CustomerCommand
    {
        protected void ValidateId()
            => RuleFor(e => e.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O campo Id está vazio!");

        protected void ValidateCPF()
            => RuleFor(e => e.CPF)
                .IsValidCPF();

        protected void ValidateName()
            => RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("O nome do cliente está em branco!")
                .MaximumLength(255)
                .WithMessage("O nome do cliente só pode ter no máximo 255 caracteres!");

    }
}
