using JaiVendas.CrossCutting.Infra.Data.Context;
using JaiVendas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.CrossCutting.Infra.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JaiVendasDataContext _context;

        public UnitOfWork(JaiVendasDataContext context)
        {
            _context = context;
        }
        public bool Commit()
            => _context.SaveChanges() > 0;

        public void Dispose()
            => _context.Dispose();
    }
}
