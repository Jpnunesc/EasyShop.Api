using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.Supplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.Supplier
{
    public class SupplierUpdateValidation : AbstractValidator<SupplierUpdateInput>
    {
        public SupplierUpdateValidation() 
        {
            RuleFor(s => s.IdSuppliers).NotEmpty().WithMessage("IdSuppliers é obrigatório.");

        }
    }
}
