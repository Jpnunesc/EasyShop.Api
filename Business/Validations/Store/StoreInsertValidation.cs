using Business.Abstractions.IO.StoreProduct;
using Business.Abstractions.IO.Store;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.Store
{
    public class StoreInsertValidation : AbstractValidator<StoreInsertInput>
    {
        public StoreInsertValidation()
        {
                RuleFor(s => s.Name).NotEmpty().WithMessage("Nome é obrigatório.");
                RuleFor(s => s.Name).MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");


                RuleFor(s => s.Cnpj).NotEmpty().WithMessage("CNPJ é obrigatório.");
                //RuleFor(s => s.Cnpj).Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$").WithMessage("CNPJ inválido.");

                RuleFor(s => s.Image).NotEmpty().WithMessage("Imagem é obrigatória.");

                RuleFor(s => s.PostalCode).NotEmpty().WithMessage("CEP é obrigatório.");
                //RuleFor(s => s.PostalCode).Length(8).WithMessage("CEP deve ter 8 dígitos.");

                RuleFor(s => s.Address).NotEmpty().WithMessage("Endereço é obrigatório.");
                //RuleFor(s => s.Address).MaximumLength(100).WithMessage("Endereço deve ter no máximo 100 caracteres.");

                RuleFor(s => s.Number).NotEmpty().WithMessage("Número é obrigatório.");
               // RuleFor(s => s.Number).MaximumLength(20).WithMessage("Número deve ter no máximo 20 caracteres.");

                RuleFor(s => s.City).NotEmpty().WithMessage("Cidade é obrigatória.");
               // RuleFor(s => s.City).MaximumLength(50).WithMessage("Cidade deve ter no máximo 50 caracteres.");

                RuleFor(s => s.State).NotEmpty().WithMessage("Estado é obrigatório.");
               // RuleFor(s => s.State).Length(2).WithMessage("Estado deve ter 2 caracteres.");

                RuleFor(s => s.PhoneNumber).NotEmpty().WithMessage("Número de telefone é obrigatório.");
                //RuleFor(s => s.PhoneNumber).Length(10).WithMessage("Número de telefone deve ter 10 dígitos.");
        }
    }
}
