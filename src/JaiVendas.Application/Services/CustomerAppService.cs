using AutoMapper;
using JaiVendas.Application.Interfaces;
using JaiVendas.Application.ViewModel.Customers;
using JaiVendas.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public Task Add(CustomerAddViewModel customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
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

        public void Update(CustomerUpdateViewModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
