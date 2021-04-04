using JaiVendas.Domain.Commands;
using JaiVendas.Domain.Interfaces.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.CrossCutting.Infra.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<TCommand>(TCommand command) where TCommand : Command
            => _mediator.Send(command);
    }
}
