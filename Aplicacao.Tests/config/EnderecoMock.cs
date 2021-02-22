using System.Collections.Generic;
using Aplicacao.Core.Models;

namespace Aplicacao.Tests.Service
{
    public class EnderecoMock
    {
        public static List<Endereco> GetEnderecos()
        {
            return new List<Endereco>()
            {
                new Endereco()
                {
                    EnderecoId = 1,
                    CEP = "42800921",
                    Bairro = "Valéria",
                    Cidade = "Salvador"
                },
                new Endereco()
                {
                    EnderecoId = 2,
                    CEP = "44500921",
                    Bairro = "São Caetano",
                    Cidade = "Salvador"
                }
            };
        }

        public static Endereco GetEndereco()
        {
            return new Endereco()
                {
                    EnderecoId = 2,
                    CEP = "44500921",
                    Bairro = "São Caetano",
                    Cidade = "Salvador"
                };
        }
    }
}