using FluentValidation.Results;
using JaiVendas.Domain.Commands.Customers.CustomerPhones;
using JaiVendas.Domain.Interfaces;
using JaiVendas.Domain.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JaiVendas.Domain.CommandHandlers.Customers.CustomerPhones
{
    public class CustomerPhoneUpdateCommandHandler : CommandHandler, IRequestHandler<CustomerPhoneUpdateCommand, ValidationResult>
    {
        protected readonly ICustomerRepository _customerRepository;

        public CustomerPhoneUpdateCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<ValidationResult> Handle(CustomerPhoneUpdateCommand request, CancellationToken cancellationToken)
        {
            //Validando dados da entidade
            if (!request.IsValid())
                return request.ValidationResult;


            var customerPhoneDb = await _customerRepository
                .CustomerPhoneGetById(request.Id);

            //Valida existência
            if (customerPhoneDb == null)
                return AddError("O telefone do cliente é inexistente!");

            //Edita entidade
            customerPhoneDb.Area = request.Area;
            customerPhoneDb.Number = request.Number;

            //Salva as alterações
            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_customerRepository.UnitOfWork);
        }
    }
}
