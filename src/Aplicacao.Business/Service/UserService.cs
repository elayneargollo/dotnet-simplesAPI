using System;
using System.Collections.Generic;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            User userNew = await _repository.CreateUserAsync(user);
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
