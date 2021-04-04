using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Commands
{
    /// <summary>
    /// Classe base para comandos do sistema
    /// </summary>
    public abstract class Command : IRequest<ValidationResult>, IBaseRequest
    {
        /// <summary>
        /// Validações do sistema
        /// </summary>
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Verifica se o comando é válido
        /// </summary>
        public abstract bool IsValid();
    }
}
