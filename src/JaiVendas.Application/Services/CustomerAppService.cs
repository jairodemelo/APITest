using AutoMapper;
using FluentValidation.Results;
using JaiVendas.Application.Interfaces;
using JaiVendas.Application.ViewModel;
using JaiVendas.Application.ViewModel.Customers;
using JaiVendas.Application.ViewModel.Customers.CustomerAddresses;
using JaiVendas.CrossCutting.Infra.Environment.Validation;
using JaiVendas.Domain.Commands.Customers;
using JaiVendas.Domain.Commands.Customers.CustomerAddresses;
using JaiVendas.Domain.Commands.Customers.CustomerPhones;
using JaiVendas.Domain.Interfaces.Bus;
using JaiVendas.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
namespace JaiVendas.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public CustomerAppService(ICustomerRepository customerRepository,
            IMapper mapper,
            IMediatorHandler bus)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<AddResponseViewModel> Add(CustomerAddViewModel customer)
        {
            var customerAddCommand = _mapper.Map<CustomerAddCommand>(customer);

            //Abre a transação de escopo
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = new ValidationResult();
                using (var internalScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //Criando cliente
                    result = await (Task<ValidationResult>)_bus.SendCommand(customerAddCommand);

                    if (!result.IsValid)
                        return new AddResponseViewModel(result);

                    internalScope.Complete();
                }

                using (var internalScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //Criando Endereços
                    foreach (var address in customer.Adresses)
                    {
                        address.CustomerId = customerAddCommand.Id;
                        var customerAddressAddCommand = _mapper.Map<CustomerAddressAddCommand>(address);
                        var resultAddress = await (Task<ValidationResult>)_bus.SendCommand(customerAddressAddCommand);
                        result.Join(resultAddress);
                    }

                    internalScope.Complete();
                }

                using (var internalScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //Criando Telefones
                    foreach (var phone in customer.Phones)
                    {
                        phone.CustomerId = customerAddCommand.Id;
                        var customerPhoneAddCommand = _mapper.Map<CustomerPhoneAddCommand>(phone);
                        var resultPhone = await (Task<ValidationResult>)_bus.SendCommand(customerPhoneAddCommand);
                        result.Join(resultPhone);
                    }

                    internalScope.Complete();
                }

                //Se inválido
                if (!result.IsValid)
                    return new AddResponseViewModel(result);

                //Se valido
                scope.Complete();
                return new AddResponseViewModel(customerAddCommand.Id, result);
            }
        }

        public async Task<ValidationResult> Update(CustomerUpdateViewModel customer)
        {
            var customerUpdateCommand = _mapper.Map<CustomerUpdateCommand>(customer);
            return await (Task<ValidationResult>)_bus.SendCommand(customerUpdateCommand);
        }

        public async Task<ValidationResult> UpdateCustomerAdresses(Guid customerId,
            IEnumerable<CustomerAddressAddViewModel> addressesToAdd,
            IEnumerable<CustomerAddressUpdateViewModel> addressesToUpdate,
            IEnumerable<CustomerAddressAddViewModel> addressesToDelete)
        {
            var cmdAddressesToAdd = _mapper.Map<IEnumerable<CustomerAddressAddCommand>>(addressesToAdd);
            var cmdAddressesToUpdate = _mapper.Map<IEnumerable<CustomerAddressAddCommand>>(addressesToUpdate);
            var cmdAddressesToDelete = _mapper.Map<IEnumerable<CustomerAddressAddCommand>>(addressesToDelete);

            //Abre a transação de escopo
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = new ValidationResult();

                //Executando comandos de Inclusão
                foreach (var item in cmdAddressesToAdd)
                {
                    var resultAdd = await (Task<ValidationResult>)_bus.SendCommand(item);
                    result.Join(resultAdd);
                }

                //Executando comandos de Update
                foreach (var item in cmdAddressesToUpdate)
                {
                    var resultUpdate = await (Task<ValidationResult>)_bus.SendCommand(item);
                    result.Join(resultUpdate);
                }

                //Executando comandos de Delete
                foreach (var item in cmdAddressesToDelete)
                {
                    var resultDelete = await (Task<ValidationResult>)_bus.SendCommand(item);
                    result.Join(resultDelete);
                }

                if (result.IsValid)
                    scope.Complete();

                return result;
            }
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var customerDeleteCommand = new CustomerDeleteCommand(id);
            return await (Task<ValidationResult>)_bus.SendCommand(customerDeleteCommand);
        }

        public async Task<IEnumerable<CustomerSimplifyedViewModel>> GetAll(string searchText = null)
        {
            var result = await _customerRepository.GetAll(searchText);
            return _mapper.Map<IEnumerable<CustomerSimplifyedViewModel>>(result);
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            var result = _customerRepository.GetById(id);
            return _mapper.Map<CustomerViewModel>(result);
        }
    }
}
