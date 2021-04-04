using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands.Customers
{
    public abstract class CustomerCommand: Command
    {
        public Guid Id { get; protected set; }

        public string CPF { get; protected set; }

        public string Name { get; protected set; }
    }
}
