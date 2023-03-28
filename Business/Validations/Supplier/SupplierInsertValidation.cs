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
            RuleFor(s => s.NumberDocument).NotEmpty().WithMessage("NumberDocument é obrigatório.");
            RuleFor(s => s.DocumentType).NotEmpty().WithMessage("DocumentType é obrigatório.");
            RuleFor(s => s.FantasyName).NotEmpty().WithMessage("FantasyName é obrigatório.");
            RuleFor(s => s.CorporateName).NotEmpty().WithMessage("CorporateName é obrigatório.");
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email é obrigatório.");
            RuleFor(s => s.PostalCode).NotEmpty().WithMessage("PostalCode é obrigatório.");
            RuleFor(s => s.Address).NotEmpty().WithMessage("Address é obrigatório.");
            RuleFor(s => s.Number).NotEmpty().WithMessage("Number é obrigatório.");
            RuleFor(s => s.CellNumber).NotEmpty().WithMessage("CellNumber é obrigatório.");
        }
    }
}
