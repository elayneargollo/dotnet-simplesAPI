using System.Collections.Generic;
using Aplicacao.Core.Models;

namespace Aplicacao.Business.Interfaces
{
    public interface IUserService
    {
         User CreateUser(User user);
         User EditUser(User user);
         List<User> FindAll();
         User FindById(long id);
         void Delete(long Id);
    }
}