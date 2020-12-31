using System;
using System.Collections.Generic;
using System.Linq;
using Aplicacao.Core.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Contexto _context;

        public UserRepository(Contexto contexto) 
        {
            _context = contexto;
        }

        public List<User> FindAll()
        {
            // return _context.users.ToList();
            return _context.users.Include(end => end.Enderecos).ToList();
        }

        public User CreateUser(User user) 
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(long id)
        {
            User user = FindById(id);
            _context.users.Remove(user);
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

    }
}