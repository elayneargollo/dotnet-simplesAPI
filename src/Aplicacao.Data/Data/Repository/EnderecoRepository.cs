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
           Endereco endereco = ConsultaSoap.GetEnderecoByCep(CEP);
            return endereco;
        }

        public List<Endereco> FindAll()
        {
           return _context.enderecos.ToList();
        }
    }
}