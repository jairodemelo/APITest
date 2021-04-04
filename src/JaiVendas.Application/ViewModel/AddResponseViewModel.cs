using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.ViewModel
{
    /// <summary>
    /// Response genérico para operações de Add
    /// </summary>
    public class AddResponseViewModel
    {
        public AddResponseViewModel(ValidationResult validationResult)
            => ValidationResult = validationResult;

        public AddResponseViewModel(Guid? id, ValidationResult validationResult)
            : this(validationResult)
            => Id = id;


        /// <summary>
        /// Id da entidade incluida.
        /// Será nula se houver erros de validação
        /// </summary>
        public Guid? Id { get; private set; }

        /// <summary>
        /// Resultado da operação
        /// </summary>
        public ValidationResult ValidationResult { get; private set; }
    }
}
