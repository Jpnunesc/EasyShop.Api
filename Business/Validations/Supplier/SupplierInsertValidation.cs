using Business.Abstractions.IO.Supplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.Supplier
{
    public class SupplierInsertValidation : AbstractValidator<SupplierInsertInput>
    {
        public SupplierInsertValidation()
        {
            RuleFor(s => s.FantasyName).NotEmpty().WithMessage("FantasyName é obrigatório.");
        }
    }
}
