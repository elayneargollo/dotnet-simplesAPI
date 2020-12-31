using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacao.Core.Models;

namespace Aplicacao.Core.Dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IEnumerable<EnderecoDto> Enderecos { get; set; }

    }
}