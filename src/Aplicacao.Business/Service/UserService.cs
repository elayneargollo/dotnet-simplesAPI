using System;
using System.Collections.Generic;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User CreateUser(User user)
        {
            User userNew = _repository.CreateUser(user);
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

        public User FindById(long id)
        {
            User user = _repository.FindById(id);
            return user;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}