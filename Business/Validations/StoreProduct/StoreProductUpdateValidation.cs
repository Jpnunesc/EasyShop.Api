using Business.Abstractions.IO.StoreProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.StoreProduct
{
    public class StoreProductUpdateValidation : AbstractValidator<StoreProductUpdateInput>
    {
        public StoreProductUpdateValidation()
        {
            RuleFor(f => f.IdStoreProduct)
                .NotEmpty().WithMessage("Campo IdProduct é obrigatório!");

        }
    }
}
