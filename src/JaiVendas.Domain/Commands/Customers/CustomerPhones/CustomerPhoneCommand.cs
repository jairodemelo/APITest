using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers.CustomerPhones
{
    public abstract class CustomerPhoneCommand : Command
    {
        public Guid Id { get; protected set; }

        public Guid CustomerId { get; protected set; }

        public string Area { get; protected set; }

        public string Number { get; protected set; }
    }
}
