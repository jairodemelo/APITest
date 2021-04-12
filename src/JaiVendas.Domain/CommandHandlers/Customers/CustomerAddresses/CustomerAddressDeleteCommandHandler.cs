using FluentValidation.Results;
using JaiVendas.Domain.Commands.Customers.CustomerAddresses;
using JaiVendas.Domain.Interfaces;
using JaiVendas.Domain.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JaiVendas.Domain.CommandHandlers.Customers.CustomerAddresses
{
    public class CustomerAddressDeleteCommandHandler : CommandHandler, IRequestHandler<CustomerAddressDeleteCommand, ValidationResult>
    {
        protected readonly ICustomerRepository _customerRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public CustomerAddressDeleteCommandHandler(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ValidationResult> Handle(CustomerAddressDeleteCommand request, CancellationToken cancellationToken)
        {
            //Validando dados da entidade
            if (!request.IsValid())
                return request.ValidationResult;

            //Validações de fluxo
            var exists = await _customerRepository
                .Exists(e => e.Id == request.Id);

            if (!exists)
                return AddError("Endereço inexistente!");

            //Realiza a exclusão
            _customerRepository.CustomerAddressDelete(request.Id);

            //Salva as alterações
            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_unitOfWork);
        }
    }
}
