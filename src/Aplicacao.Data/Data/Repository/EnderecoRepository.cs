using System;
using System.Collections.Generic;
using System.Linq;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public Endereco FindByCEP(string CEP)
        {
           Endereco endereco = ConsultaSoap.GetEnderecoByCep(CEP);
            return endereco;
        }
    }
}