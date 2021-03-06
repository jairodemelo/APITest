using JaiVendas.Domain.Validation.Customers.CustomerAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers.CustomerAddresses
{
    public class CustomerAddressAddCommand : CustomerAddressCommand
    {
        public CustomerAddressAddCommand(Guid customerId, 
            string street, 
            string number, 
            string neighborhood, 
            string city, 
            string zipCode, 
            Guid countryId, 
            Guid regionId)
        {
            CustomerId = customerId;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            ZipCode = zipCode;
            CountryId = countryId;
            RegionId = regionId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerAddressAddValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
