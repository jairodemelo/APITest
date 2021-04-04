using AutoMapper;
using FluentValidation.Results;
using JaiVendas.Application.Interfaces;
using JaiVendas.Application.ViewModel;
using JaiVendas.Application.ViewModel.Customers;
using JaiVendas.Domain.Commands.Customers;
using JaiVendas.Domain.Interfaces.Bus;
using JaiVendas.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var result = await (Task<ValidationResult>)_bus.SendCommand(customerAddCommand);
            return result.IsValid
                ? new AddResponseViewModel(customerAddCommand.Id, result)
                : new AddResponseViewModel(result);
        }

        public async Task<ValidationResult> Update(CustomerUpdateViewModel customer)
        {
            var customerUpdateCommand = _mapper.Map<CustomerUpdateCommand>(customer);
            return await (Task<ValidationResult>)_bus.SendCommand(customerUpdateCommand);
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
            var result = await _customerRepository.GetById(id);
            return _mapper.Map<CustomerViewModel>(result);
        }
    }
}
