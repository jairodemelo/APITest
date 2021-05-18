using AutoMapper;
using JaiVendas.Application.ViewModel.Customers;
using JaiVendas.Application.ViewModel.Customers.CustomerAddresses;
using JaiVendas.Application.ViewModel.Customers.CustomerPhones;
using JaiVendas.Domain.Commands.Customers;
using JaiVendas.Domain.Commands.Customers.CustomerAddresses;
using JaiVendas.Domain.Commands.Customers.CustomerPhones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.AutoMapper
{
    public class ViewModelToCommandMappingConfiguration: Profile
    {
        public ViewModelToCommandMappingConfiguration()
        {
            //Customers
            CreateMap<CustomerAddViewModel, CustomerAddCommand>()
                .ConstructUsing(e=> new CustomerAddCommand(e.CPF, e.Name));
            CreateMap<CustomerUpdateViewModel, CustomerUpdateCommand>()
                .ConstructUsing(e=> new CustomerUpdateCommand(e.Id, e.Name));
            CreateMap<CustomerAddressAddViewModel, CustomerAddressAddCommand>()
                .ConstructUsing(e=> new CustomerAddressAddCommand(e.CustomerId, e.Street, e.Number, e.Neighborhood, e.City, e.ZipCode, e.CountryId, e.RegionId));
            CreateMap<CustomerAddressUpdateViewModel, CustomerAddressUpdateCommand>()
                .ConstructUsing(e=> new CustomerAddressUpdateCommand(e.Id, e.Street, e.Number, e.Neighborhood, e.City, e.ZipCode, e.CountryId, e.RegionId));
            CreateMap<CustomerPhoneAddViewModel, CustomerPhoneAddCommand>()
                .ConstructUsing(e => new CustomerPhoneAddCommand(e.CustomerId, e.Area, e.Number));
        }
    }
}
