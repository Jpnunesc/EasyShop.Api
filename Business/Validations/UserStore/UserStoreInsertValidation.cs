using Business.Abstractions.IO.Product;
using Business.Abstractions.IO.User;
using Business.Abstractions.IO.UserStore;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.UserStore
{
    public class UserStoreInsertValidation : AbstractValidator<UserStoreInsertInput>
    {

    }
}
