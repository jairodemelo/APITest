using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.ViewModel.Customers
{
    public class CustomerSimplifyedViewModel
    {
        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
