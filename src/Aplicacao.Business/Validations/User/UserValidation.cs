using FluentValidation;
using Aplicacao.Core.Models;
using System;

namespace Aplicacao.Business.Validations
{
    public class UserValidation : AbstractValidator<Core.Models.User>
    {
        public UserValidation(User user)
        {
            RuleFor(user => user.Username).NotEmpty().WithMessage("Username é obrigatório");
            RuleFor(user => user).Must(user => !(user.Idade > 95)).WithMessage("Idade não válida");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password é obrigatório");
            RuleFor(user => user.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        }
    }

}