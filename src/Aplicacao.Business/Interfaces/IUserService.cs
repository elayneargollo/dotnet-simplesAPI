using System.Collections.Generic;
using Aplicacao.Core.Models;
using System.Threading.Tasks;

namespace Aplicacao.Business.Interfaces
{
    public interface IUserService
    {
         Task<User> CreateUserAsync(User user, string cep);
         User EditUser(User user);
         List<User> FindAll();
         Task<User> FindByIdAsync(long id);
         void Delete(long Id);
    }
}