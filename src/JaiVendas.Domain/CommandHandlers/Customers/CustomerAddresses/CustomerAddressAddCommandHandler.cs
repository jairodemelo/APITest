using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaiVendas.Domain.Commands.Customers.CustomerAddresses;
using JaiVendas.Domain.Interfaces.Repository;
using JaiVendas.Domain.Interfaces;
using System.Threading;
using JaiVendas.Domain.Model.Customers;

namespace JaiVendas.Domain.CommandHandlers.Customers.CustomerAddresses
{
    public class CustomerAddressAddCommandHandler : CommandHandler, IRequestHandler<CustomerAddressAddCommand, ValidationResult>
    {
        protected readonly ICustomerRepository _customerRepository;

        public CustomerAddressAddCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<ValidationResult> Handle(CustomerAddressAddCommand request, CancellationToken cancellationToken)
        {
            //Validando dados da entidade
            if (!request.IsValid())
                return request.ValidationResult;

            //Validações de fluxo
            var exists = await _customerRepository
                .Exists<Customer>(e => e.Id == request.CustomerId);

            if (!exists)
                return AddError("Cliente inexistente para a adição de endereço!");

            //Cria entidade
            var customerAddress = new CustomerAddress()
            {
                Id = Guid.NewGuid(),
                City = request.City,
                CustomerId = request.CustomerId,
                CountryId = request.CountryId,
                Neighborhood = request.Neighborhood,
                Number = request.Number,
                RegionId = request.RegionId,
                Street = request.Street,
                ZipCode = request.ZipCode
            };

            //Incluindo endereço
            _customerRepository.CustomerAddressAdd(customerAddress);

            //Salva as alterações
            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_customerRepository.UnitOfWork);
        }
    }
}
