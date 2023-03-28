using Business.Abstractions.IO.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.Product
{
    public class ProductInsertValidation : AbstractValidator<ProductInsertInput>
    {
        public ProductInsertValidation()
        {
            RuleFor(f => f.Name)
              .NotEmpty().WithMessage("Campo Nome obrigatório!");

            RuleFor(f => f.Sku)
                .NotEmpty().WithMessage("Campo Código de barras é obrigatório!");

            RuleFor(f => f.CodeCEST)
                .NotEmpty().WithMessage("Campo CodeCEST é obrigatório!");

            RuleFor(f => f.CodeNCM)
                .NotEmpty().WithMessage("Campo CodeNCM é obrigatório!");

            RuleFor(f => f.Price)
                .NotEmpty().WithMessage("Campo Preço é obrigatório!");

            RuleFor(f => f.Status)
                .NotEmpty().WithMessage("Campo Status obrigatório!");
        }
    }
}
