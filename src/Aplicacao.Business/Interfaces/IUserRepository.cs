using System.Collections.Generic;
using Aplicacao.Core.Models;
using System.Threading.Tasks;

namespace Aplicacao.Business.Interfaces
{
    public interface IUserRepository
    {
         Task<User> CreateUserAsync(User user, string cep);
         User EditUser(User user);
         Task<User> FindByIdAsync(long id);
         List<User> FindAll();
         void Delete(long Id);
    }
}