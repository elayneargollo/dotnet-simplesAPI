using System.Collections.Generic;
using Aplicacao.Core.Models;

namespace Aplicacao.Business.Interfaces
{
    public interface IEnderecoRepository
    {
        Endereco FindByCEP(string CEP);
        List<Endereco> FindAll();
    }
}