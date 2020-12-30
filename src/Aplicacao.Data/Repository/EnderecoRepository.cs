using System;
using System.Collections.Generic;
using System.Linq;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private static List<Endereco> enderecos = new List<Endereco>()
        {
            new Endereco()
                {
                     Id = 1,
                     CEP = "42800936",
                }
        };
        public Endereco FindByCEP(string CEP)
        {
            Endereco endereco = enderecos.Where(endereco => endereco.CEP == CEP).FirstOrDefault();
            return endereco;
        }
    }
}