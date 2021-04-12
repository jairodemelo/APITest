﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.CrossCutting.Infra.Environment.Validation
{
    public static class ValidationResultExtensions
    {
        /// <summary>
        /// Anexa os erros da instância append em source
        /// </summary>
        public static ValidationResult Join(this ValidationResult source, ValidationResult append)
        {
            if (append == null || append.IsValid)
                return source;

            source.Errors
                .AddRange(append.Errors);

            return source;
        }
    }
}
