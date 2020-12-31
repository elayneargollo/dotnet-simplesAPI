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
            Endereco newEndereco = ConsultaSoap.GetEnderecoByCep(cep);
            newEndereco.UserForeignKey = 1;

            newEndereco.User = _context.users.Where(u => u.UserId == newEndereco.UserForeignKey).FirstOrDefault();

            _context.enderecos.Add(newEndereco);
            _context.SaveChanges();

            return newEndereco;
        }

    }
}