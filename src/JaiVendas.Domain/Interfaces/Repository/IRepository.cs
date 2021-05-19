using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
