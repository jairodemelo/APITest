using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.ViewModel.Customers
{
    public class CustomerAddViewModel
    {
        public string CPF { get; set; }
        public string Name { get; set; }

        public ICollection<CustomerAddressAddViewModel> Adresses { get; set; } 
            = new List<CustomerAddressAddViewModel>();
    }
}
