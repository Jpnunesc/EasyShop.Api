using Business.Abstractions.IO.StoreProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.StoreProduct
{
    public class StoreProductInsertValidation : AbstractValidator<StoreProductInsertInput>
    {
        public StoreProductInsertValidation()
        {
            RuleFor(f => f.Description)
              .NotEmpty().WithMessage("Campo Nome obrigatório!");

            RuleFor(f => f.CodeCEST)
                .NotEmpty().WithMessage("Campo CodeCEST é obrigatório!");

            RuleFor(f => f.CodeNCM)
                .NotEmpty().WithMessage("Campo CodeNCM é obrigatório!");

            RuleFor(f => f.IdStore)
                .NotEmpty().WithMessage("Campo Preço é obrigatório!");
        }
    }
}
