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
    public class CustomerPhoneDeleteCommandHandler : CommandHandler, IRequestHandler<CustomerPhoneDeleteCommand, ValidationResult>
    {
        protected readonly ICustomerRepository _customerRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public CustomerPhoneDeleteCommandHandler(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ValidationResult> Handle(CustomerPhoneDeleteCommand request, CancellationToken cancellationToken)
        {
            //Validando dados da entidade
            if (!request.IsValid())
                return request.ValidationResult;

            //Validações de fluxo
            var exists = await _customerRepository
                .Exists<CustomerPhone>(e => e.Id == request.Id);

            if (!exists)
                return AddError("Telefone inexistente!");

            //Realiza a exclusão
            _customerRepository.CustomerPhoneDelete(request.Id);

            //Salva as alterações
            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_unitOfWork);
        }
    }
}
