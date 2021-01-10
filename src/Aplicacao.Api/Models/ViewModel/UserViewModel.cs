using System.Collections.Generic;
using Aplicacao.Core.Dto;

namespace Aplicacao.Api.Models
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IEnumerable<EnderecoDto> Enderecos { get; set; }

    }
}