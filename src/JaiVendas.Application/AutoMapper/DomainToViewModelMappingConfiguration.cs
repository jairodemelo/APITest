using AutoMapper;
using JaiVendas.Application.ViewModel.Customers;
using JaiVendas.Application.ViewModel.Customers.CustomerAddresses;
using JaiVendas.Application.ViewModel.Customers.CustomerPhones;
using JaiVendas.Application.ViewModel.Internationalization;
using JaiVendas.Domain.Model.Customers;
using JaiVendas.Domain.Model.Internationalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.AutoMapper
{
    public class DomainToViewModelMappingConfiguration: Profile
    {
        public DomainToViewModelMappingConfiguration()
        {
            CreateMap<Customer, CustomerSimplifyedViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerAddress, CustomerAddressViewModel>();
            CreateMap<CustomerPhone, CustomerPhoneViewModel>();
            
            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryRegion, CountryRegionViewModel>();
        }
    }
}
