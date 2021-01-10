using System.Collections.Generic;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Business.Services
{
    public class EnderecoService : IEnderecoService
    {
        private IEnderecoRepository _repository;

        public EnderecoService(IEnderecoRepository repository) => _repository = repository;

        public Endereco GetEnderecoByCep(string CEP)
        {
            Endereco endereco = _repository.FindByCEP(CEP);
            return endereco;
        }

        public List<Endereco> FindAll()
        {
            List<Endereco> list = new List<Endereco>();
            list = _repository.FindAll();
            return list;
        }

        public Endereco Create(string cep )
        {
            Endereco newEndereco = _repository.Create(cep);
            return newEndereco;
        }

    }
}
