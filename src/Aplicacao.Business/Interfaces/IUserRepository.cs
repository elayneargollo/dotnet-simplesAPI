using System.Collections.Generic;
using Aplicacao.Core.Models;

namespace Aplicacao.Business.Interfaces
{
    public interface IUserRepository
    {
         User CreateUser(User user);
         User EditUser(User user);
         User FindById(long id);
         List<User> FindAll();
         void Delete(long Id);
    }
}