using Business.Abstractions.IO.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.Product
{
    public class ProductUpdateValidation : AbstractValidator<ProductUpdateInput>
    {
        public ProductUpdateValidation()
        {
            RuleFor(f => f.IdProduct)
                .NotEmpty().WithMessage("Campo IdProduct é obrigatório!");

        }
    }
}
