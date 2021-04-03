using AutoMapper;
using JaiVendas.Application.ViewModel.Customers;
using JaiVendas.Domain.Model.Customers;
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
        }
    }
}
