using FluentValidation.Results;
using JaiVendas.Domain.Commands.Customers;
using JaiVendas.Domain.Interfaces;
using JaiVendas.Domain.Interfaces.Repository;
using JaiVendas.Domain.Model.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JaiVendas.Domain.CommandHandlers.Customers
{
    public class CustomerDeleteCommandHandler : CommandHandler, IRequestHandler<CustomerDeleteCommand, ValidationResult>
    {
        protected readonly ICustomerRepository _customerRepository;

        public CustomerDeleteCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            //Validando dados da entidade
            if (!request.IsValid())
                return request.ValidationResult;

            var exists = await _customerRepository.Exists<Customer>(e=> e.Id == request.Id);
            if (!exists)
                return AddError("Cliente não encontrado para exclusão!");

            _customerRepository.Delete(request.Id);
            return await Commit(_customerRepository.UnitOfWork);
        }
    }
}
