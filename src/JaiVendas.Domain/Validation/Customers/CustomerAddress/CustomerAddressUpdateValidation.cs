using JaiVendas.Domain.Commands.Customers.CustomerAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Validation.Customers.CustomerAddress
{
    public class CustomerAddressUpdateValidation: CustomerAddressValidation<CustomerAddressUpdateCommand>
    {
        public CustomerAddressUpdateValidation()
        {
            ValidateId();
            ValidateCustomerId();
            ValidateCountryId();
            ValidateRegionId();
            ValidateStreet();
            ValidateNumber();
            ValidateNeighborhood();
            ValidateCity();
            ValidateZipCode();
        }
    }
}
