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
    public class CustomerUpdateCommandHandler : CommandHandler, IRequestHandler<CustomerUpdateCommand, ValidationResult>
    {
        protected readonly ICustomerRepository _customerRepository;

        public CustomerUpdateCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            //Validando dados da entidade
            if (!request.IsValid())
                return request.ValidationResult;

            //Validações de fluxo
            if (await _customerRepository.Exists<Customer>(e => e.Name == request.Name  && e.Id != request.Id))
                return AddError("Já existe um cliente com o mesmo número de CNPJ ou Nome!");

            var customer = _customerRepository.GetById(request.Id);
            if (customer == null)
                return AddError($"O cliente '{request.Id}' não existe!");

            //Atualizando entidade
            customer.Name = request.Name;

            //Persiste alterações no sistema
            _customerRepository.Update(customer);

            //Salva as alterações
            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_customerRepository.UnitOfWork);
        }
    }
}
