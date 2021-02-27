using System.Collections.Generic;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;
using System.Threading.Tasks;
using Aplicacao.Business.Validations;
using FluentValidation.Results;
using System;
using Aplicacao.Core.Exceptions.BusinessException;

namespace Aplicacao.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User> CreateUserAsync(User user, string cep)
        {
            Console.WriteLine("Iniciando método CreateUserAsync");

            try 
            {
                UserValidation userValidation = new UserValidation(user);
                FluentResultAdapter.VerificaErros(userValidation.Validate(user));

                _repository.CreateUserAsync(user, cep);
                
                return Task.FromResult(user);

            }
            catch(BusinessException ex)
            {
                Console.WriteLine(ex.Message);
                throw new BusinessException(ex.Message);
            }
            finally
            {
                Console.WriteLine("Método CreateUserAsync finalizado.");
            }
           
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
            Console.WriteLine("Iniciando método Delete User");

            var userBase = new User() {UserId = id};

            UserDeleteValidation userValidation = new UserDeleteValidation(id, _repository);
            FluentResultAdapter.VerificaErros(userValidation.Validate(userBase));

            try 
            {
                _repository.Delete(id);
            }
            catch(BusinessException ex)
            {
                Console.WriteLine(ex.Message);
                throw new BusinessException(ex.Message);
            }
            finally
            {
                Console.WriteLine("Método Delete finalizado.");
            }
           
        }

        public async Task<User> FindByIdAsync(long id)
        {
            return await _repository.FindByIdAsync(id);
        }

    }
}
