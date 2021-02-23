using System.Collections.Generic;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;
using System.Threading.Tasks;
using Aplicacao.Business.Validations;
using FluentValidation.Results;
using System;
using FluentValidation;

namespace Aplicacao.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> CreateUserAsync(User user, string cep)
        {

            UserValidation userValidation = new UserValidation(user);
            ValidationResult result = userValidation.Validate(user);

            if (!result.IsValid)
            {
                string message = string.Format("{0}", result.Errors[0].ErrorMessage);
                throw new ArgumentException(message);

            }

            User userNew = await _repository.CreateUserAsync(user, cep);
            return userNew;

        }

        public User EditUser(User user)
        {
            User editedUser = _repository.EditUser(user);
            return editedUser;
        }

        public List<User> FindAll()
        {
            List<User> list = new List<User>();
            list = _repository.FindAll();
            return list;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public async Task<User> FindByIdAsync(long id)
        {
            return await _repository.FindByIdAsync(id);
        }

    }
}
