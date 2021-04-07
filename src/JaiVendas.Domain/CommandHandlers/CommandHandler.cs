using FluentValidation.Results;
using JaiVendas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.CommandHandlers
{
    /// <summary>
    /// Classe base do Command Handler
    /// </summary>
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult { get; set; } = new ValidationResult();

        protected ValidationResult AddError(string errorMessage, string propertyName = default)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
            return ValidationResult;
        }

        private async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
        {
            if (!await uow.Commit())
                AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow)
            => await Commit(uow, "There was an error saving data!").ConfigureAwait(false);
    }
}
