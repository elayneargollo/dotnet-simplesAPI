using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.Core.Dto
{
    public class UserEnderecoDto
    {
        
        public string CEP { set; get; }
        public string Bairro { set; get; }
        public string Cidade { set; get; }
        public string End { set; get; }
        public string UF { set; get; }
        public UserDtoEnd User {set; get; }

    }
}