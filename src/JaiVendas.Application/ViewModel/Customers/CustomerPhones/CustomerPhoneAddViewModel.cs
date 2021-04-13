using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.ViewModel.Customers.CustomerPhones
{
    public class CustomerPhoneAddViewModel
    {
        public Guid CustomerId { get; set; }
        public string Area { get; set; }
        public string Number { get; set; }
    }
}