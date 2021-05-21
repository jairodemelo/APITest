using FluentValidation.Results;
using JaiVendas.Domain.Commands.Customers.CustomerPhones;
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

namespace JaiVendas.Domain.CommandHandlers.Customers.CustomerPhones
{
    public class CustomerPhoneAddCommandHandler : CommandHandler, IRequestHandler<CustomerPhoneAddCommand, ValidationResult>
    {
        protected readonly ICustomerRepository _customerRepository;

        public CustomerPhoneAddCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<ValidationResult> Handle(CustomerPhoneAddCommand request, CancellationToken cancellationToken)
        {
            //Validando dados da entidade
            if (!request.IsValid())
                return request.ValidationResult;

            //Validações de fluxo
            var exists = await _customerRepository
                .Exists<Customer>(e => e.Id == request.CustomerId);

            if (!exists)
                return AddError("Cliente inexistente para a adição de Telefone!");

            //Cria entidade
            var customerPhone = new CustomerPhone()
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                Area = request.Area,
                Number = request.Number
            };

            _customerRepository.CustomerPhoneAdd(customerPhone);

            //Salva as alterações
            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_customerRepository.UnitOfWork);
        }
    }
}
