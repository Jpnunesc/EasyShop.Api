using Business.Abstractions.IO.Product;
using Business.Abstractions.IO.Store;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.Store
{
    public class StoreUpdateValidation : AbstractValidator<StoreUpdateInput>
    {
        public StoreUpdateValidation()
        {
            
                RuleFor(s => s.IdStore).NotEmpty().WithMessage("Endereço é obrigatório.");

        }
    }
}
