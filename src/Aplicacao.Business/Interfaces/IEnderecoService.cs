using System.Collections.Generic;
using Aplicacao.Core.Models;

namespace Aplicacao.Business.Interfaces
{
    public interface IEnderecoService
    {
        Endereco GetEnderecoByCep(string CEP);
        List<Endereco> FindAll();
    }
}