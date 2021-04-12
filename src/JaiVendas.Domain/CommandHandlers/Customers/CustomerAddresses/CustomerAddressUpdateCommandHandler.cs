using FluentValidation.Results;
using JaiVendas.Domain.Commands.Customers.CustomerAddresses;
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

namespace JaiVendas.Domain.CommandHandlers.Customers.CustomerAddresses
{
    public class CustomerAddressUpdateCommandHandler : CommandHandler, IRequestHandler<CustomerAddressUpdateCommand, ValidationResult>
    {

        protected readonly ICustomerRepository _customerRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public CustomerAddressUpdateCommandHandler(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Handle(CustomerAddressUpdateCommand request, CancellationToken cancellationToken)
        {
            //Validando dados da entidade
            if (!request.IsValid())
                return request.ValidationResult;

            //Validações de fluxo
            var exists = await _customerRepository
                .Exists(e => e.Id == request.Id);

            if (!exists)
                return AddError("Endereço inexistente!");

            //Cria entidade
            var customerAddress = new CustomerAddress()
            {
                Id = request.Id,
                Street = request.Street,
                Number = request.Number,
                Neighborhood = request.Neighborhood,
                City = request.City,
                ZipCode = request.ZipCode,
                CountryId = request.CountryId,
                RegionId = request.RegionId
            };

            //Consulta instancia do customer
            var customerAddressDb = await _customerRepository.CustomerAddressGetById(request.Id);

            customerAddressDb.Street = request.Street;
            customerAddressDb.Number = request.Number;
            customerAddressDb.Neighborhood = request.Neighborhood;
            customerAddressDb.City = request.City;
            customerAddressDb.ZipCode = request.ZipCode;
            customerAddressDb.CountryId = request.CountryId;
            customerAddressDb.RegionId = request.RegionId;

            //Salva as alterações
            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_unitOfWork);
        }
    }
}
