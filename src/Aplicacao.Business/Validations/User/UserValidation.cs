using FluentValidation;
using Aplicacao.Core.Models;
using System;

namespace Aplicacao.Business.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        internal UserValidation(User user)
        {
            RuleFor(user => user.Username).NotEmpty().WithMessage("Username não pode ser nulo");
        }
    }

}