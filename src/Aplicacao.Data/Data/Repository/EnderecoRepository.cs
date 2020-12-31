using System;
using System.Collections.Generic;
using System.Linq;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly Contexto _context;

        public EnderecoRepository(Contexto contexto) 
        {
            _context = contexto;
        }

        public Endereco FindByCEP(string CEP)
        {
           Endereco endereco = _context.enderecos.Where(endereco => endereco.CEP == CEP).FirstOrDefault();
           
           User user = _context.users.First(u => u.UserId == endereco.UserForeignKey);
           endereco.User = user;

           return endereco;
        }

        public List<Endereco> FindAll()
        {
            List<Endereco> enderecos = new List<Endereco>();
            enderecos = _context.enderecos.ToList();
            return enderecos;
        }

        
        public Endereco Create(string cep) 
        {
            Endereco endereco = ConsultaSoap.GetEnderecoByCep(cep);
            endereco.UserForeignKey = 2;

            if (endereco.UserForeignKey >= 1)
            {
                endereco.User = _context.users
                                .Where(u => u.UserId == endereco.UserForeignKey)
                                .FirstOrDefault();
            }
            
            _context.enderecos.Add(endereco);
            _context.SaveChanges();

            return endereco;
        }

    }
}