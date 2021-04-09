using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers.CustomerAddresses
{
    public abstract class CustomerAddressCommand: Command
    {
        public Guid Id { get; protected set; }

        public Guid CustomerId { get; protected set; }

        public string Street { get; protected set; }

        public string Number { get; protected set; }

        public string Neighborhood { get; protected set; }

        public string City { get; protected set; }

        public string ZipCode { get; protected set; }

        public Guid CountryId { get; protected set; }

        public Guid RegionId { get; protected set; }

    }
}
