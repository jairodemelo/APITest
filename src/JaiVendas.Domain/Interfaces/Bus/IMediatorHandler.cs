using JaiVendas.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Interfaces.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<TCommand>(TCommand command) 
            where TCommand : Command;
    }
}
