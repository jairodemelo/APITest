using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Model.Internationalization
{
    public class CountryRegion
    {
        public Guid Id { get; set; }

        public Guid CountryId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
