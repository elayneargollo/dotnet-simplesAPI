using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Aplicacao.Core.Models
{

    public class User
    {

        public long Id {get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Idade { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }

    }
}