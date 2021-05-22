using JaiVendas.Application.ViewModel.Internationalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.ViewModel.Customers.CustomerAddresses
{
    public class CustomerAddressViewModel
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public Guid CountryId { get; set; }
        public CountryViewModel Country { get; set; }

        public Guid RegionId { get; set; }

        public CountryRegionViewModel Region { get; set; }
    }
}
