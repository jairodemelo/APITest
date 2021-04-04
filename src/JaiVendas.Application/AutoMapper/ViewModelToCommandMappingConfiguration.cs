using AutoMapper;
using JaiVendas.Application.ViewModel.Customers;
using JaiVendas.Domain.Commands.Customers;
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
            CreateMap<CustomerAddViewModel, CustomerAddCommand>();
            CreateMap<CustomerUpdateViewModel, CustomerUpdateCommand>();
        }
    }
}
