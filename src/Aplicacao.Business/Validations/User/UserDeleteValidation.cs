using FluentValidation;
using Aplicacao.Core.Models;
using System;
using Aplicacao.Business.Interfaces;
using FluentValidation.Validators;
using System.Linq;

namespace Aplicacao.Business.Validations
{
    public class UserDeleteValidation : AbstractValidator<User>
    {
        public UserDeleteValidation(long id, IUserRepository _repository)
        {

            RuleFor(instance => instance)
                    .SetValidator(new UserNotFound(id, _repository)).WithMessage("Usuário não encontrado");

        }

        private class UserNotFound : PropertyValidator
        {
            private readonly IUserRepository _repository;
            private readonly long _id;
            public UserNotFound(long id, IUserRepository repository) 
            {
                _repository = repository;
                _id = id;

            }
            protected override bool IsValid(PropertyValidatorContext context)
            {
                return _repository.FindAll().FirstOrDefault(p=> p.UserId == _id) != null;
            }
        }
    }

}