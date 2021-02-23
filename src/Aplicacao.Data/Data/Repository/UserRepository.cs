using System.Collections.Generic;
using System.Linq;
using Aplicacao.Core.Models;
using Microsoft.EntityFrameworkCore;
using Aplicacao.Business.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Contexto _context;

        public UserRepository(Contexto contexto) 
        {
            _context = contexto;
        }

        public async Task<User> CreateUserAsync(User user, string cep) 
        {
            List<Endereco> enderecos = new List<Endereco>();

            if(!isExistCEP(cep))
            {
                enderecos.Add(ConsultaSoap.GetEnderecoByCep(cep));
                user.Enderecos = enderecos;
            } 
            else 
            {
                enderecos = _context.enderecos.Where(end => end.CEP == cep).ToList();
                user.Enderecos = enderecos;
            }

            _context.users.Add(user);
            _context.SaveChanges();

            return  await Task.Run(() => FindById(user.UserId));;
        }

        public async Task<User> FindByIdAsync(long id)
        {
            return await Task.Run(() => _context.users
                .Where(p => p.UserId == id)
                .Include(end => end.Enderecos)
                .FirstOrDefault());
        }


        public List<User> FindAll()
        {
            return _context.users.ToList();
        }
     
        public void Delete(long id)
        {
            User user = FindById(id);
            _context.users.Remove(user);
            _context.SaveChanges();
        }

        public User FindById(long id)
        {
            User user = _context.users
            .Where(p => p.UserId == id)
            .Include(end => end.Enderecos)
            .FirstOrDefault();
            
            return user;
        }

        public User EditUser(User user)
        {
            
            User userNew = FindById(user.UserId);

            if (userNew !=null)
            {
                userNew.Idade = user.Idade;
                userNew.Nome = user.Nome;
                userNew.Password = user.Password;
                userNew.Sobrenome = user.Sobrenome;
                userNew.Username = user.Username;
            }
            
            return user;
        }

        public bool isExistCEP(string cep)
        {
            return _context.enderecos.Where(endereco => endereco.CEP == cep).Any();
        }

    }
}