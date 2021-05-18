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
    public class CustomerAddCommandHandler : CommandHandler, IRequestHandler<CustomerAddCommand, ValidationResult>
    {
        protected readonly ICustomerRepository _customerRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public CustomerAddCommandHandler(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        

        public async Task<ValidationResult> Handle(CustomerAddCommand request, CancellationToken cancellationToken)
        {
            //Validando dados da entidade
            if (!request.IsValid())
                return request.ValidationResult;

            //Validações de fluxo
            var exists = await _customerRepository
                .Exists<Customer>(e => e.CPF == request.CPF || e.Name == request.Name);

            if (exists)
                return AddError("Já existe um cliente com o mesmo número de CNPJ ou Nome!");

            //Cria entidade
            var customer = new Customer()
            {
                Id = request.Id,
                Active = true,
                CPF = request.CPF,
                Name = request.Name
            };

            //Persiste o cliente no sistema
            await _customerRepository.Add(customer);

            //Salva as alterações
            cancellationToken.ThrowIfCancellationRequested();
            return Commit(_unitOfWork);
        }
    }
}
